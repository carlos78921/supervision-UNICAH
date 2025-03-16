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

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e) //Evento del ratón "e"
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); //El evento en memoria se mantiene
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
        }

        private void btnMarca_Click(object sender, EventArgs e)
        {
            /*this.Close();
            frmAsistencia asisto = new frmAsistencia();
            asisto.Show();*/
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

    }
}