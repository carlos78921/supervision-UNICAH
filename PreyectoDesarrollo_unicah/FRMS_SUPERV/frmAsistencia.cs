using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmAsistencia : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture(); //Externo por la importación realizada en comando

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public frmAsistencia()
        {
            InitializeComponent();
            this.MouseDown += frmSupervisor_MouseDown;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSupervisor Menu = new frmSupervisor();
            Menu.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Procesos en carga del formulario
        private void FiltroInicial()
        {
            cmbEdificio.SelectedIndex = 0;
            cmbAula.SelectedIndex = 0;
            cmbHora.SelectedIndex = 0;
        }

        private void LimiteMes()
        {
            int año = DateTime.Now.Year;

            mesSupervisor.MinDate = new DateTime(año, 1, 20);
            mesSupervisor.MaxDate = new DateTime(año, 4, 12);
        }

        private void FrmAsiste_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;

            dgvAsiste = (dgvAsiste as DataGridView);

            LimiteMes();
            FiltroInicial();

            ACCIONES_BD.tablaSupervisor(dgvAsiste);
            ACCIONES_BD.CargarAsistenciaSuperv(mesSupervisor, (string)dgvAsiste.CurrentRow.Cells[0].Value, (string)dgvAsiste.CurrentRow.Cells[1].Value, (string)dgvAsiste.CurrentRow.Cells[2].Value, (string)dgvAsiste.CurrentRow.Cells[3].Value, (string)dgvAsiste.CurrentRow.Cells[4].Value);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmSupervisor Menu = new frmSupervisor();
            Menu.Show();
        }

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void mesSupervisor_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start.Date;

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

            // Verificar si la fecha seleccionada es domingo
            if (mesSupervisor.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
            {
                MessageBox.Show("Los domingos no están disponibles para selección.",
                              "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Marcar asistencia para esta fecha?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ACCIONES_BD.RegistrarAsistencia(dgvAsiste, (string)dgvAsiste.CurrentRow.Cells[0].Value, (string)dgvAsiste.CurrentRow.Cells[1].Value, (string)dgvAsiste.CurrentRow.Cells[2].Value, (string)dgvAsiste.CurrentRow.Cells[3].Value, (string)dgvAsiste.CurrentRow.Cells[4].Value, fechaSeleccionada.Date, true);
                mesSupervisor.AddBoldedDate(fechaSeleccionada);
                mesSupervisor.UpdateBoldedDates();
            }
            else
            {
                ACCIONES_BD.RegistrarAsistencia(dgvAsiste, (string)dgvAsiste.CurrentRow.Cells[0].Value, (string)dgvAsiste.CurrentRow.Cells[1].Value, (string)dgvAsiste.CurrentRow.Cells[2].Value, (string)dgvAsiste.CurrentRow.Cells[3].Value, (string)dgvAsiste.CurrentRow.Cells[4].Value, fechaSeleccionada.Date, false);
                mesSupervisor.RemoveBoldedDate(fechaSeleccionada);
                mesSupervisor.UpdateBoldedDates();
            }
        }

        private void dgvAsiste_SelectionChanged(object sender, EventArgs e) //Método seguro para almacenar asistencias
        {
            if (dgvAsiste.CurrentRow != null)
            {
                //Object almacena el dato de su tipo
                object docenteValue = dgvAsiste.CurrentRow.Cells[0].Value; //Object porque un error indica el string considera como uso de objeto instancia al tomar la fila con ".valor.ToString()"
                string Docente = docenteValue != null ? docenteValue.ToString() : "";  //Esto es verificación de una cadena que devuelve nulo por no asignarse o considerarse objeto

                //"?" es if de Value != null, ":" es else
                object claseValue = dgvAsiste.CurrentRow.Cells[1].Value;
                string clase = claseValue != null ? claseValue.ToString() : "";

                object seccionValue = dgvAsiste.CurrentRow.Cells[2].Value;
                string seccion = seccionValue != null ? seccionValue.ToString() : "";

                object aulaValue = dgvAsiste.CurrentRow.Cells[3].Value;
                string aula = aulaValue != null ? aulaValue.ToString() : "";

                object edificioValue = dgvAsiste.CurrentRow.Cells[4].Value;
                string edificio = edificioValue != null ? edificioValue.ToString() : "";

                // Limpiar las fechas resaltadas previas en el MonthCalendar.
                mesSupervisor.RemoveAllBoldedDates();

                // Llama al método para cargar las fechas marcadas para ese registro.
                ACCIONES_BD.CargarAsistenciaSuperv(mesSupervisor, Docente, clase, seccion, aula, edificio);
            }
        }

        private void txtDoc_KeyUp(object sender, KeyEventArgs e)
        {
            ACCIONES_BD.FiltrarDatosSuperv(txtDoc.Text, txtClase.Text, cmbHora.Text, cmbAula.Text, cmbEdificio.Text, dgvAsiste);
        }

        private void txtClase_KeyUp(object sender, KeyEventArgs e)
        {
            ACCIONES_BD.FiltrarDatosSuperv(txtDoc.Text, txtClase.Text, cmbHora.Text, cmbAula.Text, cmbEdificio.Text, dgvAsiste);
        }

        private void cmbEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ACCIONES_BD.FiltrarDatosSuperv(txtDoc.Text, txtClase.Text, cmbHora.Text, cmbAula.Text, cmbEdificio.Text, dgvAsiste);
        }

        private void cmbAula_SelectedIndexChanged(object sender, EventArgs e) 
        {
            ACCIONES_BD.FiltrarDatosSuperv(txtDoc.Text, txtClase.Text, cmbHora.Text, cmbAula.Text, cmbEdificio.Text, dgvAsiste);
        }

        private void cmbHora_SelectedIndexChanged(object sender, EventArgs e)
        {
            ACCIONES_BD.FiltrarDatosSuperv(txtDoc.Text, txtClase.Text,  cmbHora.Text, cmbAula.Text, cmbEdificio.Text, dgvAsiste);
        }
    }
}
