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
    public partial class frmJustificacion : Form
    {
        public frmJustificacion()
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
            this.Close();
            frmDecano menu = new frmDecano();
            menu.Show();
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

        private void lblPersona_Click(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
        }

        private void txtBusco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validar = new Validaciones();

            validar.ValidarFiltro(e, txtBusco);
        }

        private void txtJustifica_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validar = new Validaciones();

            validar.ValidarFiltro(e, txtJustifica);
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
    }
}
