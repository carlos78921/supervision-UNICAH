using PreyectoDesarrollo_unicah.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmSupervisor : Form
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
            if (nombreCompleto.Trim().Length == 0)
            {
                nombreCompleto = "Nombre no disponible";
            }

            label4.Text = nombreCompleto;
            this.Text = $"Supervisor - {nombreCompleto}";
        }



        public frmSupervisor()
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void nudWeeks_ValueChanged(object sender, EventArgs e)
        {
            if (nudWeeks.SelectedIndex >= 0)
            {
                // Obtener el nombre del día seleccionado
                string diaSeleccionado = nudWeeks.SelectedItem.ToString();

                // Diccionario para mapear nombres de días con nombres de columnas en el DataGridView
                Dictionary<string, string> diasColumnas = new Dictionary<string, string>
        {
            { "Lunes", "clmLunes" },
            { "Martes", "clmMartes" },
            { "Miércoles", "clmMiercoles" },
            { "Jueves", "clmJueves" },
            { "Viernes", "clmViernes" },
            { "Sábado", "clmSabado" }
        };

                // Verificar si el día seleccionado tiene una columna asignada
                if (diasColumnas.ContainsKey(diaSeleccionado))
                {
                    string nombreColumna = diasColumnas[diaSeleccionado];

                    // Iterar sobre las filas y marcar con "X" en la columna correspondiente
                    foreach (DataGridViewRow fila in dgvDoc.Rows)
                    {
                        if (fila.Cells[nombreColumna] != null)
                        {
                            fila.Cells[nombreColumna].Value = "X";
                        }
                    }
                }
            }
        }
    }
}
