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
using DocumentFormat.OpenXml.Office.Word;

namespace PreyectoDesarrollo_unicah.CLASES
{
    class ACCIONES_BD
    {
        public static string nombre, apellido;
        public static string docente;

        public CONEXION_BD conexion = new CONEXION_BD();

        public ACCIONES_BD()
        {
            nombre = "";
            apellido = "";
        }

        public ACCIONES_BD(string codigo)
        {
            docente = codigo;
        }

        public static bool AdminCasoContra(string usuario, string contraseña, Form Login)
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
                            if ((contraseña != "Contraseña:" && contraseña.Length < 8))
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

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) 
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

        public static void AdminContra(string contraseña, Form Contra)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conexion.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Contra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Usuario", 1);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Contraseña agregada, abriendo sesión de administrador, bienvenido", "Inicio de sesión Admin.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    frmAdmin Menu = new frmAdmin();
                    Contra.Close();
                    Menu.Show();
                }
            }
        }

        public static void RegistrarAsistencia(DataGridView dgv, string Docente, string clase, string seccion, string aula, string edificio, bool Marco)
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
                cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                cmd.Parameters.AddWithValue("@Marca", Marco);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<DateTime> CargarAsistenciaSuperExcel(string Docente, string clase, string seccion, string aula, string edificio)
        {
            List<DateTime> fechas = new List<DateTime>();
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
                dgv.Refresh(); 
                dgv.Columns[0].Width = 300;
                dgv.Columns[1].Width = 250;
                dgv.Columns[2].Width = 60;
                dgv.Columns[3].Width = 150;
                dgv.Columns[4].Visible = false;
                dgv.Columns[5].Width = 55;
                if (dgv.Columns.Contains("AsistenciaHoy"))
                {
                    dgv.Columns["AsistenciaHoy"].HeaderText = DateTime.Today.ToString("dddd dd/MM/yyyy");
                }
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

                    dgv.DataSource = dt;
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
                dgv.Refresh();
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


            foreach (DataRow row in dtFechas.Rows)
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

        public static void AdminAsignaContra(string usuario, string contraseña)
        {
            using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conexion.Open();

                using (SqlCommand cmd = new SqlCommand("PA_Contra", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contraseña", contraseña);

                    //"@" = Parámetro, "RetVal" = ReturnValue, SqlDbType.Int = Tipo de dato del retorno
                    SqlParameter @retorno = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                    @retorno.Direction = ParameterDirection.ReturnValue; //Obtener el parámetro de retorno

                    cmd.ExecuteNonQuery();

                    int resultado = (int)@retorno.Value;
                    if (resultado == 0)
                    {
                        MessageBox.Show("Usuario no encontrado");
                    }
                    else
                    {
                        MessageBox.Show("Contraseña cambiada con éxito", "Contraseña Cambiada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

        }
        public static DataTable tablaJustifica(DataGridView dgv)
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
                dgv.Refresh();
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

                    dgv.DataSource = dt;
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
                    cmd.ExecuteNonQuery();                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        public static DataTable tablaRepone(DataGridView dgv)         {
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
                dgv.Refresh(); 
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

                    dgv.DataSource = dt;                 }

                dgv.Columns[0].Visible = false;
            }
        }

        public static void Repongo(DataGridView dgv, int Ausencia, DateTimePicker dtp)
        {
            DateTime dia = dtp.Value;             using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Insertar_Reposicion", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Asistencia", Ausencia);
                    cmd.Parameters.AddWithValue("@Fecha_Reposicion", dia);
                    cmd.ExecuteNonQuery();                     SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv.DataSource = dt;
                }
            }
        }

        public DataTable codigo_doc_tabla()
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

                        cmd.Parameters.AddWithValue("@CodigoDocente", docente);

                        SqlDataAdapter da = new SqlDataAdapter(cmd); da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }
            return dt;
        }

        public void tabla_docente(DataGridView dgv)
        {
            DataTable dt = codigo_doc_tabla(); 

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


            foreach (DataRow row in dtFechas.Rows)
            {
                docFechas.AddBoldedDate(Convert.ToDateTime(row["Fecha"]));
            }

            docFechas.UpdateBoldedDates();

            return dtFechas;
        }
    }
}