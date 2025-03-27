using DocumentFormat.OpenXml.Bibliography;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Runtime.InteropServices; //Relacionado con Dll (Librería)


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

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;

            if (!Validaciones.DatoVacio(usuario, contraseña, txtusuario))
                // La validación falló, se detiene el proceso de login
                return;


            if (!Validaciones.SoloNumero(usuario))
            {
                MessageBox.Show("El usuario corresponde a números", "Error Letras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusuario.Focus();
                return;
            }

            if (!ACCIONES_BD.AdminContraVacio(usuario, contraseña, this))
                return;
            
            if (!Validaciones.CasoContraseña(contraseña, txtcontraseña))
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
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0); 
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e) //Cuando aprieta tecla en texto vacío, en el caso sería "Enter"
        {
            string usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;
            if (!Validaciones.ValidarUsuario(e, usuario, contraseña))
                return;
            if (e.KeyChar == (char)Keys.Enter)
                ACCIONES_BD.Login(usuario, contraseña, this);
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            string usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;
            if (!Validaciones.ValidarContraseña(e, usuario, contraseña))
                return;
            if (e.KeyChar == (char)Keys.Enter)
                ACCIONES_BD.Login(usuario, contraseña, this);
        }
    }
}
