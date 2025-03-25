using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmCambioContraseña : Form
    {
        public frmCambioContraseña()
        {
            InitializeComponent();
        }

        private void Frmolvidecontra_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Ya recuerda la contraseña?", "Recuerdo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 Login = new Form1();
                this.Close();
                Login.Show();
            }
        }

        private void btnContraseña_Click(object sender, EventArgs e)
        {
            ACCIONES_BD.AdminContra(txtcontraseña.Text);
            MessageBox.Show("Contraseña agregada, abriendo sesión de administrador, bienvenido", "Inicio de sesión Admin.", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            frmAdmin Menu = new frmAdmin();
            this.Close();
            Menu.Show();
        }
    }
}
