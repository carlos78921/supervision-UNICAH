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
    public partial class frmAsistencia : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture(); //Externo por la importación realizada en comando

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public frmAsistencia()
        {
            InitializeComponent();
            this.MouseDown += frmSupervisor_MouseDown;
        }
        private BindingSource bs = new BindingSource(); //Para búsqueda

        private void Busqueda()
        {
            DataTable dt = ACCIONES_BD.tablaSupervisor(dgvAsiste);
            bs.DataSource = dt;
            dgvAsiste.DataSource = bs;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FiltroInicial()
        {
            cmbEdificio.SelectedIndex = 0;
            cmbAula.SelectedIndex = 0;
            cmbHora.SelectedIndex = 0;
        }

        private void FrmReporte_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
            //Ajustes del formulario
            FiltroInicial();

            //Ajustes del bdd
            ACCIONES_BD.tablaSupervisor(dgvAsiste);
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void frmSupervisor_MouseDown(object sender, MouseEventArgs e) //Evento del ratón "e"
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0); //El evento en memoria se mantiene
            }
        }

        private void dgvAsiste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //El "e" proviene de celdas afectadas como los checkbox
        {
            //Clic solo en columnas con checkbox, los de textbox como docentes, entre otros, no se afectan
            if (!(dgvAsiste.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
                return;
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dgvAsiste.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    // Finaliza la edición para que el cambio se registre inmediatamente
                    dgvAsiste.EndEdit();

                    string dia = dgvAsiste.Columns[e.ColumnIndex].Name; // Día modificado

                    string Docente = dgvAsiste.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string Asignatura = dgvAsiste.Rows[e.RowIndex].Cells[1].Value.ToString();
                    string Seccion = dgvAsiste.Rows[e.RowIndex].Cells[2].Value.ToString();
                    string Aula = dgvAsiste.Rows[e.RowIndex].Cells[3].Value.ToString();

                    string Edificio = dgvAsiste.Rows[e.RowIndex].Cells[4].Value.ToString();

                    bool asistencia = Convert.ToBoolean(dgvAsiste.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    if (asistencia)
                        ACCIONES_BD.presenteSup(Docente, Asignatura, Seccion, Aula, Edificio, dia);
                    else
                        ACCIONES_BD.RegistrarFalta(Docente, Asignatura, Seccion, Aula, Edificio, dia);
                }
            }
        }

        private void txtDoc_KeyUp(object sender, KeyEventArgs e)
        {
            Busqueda();
            string filtro = txtDoc.Text.Trim();
            // Evitar errores con comillas simples
            if (string.IsNullOrEmpty(filtro))
            {
                // Si el campo está vacío, aparecen todas la filas
                bs.RemoveFilter();
            }
            else
            {
                bs.Filter = string.Format("Docente LIKE '%{0}%'", filtro);
            }
        }

        private void txtClase_KeyUp(object sender, KeyEventArgs e)
        {
            Busqueda();
            string filtro = txtDoc.Text.Trim();
            // Evitar errores con comillas simples
            if (string.IsNullOrEmpty(filtro))
            {
                // Si el campo está vacío, aparecen todas la filas
                bs.RemoveFilter();
            }
            else
            {
                bs.Filter = string.Format("Asignatura LIKE '%{0}%'", filtro);
            }
        }
    }
}
