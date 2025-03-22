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
            Application.Exit();
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

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;

            //Ajustes del formulario
            FiltroInicial();

            //Ajustes del bdd
            ACCIONES_BD.tablaSupervisor(dgvAsiste);
            ACCIONES_BD.CargarAsistencia(mesSupervisor);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e) //Evento del ratón "e"
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); //El evento en memoria se mantiene
            }
        }

        //ME FALTA AJUSTAR ÉSTE
        private void dgvAsiste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //El "e" proviene de celdas afectadas como los checkbox
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvAsiste.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    // Finaliza la edición para que el cambio se registre inmediatamente
                    dgvAsiste.EndEdit();

                    string dia = dgvAsiste.Columns[e.ColumnIndex].Name; // Día modificado

                    string Docente = dgvAsiste.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string Asignatura = dgvAsiste.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string Sitio = dgvAsiste.Rows[e.RowIndex].Cells[2].Value.ToString();


                    // Aquí puedes llamar a la función que maneja el cambio (por ejemplo, llamar a PA_Marcar_Asistencia o PA_Registrar_Falta)
                    bool asistencia = Convert.ToBoolean(dgvAsiste.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    if (asistencia)
                        ACCIONES_BD.presenteSup(Docente, Asignatura, Sitio, dia);
                    else
                        ACCIONES_BD.RegistrarFalta(Docente, Asignatura, Sitio, dia);
                }
            }
        }

        private void mesSupervisor_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start.Date;

        
            if (MessageBox.Show("¿Marcar asistencia para esta fecha?", "Confirmar",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            { 
                ACCIONES_BD.RegistrarAsistencia(dgvAsiste, (string)dgvAsiste.CurrentRow.Cells[0].Value, (string)dgvAsiste.CurrentRow.Cells[1].Value, (string)dgvAsiste.CurrentRow.Cells[2].Value, (string)dgvAsiste.CurrentRow.Cells[3].Value, (string)dgvAsiste.CurrentRow.Cells[4].Value, fechaSeleccionada.Date, true);
                mesSupervisor.AddBoldedDate(fechaSeleccionada);
                mesSupervisor.UpdateBoldedDates();
            }
            else
            {
                ACCIONES_BD.RegistrarAsistencia(dgvAsiste, (string)dgvAsiste.CurrentRow.Cells[0].Value, (string)dgvAsiste.CurrentRow.Cells[1].Value, (string)dgvAsiste.CurrentRow.Cells[2].Value, (string)dgvAsiste.CurrentRow.Cells[3].Value, (string)dgvAsiste.CurrentRow.Cells[4].Value, fechaSeleccionada.Date,false);
                mesSupervisor.RemoveBoldedDate(fechaSeleccionada);
                mesSupervisor.UpdateBoldedDates();
            }  
        }

        private void dgvAsiste_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
