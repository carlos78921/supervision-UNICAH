using PreyectoDesarrollo_unicah.CLASES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmDecano : Form
    {
        public frmDecano()
        {
            InitializeComponent();

        }

        private void Frm_Admin_Load(object sender, EventArgs e)
        {
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";
            // ACCIONES_BD.cargar(dgvDoc,)
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
