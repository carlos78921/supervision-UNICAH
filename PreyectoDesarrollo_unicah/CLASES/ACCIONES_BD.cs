using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Policy;
using System.Drawing.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
using DocumentFormat.OpenXml.Office.Word;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using System.ComponentModel;
using DocumentFormat.OpenXml.Spreadsheet;


namespace PreyectoDesarrollo_unicah.CLASES
{
    class ACCIONES_BD
    {
        public static string nombre, apellido, empleado, rutaExcel = "", tempFile; 

        public readonly string RolForzado;

        public CONEXION_BD conexion = new CONEXION_BD();

        public ACCIONES_BD()
        {
            nombre = "";
            apellido = "";
            rutaExcel = "";
        }
        public static bool CrearBDD()
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarServidor.ConnectionString))
            {
                conn.Open();
                using (SqlCommand crear = new SqlCommand("PA_Supervision_Unicah", conn))
                {
                    crear.ExecuteNonQuery();
                }
            }

            using (SqlConnection conexionBDD = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexionBDD.Open();
                using (SqlCommand admin = new SqlCommand("PA_No_Admin", conexionBDD))
                {
                    object valor = admin.ExecuteScalar();
                    if ((int)valor == 0)
                    {
                        MessageBox.Show("Ningún administrador encontrado...", "Importar datos", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        string ruta = MostrarDialogoArchivoExcel();
                        if (string.IsNullOrEmpty(ruta)) return false;

                        CrearEmpleadosDesdeExcel(ruta);
                    }
                }
                conexionBDD.Close();
            }

            return true;
        }

        public static void CrearEmpleadosDesdeExcel(string rutaExcel)
        {
            DataTable autoridades = CrearDatos(rutaExcel, "Autoridades");

            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();

                foreach (DataRow row in autoridades.Rows)
                {
                    using (SqlCommand datosAuto = new SqlCommand("PA_Nombres_Completos", conn))
                    {
                        datosAuto.CommandType = CommandType.StoredProcedure;
                        datosAuto.Parameters.AddWithValue("@Nombre", row["Nombre"]);
                        datosAuto.Parameters.AddWithValue("@Apellido", row["Apellido"]);
                        datosAuto.ExecuteNonQuery();
                    }

                    using (SqlCommand IdAuto = new SqlCommand("PA_Empleados", conn))
                    {
                        IdAuto.CommandType = CommandType.StoredProcedure;
                        IdAuto.Parameters.AddWithValue("@Nombre", row["Nombre"]);
                        IdAuto.Parameters.AddWithValue("@Apellido", row["Apellido"]);
                        IdAuto.Parameters.AddWithValue("@codigo", row["Cod_Empleado"]);
                        IdAuto.Parameters.AddWithValue("@rol", row["rol"]);
                        IdAuto.ExecuteNonQuery();
                    }
                }

                conn.Close();
            }
        }

        public static string MostrarDialogoArchivoExcel()
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                ofd.Title = "Seleccionar archivo Excel";

                DialogResult resultado = ofd.ShowDialog();
                if (resultado != DialogResult.OK)
                {
                    // Usuario canceló
                    return null;
                }

                string ruta = ofd.FileName;
                string extension = System.IO.Path.GetExtension(ruta);

                if (!extension.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("El archivo seleccionado no es un archivo Excel válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                return ruta;
            }
        }


        public static DataTable CrearDatos(string rutaArchivo, string hojaNombre)
        {
            var dt = new DataTable();

            using (var workbook = new XLWorkbook(rutaArchivo))
            {
                if (!workbook.Worksheets.TryGetWorksheet(hojaNombre, out var hoja))
                {
                    MessageBox.Show("Datos no hayados. Importe los datos correctos de Excel", "Datos incorrectos", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return dt;
                }

                // 1) Primera fila = encabezados
                var filaEncabezados = hoja.FirstRowUsed();
                foreach (var celda in filaEncabezados.CellsUsed())
                {
                    var nombre = celda.GetString().Trim();
                    // Decide tipo según el nombre de la columna
                    if (nombre.Equals("Fecha", StringComparison.OrdinalIgnoreCase) || //OrdinalIgnoreCase detecta la cadena con cualquier letra normal o especial (como ñ, á, ü, etc.), ignorando las mayúsculas y minúsculas
                        nombre.Equals("Fecha_Reposicion", StringComparison.OrdinalIgnoreCase))
                        dt.Columns.Add(nombre, typeof(DateTime));

                    else if (nombre.Equals("ID_Clase", StringComparison.OrdinalIgnoreCase) ||
                             nombre.Equals("ID_Sitio", StringComparison.OrdinalIgnoreCase) ||
                             nombre.Equals("ID_Empleado", StringComparison.OrdinalIgnoreCase))
                        dt.Columns.Add(nombre, typeof(int));
 
                    else if (nombre.Equals("Presente", StringComparison.OrdinalIgnoreCase))
                        dt.Columns.Add(nombre, typeof(bool));

                    else
                        dt.Columns.Add(nombre, typeof(string));
                }

                // 2) Resto de filas = datos
                foreach (var fila in hoja.RowsUsed().Skip(1))
                {
                    var dr = dt.NewRow();
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        var colName = dt.Columns[i].ColumnName;
                        var celda = fila.Cell(i + 1);

                        if (dt.Columns[i].DataType == typeof(DateTime))
                        {
                            object raw = celda.Value;

                            if (raw == null || string.IsNullOrWhiteSpace(raw.ToString()))
                                dr[i] = DBNull.Value;
                            else
                            {
                                DateTime fecha;
                                if (raw is DateTime dtVal)
                                    fecha = dtVal;
                                else if (raw is double oa)
                                    // Excel almacena fechas como OADate, entonces se detecta del programa
                                    fecha = DateTime.FromOADate(oa);
                                else if (!DateTime.TryParse(raw?.ToString(), out fecha))
                                {
                                    // Aquí se decide: saltar la fila, o asignar default.
                                    // Por ejemplo, lanzamos para que sepas en qué celda falla:
                                    throw new FormatException(
                                      $"Fila {fila.RowNumber()}, columna «{colName}»: «{raw}» no es fecha válida."
                                    );
                                }
                                dr[i] = fecha;
                            }
                        }
                        else if (dt.Columns[i].DataType == typeof(bool))
                            // Lee booleanos directamente
                            dr[i] = celda.GetValue<bool>();

                        else if (dt.Columns[i].DataType == typeof(int))
                            dr[i] = celda.GetValue<int>();
                        else // strings u otros
                            dr[i] = celda.GetValue<string>()?.Trim() ?? string.Empty;
                    }

                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        public void Login(string usuario, string contraseña, Form Login, string rolAccess)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("PA_Login", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            nombre = reader["Nombre"].ToString();
                            apellido = reader["Apellido"].ToString();
                            string rolUsuario = reader["rol"].ToString();
                            string codigo = usuario.ToString();
                            empleado = codigo;

                            MessageBox.Show($"Bienvenido(a), {nombre} {apellido}. Su rol es: {rolUsuario}", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (rolUsuario == "administrador")
                            {
                                frmAdmin admin = new frmAdmin();
                                admin.Show();
                                Login.Hide();
                            }
                            else if (rolUsuario == "supervisor")
                            {
                                frmSupervisor supervisor = new frmSupervisor();
                                supervisor.Show();
                                Login.Hide();
                            }
                            else if (rolUsuario == "decano")
                            {
                                frmDecano decano = new frmDecano();
                                decano.Show();
                                Login.Hide();
                            }
                            else if (rolUsuario == "docente")
                            {
                                frmDocente doc = new frmDocente();
                                doc.Show();
                                Login.Hide();
                            }
                            else
                                MessageBox.Show("Rol no reconocido. Contacte al administrador para ajustar su rol y accesar", "Error de Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            if (rolAccess == "administrador")
                                if (!AdminContraseñaError(usuario, Login, conexion, reader)) 
                                    return;
                            MessageBox.Show("Usuario o contraseña incorrectos.\nComunicarse con el administrador en\ncaso de inconveniencia", "Error dato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        public static string Persona()
        {
            string name = nombre.ToLower();
            string ape = apellido.ToLower();
            if (string.IsNullOrWhiteSpace(name))
                return char.ToUpper(ape[0]) + ape.Substring(1);
            if (string.IsNullOrWhiteSpace(ape))
                return char.ToUpper(name[0]) + name.Substring(1);
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(ape))
                return "";
            else
                return char.ToUpper(name[0]) + name.Substring(1) + ' ' + char.ToUpper(ape[0]) + ape.Substring(1); //Substring ubica cadena inicial a leer
        }

        public static bool AdminCasoContra(string usuario, string contraseña, Form Login, TextBox contra)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Admin_Save", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (contraseña == "Contraseña:" || string.IsNullOrWhiteSpace(contraseña))
                            {
                                if (MessageBox.Show("Saludos Administrador, no podemos otorgar el acceso con su contraseña no ingresada, ¿olvidó su contraseña?", "Contraseña Vacía Admin.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                                {
                                    frmPierdoContraseña Lost = new frmPierdoContraseña();
                                    Login.Hide();
                                    Lost.Show();
                                }
                                return false;
                            }

                            if (contraseña.Length < 8)
                            {
                                if (MessageBox.Show("Saludos Administrador, su contraseña debe contener más de ocho caracteres, ¿perdió su contraseña?", "Contraseña Corta Admin.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                                {
                                    frmPierdoContraseña Lost = new frmPierdoContraseña();
                                    Login.Hide();
                                    Lost.Show();
                                }
                                return false;
                            }
                        }
                        else
                        {
                            if (contraseña == "Contraseña:" || string.IsNullOrWhiteSpace(contraseña))
                            {
           /**/                 if (contraseña == "Contraseña:" || string.IsNullOrWhiteSpace(contraseña))
                                {
                                    MessageBox.Show("Contraseña no puede quedar vacía.", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    contra.Focus();
                                    return false;
                                }
                            }

                            if (contraseña.Length < 8)
                            {
/**/                            if (MessageBox.Show("La contraseña debe tener al menos 8 caracteres", "Contraseña Corta", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes) 
                                {
                                    frmPierdoContraseña Lost = new frmPierdoContraseña();
                                    Login.Hide();
                                    Lost.Show();
                                }
                                return false;
                            }
                        }
                    }
                }
                return true;
            }
        }
 
        private static bool AdminContraseñaError(string usuario, Form Login, SqlConnection conexion, SqlDataReader read)
        {
            using (SqlCommand cmd = new SqlCommand("PA_Admin_Save", conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", usuario);

                read.Close();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        if (MessageBox.Show("Saludos Administrador, su contraseña es incorrecta, ¿olvidó su contraseña?", "Contraseña incorrecta", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            frmPierdoContraseña Lost = new frmPierdoContraseña();
                            Login.Hide();
                            Lost.Show();
                        }
                        return false;
                    }
                    else
                    { 
                        MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        public static void AdminContra(string contraseña, Form Contra)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexion.Open();

                string trigger = "UPDATE Empleados SET Contraseña = @Contraseña WHERE rol = 'Administrador'";
                using (SqlCommand cmd = new SqlCommand(trigger, conexion))
                {
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Contraseña agregada, abriendo sesión de administrador, bienvenido", "Inicio de sesión Admin.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    frmAdmin Menu = new frmAdmin();
                    Contra.Close();
                    Menu.Show();
                }
            }
        }

        public static void MigrarDatosNuevo()
        {
            MigrarDatos();
            try
            {
                File.Copy(rutaExcel, tempFile, overwrite: true);

                var dtLista = CrearDatos(tempFile, "Migración");

                using (var conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
                {
                    conn.Open();

                    foreach (DataRow row in dtLista.Rows)
                    {
                        using (var cmd = new SqlCommand("PA_Asistencia", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Clase", row["Curso"]);
                            cmd.Parameters.AddWithValue("@Aula", row["Aula"]);
                            cmd.Parameters.AddWithValue("@Seccion", row["Seccion"]);
                            cmd.Parameters.AddWithValue("@Edificio", row["Edificio"]);
                            cmd.Parameters.AddWithValue("@Nombre", row["Nombre"]);
                            cmd.Parameters.AddWithValue("@Apellido", row["Apellido"]);
                            cmd.ExecuteNonQuery();
                        }
                    }


                    conn.Close();
                }
            }
            finally
            {
                try { File.Delete(tempFile); }
                catch { }
            }
        }

        public static void MigrarDatos()
        {
            DataTable empleados = new DataTable();
            DataTable decanos = new DataTable();
            DataTable clases = new DataTable();
            DataTable Lugares = new DataTable();
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                ofd.Title = "Seleccionar archivo Excel";
                var dr = ofd.ShowDialog();
                if (dr != DialogResult.OK)
                    // El usuario canceló o cerró el diálogo: salimos
                    return;
                else
                {
                    rutaExcel = ofd.FileName;

                    string Excel = System.IO.Path.GetExtension(rutaExcel);
                    if (!Excel.Equals(".xlsx", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("El archivo seleccionado no es un archivo Excel válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (string.IsNullOrEmpty(Excel))
                        return;
                }
            }

            tempFile = System.IO.Path.Combine(
                                      System.IO.Path.GetTempPath(),
                                      Guid.NewGuid().ToString() + ".xlsx"
                                      );
            try
            {
                File.Copy(rutaExcel, tempFile, overwrite: true);

                // 3) Leer cada hoja sólo una vez
                var dtEmpleados = CrearDatos(tempFile, "Empleados");
                if (dtEmpleados.Rows.Count == 0)
                {
                    return;
                }
                var dtDecanos = CrearDatos(tempFile, "Decanos");
                var dtClases = CrearDatos(tempFile, "Clase");
                var dtLugares = CrearDatos(tempFile, "Lugares");

                using (var conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
                {
                    conn.Open();

                    foreach (DataRow row in dtEmpleados.Rows)
                    {
                        using (var cmd = new SqlCommand("PA_Nombres_Completos", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Nombre", row["Nombre"]);
                            cmd.Parameters.AddWithValue("@Apellido", row["Apellido"]);
                            cmd.ExecuteNonQuery();
                        }

                        using (var cmd = new SqlCommand("PA_Empleados", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Nombre", row["Nombre"]);
                            cmd.Parameters.AddWithValue("@Apellido", row["Apellido"]);
                            cmd.Parameters.AddWithValue("@codigo", row["Cod_Empleado"]);
                            cmd.Parameters.AddWithValue("@rol", row["rol"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (DataRow row in dtDecanos.Rows)
                    {
                        using (var cmd = new SqlCommand("PA_DecanoFacultad", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Codigo_Facu", row["Codigo_Facultad"]);
                            cmd.Parameters.AddWithValue("@ID", row["ID_Empleado"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (DataRow row in dtClases.Rows)
                    {
                        using (var cmd = new SqlCommand("PA_Clases", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Cod_Clase", row["Codigo_Asignatura"]);
                            cmd.Parameters.AddWithValue("@Cod_Facu", row["Codigo_Facultad"]);
                            cmd.Parameters.AddWithValue("@Clase", row["Curso"]);
                            cmd.Parameters.AddWithValue("@inicio", row["InicioDia"]);
                            cmd.Parameters.AddWithValue("@fin", row["FinDia"]);
                            cmd.Parameters.AddWithValue("@dia", row["DiaElegido"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    foreach (DataRow row in dtLugares.Rows)
                    {
                        using (var cmd = new SqlCommand("PA_Lugares", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Edificio", row["Edificio"]);
                            cmd.Parameters.AddWithValue("@Aula", row["Aula"]);
                            cmd.Parameters.AddWithValue("@Seccion", row["Seccion"]);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    conn.Close();
                }

                MessageBox.Show(
                    "Datos migrados con éxito",
                    "Migración de Datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            finally
            {
                try { File.Delete(tempFile); }
                catch { }
            }
        }

        public static DataTable tablaAdmin(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PA_Admin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                dgv.Columns.Clear();

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                bs.ResetBindings(false);
                dgv.AutoGenerateColumns = true;
                dgv.Refresh();
                dgv.Columns[0].Width = 140;
                dgv.Columns[0].ReadOnly = true;
                dgv.Columns[1].Width = 100;
                dgv.Columns[2].Width = 100;
                dgv.Columns[3].Width = 110;
                dgv.Columns[4].Width = 116;
                dgv.Columns[5].Width = 110;
                dgv.Columns[0].ReadOnly = true;
            }
            return dt;
        }

        public static DataTable RespaldoBDD()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Respaldo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    using (var da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                conn.Close();
            }
            return dt;
        }

        public static void ReiniciarBDD(string bdd)
        {
            var builder = new SqlConnectionStringBuilder(CONEXION_BD.conectarServidor.ConnectionString)
            {
                InitialCatalog = "master" //use master
            };

            using (var conn = new SqlConnection(builder.ConnectionString))
            using (var cmd = new SqlCommand("PA_NoBDD", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@DatabaseName", bdd);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void tablaSupervisor(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Supervisor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                conn.Close();
            }

            dgv.Columns.Clear();
            dgv.DataSource = dt;
            dgv.AutoGenerateColumns = true;
            dgv.Refresh();

            // Ajustar columnas
            if (dgv.Columns.Contains("AsistenciaHoy"))
            {
                dgv.Columns["AsistenciaHoy"].HeaderText = DateTime.Today.ToString("dddd dd/MM/yyyy");
                dgv.Columns[5].Width = 80;
                dgv.Columns["AsistenciaHoy"].ReadOnly = false;
            }

            using (SqlConnection conn1 = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn1.Open();
                SqlCommand time = new SqlCommand("PA_Periodo", conn1);
                time.CommandType = CommandType.StoredProcedure;
                using (SqlDataReader reader = time.ExecuteReader())
                {
                    if (reader.Read())
                        if (DateTime.Today >= Convert.ToDateTime(reader["FechaInicio"]) && DateTime.Today <= Convert.ToDateTime(reader["FechaFin"]))
                            dgv.Columns[5].Visible = true;
                        else
                            dgv.Columns[5].Visible = false;
                }
                conn1.Close();
            }
            dgv.Columns[0].Width = 300;
            dgv.Columns[0].ReadOnly = true;
            dgv.Columns[1].Width = 250;
            dgv.Columns[1].ReadOnly = true;
            dgv.Columns[2].Width = 60;
            dgv.Columns[2].ReadOnly = true;
            dgv.Columns[2].HeaderText = "Sección";
            dgv.Columns[3].Width = 150;
            dgv.Columns[3].ReadOnly = true;
            dgv.Columns[4].Visible = false;
        }

        public static void RegistrarAsistencia(DataGridView dgv, string Docente, string clase, string seccion, string aula, string edificio, bool Marco)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PA_Marcar_Asistencia", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Docente", Docente);
                cmd.Parameters.AddWithValue("@Asigno", clase);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Edificio", edificio);
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Now.Date);
                cmd.Parameters.AddWithValue("@Marca", Marco);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void FiltrarDatosSuperv(string Docente, string clase, string Aula, string Edificio, string Seccion, DataGridView dgv)
        {
            int horaSeccion;
            if (Seccion.Length >= 2 && int.TryParse(Seccion.Substring(0, 2), out horaSeccion))
            {
                if (horaSeccion > DateTime.Now.Hour)
                {
                    MessageBox.Show("No se pueden filtrar secciones futuras, por favor esperar\npara poder filtrarlas", "Sección futura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                MessageBox.Show("Secciones cargadas presentes o pasadas: " + dgv.Rows.Count, "Secciones presentes o pasados", MessageBoxButtons.OK, MessageBoxIcon.Information);            
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Buscar_Superv", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Docente", Docente);
                    cmd.Parameters.AddWithValue("@Clase", clase);
                    cmd.Parameters.AddWithValue("@Aula", Aula);
                    cmd.Parameters.AddWithValue("@Edificio", Edificio);
                    cmd.Parameters.AddWithValue("@Seccion", Seccion);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt;
                }
            }
        }

        public static List<DateTime> CargarAsistenciaSuperv(string Docente, string clase, string seccion, string aula, string edificio)
        {
            List<DateTime> fechas = new List<DateTime>();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Asistencia_Superv", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Docente", Docente);
                cmd.Parameters.AddWithValue("@Asigno", clase);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Edificio", edificio);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            fechas.Add(reader.GetDateTime(0));
                        }
                    }
                }
            }
            return fechas;
        }

        public static DataTable CargarAsistenciaSuperv(MonthCalendar adminFechas, string refiero, string curso, string seccion, string aula, string empleo)
        {
            DataTable dtFechas = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Asistencia_Admin", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Referencia", refiero);
                cmd.Parameters.AddWithValue("@Curso", curso);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Empleado", empleo);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFechas);
            }


            foreach (DataRow row in dtFechas.Rows)
            {
                adminFechas.AddBoldedDate(Convert.ToDateTime(row["Fecha"]));
            }

            adminFechas.UpdateBoldedDates();

            return dtFechas;
        }

        public static void CrearPeriodo(DateTime inicio, DateTime fin)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexion.Open();
                string trigger = "INSERT INTO Periodo (FechaInicio, FechaFin) VALUES (@inicio, @fin)";
                SqlCommand cmd = new SqlCommand(trigger, conexion);
                cmd.Parameters.AddWithValue("@inicio", inicio.Date);
                cmd.Parameters.AddWithValue("@fin", fin.Date);
                cmd.ExecuteNonQuery();
            }
        }

        public static void Periodo(DateTimePicker inicio, DateTimePicker fin, Button periodo, MonthCalendar trimestre)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("PA_Periodo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    inicio.Value = (DateTime)(reader["FechaInicio"]);
                    fin.Value = (DateTime)(reader["FechaFin"]);
                    trimestre.MinDate = (DateTime)(reader["FechaInicio"]);
                    trimestre.MaxDate = (DateTime)(reader["FechaFin"]);
                }
                else
                    return;

                if (DateTime.Now >= inicio.Value)
                {
                    inicio.Enabled = false;
                    fin.Enabled = false;
                    periodo.Enabled = false;
                }

                if (DateTime.Now >= fin.Value)
                {
                    inicio.Enabled = true;
                    fin.Enabled = true;
                    periodo.Enabled = true;
                }
            }
        }

        public static void Periodo(MonthCalendar trimestre)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("PA_Periodo", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    trimestre.MinDate = (DateTime)(reader["FechaInicio"]);
                    trimestre.MaxDate = (DateTime)(reader["FechaFin"]);
                }
            }
        }

        public static DataTable tablaJustifica(DataGridView dgv, string decanoCodigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Justifica", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoDecano", decanoCodigo);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                dgv.Columns.Clear();

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                bs.ResetBindings(false);
                dgv.AutoGenerateColumns = true;
                dgv.Refresh();

                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 150;
                dgv.Columns[2].Width = 80;
                dgv.Columns[3].Width = 66;
                dgv.Columns[4].Width = 120;
                dgv.Columns[4].HeaderText = "Sección";
                dgv.Columns[5].Width = 304;
                dgv.Columns[5].HeaderText = "Justificación";
            }

            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            dgv.Refresh();

            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 300;
            dgv.Columns[4].Width = 100;
            dgv.Columns[5].Width = 304;


            return dt;
        }

        public static void Justifico(DataGridView dgv, int Ausencia, string Justificacion)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Insertar_Justificacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Asistencia", Ausencia);
                    cmd.Parameters.AddWithValue("@Justificacion", Justificacion);
                    cmd.ExecuteNonQuery(); SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        public static DataTable tablaJustificaTodo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("PA_Justifica_Todo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoDecano", empleado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }


            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                sfd.Title = "Guardar Reporte Justificaciones";
                sfd.FileName = "Justificaciones.xlsx";

                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Justificaciones");
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            wb.SaveAs(sfd.FileName);
                        }
                        catch (Exception ex)
                        {
                            // ¿Es un bloqueo por "being used by another process"?
                            if (ex is IOException ||
                                ex is Win32Exception ||
                                ex.Message.Contains("being used by another process"))
                                MessageBox.Show("Por favor cerrar el archivo seleccionado para guardar", "Interrupción de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            return dt;
        }

        public static void FiltrarDatosJusto(string Docente, string Edificio, DateTime Pasado, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Buscar_Justo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Docente", Docente);
                    cmd.Parameters.AddWithValue("@Edificio", Edificio);
                    cmd.Parameters.AddWithValue("@FechaPasada", Pasado);
                    cmd.Parameters.AddWithValue("@CodigoDecano", empleado);


                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt;
                }
                dgv.Columns[0].Visible = false;
            }
        }

        public static DataTable tablaRepone(DataGridView dgv, string decanoCodigo)         
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Repone", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoDecano", decanoCodigo);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }

            if (dt.Rows.Count > 0)
            {
                dgv.Columns.Clear();

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                bs.ResetBindings(false);
                dgv.AutoGenerateColumns = true;
                dgv.Refresh(); 
                dgv.Columns[0].Visible = false;
            }

            dgv.AutoGenerateColumns = true;
            dgv.DataSource = dt;
            dgv.Refresh();


            dgv.Columns[1].Width = 150;
            dgv.Columns[2].Width = 100;
            dgv.Columns[3].Width = 300;
            dgv.Columns[4].Width = 100;

            dgv.Columns[4].HeaderText = "Sección";
            dgv.Columns[5].Width = 125;
            dgv.Columns[5].HeaderText = "Fecha de Reposición";

            dgv.Columns[5].Width = 125;

            return dt;
        }

        public static DataTable tablaReponeTodo()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            using (SqlCommand cmd = new SqlCommand("PA_Repone_Todo", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CodigoDecano", empleado);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }


            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                sfd.Title = "Guardar Reporte Reposiciones";
                sfd.FileName = "Reposiciones.xlsx";

                using (var wb = new XLWorkbook())
                {
                    wb.Worksheets.Add(dt, "Reposiciones");
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            wb.SaveAs(sfd.FileName);
                        }
                        catch (Exception ex)
                        {
                            // ¿Es un bloqueo por "being used by another process"?
                            if (ex is IOException ||
                                ex is Win32Exception ||
                                ex.Message.Contains("being used by another process"))
                                MessageBox.Show("Por favor cerrar el archivo seleccionado para guardar", "Interrupción de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            return dt;
        }

        public static void Repongo(DataGridView dgv, int Ausencia, DateTimePicker dtp)
        {

            DateTime dia = dtp.Value;
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))

            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Insertar_Reposicion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Asistencia", Ausencia);
                    cmd.Parameters.AddWithValue("@Fecha_Reposicion", dia);
                    cmd.ExecuteNonQuery(); SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        public static void FiltrarDatosRepo(string Repo, string Edificio, DateTime Pasado, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Buscar_Repo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Repo", Repo);
                    cmd.Parameters.AddWithValue("@Edificio", Edificio);
                    cmd.Parameters.AddWithValue("@FechaPasada", Pasado);
                    cmd.Parameters.AddWithValue("@CodigoDecano", empleado);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt;                 
                }

                dgv.Columns[0].Visible = false;
            }
        }

        public static DataTable tabla_docente(DataGridView dgv, string docenteCodigo)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Asistencia_Doc", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@CodigoDocente", docenteCodigo);

                    SqlDataAdapter da = new SqlDataAdapter(cmd); da.Fill(dt);
                }
            }

            if (dt.Rows.Count > 0)
            {
                dgv.Columns.Clear();

                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                bs.ResetBindings(false);

                dgv.AutoGenerateColumns = true;
                dgv.Refresh(); 
                dgv.Columns[0].Width = 150;
                dgv.Columns[1].Width = 58;
                dgv.Columns[1].HeaderText = "Sección";
                dgv.Columns[2].Visible = false;
                dgv.Columns[3].Visible = false;
            }
            return dt;
        }

        public static DataTable CargarAsistenciaDoc(MonthCalendar docFechas, string clase, string seccion, string aula, string edificio)
        {
            DataTable dtFechas = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Fecha_Doc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CodDocente", empleado);
                cmd.Parameters.AddWithValue("@Asigna", clase);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Edificio", edificio);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFechas);
            }


            foreach (DataRow row in dtFechas.Rows)
            {
                docFechas.AddBoldedDate(Convert.ToDateTime(row["Fecha"]));
            }

            docFechas.UpdateBoldedDates();

            return dtFechas;
        }
    }
}

