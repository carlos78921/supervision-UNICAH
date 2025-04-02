using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices; 


namespace PreyectoDesarrollo_unicah
{
    public partial class Form1 : Form
    {
        public Form1() 
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtusuario_Enter(object sender, EventArgs e)
        {
            if (txtusuario.Text == "Usuario:")
            {
                txtusuario.Text = "";
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "Usuario:";
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "Contraseña:")
            {
                txtcontraseña.Text = "";
                txtcontraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "")
            {
                txtcontraseña.Text = "Contraseña:";
                txtcontraseña.UseSystemPasswordChar = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;

            if (!Validaciones.LoginVale(sender, e, txtusuario, txtcontraseña, usuario, contraseña, this))
                return;

            ACCIONES_BD.Login(usuario, contraseña, this);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); 
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); 
        }

        private void Datos_KeyPress(object sender, KeyPressEventArgs e)
        {
            string usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita el sonido de error por defecto
                if (!Validaciones.LoginVale(sender, e, txtusuario, txtcontraseña, usuario, contraseña, this))
                    return;
                if (!ACCIONES_BD.AdminContraVacio(usuario, contraseña, this))
                    return;
                ACCIONES_BD.Login(usuario, contraseña, this);
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
        }
    }
}
