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

namespace PreyectoDesarrollo_unicah.FRMS_SUPERV
{
    public partial class frmReporte : Form
    {
        public frmReporte()
        {
            InitializeComponent();
        }

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
            // 1. Crear el DataTable y llenarlo con los datos base desde la base de datos usando PA_Admin.
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Supervisor", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            // Ahora dt tiene las 5 columnas base: Referencia, Curso, Sección, Aula y Empleado.

            // 2. Agregar columnas para asistencia (12 semanas x 6 días = 72 columnas).
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
            // Al final, dt tendrá 5 + 72 = 77 columnas.

            // 3. Recorrer cada fila del dt (datos base) para llenar las columnas de asistencia.
            // Se usará una fecha de inicio (por ejemplo, la mínima del calendario o una fecha fija).
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, 1, 20);
            // Si el MonthCalendar está configurado correctamente, podrías usar:
            // DateTime fechaInicio = mesAdmin.MinDate;

            // Por cada fila (cada registro de PA_Admin)
            foreach (DataRow row in dt.Rows)
            {
                string docente = row["Docente"].ToString();
                string clase = row["Asignatura"].ToString();
                string seccion = row["Seccion"].ToString();
                string aula = row["Aula"].ToString();
                string edificio = row["Edificio"].ToString();

                // Obtener las fechas de asistencia para este registro usando tu método
                List<DateTime> fechasAsistencia = ACCIONES_BD.CargarAsistenciaSuperExcel(docente, clase, seccion, aula, edificio);

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
            // Obtén el DataTable directamente de la base de datos (sin usar dgv).
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
                    workbook.SaveAs(saveFileDialog.FileName);
            }
        }
    }
}