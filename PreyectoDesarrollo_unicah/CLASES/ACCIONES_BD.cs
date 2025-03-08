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
        public static string docente;

        public CONEXION_BD conexion = new CONEXION_BD();
        SqlDataAdapter ad;
        DataTable dt;

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

        public DataTable codigo_doc()
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = conexion.conectar)
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("PA_Asistencia_Doc", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (string.IsNullOrEmpty(docente))
                        {
                            MessageBox.Show("Error: No se ha asignado un código de docente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return dt; //Concluye con mensaje de error
                        }
                        // Se asigna el parámetro con el código del docente.
                        cmd.Parameters.AddWithValue("@cod_docente", docente);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (DataColumn col in dt.Columns)
                            {
                                MessageBox.Show($"Columna: {col.ColumnName}, Valor: {row[col]}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener datos: " + ex.Message);
            }
            //Mostrar cantidad de filas según el PA
            MessageBox.Show($"Filas obtenidas: {dt.Rows.Count}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return dt;
        }

        public void LlenarDataGridViewConDatosDePrueba(DataGridView dgv)
        {
            // Crear un DataTable y definir las columnas
            DataTable dt = new DataTable();
            dt.Columns.Add("Asignatura", typeof(string));
            dt.Columns.Add("Sección", typeof(string));
            dt.Columns.Add("L", typeof(bool));
            dt.Columns.Add("M", typeof(bool));
            dt.Columns.Add("X", typeof(bool));
            dt.Columns.Add("J", typeof(bool));
            dt.Columns.Add("V", typeof(bool));
            dt.Columns.Add("S", typeof(bool));

            // Agregar filas de datos de prueba
            dt.Rows.Add("Gato", 1001, true, true, true, true, true, true);
            dt.Rows.Add("Dato2", 1002,true, false, true, false, true, false);

            // Asignar el DataTable al DataGridView
            dgv.DataSource = dt;

            // Refrescar el DataGridView
            dgv.Refresh();

            // Mostrar un mensaje de éxito
            MessageBox.Show("Datos de prueba asignados correctamente al DataGridView.");
        }

        public void tabla_docente(DataGridView dgv)
        {
            DataTable dt = codigo_doc();

            foreach (DataColumn col in dt.Columns)
            {
                MessageBox.Show($"Columna encontrada: {col.ColumnName}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            foreach (DataRow row in dt.Rows)
            {
                MessageBox.Show($"Fila: {row["Asignatura"]}, {row["Sección"]}, " +
                $"{row["L"]}, {row["M"]}, {row["X"]}, " +
                $"{row["J"]}, {row["V"]}, {row["S"]}");
            }
            if (dt.Rows.Count > 0)
            {
                /*Binding source: una forma efectiva de actualizar dgv para un form
                BindingSource bs = new BindingSource(); 
                bs.DataSource = dt; // Enlaza el DataTable al BindingSource
                dgv.DataSource = null; //Libera cualquier dato previo (vacío) en el DataGridView
                dgv.DataSource = bs; // Enlaza el BindingSource al DataGridView
                bs.ResetBindings(false); // Actualiza la vista del dgv si hay cambios en los datos*/

                dgv.DataSource = dt;
                dgv.AutoGenerateColumns = true;
                dgv.Refresh(); //Forzar la actualización de la UI

                //Ajustar ancho de columnas en "dgv nuevo"
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
