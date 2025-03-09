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
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        public frmSupervisor()
        {
            InitializeComponent();
            panel1.MouseDown += FrmSupervisor_MouseDown; ;
            CargarNombreUsuario();
        }

        private void FrmSupervisor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void FrmSupervisor_Load(object sender, EventArgs e)
        {
            // Agregar días al nudWeeks (DomainUpDown)
            nudWeeks.Items.Add("Lunes");
            nudWeeks.Items.Add("Martes");
            nudWeeks.Items.Add("Miércoles");
            nudWeeks.Items.Add("Jueves");
            nudWeeks.Items.Add("Viernes");
            nudWeeks.Items.Add("Sábado"); 
            nudWeeks.SelectedItem = "Lunes"; // Seleccionar por defecto el primer día

            // Configurar columnas del DataGridView (DGV)
            dgvDoc.ColumnCount = 6;
            dgvDoc.Columns[0].Name = "Lunes";
            dgvDoc.Columns[1].Name = "Martes";
            dgvDoc.Columns[2].Name = "Miércoles";
            dgvDoc.Columns[3].Name = "Jueves";
            dgvDoc.Columns[4].Name = "Viernes";
            dgvDoc.Columns[5].Name = "Sábado"; 

            // Desactivar todas las columnas al inicio
            foreach (DataGridViewColumn col in dgvDoc.Columns)
            {
                col.ReadOnly = true;
            }
        }

        private void CargarNombreUsuario()
        {
            ACCIONES_BD accionesBD = new ACCIONES_BD();
            string nombreCompleto = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}".Trim();
            lblNombrePer.Text = string.IsNullOrEmpty(nombreCompleto) ? "Nombre no disponible" : nombreCompleto;
            this.Text = string.IsNullOrEmpty(nombreCompleto) ? "Supervisor" : $"Supervisor - {nombreCompleto}";
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

        private void nudWeeks_ValueChanged(object sender, EventArgs e)
        {
            string diaSeleccionado = nudWeeks.Text;

            // Desactivar todas las columnas
            foreach (DataGridViewColumn col in dgvDoc.Columns)
            {
                col.ReadOnly = true;
            }

            // Activar solo la columna del día seleccionado
            int columna = ObtenerIndiceColumna(diaSeleccionado);

            if (columna != -1)
            {
                dgvDoc.Columns[columna].ReadOnly = false;
            }
        }

        private void btnTransferir_Click(object sender, EventArgs e)
        {
            string diaSeleccionado = nudWeeks.Text;
            int columna = ObtenerIndiceColumna(diaSeleccionado);

            if (columna != -1)
            {
                string datosTransferidos = "";

                foreach (DataGridViewRow row in dgvDoc.Rows)
                {
                    if (row.Cells[columna].Value != null)
                    {
                        datosTransferidos += $"{diaSeleccionado}: {row.Cells[columna].Value}\n";
                    }
                }

                MessageBox.Show("Datos transferidos al SP:\n" + datosTransferidos);
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
    }
    
}

