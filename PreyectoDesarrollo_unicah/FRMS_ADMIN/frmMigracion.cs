using ClosedXML.Excel;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmMigracion : Form
    {
        public frmMigracion()
        {
            InitializeComponent();
        }

        //Proceso en carga de formulario
        private void LimiteMes()
        {
            int año = DateTime.Now.Year;

            // Definir el rango (20 enero - 18 abril del año actual), académicamente
            mesAdmin.MinDate = new DateTime(año, 1, 20);
            mesAdmin.MaxDate = new DateTime(año, 4, 18);
        }

        private void frmMigración_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;

            //Ajuste del formulario
            LimiteMes();

            //Ajustes del bdd
            ACCIONES_BD.tablaAdmin(dgvAdmin);
            ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, (string)dgvAdmin.CurrentRow.Cells[0].Value, (string)dgvAdmin.CurrentRow.Cells[1].Value, (string)dgvAdmin.CurrentRow.Cells[2].Value, (string)dgvAdmin.CurrentRow.Cells[3].Value, (string)dgvAdmin.CurrentRow.Cells[4].Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdmin.CurrentRow != null)
            {
                // Extraer los valores de la fila seleccionada.
                string refiero = dgvAdmin.CurrentRow.Cells[0].Value.ToString();
                string curso = dgvAdmin.CurrentRow.Cells[1].Value.ToString();
                string seccion = dgvAdmin.CurrentRow.Cells[2].Value.ToString();
                string aula = dgvAdmin.CurrentRow.Cells[3].Value.ToString();
                string empleo = dgvAdmin.CurrentRow.Cells[4].Value.ToString();

                // Limpiar las fechas resaltadas previas en el MonthCalendar.
                mesAdmin.RemoveAllBoldedDates();

                // Llama al método para cargar las fechas marcadas para ese registro.
                ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, refiero, curso, seccion, aula, empleo);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // Crear un DataTable para almacenar los datos del DataGridView
            DataTable dt = new DataTable();

            // Agregar las columnas del DataGridView primero
            foreach (DataGridViewColumn columna in dgvAdmin.Columns)
            {
                dt.Columns.Add(columna.HeaderText);
            }

            // Agregar las columnas de asistencia organizadas en 4 semanas
            string[] diasSemana = { "lunes", "martes", "miércoles", "jueves", "viernes", "sábado" };
            int semanas = 4; // Número de semanas
            int columnasPorSemana = diasSemana.Length;

            for (int semana = 1; semana <= semanas; semana++)
            {
                foreach (string dia in diasSemana)
                {
                    dt.Columns.Add($"Semana {semana} - {dia}"); // Solución: Nombres únicos
                                                                // Agregar los días de la semana
                }
            }

            // Agregar las filas al DataTable
            foreach (DataGridViewRow fila in dgvAdmin.Rows)
            {
                DataRow dr = dt.NewRow();

                // Llenar las primeras columnas con datos del DataGridView
                foreach (DataGridViewCell celda in fila.Cells)
                {
                    dr[celda.ColumnIndex] = celda.Value?.ToString();
                }

                // Llenar las columnas de asistencia con valores predeterminados ("-" vacío)
                for (int i = dgvAdmin.Columns.Count; i < dt.Columns.Count; i++)
                {
                    dr[i] = "-";
                }

                dt.Rows.Add(dr);
            }

            // Crear un archivo Excel con ClosedXML
            using (var workbook = new XLWorkbook())
            {
                var hoja = workbook.Worksheets.Add("Asistencia");

                // Insertar los datos en la celda (fila 3 en adelante para evitar superposición con encabezados)
                hoja.Cell(3, 1).InsertTable(dt);

                // Fusionar celdas y agregar encabezados de semanas
                int columnaInicio = dgvAdmin.Columns.Count + 1;
                for (int semana = 1; semana <= semanas; semana++)
                {
                    int columnaFin = columnaInicio + columnasPorSemana - 1;
                    hoja.Range(1, columnaInicio, 1, columnaFin).Merge();
                    hoja.Cell(1, columnaInicio).Value = $"SEMANA {semana}";
                    hoja.Cell(1, columnaInicio).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hoja.Cell(1, columnaInicio).Style.Font.Bold = true;
                    hoja.Range(1, columnaInicio, 1, columnaFin).Style.Fill.BackgroundColor = XLColor.LightSkyBlue;

                    columnaInicio = columnaFin + 1;
                }

                // Formato para los días de la semana (negrita y color de fondo azul claro)
                for (int col = dgvAdmin.Columns.Count + 1; col <= dt.Columns.Count; col++)
                {
                    hoja.Cell(2, col).Style.Font.Bold = true;
                    hoja.Cell(2, col).Style.Fill.BackgroundColor = XLColor.LightBlue;
                }

                // Mostrar el diálogo para guardar el archivo
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivo Excel (.xlsx)|*.xlsx",
                    Title = "Guardar archivo Excel",
                    FileName = "Asistencia.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Asistencia exportada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
