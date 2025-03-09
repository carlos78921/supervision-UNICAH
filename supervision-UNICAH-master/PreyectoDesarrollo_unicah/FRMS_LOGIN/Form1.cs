using PreyectoDesarrollo_unicah.CLASES;
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

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña) ||
                usuario == "Usuario:" || contraseña == "Contraseña:") //Vacío con o sin un dato
            {
                MessageBox.Show("Por favor ingrese todos los datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Realizar la conexión y consulta
            try
            {
                string cadenaConexion = "DATA SOURCE= LAB7-9\\SQLEXPRESS2017; Initial Catalog=Supervision_Unicah; Integrated Security=True";
                using (SqlConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    // Consulta para obtener el rol, nombre y apellido
                    string consulta = "SELECT nombre_empleado, apellido_empleado, rol FROM Empleados WHERE usuario = @usuario AND contraseña = @contrasena";
                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contraseña);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read()) // Si coincide usuario y contraseña, y hay datos del select
                            {
                                string nombre = reader["nombre_empleado"].ToString();
                                string apellido = reader["apellido_empleado"].ToString();
                                string rolUsuario = reader["rol"].ToString();
                                ACCIONES_BD.nombre = nombre;
                                ACCIONES_BD.apellido = apellido;
                                MessageBox.Show($"Bienvenido, {nombre} {apellido}. Tu rol es: {rolUsuario}", "Inicio de Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                if (rolUsuario == "administrador")
                                {
                                    // Abrir la pantalla del administrador
                                    frmMigración admin = new frmMigración();
                                    admin.Show();
                                    this.Hide();                                    
                                }
                                else if (rolUsuario == "supervisor")
                                {
                                    // Abrir las pantallas del supervisor
                                    frmSupervisor supervisor = new frmSupervisor();
                                    supervisor.Show();
                                    this.Hide();
                                }
                                else if (rolUsuario == "decano")
                                {
                                    // Abrir las pantallas del decano
                                    frmDecano decano = new frmDecano();
                                    decano.Show();
                                    this.Hide();
                                }
                                else if (rolUsuario == "docente")
                                {
                                    // Abrir las pantallas del docente
                                    frmDocente docente = new frmDocente();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
