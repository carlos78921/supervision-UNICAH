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
    public partial class frmJustificación : Form
    {
        public frmJustificación()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmJustificación_Load(object sender, EventArgs e)
        {
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";
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

        private void frmJustificación_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);  //El evento en memoria se mantiene
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);  //El evento en memoria se mantiene
        }

        private void btnBusco_Click(object sender, EventArgs e)
        {
            string docenteBuscado = txtBusco.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(docenteBuscado))
            {
                MessageBox.Show("Por favor, ingrese el nombre del docente a buscar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool encontrado = false;

            foreach (DataGridViewRow row in dgvJustificacion.Rows)
            {
                if (row.Cells["Docente"].Value != null)
                {
                    string docente = row.Cells["Docente"].Value.ToString().ToLower();
                    if (docente.Contains(docenteBuscado))
                    {
                        row.Selected = true; // Selecciona la fila encontrada
                        dgvJustificacion.FirstDisplayedScrollingRowIndex = row.Index; // Desplaza la vista hasta la fila encontrada
                        encontrado = true;
                        break; // Termina la búsqueda en la primera coincidencia
                    }
                }
            }

            if (!encontrado)
            {
                MessageBox.Show("Docente no encontrado.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvJustificacion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dgvJustificacion.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            {
                bool justificado = Convert.ToBoolean(dgvJustificacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                dgvJustificacion.Rows[e.RowIndex].DefaultCellStyle.BackColor = justificado ? Color.LightGreen : Color.White;
            }

            // Verifica que no se haya hecho clic en el encabezado de la columna
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            // Verifica si la columna es un CheckBox (para la reposición)
            if (!(dgvJustificacion.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn))
                return;

            // Finaliza la edición para registrar los cambios
            dgvJustificacion.EndEdit();

            // Obtener valores de la fila seleccionada
            string asignatura = dgvJustificacion.Rows[e.RowIndex].Cells["Asignatura"].Value.ToString();
            string fechaAusencia = dgvJustificacion.Rows[e.RowIndex].Cells["Fecha de Ausencia"].Value.ToString();
            string seccion = dgvJustificacion.Rows[e.RowIndex].Cells["Sección"].Value.ToString();
            string docente = dgvJustificacion.Rows[e.RowIndex].Cells["Docente"].Value.ToString();
            string fechaReposicion = dgvJustificacion.Rows[e.RowIndex].Cells["Justificación"].Value.ToString();

            // Obtener el estado del CheckBox (si se confirma la reposición)
            bool reposicionConfirmada = Convert.ToBoolean(dgvJustificacion.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

        }

        private void txtJustifica_TextChanged(object sender, EventArgs e)
        {
            int maxLength = 200; // Límite de caracteres
            if (txtJustifica.Text.Length > maxLength)
            {
                txtJustifica.Text = txtJustifica.Text.Substring(0, maxLength);
                txtJustifica.SelectionStart = txtJustifica.Text.Length; // Mantener el cursor al final
            }
            lblCaracteres.Text = $"{txtJustifica.Text.Length}/{maxLength}"; // Mostrar el conteo de caracteres
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvJustificacion.SelectedCells.Count > 0) // Verificar que haya una celda seleccionada
            {
                int rowIndex = dgvJustificacion.SelectedCells[0].RowIndex; // Obtener índice de la fila seleccionada

                if (rowIndex >= 0) // Asegurar que la fila seleccionada es válida
                {
                    dgvJustificacion.Rows[rowIndex].Cells["Justificacion"].Value = txtJustifica.Text; // Insertar la justificación
                    MessageBox.Show("Justificación insertada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila en la tabla para insertar la justificación.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFecha.Value;
            CargarJustificaciones(fechaSeleccionada);
            OcultarColumnas(); // Oculta las columnas innecesarias
        }

        private void CargarJustificaciones(DateTime fecha)
        {
            string consulta = $"SELECT * FROM Justificaciones WHERE Fecha = '{fecha:yyyy-MM-dd}'";
            DataTable dtJustificaciones = ObtenerDatosDesdeBD(consulta);
            dgvJustificacion.DataSource = dtJustificaciones;
        }

        private void OcultarColumnas()
        {
            if (dgvJustificacion.Columns.Contains("Fecha"))
                dgvJustificacion.Columns["Fecha"].Visible = false;

            if (dgvJustificacion.Columns.Contains("Día de semana"))
                dgvJustificacion.Columns["Día de semana"].Visible = false;
        }

    }
}
