using PreyectoDesarrollo_unicah.CLASES;
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
    public partial class frmReporte : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture(); //Externo por la importación realizada en comando

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        private void CargarNombreUsuario()
        {
            ACCIONES_BD accionesBD = new ACCIONES_BD();
            string nombreCompleto = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}".Trim();
            lblPersona.Text = string.IsNullOrEmpty(nombreCompleto) ? "Nombre no disponible" : nombreCompleto;
            this.Text = string.IsNullOrEmpty(nombreCompleto) ? "Supervisor" : $"Supervisor - {nombreCompleto}";
        }

        public frmReporte()
        {
            InitializeComponent();
            this.MouseDown += frmSupervisor_MouseDown;
            CargarNombreUsuario();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            cmbEdificio.SelectedIndex = 0;
            cmbAula.SelectedIndex = 0;
            cmbHora.SelectedIndex = 0;

            string pa = "PA_Asistencia_Superv";
            string conexion = Environment.GetEnvironmentVariable("CONN_STRING_SQL", EnvironmentVariableTarget.User);
            using (SqlConnection conn = new SqlConnection(conexion))
            {
                SqlCommand cmd = new SqlCommand(pa, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvAsiste.DataSource = dt;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void tmrFecha_Tick(object sender, EventArgs e)
        {
            lblFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e) //Evento del ratón "e"
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); //El evento en memoria se mantiene
            }
        }

        private int ObtenerIndiceColumna(string dia)
        {
            switch (dia)
            {
                case "Lunes": return 0;
                case "Martes": return 1;
                case "Miércoles": return 2;
                case "Jueves": return 3;
                case "Viernes": return 4;
                case "Sábado": return 5;
                default: return -1;
            }
        }

        private void dgvAsiste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string dia = dgvAsiste.Columns[e.ColumnIndex].Name; // Día modificado
                bool asistencia = Convert.ToBoolean(dgvAsiste.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                string codAsignatura = dgvAsiste.Rows[e.RowIndex].Cells["Cod_Asignatura"].Value.ToString();
                int idSitio = Convert.ToInt32(dgvAsiste.Rows[e.RowIndex].Cells["ID_Sitio"].Value);
                string codEmpleado = dgvAsiste.Rows[e.RowIndex].Cells["Codigo_Empleado"].Value.ToString();
                DateTime fechaActual = DateTime.Today;

                if (asistencia)
                    ACCIONES_BD.presenteSup(codAsignatura, idSitio, codEmpleado, fechaActual, dia);
                else
                    ACCIONES_BD.RegistrarFalta(codAsignatura, idSitio, codEmpleado, fechaActual, dia);
            }
        }
    }
}
