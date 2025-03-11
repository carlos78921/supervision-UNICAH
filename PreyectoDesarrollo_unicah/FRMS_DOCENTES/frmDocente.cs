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

        private void frmDocente_Load(object sender, EventArgs e) 
        {
            string doc = ACCIONES_BD.docente;
            if (string.IsNullOrEmpty(doc))
            {
                MessageBox.Show("Error: Código del docente no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Hasta aquí concluye si sucede
            }
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";
            ACCIONES_BD objDoc = new ACCIONES_BD(doc);
            dgvDoc.AutoGenerateColumns = true;
            //MessageBox.Show($"Código del docente: {ACCIONES_BD.docente}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
            objDoc.tabla_docente(dgvDoc);
            //MessageBox.Show($"Columnas en dgvDoc: {dgvDoc.Columns.Count}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvDoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string dia = dgvAsiste.Columns[e.ColumnIndex].Name; // Día modificado
                bool asistencia = Convert.ToBoolean(dgvAsiste.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                string asignatura = dgvAsiste.Rows[e.RowIndex].Cells["Asignatura"].Value.ToString();
                string docente = dgvAsiste.Rows[e.RowIndex].Cells["Docente"].Value.ToString();
                string seccion = dgvAsiste.Rows[e.RowIndex].Cells["Seccion"].Value.ToString();
                DateTime fechaActual = DateTime.Today;

                if (asistencia)
                {
                    MarcarAsistencia(asignatura, docente, seccion, dia, fechaActual); //En ACCIONES_BD
                }
                else
                {
                    RegistrarFalta(asignatura, docente, seccion, dia, fechaActual); //En ACCIONES_BD
                }
            }
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
    }
}
