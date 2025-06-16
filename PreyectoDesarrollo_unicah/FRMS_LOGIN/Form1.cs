using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.Win32;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices; 


namespace PreyectoDesarrollo_unicah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SeguridadRol();
        }

        public static string rol = "desconocido";

        private void SeguridadRol()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Unicah"))
                {
                    if (key != null)
                    {
                        object value = key.GetValue("Rol");
                        if (value != null)
                            rol = value.ToString().ToLower();
                    }
                }
            }
            catch { rol = "desconocido"; }
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
                txtusuario.UseSystemPasswordChar = true;
            }
        }

        private void txtusuario_Leave(object sender, EventArgs e)
        {
            if (txtusuario.Text == "")
            {
                txtusuario.Text = "Usuario:";
                txtusuario.UseSystemPasswordChar = false;
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
            string contraseña = txtcontraseña.Text.Trim();

            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            if (!Validaciones.Usuario(sender, e, usuario, contraseña, txtusuario))
                return;

            if (rol == "administrador")
                if (!ACCIONES_BD.CrearBDD())
                    return;

            if (!Validaciones.Contraseña(sender, e, usuario, contraseña, this, txtusuario, txtcontraseña, rol))
                return;

            ACCIONES_BD Login = new ACCIONES_BD();
            Login.Login(usuario, contraseña, this, rol);
        }

        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Datos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!CONEXION_BD.ConexionPerdida(this))
                    return;
                string usuario = txtusuario.Text;
                string contraseña = txtcontraseña.Text.Trim();
                if (!Validaciones.Usuario(sender, e, usuario, contraseña, txtusuario))
                    return;
                if (rol == "administrador")
                    if (!ACCIONES_BD.CrearBDD())
                        return;
                if (!Validaciones.Contraseña(sender, e, usuario, contraseña, this, txtusuario, txtcontraseña, rol))
                    return;
                ACCIONES_BD Login = new ACCIONES_BD();
                Login.Login(usuario, contraseña, this, rol);
            }
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            Datos_KeyPress(sender, e);
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            Datos_KeyPress(sender, e);
        }
    }
}
