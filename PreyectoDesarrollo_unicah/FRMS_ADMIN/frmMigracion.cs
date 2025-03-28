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
        private void LimiteMeses()
        {
            int año = DateTime.Now.Year;

            // Definir el rango (20 enero - 18 abril del año actual), académicamente
            mesAdmin.MinDate = new DateTime(año, 1, 20);
            mesAdmin.MaxDate = new DateTime(año, 4, 12);
        }

        private void frmMigración_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;

            //Ajuste del formulario
            LimiteMeses();

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

        private DataTable TransferirDatosExcel()
        {
            // 1. Crear el DataTable
            DataTable dt = new DataTable();

            // 1A. Agregar las columnas del dgvAdmin
            foreach (DataGridViewColumn columna in dgvAdmin.Columns)
            {
                dt.Columns.Add(columna.HeaderText);
            }

            // 1B. Agregar columnas para 4 semanas x 6 días (Lunes a Sábado)
            string[] diasSemana = { "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado" };
            int semanas = 4; // Número de semanas
            for (int semana = 1; semana <= semanas; semana++)
            {
                foreach (string dia in diasSemana)
                {
                    dt.Columns.Add($"Semana {semana} - {dia}");
                }
            }

            // 2. Recorrer cada fila del dgvAdmin para construir la fila en dt
            foreach (DataGridViewRow fila in dgvAdmin.Rows)
            {
                if (!fila.IsNewRow)
                {
                    DataRow dr = dt.NewRow();

                    // 2A. Copiar las 5 columnas del dgv (Referencia, Curso, Sección, Aula, Empleado)
                    for (int i = 0; i < dgvAdmin.Columns.Count; i++)
                    {
                        dr[i] = fila.Cells[i].Value?.ToString();
                    }

                    // 2B. Obtener datos para filtrar asistencia en la BD
                    string refiero = fila.Cells[0].Value?.ToString(); // Referencia
                    string curso = fila.Cells[1].Value?.ToString(); // Curso
                    string seccion = fila.Cells[2].Value?.ToString(); // Sección
                    string aula = fila.Cells[3].Value?.ToString(); // Aula
                    string empleado = fila.Cells[4].Value?.ToString(); // Empleado

                    // 2C. Obtener las fechas de asistencia para este registro
                    //     Usarás el mismo PA_Asistencia_Admin (o uno similar) que llenas el MonthCalendar
                    List<DateTime> fechasAsistencia = ACCIONES_BD.CargarAsistenciaAdminExcel(refiero, curso, seccion, aula, empleado);

                    // 2D. Llenar las columnas de asistencia (Semana X - Día) con "P" si la fecha coincide
                    //     Necesitas definir cómo calcular la semana y el día de la fecha
                    foreach (DateTime fecha in fechasAsistencia)
                    {
                        // Calcular semana y día según tu rango
                        // Por ejemplo, asumes un "Inicio de rango" para la semana 1
                        DateTime fechaInicio = new DateTime(DateTime.Now.Year, 1, 20); // Ejemplo: 20 de enero
                                                                                       // Podrías usar mesAdmin.MinDate si quieres usar el rango del MonthCalendar

                        // Distancia en días entre fechaInicio y la fecha de asistencia
                        int diasOffset = (fecha - fechaInicio).Days;
                        if (diasOffset < 0 || diasOffset >= 4 * 7)
                        {
                            // Si la fecha está fuera de las 4 semanas definidas, la ignoras
                            continue;
                        }

                        // Calcular la semana (0 a 3) y el día de la semana (0 a 6)
                        int numeroSemana = diasOffset / 7;   // 0 = semana 1, 1 = semana 2, ...
                        int diaEnSemana = diasOffset % 7;    // 0 = lunes, 1 = martes, ...

                        // Ojo: DateTime en C# define Monday = 1, Tuesday = 2, etc.
                        // Si tu offset asume que 0 = lunes, 1 = martes, etc., ajusta la lógica.

                        // Asumiendo que "lunes" es el día 0 y "sábado" es el día 5,
                        // debes asegurar que no te pases de 5 (sábado).
                        if (diaEnSemana >= 6)
                            continue; // Si es domingo, por ejemplo, no lo registras

                        // Buscar la columna correspondiente
                        // Las primeras 5 columnas son Referencia, Curso, Sección, Aula, Empleado
                        // A partir de la columna 6 se encuentran las 4 semanas x 6 días
                        int baseColumnIndex = dgvAdmin.Columns.Count; // 5
                                                                      // El offset de semana en columnas
                        int semanaColumnOffset = numeroSemana * 6;  // 6 días por semana
                        int columnIndex = baseColumnIndex + semanaColumnOffset + diaEnSemana;

                        // Asignar "P" (presente) en esa columna
                        dr[columnIndex] = "P";
                    }

                    // 2E. Para las columnas que no fueron asignadas, poner "-" 
                    //     (Aunque ya lo hiciste con dr[columnIndex] = "P", 
                    //      podrías inicializarlas antes en "-")
                    for (int c = dgvAdmin.Columns.Count; c < dt.Columns.Count; c++)
                    {
                        if (string.IsNullOrEmpty(dr[c].ToString()))
                        {
                            dr[c] = "-";
                        }
                    }

                    // 2F. Agregar la fila al DataTable
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        private void btnExcel_Click(object sender, EventArgs e) //Exportar datos del dgv y asistencia al excel, aunque solo están los valores del dgv puestos
        {
            DataTable dt = TransferirDatosExcel();

            // Crear el archivo Excel con ClosedXML
            using (var workbook = new XLWorkbook())
            {
                var hoja = workbook.Worksheets.Add("Asistencia");

                // Insertar los datos en la celda (fila 3 en adelante)
                hoja.Cell(3, 1).InsertTable(dt);

                // Fusionar celdas y agregar encabezados de semanas
                int columnasBase = dgvAdmin.Columns.Count; // 5
                int semanas = 4;
                int diasPorSemana = 6;
                int columnaInicio = columnasBase + 1;

                for (int semana = 1; semana <= semanas; semana++)
                {
                    int columnaFin = columnaInicio + diasPorSemana - 1;
                    hoja.Range(1, columnaInicio, 1, columnaFin).Merge();
                    hoja.Cell(1, columnaInicio).Value = $"SEMANA {semana}";
                    hoja.Cell(1, columnaInicio).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    hoja.Cell(1, columnaInicio).Style.Font.Bold = true;
                    hoja.Range(1, columnaInicio, 1, columnaFin).Style.Fill.BackgroundColor = XLColor.LightSkyBlue;

                    columnaInicio = columnaFin + 1;
                }

                // Formato para los días de la semana (fila 2)
                for (int col = columnasBase + 1; col <= dt.Columns.Count; col++)
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

        private void mesAdmin_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start;

            // Definir la fecha de inicio del primer parcial
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, 1, 20); // 20 de enero

            // Calcular la diferencia en días
            int offsetDias = (fechaSeleccionada - fechaInicio).Days; // Puede ser negativo si está antes del 20/ene

            // Cada semana son 7 días
            // Tenemos 12 semanas en total (3 parciales * 4 semanas)
            // Rango total: 0 <= offsetDias < 12 * 7 = 84

            if (offsetDias < 0 || offsetDias >= 12 * 7)
            {
                // Fuera de rango (antes del 20/ene o después de 12 semanas)
                lblParcial.Text = "Fuera de rango";
                lblWeek.Text = "";
                return;
            }

            // Calcular el índice de la semana (0 a 11)
            int indiceSemana = offsetDias / 7; // entero

            // Calcular el índice de parcial (0 a 2)
            // 4 semanas por parcial => parcial = floor(indiceSemana / 4)
            int indiceParcial = indiceSemana / 4; // 0 = parcial 1, 1 = parcial 2, 2 = parcial 3

            // Convertir a 1-based
            int parcial = indiceParcial + 1;     // 1..3
            int semanaEnParcial = (indiceSemana % 4) + 1; // 1..4

            // Mostrar en labels
            lblParcial.Text = $"Parcial {parcial}";
            lblWeek.Text = $"Semana {semanaEnParcial}";

        }
    }
}
