using PreyectoDesarrollo_unicah.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmPierdoContraseña : Form
    {
        public frmPierdoContraseña()
        {
            InitializeComponent();
            // Genera el código constante por asignación
            codigo = GenerarCodigo();
            // Envía el correo usando el codigo constante
            GenerarCorreo(codigo);
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private string codigo;
        private string GenerarCodigo()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder resultado = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                resultado.Append(caracteres[random.Next(caracteres.Length)]); //Append: no devuelve instancia, sino como llamada de string en resultado tipo StringBuilder
            }

            return resultado.ToString();
        }

        private bool GenerarCorreo(string codigo)
        {
            MailAddress From = new MailAddress("byrd_riverat42@unicah.edu", "BYRON DANIEL RIVERA TABORA"); //De mí
            MailAddress To = new MailAddress("byrd_riverat42@unicah.edu", "BYRON DANIEL RIVERA TABORA"); //Para mí
            MailMessage msg = new MailMessage(From, To); //Correo de mí para mí
            msg.Subject = "Recuperación de contraseña"; //Asunto
            msg.Body = "Código de acceso: " + codigo + ". Por seguridad, borrar el correo después de ingreso"; //Mensaje
            msg.IsBodyHtml = false;

            SmtpClient client = new SmtpClient("mail.smtp2go.com", 2525);
            client.Credentials = new NetworkCredential("unicah.edu", "Password1");
            client.EnableSsl = true; //Habilitar encriptación de conexión
            client.Send(msg);

            return true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void btnRecibir_Click(object sender, EventArgs e)
        {
            lblCode.Text = "Su código ha sido generado de nuevo";
            //Esto cambia el código
            codigo = GenerarCodigo();
            // Envía el correo usando el codigo constante
            GenerarCorreo(codigo);
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (!Validaciones.CodeVale()
            {
                MessageBox.Show("Código inválido");
            }
            else
            {
                this.Close();
                frmCambioContraseña Cambio = new frmCambioContraseña();
                Cambio.Show();
            }
        }

        private void frmPierdoContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!Validaciones.CodeVale())
                    return;

                this.Close();
                frmCambioContraseña Cambio = new frmCambioContraseña();
                Cambio.Show();
            }
        }
    }
}
