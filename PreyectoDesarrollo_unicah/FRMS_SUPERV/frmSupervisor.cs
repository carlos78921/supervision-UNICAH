using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
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

namespace PreyectoDesarrollo_unicah.FRMS_SUPERV
{
    public partial class frmSupervisor : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture(); //Externo por la importación realizada en comando

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public frmSupervisor()
        {
            InitializeComponent();
            this.MouseDown += frmSupervisor_MouseDown;
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
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

<<<<<<< HEAD
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnReporte_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAsistencia asisto = new frmAsistencia();
            asisto.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
            frmOrden orden = new frmOrden();
            orden.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void frmSupervisor_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
=======
        private void lblPersona_Click(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
        }
>>>>>>> 2ef61400c506789df19a139b0eb97ecd68bdb72b
    }
}