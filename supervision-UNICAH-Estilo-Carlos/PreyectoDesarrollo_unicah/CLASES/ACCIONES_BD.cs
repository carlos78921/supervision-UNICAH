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
        private string docente;

        public CONEXION_BD conexion = new CONEXION_BD();
        SqlDataAdapter ad;
        DataTable dt;

        public ACCIONES_BD()
        {
            nombre = "";
            apellido = "";
        }

        public ACCIONES_BD(string codigo) //Constructor parametrizado
        {
            docente = codigo;
        }

        public DataTable codigo_doc()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = conexion.conectar)
                {
                    using (SqlCommand cmd = new SqlCommand("PA_Asistencia_Doc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        // Se asigna el parámetro con el código del docente.
                        cmd.Parameters.AddWithValue("@cod_docente", docente);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
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
            DataTable dt = codigo_doc();
            if (dt.Rows.Count > 0)
            {
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
