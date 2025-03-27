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
    public partial class frmDocente : Form
    {
        private static string docente;
        public frmDocente()
        {
            InitializeComponent();
            dgvDoc.AutoGenerateColumns = true;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void frmDocente_Load(object sender, EventArgs e) //Método del formulario
        {
            //Ajuste de forulario
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";

            //Ajustes de BDD
            string doc = ACCIONES_BD.docente;
            if (string.IsNullOrEmpty(doc))
            {
                MessageBox.Show("Error: Código del docente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hasta aquí concluye si sucede
            }

            ACCIONES_BD objDoc = new ACCIONES_BD(doc); //Instancia para involucrar el atributo del docente
            dgvDoc.AutoGenerateColumns = true;
            objDoc.tabla_docente(dgvDoc);
            objDoc.CargarAsistenciaDoc(
                mesDoc,
                (string)dgvDoc.CurrentRow.Cells[0].Value,
                (string)dgvDoc.CurrentRow.Cells[1].Value,
                (string)dgvDoc.CurrentRow.Cells[2].Value,
                (string)dgvDoc.CurrentRow.Cells[3].Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 Login = new Form1();
            Login.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmDocente_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvDoc_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDoc.CurrentRow != null)
            {
                // Extraer los valores de la fila seleccionada.
                string Clase = dgvDoc.CurrentRow.Cells[0].Value.ToString();
                string seccion = dgvDoc.CurrentRow.Cells[1].Value.ToString();
                string aula = dgvDoc.CurrentRow.Cells[2].Value.ToString();
                string edificio = dgvDoc.CurrentRow.Cells[3].Value.ToString();

                // Limpiar las fechas resaltadas previas en el MonthCalendar.
                mesDoc.RemoveAllBoldedDates();

                // Llama al método para cargar las fechas marcadas para ese registro.
                ACCIONES_BD objDoc = new ACCIONES_BD();
                objDoc.CargarAsistenciaDoc(mesDoc, Clase, seccion, aula, edificio);
            }
        }
    }
}
