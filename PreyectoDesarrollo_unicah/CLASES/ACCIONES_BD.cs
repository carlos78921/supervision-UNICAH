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
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;

namespace PreyectoDesarrollo_unicah.CLASES
{
    class ACCIONES_BD
    {
        //Atributos
        public static string nombre, apellido;
        public static string docente;
        public CONEXION_BD conexion = new CONEXION_BD();

        //Constructor
        public ACCIONES_BD()
        {
            nombre = "";
            apellido = "";
        }

        public ACCIONES_BD(string codigo)
        {
            if (!string.IsNullOrEmpty(codigo))
            {
                docente = codigo;
            }
        }

        public static bool AdminContraVacio(string usuario, string contraseña, Form Login)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
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
                            if (contraseña == "Contraseña:")
                            {
                                if (MessageBox.Show("Saludos Administrador, no podemos otorgar el acceso con su contraseña vacía, ¿olvidó su contraseña?", "Contraseña Vacía Admin.", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                                {
                                    frmPierdoContraseña Lost = new frmPierdoContraseña();
                                    Login.Hide();
                                    Lost.Show();
                                }
                                return false;
                            }
                            if (contraseña.Length < 8)
                            {
                                if (MessageBox.Show("Saludos Administrador, su contraseña debe contener más de ocho caracteres, ¿olvidó su contraseña?", "Contraseña Corta", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
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
            }
            return true;
        }

        public static void Login(string usuario, string contraseña, Form Login)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("PA_Login", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contraseña);

                    // Consulta para obtener el rol, nombre y apellido
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // Verifica si hay usuario y contraseña para leer otros datos
                        {
                            string nombre = reader["nombre1"].ToString();
                            string apellido = reader["apellido1"].ToString();
                            string rolUsuario = reader["rol"].ToString();
                            string codigoDocente = usuario.ToString();
                            ACCIONES_BD.nombre = nombre;
                            ACCIONES_BD.apellido = apellido;
                            ACCIONES_BD.docente = codigoDocente;

                            MessageBox.Show($"Bienvenido(a), {nombre} {apellido}. Su rol es: {rolUsuario}", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (rolUsuario == "administrador")
                            {
                                // Abrir la pantalla del administrador
                                frmAdmin admin = new frmAdmin();
                                admin.Show();
                                Login.Hide();
                            }
                            else if (rolUsuario == "supervisor")
                            {
                                // Abrir las pantallas del supervisor
                                frmSupervisor supervisor = new frmSupervisor();
                                supervisor.Show();
                                Login.Hide();
                            }
                            else if (rolUsuario == "decano")
                            {
                                // Abrir las pantallas del decano
                                frmDecano decano = new frmDecano();
                                decano.Show();
                                Login.Hide();
                            }
                            else if (rolUsuario == "docente")
                            {
                                // Abrir las pantallas del docente
                                frmDocente doc = new frmDocente();
                                doc.Show();
                                Login.Hide();
                            }
                        }
                        else
                        {
                            if (!AdminContraseñaError(usuario, Login, conexion, reader))
                                return;
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
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
                            // Usuario o contraseña incorrectos
                            if (MessageBox.Show("Saludos Administrador, su contraseña es incorrecta, ¿olvidó su contraseña?", "Contraseña incorrecta", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                            {
                                frmPierdoContraseña Lost = new frmPierdoContraseña();
                                Login.Hide();
                                Lost.Show();
                            }
                            return false;
                        }
                    }
                }
            return true;
        }

        public static void AdminContra(string contraseña)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conexion.Open();
                string query = "UPDATE Empleados SET Contraseña = @Contraseña WHERE Rol = 'Administrador'";
                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.ExecuteNonQuery(); 
                }
            }
        }

