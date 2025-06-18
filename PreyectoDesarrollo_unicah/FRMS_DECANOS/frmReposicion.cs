using DocumentFormat.OpenXml.Office.SpreadSheetML.Y2023.MsForms;
using DocumentFormat.OpenXml.Wordprocessing;
using PreyectoDesarrollo_unicah.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices; //Relacionado con Dll (Librería)
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmReposicion : Form
    {
        public frmReposicion()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmReposición_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.Persona();
            dtpReposicion.MinDate = DateTime.Today;
            dtpAusencia.MaxDate = DateTime.Today;
            //Ajuste del formulario
            cmbEdificio.SelectedIndex = 0;

            //Ajustes del bdd
            ACCIONES_BD.tablaRepone(dgvRepone, ACCIONES_BD.empleado);
        }

        private void Cerrar(object sender, EventArgs e)
        {
            this.Close();
            frmDecano menu = new frmDecano();
            menu.Show();
        }

        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);  //El evento en memoria se mantiene
        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;
            if (dgvRepone.CurrentRow == null)
            {
                MessageBox.Show("Seleccionar una fila para insertar día de reposición", "Error selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Ajustes en la BDD
            ACCIONES_BD.Repongo(dgvRepone, (int)dgvRepone.CurrentRow.Cells[0].Value, dtpReposicion);
            ACCIONES_BD.tablaRepone(dgvRepone, ACCIONES_BD.empleado);
        }

        private void Filtros(object sender, EventArgs e)
        {
            ACCIONES_BD.FiltrarDatosRepo(txtBusco.Text, cmbEdificio.Text, dtpAusencia.Value, dgvRepone);
        }

        private void btnReporta_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;
            ACCIONES_BD.tablaReponeTodo();
        }

        private void dgvRepone_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRepone.CurrentRow.Index > -1)
            {
                btnDay.Enabled = true;
                dtpReposicion.Enabled = true;
            }
        }
    }
}