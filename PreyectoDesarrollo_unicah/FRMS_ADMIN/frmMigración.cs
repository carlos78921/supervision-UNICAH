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
    public partial class frmMigración : Form
    {
        public frmMigración()
        {
            InitializeComponent();
        }

        private void lblPersona_Click(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
        }
    }
}
