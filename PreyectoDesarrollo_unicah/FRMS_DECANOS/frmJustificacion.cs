using DocumentFormat.OpenXml.Wordprocessing;
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
            lblPersona.Text = ACCIONES_BD.Persona();

            //Ajuste de controles
            txtJustifica.Text = Environment.NewLine; // (TextChanged) Mantener la primera línea vacía cuando se opera esto
            txtJustifica.SelectionStart = txtJustifica.Text.Length; // (TextChanged) Colocar el cursor en la segunda línea cuando se opera esto

            //Ajuste en la BDD
            ACCIONES_BD.tablaJustifica(dgvJustificacion, ACCIONES_BD.empleado);
        }

        private void Salir(object sender, EventArgs e)
        {
            this.Close();
            frmDecano menu = new frmDecano();
            menu.Show();
        }

        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            //este es para poder mover el form
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);  //El evento en memoria se mantiene
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtJustifica.Text.Trim()))
            {
                ACCIONES_BD.Justifico(dgvJustificacion, (int)dgvJustificacion.CurrentRow.Cells[0].Value, txtJustifica.Text);
                ACCIONES_BD.tablaJustifica(dgvJustificacion, ACCIONES_BD.empleado); //Esto ayuda a actualizar la tabla, la línea anterior actualiza datos
            }
        }

        //Métodos para el textbox de justificación

        private bool bloqueado = false; // Evita que los eventos se disparen mutuamente
        private void Renglon2()
        {
            if (bloqueado) return; // Evita que los eventos se disparen mutuamente
            bloqueado = true;

            string[] lineas = txtJustifica.Lines;

            // Asegurar que la primera línea esté vacía
            if (lineas.Length > 0)
            {
                lineas[0] = ""; // Vaciar la primera línea
            }

            // Si hay más de dos líneas, eliminar las adicionales
            if (lineas.Length > 2)
            {
                txtJustifica.Lines = lineas.Take(2).ToArray(); //Despeja el dos del arreglo
            }
            else
            {
                txtJustifica.Lines = lineas; // Asignar líneas modificadas
            }

            // Si el usuario borra todo, mantener la primera línea vacía y el cursor en la segunda línea
            if (txtJustifica.Text.Trim() == "")
            {
                txtJustifica.Text = Environment.NewLine;
            }

            txtJustifica.SelectionStart = txtJustifica.Text.Length; // Mantener el cursor en la segunda línea

            bloqueado = false; //Desactiva método contador de caracteres

            ContarChars(); //Aquí se ubica por orden
        }

        private void ContarChars()
        {
            int Max = 150; // Límite máximo de caracteres
            if (bloqueado) return;
            bloqueado = true;

            // "?" es un if para true y ":" es un else, donde esa resta al contener un valor que "suma caracteres" a dos, pues resta a dos para valor original, en renglón 2
            int conteoRenglon2 = txtJustifica.Text.Trim() == "" ? 0 : txtJustifica.Text.Length - Environment.NewLine.Length;

            if (txtJustifica.Text.Length > Max + 1)
            {
                txtJustifica.Text = txtJustifica.Text.Substring(0, Max); // Limitar la cantidad de caracteres
                txtJustifica.SelectionStart = txtJustifica.Text.Length; // Mantener el cursor al final
            }
            lblCaracteres.Text = $"{conteoRenglon2}/{Max}"; // Mostrar el conteo de caracteres
            bloqueado = false;
        }

        private void txtJustifica_TextChanged(object sender, EventArgs e)
        {
            Renglon2();
        }

        private void txtBusco_KeyDown(object sender, KeyEventArgs e)
        {
            ACCIONES_BD.FiltrarDatosJusto(txtBusco.Text, cmbEdificio.Text, dgvJustificacion);
        }

        private void cmbEdificio_SelectedIndexChanged(object sender, EventArgs e)
        {
            ACCIONES_BD.FiltrarDatosJusto(txtBusco.Text, cmbEdificio.Text, dgvJustificacion);
        }

        private void btnReporta_Click(object sender, EventArgs e)
        {
            ACCIONES_BD.tablaJustificaTodo();
        }
    }
}
