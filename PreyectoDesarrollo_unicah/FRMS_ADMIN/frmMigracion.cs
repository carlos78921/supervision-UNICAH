using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
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
    public partial class frmMigracion : Form
    {
        public frmMigracion()
        {
            InitializeComponent();
        }

        private void frmMigración_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.nombre + " " + ACCIONES_BD.apellido;
            
            //Ajustes del bdd
            ACCIONES_BD.tablaAdmin(dgvAdmin);
            ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, (string)dgvAdmin.CurrentRow.Cells[0].Value, (string)dgvAdmin.CurrentRow.Cells[1].Value, (string)dgvAdmin.CurrentRow.Cells[2].Value, (string)dgvAdmin.CurrentRow.Cells[3].Value, (string)dgvAdmin.CurrentRow.Cells[4].Value);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdmin.CurrentRow != null)
            {
                // Extraer los valores de la fila seleccionada.
                string refiero = dgvAdmin.CurrentRow.Cells[0].Value.ToString();
                string curso = dgvAdmin.CurrentRow.Cells[1].Value.ToString();
                string seccion = dgvAdmin.CurrentRow.Cells[2].Value.ToString();
                string aula = dgvAdmin.CurrentRow.Cells[3].Value.ToString();
                string empleo = dgvAdmin.CurrentRow.Cells[4].Value.ToString();

                // Limpiar las fechas resaltadas previas en el MonthCalendar.
                mesAdmin.RemoveAllBoldedDates();

                // Llama al método para cargar las fechas marcadas para ese registro.
                ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, refiero, curso, seccion, aula, empleo);
            }
        }
    }
}
