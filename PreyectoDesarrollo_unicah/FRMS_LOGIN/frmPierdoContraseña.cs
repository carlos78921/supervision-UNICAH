using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
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
        }

        private string GenerarCodigo()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            StringBuilder resultado = new StringBuilder();
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                resultado.Append(caracteres[random.Next(caracteres.Length)]);
            }

            return resultado.ToString();
        }

        private void GenerarCorreo()
        {
            MailAddress From = new MailAddress("byrd_riverat42@unicah.edu", "BYRON DANIEL RIVERA TABORA"); //De mí
            MailAddress To = new MailAddress("byrd_riverat42@unicah.edu", "BYRON DANIEL RIVERA TABORA"); //Para mí
            MailMessage message = new MailMessage(From, To); //Correo de mí para mí
            message.Subject = "Recuperación de contraseña"; //Asunto
            message.Body = "Código de acceso: " + GenerarCodigo(); //Mensaje
        }
        private void Frmolvidecontra_Load(object sender, EventArgs e)
        {
            GenerarCorreo();            
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
    }
}
