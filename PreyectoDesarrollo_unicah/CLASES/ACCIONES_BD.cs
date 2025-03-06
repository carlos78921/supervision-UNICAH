using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Security.Policy;

namespace PreyectoDesarrollo_unicah.CLASES
{
    class ACCIONES_BD
    {
        //Atributos
        public static string nombre, apellido;

        public CONEXION_BD conexion = new CONEXION_BD();
        SqlDataAdapter ad;
        DataTable dt;

        public ACCIONES_BD()
        {
            nombre = "";
            apellido = "";
        }

        public void tabla_docente(DataGridView dgv, string clase, string seccion,
            bool lunes, bool martes, bool miercoles, bool jueves, bool viernes, bool sabado)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("PA_Asistencia_Doc", conexion.conectar))
                //Comando recibido de conexión en referencia del atributo para conexión 
                {
                    cmd.CommandType = CommandType.StoredProcedure; //Tipo de comando: SP
                    cmd.Parameters.AddWithValue("@Clase", clase); //Agrega valor de campos
                    cmd.Parameters.AddWithValue("@Seccion", seccion);
                    cmd.Parameters.AddWithValue("@L", lunes);
                    cmd.Parameters.AddWithValue("@M", martes);
                    cmd.Parameters.AddWithValue("@X", miercoles);
                    cmd.Parameters.AddWithValue("@J", jueves);
                    cmd.Parameters.AddWithValue("@V", viernes);
                    cmd.Parameters.AddWithValue("@S", sabado);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable(); //dt es del data table... como consulta
                    da.Fill(dt); // Llena la tabla con los datos del SP "AddWithValue"
                    foreach (DataColumn col in dt.Columns)
                    {
                        MessageBox.Show("Columna en DataTable: " + col.ColumnName);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Datos obtenidos: " + dt.Rows[0][0].ToString() + " - " + dt.Rows[0][1].ToString());
                        dgv.Columns.Clear();
                        dgv.DataSource = dt; // Asigna los datos al DataGridView
                        dgv.Refresh(); //Forzar la actualización de la UI
                        dgv.Columns[0].Width = 125;
                        dgv.Columns[1].Width = 58;
                        dgv.Columns[2].Width = 20; //Ajustar ancho de columnas en "dgv nuevo"
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
            }
            catch (Exception ex) //Requiere un recurso de validación para error
            {
                MessageBox.Show("Error de conexión: " + ex.Message);
            }
        }

        public void cargar(DataGridView dgv, string nombreTabla)
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
    }
}
