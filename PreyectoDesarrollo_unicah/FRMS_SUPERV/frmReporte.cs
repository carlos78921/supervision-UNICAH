using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using PreyectoDesarrollo_unicah.CLASES;
using System.Data.SqlClient;
using DocumentFormat.OpenXml.Office.Word;
using System.Runtime.InteropServices;

namespace PreyectoDesarrollo_unicah.FRMS_SUPERV
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmReporte_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            frmSupervisor Menu = new frmSupervisor();
            this.Close();
            Menu.Show();
        }

        private void btnChao_Click(object sender, EventArgs e)
        {
            frmSupervisor superv = new frmSupervisor();
            this.Close();
            superv.Show();
        }

        private DataTable TransferirDatosSuperExcel()
        {
            // 1. Crear el DataTable y llenarlo con los datos base desde la base de datos usando la tabla del supervisor sin "Presente"
            DataTable dt = new DataTable();
            using (SqlConnection muestra = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                muestra.Open();
                using (SqlCommand tabla = new SqlCommand("PA_Supervisor_Excel", muestra))
                {
                    tabla.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(tabla);
                    da.Fill(dt);
                }
            }

            /* Ahora dt tiene las 5 columnas base: Docente, Asignatura, Aula, Sección y Edificio.
               2. Agregar columnas para asistencia (12 semanas x 6 días = 72 columnas).*/
            for (int parcial = 1; parcial <= 3; parcial++)
            {
                for (int semana = 1; semana <= 4; semana++)
                {
                    string[] diasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
                    foreach (string dia in diasSemana)
                    {
                        dt.Columns.Add($"Parcial {parcial} - Semana {semana} - {dia}");
                    }
                }
            }
            /* Al final, dt tendrá 5 + 72 = 77 columnas.

             3. Recorrer cada fila del dt (datos base) para llenar las columnas de asistencia.
             Se usará una fecha de inicio (por ejemplo, la mínima del calendario o una fecha fija).*/

            // Conectar a la base de datos para obtener la fecha de inicio.
            DateTime fechaInicio = DateTime.Now; //Valor por defecto, luego se cambiará
            using (SqlConnection fecha = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                fecha.Open();
                SqlCommand inicio = new SqlCommand("PA_Periodo", fecha);
                inicio.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = inicio.ExecuteReader();
                if (reader.Read())
                    fechaInicio = reader.GetDateTime(0);
            }

            // Por cada fila (cada registro de la tabla del supervisor)
            foreach (DataRow row in dt.Rows)
            {
                string docente = row["Docente"].ToString();
                string clase = row["Asignatura"].ToString();
                string seccion = row["Seccion"].ToString();
                string aula = row["Aula"].ToString();
                string edificio = row["Edificio"].ToString();

                // Obtener las fechas de asistencia para este registro usando el método de PA para fechas
                List<DateTime> fechasAsistencia = ACCIONES_BD.CargarAsistenciaSuperv(docente, clase, seccion, aula, edificio);

                // Recorrer cada fecha de asistencia
                foreach (DateTime fecha in fechasAsistencia)
                {
                    // Calcular cuántos días han pasado desde fechaInicio
                    int diasOffset = (fecha - fechaInicio).Days;
                    // Aceptamos solo fechas dentro de 12 semanas (12*7 = 84 días)
                    if (diasOffset < 0 || diasOffset >= 84)
                        continue;

                    // Calcular en qué semana (0 a 11) y en qué día (0 a 6)
                    int numeroSemana = diasOffset / 7;    // si 0, estamos en la 1ª semana (en numeración base 0)
                    int diaEnSemana = diasOffset % 7;       // 0 = lunes, 1 = martes, ... 6 = domingo

                    // Si queremos solo lunes a sábado, ignoramos domingo (si diaEnSemana == 6)
                    if (diaEnSemana >= 6)
                        continue;

                    // Las primeras 5 columnas son de datos base.
                    int baseColumnIndex = 5;
                    // Cada semana tiene 6 columnas (para 6 días).
                    int semanaColumnOffset = numeroSemana * 6;
                    int columnIndex = baseColumnIndex + semanaColumnOffset + diaEnSemana;
                    // Asigna "P" (presente) en la columna calculada.
                    row[columnIndex] = "P";


                    // Rellenar con "-" las columnas de asistencia que no se hayan asignado.
                    for (int c = baseColumnIndex; c < dt.Columns.Count; c++)
                    {
                        if (string.IsNullOrEmpty(row[c].ToString()))
                        {
                            row[c] = "-";
                        }
                    }
                }
            }

            return dt;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            // Obtener el DataTable directamente de la base de datos (sin usar dgv).
            DataTable dt = TransferirDatosSuperExcel();

            int baseColumns = 5; int columnasPorParcial = 4 * 6;
            using (var workbook = new XLWorkbook())
            {
                for (int parcial = 0; parcial < 3; parcial++)
                {
                    DataTable dtParcial = dt.Clone();

                    for (int i = dtParcial.Columns.Count - 1; i >= baseColumns; i--)
                    {
                        dtParcial.Columns.RemoveAt(i);
                    }

                    for (int i = 0; i < columnasPorParcial; i++)
                    {
                        int indiceReal = baseColumns + (parcial * columnasPorParcial) + i;
                        dtParcial.Columns.Add(dt.Columns[indiceReal].ColumnName, typeof(string));
                    }

                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtParcial.NewRow();

                        for (int i = 0; i < baseColumns; i++)
                        {
                            newRow[i] = row[i];
                        }
                        for (int i = 0; i < columnasPorParcial; i++)
                        {
                            int indiceReal = baseColumns + (parcial * columnasPorParcial) + i;
                            newRow[baseColumns + i] = row[indiceReal];
                        }
                        dtParcial.Rows.Add(newRow);
                    }

                    var ws = workbook.Worksheets.Add($"Parcial {parcial + 1}");
                    ws.Cell(1, 1).InsertTable(dtParcial);
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivo Excel (.xlsx)|*.xlsx",
                    Title = "Guardar archivo Excel",
                    FileName = "Reporte_Supervisor.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        if (ex is IOException ||
                            ex is Win32Exception ||
                            ex.Message.Contains("being used by another process"))
                            MessageBox.Show("El archivo ya está abierto en Excel.\nPor favor cerrar antes de guardar.", "Archivo en uso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        
        private void MoveForm_MouseDown(object sender, MouseEventArgs e) 
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); //El evento en memoria se mantiene
        }
    }
}