        public static void RegistrarAsistencia(DataGridView dgv, string Docente, string clase, string seccion, string aula, string edificio, DateTime fechaMarca, bool Marco)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Marcar_Asistencia", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Docente", Docente);
                cmd.Parameters.AddWithValue("@Asigno", clase);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Edificio", edificio);
                cmd.Parameters.AddWithValue("@Fecha", fechaMarca);
                cmd.Parameters.AddWithValue("@Marca", Marco);
                cmd.ExecuteNonQuery(); //Esto permite la ejecución de insert o update 
            }
        }

        public static DataTable CargarAsistenciaSuperv(MonthCalendar supervisorFechas, string Docente, string clase, string seccion, string aula, string edificio)
        {
            DataTable dtFechas = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Asistencia_Superv", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Docente", Docente);
                cmd.Parameters.AddWithValue("@Asigno", clase);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Edificio", edificio);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFechas);
            }

            foreach (DataRow row in dtFechas.Rows) //De la tabla del SQL para obtener campo fecha
            {
                supervisorFechas.AddBoldedDate(Convert.ToDateTime(row["Fecha"]));
            }

            supervisorFechas.UpdateBoldedDates();

            return dtFechas;
        }

        public static DataTable tablaSupervisor(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("PA_Supervisor", conn);
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
                dgv.Refresh(); // Forzar actualización de la UI

                dgv.Columns[0].Width = 300;
                dgv.Columns[1].Width = 250;
                dgv.Columns[2].Width = 60;
                dgv.Columns[3].Width = 150;
                dgv.Columns[4].Visible = false;
            }
            return dt;
        }

        public static void FiltrarDatosSuperv(string Docente, string clase, string Seccion, string Aula, string Edificio, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Buscar_Superv", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Docente", Docente);
                    cmd.Parameters.AddWithValue("@Clase", clase);
                    cmd.Parameters.AddWithValue("@Seccion", Seccion);
                    cmd.Parameters.AddWithValue("@Aula", Aula);
                    cmd.Parameters.AddWithValue("@Edificio", Edificio);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt; // Cargamos los datos filtrados
                }
            }
        }

        public static DataTable tablaAdmin (DataGridView dgv)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
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
                dgv.Refresh(); // Forzar actualización de la UI

                //Ajustar ancho de las columnas 
                dgv.Columns[0].Width = 115;
                dgv.Columns[1].Width = 170;
                dgv.Columns[2].Width = 58;
                dgv.Columns[3].Width = 183;
                dgv.Columns[4].Width = 325;
            }
            return dt;
        }

        public static DataTable CargarAsistenciaAdmin(MonthCalendar adminFechas, string refiero, string curso, string seccion, string aula, string empleo)
        {
            DataTable dtFechas = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
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


            foreach (DataRow row in dtFechas.Rows) //De la tabla del SQL para obtener campo fecha
            {
                adminFechas.AddBoldedDate(Convert.ToDateTime(row["Fecha"]));
            }

            adminFechas.UpdateBoldedDates();

            return dtFechas;
        }

        public static List<DateTime> CargarAsistenciaAdminExcel(string refiero, string curso, string seccion, string aula, string empleado)
        {
            List<DateTime> fechas = new List<DateTime>();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Asistencia_Admin", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Referencia", refiero);
                    cmd.Parameters.AddWithValue("@Curso", curso);
                    cmd.Parameters.AddWithValue("@Seccion", seccion);
                    cmd.Parameters.AddWithValue("@Aula", aula);
                    cmd.Parameters.AddWithValue("@Empleado", empleado);

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
            }
            return fechas;
        }

        public static DataTable tablaJustifica(DataGridView dgv) //Decano
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Justifica", conn);
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
                dgv.Refresh(); // Forzar actualización de la UI

                //Ajustar ancho de las columnas
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 150;
                dgv.Columns[2].Width = 80;
                dgv.Columns[3].Width = 66;
                dgv.Columns[4].Width = 120;
                dgv.Columns[5].Width = 304;
            }

            return dt;
        }

        public static void FiltrarDatosJusto(string Docente, string Edificio, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Buscar_Justo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Docente", Docente);
                    cmd.Parameters.AddWithValue("@Edificio", Edificio);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt; // Cargamos los datos filtrados
                }
                dgv.Columns[0].Visible = false;
            }
        }

        public static void Justifico (DataGridView dgv, int Ausencia, string Justificacion)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Insertar_Justificacion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Asistencia", Ausencia);
                    cmd.Parameters.AddWithValue("@Justificacion", Justificacion);
                    cmd.ExecuteNonQuery(); //Esto permite la ejecución de insert o update
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        public static DataTable tablaRepone(DataGridView dgv) //Decano
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Repone", conn);
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
                dgv.Refresh(); // Forzar actualización de la UI

                //Ajustar ancho de las columnas
                dgv.Columns[0].Visible = false;
                dgv.Columns[1].Width = 150;
                dgv.Columns[2].Width = 80;
                dgv.Columns[3].Width = 66;
                dgv.Columns[4].Width = 120;
                dgv.Columns[5].Width = 304;
            }
            return dt;
        }

        public static void FiltrarDatosRepo(string Repo, string Edificio, DataGridView dgv)
        {
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Buscar_Repo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Repo", Repo);
                    cmd.Parameters.AddWithValue("@Edificio", Edificio);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgv.DataSource = dt; // Cargamos los datos filtrados
                }

                dgv.Columns[0].Visible = false;
            }
        }

        public static void Repongo(DataGridView dgv, int Ausencia, DateTimePicker dtp)
        {
            DateTime dia = dtp.Value; // DateTimePicker o cualquier otro control de fecha
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Insertar_Reposicion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Asistencia", Ausencia);
                    cmd.Parameters.AddWithValue("@Fecha_Reposicion", dia);
                    cmd.ExecuteNonQuery(); //Esto permite la ejecución de insert o update
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        public DataTable codigo_doc_tabla() //Con esto muestra las filas por código del docente
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("PA_Asistencia_Doc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        /*if (string.IsNullOrEmpty(docente)) //No se lee el código del docente  
                        {
                            MessageBox.Show("Error: No se ha asignado un código de docente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return dt; //Concluye con mensaje de error
                        }*/

                        // Se asigna el parámetro con el código del docente.
                        cmd.Parameters.AddWithValue("@CodigoDocente", docente);

                        SqlDataAdapter da = new SqlDataAdapter(cmd); //Adaptador de comando por conexión
                        da.Fill(dt); //Llenar los datos del PA

                        /*foreach (DataRow row in dt.Rows) //Depuración: Mostrar columnas y valores en la fila
                        {
                            foreach (DataColumn col in dt.Columns)
                            {
                                MessageBox.Show($"Columna: {col.ColumnName}, Valor: {row[col]}");
                            }
                        */
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }
            /*Mostrar cantidad de filas según el PA
              MessageBox.Show($"Filas obtenidas: {dt.Rows.Count}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);*/
            return dt;
        }

        public void tabla_docente(DataGridView dgv)
        {
            DataTable dt = codigo_doc_tabla(); // Se llena los valores del PA según el código en DataTable

            /* Depuración: Mostrar columnas leídas del dgv 
            foreach (DataColumn col in dt.Columns)
            {
                MessageBox.Show($"Columna encontrada: {col.ColumnName}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }*/

            if (dt.Rows.Count > 0)
            {
                /* Limpia las columnas actuales para evitar duplicados posiblemente por el PA
                o columnas mal detectadas                 por más de una fila*/
                dgv.Columns.Clear();

                // Usa BindingSource para enlazar los datos
                BindingSource bs = new BindingSource();
                bs.DataSource = dt;
                dgv.DataSource = bs;
                bs.ResetBindings(false);

                dgv.AutoGenerateColumns = true;
                dgv.Refresh(); // Forzar actualización de la UI

                dgv.Columns[0].Width = 150;
                dgv.Columns[1].Width = 58;
                dgv.Columns[2].Visible = false;
                dgv.Columns[3].Visible = false;
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
        }

        public DataTable CargarAsistenciaDoc(MonthCalendar docFechas, string clase, string seccion, string aula, string edificio)
        {
            DataTable dtFechas = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("PA_Fecha_Doc", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CodDocente", docente);
                cmd.Parameters.AddWithValue("@Asigna", clase);
                cmd.Parameters.AddWithValue("@Seccion", seccion);
                cmd.Parameters.AddWithValue("@Aula", aula);
                cmd.Parameters.AddWithValue("@Edificio", edificio);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dtFechas);
            }


            foreach (DataRow row in dtFechas.Rows) //De la tabla del SQL para obtener campo fecha
            {
                docFechas.AddBoldedDate(Convert.ToDateTime(row["Fecha"]));
            }

            docFechas.UpdateBoldedDates();

            return dtFechas;
        }
    }
}
