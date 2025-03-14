using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
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

        public frmReporte()
        {
            InitializeComponent();
            this.MouseDown += frmSupervisor_MouseDown;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        //Procesos en carga del formulario
        private void AsistenciaxDia()
        {
            string[] dias = { "L", "M", "X", "J", "V", "S" };
            /*Arreglo requerido para detectar cantidad de índices medidos con Length
            y poder ocultar según día*/
            for (int i = 0; i < dias.Length; i++)
            {
                if (dgvAsiste.Columns.Contains(dias[i]))
                //Primero es el arreglo que se detecta del índice i
                {
                    dgvAsiste.Columns[dias[i]].Visible = false; //Aquí detecta de la columna
                }
            }
            //Detección de día automática por número del 0 al 6 (6 o -1 por domingo)
            DayOfWeek hoy = DateTime.Today.DayOfWeek;
            int indiceDia = -1; // Índice correspondiente al día en el array 
            switch (hoy)
            {
                case DayOfWeek.Monday: indiceDia = 0; break;
                case DayOfWeek.Tuesday: indiceDia = 1; break;
                case DayOfWeek.Wednesday: indiceDia = 2; break;
                case DayOfWeek.Thursday: indiceDia = 3; break;
                case DayOfWeek.Friday: indiceDia = 4; break;
                case DayOfWeek.Saturday: indiceDia = 5; break;
                case DayOfWeek.Sunday: indiceDia = -1; break; // En domingo oculta todas las columnas 
            }

            if (indiceDia != -1 && dgvAsiste.Columns.Contains(dias[indiceDia]))
            {
                dgvAsiste.Columns[dias[indiceDia]].Visible = true;
            }
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
            AsistenciaxDia();
            //Ajustes del bdd
            ACCIONES_BD.tablaSupervisor(dgvAsiste);
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
                    string Sitio = dgvAsiste.Rows[e.RowIndex].Cells[2].Value.ToString();


                    // Aquí puedes llamar a la función que maneja el cambio (por ejemplo, llamar a PA_Marcar_Asistencia o PA_Registrar_Falta)
                    bool asistencia = Convert.ToBoolean(dgvAsiste.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                    if (asistencia)
                        ACCIONES_BD.presenteSup(Docente, Asignatura, Sitio, dia);
                    else
                        ACCIONES_BD.RegistrarFalta(Docente, Asignatura, Sitio, dia);
                }
            }
        }
    }
}
