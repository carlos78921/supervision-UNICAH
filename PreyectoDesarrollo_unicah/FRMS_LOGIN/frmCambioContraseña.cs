using DocumentFormat.OpenXml.Spreadsheet;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
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
    public partial class frmCambioContraseña : Form
    {
        public frmCambioContraseña()
        {
            InitializeComponent();
        }


        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Ya recuerda la contraseña?", "Recuerdo la Contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Form1 Login = new Form1();
                this.Close();
                Login.Show();
            }
        }

        private void btnContraseña_Click(object sender, EventArgs e)
        {
            TextBox txtadmin = new TextBox();
            string admin = "", contraseña = txtcontraseña.Text.Trim();
            if (!Validaciones.Contraseña(sender, e, admin, contraseña, this, txtadmin, txtcontraseña))
                return;
            ACCIONES_BD.AdminContra(txtcontraseña.Text, this);
        }

        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void txtcontraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                e.Handled = true;
            TextBox txtadmin = new TextBox();
            string admin = "", contraseña = txtcontraseña.Text.Trim();

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!Validaciones.Contraseña(sender, e, admin, contraseña, this, txtadmin, txtcontraseña))
                    return;
                e.Handled = true; // Evita el sonido de error por defecto en símbolo de retorno
                ACCIONES_BD.AdminContra(txtcontraseña.Text, this);
            }
        }

        private void txtcontraseña_Enter(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "Contraseña nueva:")
            {
                txtcontraseña.Text = "";
                txtcontraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtcontraseña_Leave(object sender, EventArgs e)
        {
            if (txtcontraseña.Text == "")
            {
                txtcontraseña.Text = "Contraseña nueva:";
                txtcontraseña.UseSystemPasswordChar = false;
            }
        }
    }
}
