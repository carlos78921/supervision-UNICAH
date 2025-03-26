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
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";
            //Ajuste del formulario
            cmbEdificio.SelectedIndex = 0;

            //Ajustes del bdd
            ACCIONES_BD.tablaRepone(dgvRepone);
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

        private void txtBusco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validaciones validar = new Validaciones();

            validar.ValidarFiltro(e, txtBusco);
        }

        private void cmbEdificio_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void btnDay_Click(object sender, EventArgs e) //SOLO ME FALTA INSERTAR FECHA DE REPOSICIÓN
        {
            ACCIONES_BD.tablaJustifica(dgvJustificacion);
            //Ajustes en la BDD
        }
    }
}
