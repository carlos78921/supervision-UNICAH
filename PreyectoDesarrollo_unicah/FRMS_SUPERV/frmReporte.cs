using PreyectoDesarrollo_unicah.CLASES;
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
    public partial class frmReporte : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture(); //Externo por la importación realizada en comando

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void CargarNombreUsuario()
        {
            ACCIONES_BD accionesBD = new ACCIONES_BD();
            string nombreCompleto = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}".Trim();
            lblPersona.Text = string.IsNullOrEmpty(nombreCompleto) ? "Nombre no disponible" : nombreCompleto;
            this.Text = string.IsNullOrEmpty(nombreCompleto) ? "Supervisor" : $"Supervisor - {nombreCompleto}";
        }

        public frmReporte()
        {
            InitializeComponent();
            this.MouseDown += frmSupervisor_MouseDown;
            CargarNombreUsuario();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            cmbEdificio.SelectedIndex = 0;
            cmbAula.SelectedIndex = 0;
            cmbHora.SelectedIndex = 0;
            ACCIONES_BD.tablaSupervisor(dgvAsiste);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e) //Evento del ratón "e"
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); //El evento en memoria se mantiene
            }
        }

        private void dgvAsiste_CellContentClick(object sender, DataGridViewCellEventArgs e) 
        //El "e" proviene de celdas afectadas como los checkbox
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string dia = dgvAsiste.Columns[e.ColumnIndex].Name; // Día modificado
                bool asistencia = Convert.ToBoolean(dgvAsiste.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                string codAsignatura = dgvAsiste.Rows[e.RowIndex].Cells[0].Value.ToString();
                string codEmpleado = dgvAsiste.Rows[e.RowIndex].Cells[1].Value.ToString();
                string idSitio = dgvAsiste.Rows[e.RowIndex].Cells[2].Value.ToString();

                if (asistencia)
                    ACCIONES_BD.presenteSup(codAsignatura, idSitio, codEmpleado, dia);
                else
                    ACCIONES_BD.RegistrarFalta(codAsignatura, idSitio, codEmpleado, dia);
            }
        }
    }
}
