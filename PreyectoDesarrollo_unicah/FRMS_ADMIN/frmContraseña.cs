using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmContraseña : Form
    {
        public frmContraseña()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnSale_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
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
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
        }

        private void btnContra_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();
            if (contraseña == "Contraseña nueva:")
                contraseña = "Contraseña:";

            if (string.IsNullOrEmpty(usuario) || usuario == "Usuario:") //Vacío con o sin un dato
            {
                MessageBox.Show("Por favor ingrese el usuario", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(CONEXION_BD.conectar.ConnectionString))
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand("PA_Contra", conexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contraseña", contraseña);

                        //"@" = Parámetro, "RetVal" = ReturnValue, SqlDbType.Int = Tipo de dato del retorno
                        SqlParameter @retorno = cmd.Parameters.Add("RetVal", SqlDbType.Int);
                        @retorno.Direction = ParameterDirection.ReturnValue; //Obtener el parámetro de retorno

                        cmd.ExecuteNonQuery();

                        int resultado = (int)@retorno.Value;
                        if (resultado == 0)
                        {
                            MessageBox.Show("Usuario no encontrado");
                        }
                        else
                        {
                            MessageBox.Show("Contraseña cambiada con éxito");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario:")
            {
                txtUsuario.Text = "";
            }

        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario:";
            }
        }

        private void txtContraseña_Enter(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña nueva:")
            {
                txtContraseña.Text = "";
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña nueva:";
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void frmContraseña_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
