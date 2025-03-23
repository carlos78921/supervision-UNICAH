using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoDesarrollo_unicah.CLASES
{
    internal class Validaciones
    {

        public void ValidarCuenta(KeyPressEventArgs e, string textBox)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.Equals(textBox, "Usuario:"))
                    MessageBox.Show("Usuario no puede quedar vacío.", "Error Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (string.Equals(textBox, "Contraseña:"))
                    MessageBox.Show("Contraseña no puede quedar vacía, en caso de no obtener, consultar al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ValidarUsuario(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea caracteres no permitidos
            }
            else
            {
                e.Handled = false;
            }

            // Verifica si el campo está en blanco después de la entrada
            if (string.IsNullOrEmpty(textBox.Text) && e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Usuario no puede quedar vacío.", "Error Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ValidarCuenta(e, Convert.ToString(textBox));
        }

        public void ValidarContraseña(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // Bloquea caracteres no permitidos
            else
                e.Handled = false;

            // Verifica si el campo está en blanco después de la entrada
            if (string.IsNullOrWhiteSpace(textBox.Text) && e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Contraseña no puede quedar vacía, en caso de no obtener, consultar al administrador.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            ValidarCuenta(e, Convert.ToString(textBox));
        }

        public void ValidarFiltro(KeyPressEventArgs e, TextBox textBox)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // Bloquea caracteres no permitidos
            else
                e.Handled = false;

            // Verifica si el campo está en blanco después de la entrada
            if (string.IsNullOrWhiteSpace(textBox.Text) && e.KeyChar == (char)Keys.Enter)
                MessageBox.Show("El campo no puede quedar en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}


