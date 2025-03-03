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
    public partial class frmReposición : Form
    {
        public frmReposición()
        {
            InitializeComponent();
        }

        private void frmReposición_Load(object sender, EventArgs e)
        {
            lblPersona.Text = $"{ACCIONES_BD.nombre} {ACCIONES_BD.apellido}";
            // ACCIONES_BD.cargar(dgvDoc,)
        }
    }
}
