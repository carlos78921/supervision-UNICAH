using ClosedXML.Excel;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
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

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        //Proceso en carga de formulario
        private void LimiteMeses()
        {
            int a�o = DateTime.Now.Year;

            // Definir el rango (20 enero - 18 abril del a�o actual), acad�micamente
            mesAdmin.MinDate = new DateTime(a�o, 1, 20);
            mesAdmin.MaxDate = new DateTime(a�o, 4, 12);
        }

        private void frmMigraci�n_Load(object sender, EventArgs e)
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

                // Llama al m�todo para cargar las fechas marcadas para ese registro.
                ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, refiero, curso, seccion, aula, empleo);
            }

        }

        private DataTable TransferirDatosExcel()
        {
            // 1. Crear el DataTable
            DataTable dt = new DataTable();

            // 1A. Agregar las columnas del dgvAdmin al dt
            foreach (DataGridViewColumn columna in dgvAdmin.Columns)
            {
                dt.Columns.Add(columna.HeaderText);
            }

            // 1B. Estructurar columnas para 3 parciales x 4 semanas x 6 d�as (Lunes a S�bado)
            for (int parcial = 1; parcial <= 3; parcial++)
            {
                for (int semana = 1; semana <= 4; semana++) 
                {
                    string[] diasSemana = { "Lunes", "Martes", "Mi�rcoles", "Jueves", "Viernes", "S�bado" };
                    foreach (string dia in diasSemana)
                    {
                        dt.Columns.Add($"Parcial {parcial} - Semana {semana} - {dia}");
                    }
                }
            }


            // 2. Recorrer cada fila del dgvAdmin para construir la fila en dt
            foreach (DataGridViewRow fila in dgvAdmin.Rows)
            {
                if (!fila.IsNewRow) // Ignorar la fila vac�a al final del dgvAdmin
                {
                    DataRow dr = dt.NewRow(); // Crear una nueva fila de las no vac�as

                    // 2A. Copiar las 5 columnas del dgv (Referencia, Curso, Secci�n, Aula, Empleado)
                    for (int i = 0; i < dgvAdmin.Columns.Count; i++)
                    {
                        dr[i] = fila.Cells[i].Value?.ToString();
                    }

                    // 2B. Obtener datos para filtrar asistencia en la BD
                    string refiero = fila.Cells[0].Value?.ToString(); 
                    string curso = fila.Cells[1].Value?.ToString(); 
                    string seccion = fila.Cells[2].Value?.ToString(); 
                    string aula = fila.Cells[3].Value?.ToString(); 
                    string empleado = fila.Cells[4].Value?.ToString();

                    // 2C. Usar el mismo PA_Asistencia_Admin (o uno similar) que lleno del MonthCalendar para obtener los datos
                    List<DateTime> fechasAsistencia = ACCIONES_BD.CargarAsistenciaAdminExcel(refiero, curso, seccion, aula, empleado);

                    /* 2D. Llenar las columnas de asistencia (Semana X - D�a) con "P" si la fecha coincide en la semana
                           al operar valores seg�n la estructura, realizaremos c�lculo de semanas y d�a de la fecha*/
                    foreach (DateTime fecha in fechasAsistencia)
                    {
                        // Le hacemos saber al foreach d�nde detectar� valor de estructura como en el calendario
                        DateTime fechaInicio = mesAdmin.MinDate;                                                                                        

                        // Distancia en d�as entre fechaInicio y la fecha de asistencia
                        int diasOffset = (fecha - fechaInicio).Days;
                        if (diasOffset < 0 || diasOffset >= 12 * 7) 
                            continue;   

                        // Calcular la semana (0 a 3 o 1 a 4) y el d�a de la semana (0 a 6 o 1 a 7), estos por �ndice
                        int numeroSemana = diasOffset / 7;   // 0 o aproximado a 1 = semana 1, 1 o aproximado a 2 = semana 2, ...
                        int diaEnSemana = diasOffset % 7;    // "%" es s�mbolo de m�dulo, es decir que obtiene resultado del residuo, tradicionalmente dividiendo: 0/7 = 0 (Residuo) = lunes, 1/7 = 1 (Residuo) = martes, ...
                        
                        // Asumiendo que "lunes" es el d�a 0 y "s�bado" es el d�a 5,
                        if (diaEnSemana >= 6)
                            continue; // Si es domingo, no se registra

                        /*Buscar el valor de columna correspondiente
                          Las primeras 5 columnas de 0 a 4 son Referencia, Curso, Secci�n, Aula, Empleado
                          A partir de la columna 6 se inicia y encuentran las 4 semanas x 6 d�as*/
                        int baseColumnIndex = dgvAdmin.Columns.Count; // 5
                                                                      // El offset de semana en columnas
                        int semanaColumnOffset = numeroSemana * 6;  // 6 d�as por semana
                        int columnIndex = baseColumnIndex + semanaColumnOffset + diaEnSemana; //Esto es l�gica en n�meros grandes para coincidencia de valores en diasOffset, sin fijarse mucho en "columnas"

                        // Asignar "P" (presente) en esa columna
                        dr[columnIndex] = "P";
                    }

                    /* 2E. Para las columnas que no fueron asignadas, poner "-" 
                           (Aunque ya lo hiciste con dr[columnIndex] = "P", 
                            podr�as inicializarlas antes en "-")*/
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
            MessageBox.Show("Total columnas: " + dt.Columns.Count);
            //            MessageBox.Show("La columna de asistencia est� en el �ndice: " + dt.Columns.IndexOf("Semana 2 - Lunes"));
            return dt;
        }

        private void btnExcel_Click(object sender, EventArgs e) //Exportar datos del dgv y asistencia al excel, aunque solo est�n los valores del dgv puestos
        {
            DataTable dt = TransferirDatosExcel();

            int baseColumns = 5; //Columnas del dgv
            int columnasPorParcial = 4 * 6; //Cuatro semanas por seis d�as (lunes a s�bado)

            using (var workbook = new XLWorkbook())
            {
                // Iterar por cada parcial (0 a 2)
                for (int parcial = 0; parcial < 3; parcial++)
                {
                    // Clonar la estructura del dtCompleto
                    DataTable dtParcial = dt.Clone();

                    // Eliminar las columnas de asistencia que no correspondan a este parcial.
                    // Primero, eliminamos todas las columnas de asistencia del clon.
                    for (int i = dtParcial.Columns.Count - 1; i >= baseColumns; i--)
                    {
                        dtParcial.Columns.RemoveAt(i);
                    }

                    // Agregar solo las columnas de asistencia de este parcial.
                    for (int i = 0; i < columnasPorParcial; i++)
                    {
                        // El �ndice real en dtCompleto para la columna de asistencia:
                        int indiceReal = baseColumns + (parcial * columnasPorParcial) + i;
                        // Agregar la columna al dtParcial con el mismo nombre.
                        dtParcial.Columns.Add(dt.Columns[indiceReal].ColumnName, typeof(string));
                    }

                    // Ahora, copiar las filas filtrando las columnas de asistencia correspondientes.
                    foreach (DataRow row in dt.Rows)
                    {
                        DataRow newRow = dtParcial.NewRow();

                        // Copiar las columnas base (por ejemplo, 0 a baseColumns-1).
                        for (int i = 0; i < baseColumns; i++)
                        {
                            newRow[i] = row[i];
                        }
                        // Copiar las columnas de asistencia para este parcial.
                        for (int i = 0; i < columnasPorParcial; i++)
                        {
                            int indiceReal = baseColumns + (parcial * columnasPorParcial) + i;
                            newRow[baseColumns + i] = row[indiceReal];
                        }
                        dtParcial.Rows.Add(newRow);
                    }

                    // Agregar una nueva hoja al libro para este parcial.
                    var ws = workbook.Worksheets.Add($"Parcial {parcial + 1}");
                    ws.Cell(1, 1).InsertTable(dtParcial);

                    // Opcional: aplicar formato, ajustar anchos, encabezados, etc.
                }

                // Guardar el archivo Excel.
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "Archivo Excel (.xlsx)|*.xlsx",
                    Title = "Guardar archivo Excel",
                    FileName = "Asistencia_Por_Parciales.xlsx"
                };

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    workbook.SaveAs(saveFileDialog.FileName);
                    MessageBox.Show("Exportaci�n realizada correctamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void mesAdmin_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start;

            // Definir la fecha de inicio del primer parcial
            DateTime fechaInicio = new DateTime(DateTime.Now.Year, 1, 20); // 20 de enero

            // Calcular la diferencia en d�as
            int offsetDias = (fechaSeleccionada - fechaInicio).Days; // Puede ser negativo si est� antes del 20/ene

            // Calcular el �ndice de la semana (0 a 11)
            int indiceSemana = offsetDias / 7; // entero

            // Calcular el �ndice de parcial (0 a 2)
            // 4 semanas por parcial => parcial = floor(indiceSemana / 4)
            int indiceParcial = indiceSemana / 4; // 0 = parcial 1, 1 = parcial 2, 2 = parcial 3

            // Convertir a 1-based
            int parcial = indiceParcial + 1;     // 1..3
            int semanaEnParcial = (indiceSemana % 4) + 1; // 1..4

            // Mostrar en labels
            lblParcial.Text = $"Parcial {parcial}";
            lblWeek.Text = $"Semana {semanaEnParcial}";

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmMigracion_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
