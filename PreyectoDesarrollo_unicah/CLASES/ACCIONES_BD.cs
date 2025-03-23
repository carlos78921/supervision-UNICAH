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

        public ACCIONES_BD(string codigo) //Constructor parametrizado del docente
        {
            if (!string.IsNullOrEmpty(codigo)) //Validación requerida de codigo transferido
            {
                docente = codigo;
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

                cmd.ExecuteNonQuery();
            }
        }

        public static DataTable CargarAsistencia(MonthCalendar supervisorFechas, string Docente, string clase, string seccion, string aula, string edificio)
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

        public static DataTable tablaAdmin (DataGridView dgv)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
                {
                    SqlCommand cmd = new SqlCommand("PA_Admin", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
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

                dgv.Columns[0].Width = 115;
                dgv.Columns[1].Width = 170;
                dgv.Columns[2].Width = 58;
                dgv.Columns[3].Width = 183;
                dgv.Columns[4].Width = 325;
            }
            return dt;
        }
 
        public DataTable codigo_doc()
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
                        cmd.Parameters.AddWithValue("@cod_docente", docente);

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
            DataTable dt = codigo_doc(); // Se llena los valores del PA según el código en DataTable

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

                dgv.Columns[0].Width = 125;
                dgv.Columns[1].Width = 58;
                dgv.Columns[2].Width = 20;
                dgv.Columns[3].Width = 22;
                dgv.Columns[4].Width = 22;
                dgv.Columns[5].Width = 20;
                dgv.Columns[6].Width = 20;
                dgv.Columns[7].Width = 20;
            }
            else
            {
                MessageBox.Show("No se encontraron registros.");
            }
        }


        /*        public static void presenteSup(string docente, string asignatura, string seccion, string dia)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
                        {
                            conn.Open();
                            using (SqlCommand cmd = new SqlCommand("PA_Marcar_Asistencia", conn))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@Asignatura", asignatura);
                                cmd.Parameters.AddWithValue("@Docente", docente);
                                cmd.Parameters.AddWithValue("@Seccion", seccion);
                                cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                                cmd.Parameters.AddWithValue("@Dia", dia);
                                cmd.ExecuteNonQuery(); 
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al marcar asistencia: " + ex.Message);
                    }
                }

                public static void RegistrarFalta(string docente, string asignatura, string seccion, string dia)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("PA_Registrar_Falta", conn);
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("@Asignatura", asignatura);
                            cmd.Parameters.AddWithValue("@Docente", docente);
                            cmd.Parameters.AddWithValue("@Seccion", seccion);
                            cmd.Parameters.AddWithValue("@Fecha", DateTime.Today);
                            cmd.Parameters.AddWithValue("@Dia", dia);

                            //cmd.ExecuteNonQuery();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al registrar falta: " + ex.Message);
                    }
                }
        */

        /*public void cargar(DataGridView dgv, string nombreTabla)
        {
            try
            {
                string consulta = $"SELECT * FROM {nombreTabla}";
                SqlDataAdapter da = new SqlDataAdapter(consulta, conexion.conectar); //usa la conexión de la clase `CONEXION_BD`
                DataTable dt = new DataTable();
                da.Fill(dt);

                MessageBox.Show($"Filas cargadas: {dt.Rows.Count}"); //esto verifica cuántas filas se cargaron

                if (dt.Rows.Count > 0) //se asegura de que hayan datos cargados al dataGridView
                {
                    dgv.DataSource = dt; //asigna el dataTable al dataGridView
                }
                else
                {
                    MessageBox.Show("No se encontraron datos en la tabla.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);   //captura los errores y los envia en un messagebox
                }
            }
            catch { }
        }
        */
    }
}
