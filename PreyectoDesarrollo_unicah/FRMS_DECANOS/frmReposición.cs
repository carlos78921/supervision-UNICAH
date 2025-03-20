using PreyectoDesarrollo_unicah.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices; //Relacionado con Dll (Librería)
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmReposición : Form
    {
        public frmReposición()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmReposición_Load(object sender, EventArgs e)
        {
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";
            cmbEdificio.SelectedIndex = 0;
            // ACCIONES_BD.cargar(dgvDoc,)
        }

        private void btnVoy_Click(object sender, EventArgs e)
        {
            this.Close();
            frmDecano menu = new frmDecano();
            menu.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Seguro que quieres salirte por completo", "Salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);  //El evento en memoria se mantiene
        }

        private void frmReposición_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);  //El evento en memoria se mantiene
        }

        private void dgvReposicion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvReposicion.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                bool justificado = Convert.ToBoolean(dgvReposicion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                dgvReposicion.Rows[e.RowIndex].DefaultCellStyle.BackColor = justificado ? Color.LightGreen : Color.White;
            }
            // Verifica que no se haya hecho clic en el encabezado de la columna
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Verifica si la columna es un CheckBox (para la reposición)
            if (!(dgvReposicion.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
                return;

            // Finaliza la edición para registrar los cambios
            dgvReposicion.EndEdit();

            // Obtener valores de la fila seleccionada
            string asignatura = dgvReposicion.Rows[e.RowIndex].Cells["Asignatura"].Value.ToString();
            string fechaAusencia = dgvReposicion.Rows[e.RowIndex].Cells["Fecha de Ausencia"].Value.ToString();
            string seccion = dgvReposicion.Rows[e.RowIndex].Cells["Sección"].Value.ToString();
            string docente = dgvReposicion.Rows[e.RowIndex].Cells["Docente"].Value.ToString();
            string fechaReposicion = dgvReposicion.Rows[e.RowIndex].Cells["Fecha de Reposición"].Value.ToString();

            // Obtener el estado del CheckBox (si se confirma la reposición)
            bool reposicionConfirmada = Convert.ToBoolean(dgvReposicion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFecha.Value;
            CargarReposicion(fechaSeleccionada);
            OcultarColumnas(); // Oculta las columnas innecesarias
        }

        private void CargarReposicion(DateTime fecha)
        {
            string consulta = $"SELECT * FROM Justificaciones WHERE Fecha = '{fecha:yyyy-MM-dd}'";
            DataTable dtJustificaciones = ObtenerDatosDesdeBD(consulta);
            dgvReposicion.DataSource = dtJustificaciones;
        }

        private void OcultarColumnas()
        {
            if (dgvReposicion.Columns.Contains("Fecha"))
                dgvReposicion.Columns["Fecha"].Visible = false;

            if (dgvReposicion.Columns.Contains("Día de semana"))
                dgvReposicion.Columns["Día de semana"].Visible = false;
        }


    }
}
