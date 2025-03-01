using System.Data.SqlClient;
using System.Runtime.InteropServices;


namespace PreyectoDesarrollo_unicah
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        frmOlvideDatos contra = new frmOlvideDatos();

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
            //se añade un tipo de marca de agua a los txtbox
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


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usuario = txtusuario.Text.Trim();
            string contraseña = txtcontraseña.Text.Trim();


            if (usuario == "Usuario:" || contraseña == "Contraseña:")
            {
                MessageBox.Show("Por favor ingrese todos los datos", "advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Realizar la conexión y consulta
            try
            {
                string cadenaConexion = "Data Source= (También en clase: Conexión_BD);Initial Catalog=Supervision_Unicah;Integrated Security=True;TrustServerCertificate=True;";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    string consulta = "SELECT ROL FROM docentes WHERE usuario = @usuario AND contraseña = @contrasena";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))

                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contraseña);

                        object rol = cmd.ExecuteScalar(); // Obtiene el rol del usuario

                        if (rol != null)
                        {
                            // Usuario encontrado, verifica el rol
                            string rolUsuario = rol.ToString();
                            MessageBox.Show($"Bienvenido, {usuario}. Tu rol es: {rolUsuario}", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            if (rolUsuario == "supervisor")
                            {
                                // Abrir las pantallas del supervisor
                                FrmReporte supervisor = new FrmReporte();
                                supervisor.Show();
                                this.Hide();
                            }
                            else if (rolUsuario == "decano")
                            {
                                // Abrir las pantallas del decano
                                frmJustificación decano = new frmJustificación();
                                decano.Show();
                                this.Hide();
                            }
                            else if (rolUsuario == "docente")
                            {
                                //abre las pantallas del docente
                                FrmDocente docente = new FrmDocente();
                                docente.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Rol no reconocido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Usuario o contraseña incorrectos
                            MessageBox.Show("Usuario o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al conectar con la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtusuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            contra.ShowDialog();
            this.Dispose(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
