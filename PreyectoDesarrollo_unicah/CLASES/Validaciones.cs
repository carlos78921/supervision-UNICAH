using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoDesarrollo_unicah.CLASES
{
    internal class Validaciones
    {

        public static bool DatoVacio (string usuario, string contraseña, TextBox txtUsuario)
        {
            if ((usuario == "Usuario:" || string.IsNullOrWhiteSpace(usuario)) && //Usuario y contraseña vacía
                (contraseña == "Contraseña:" || string.IsNullOrWhiteSpace(contraseña))) 
            {
                MessageBox.Show("Datos no escritos por usted, ingrese sus datos", "Error Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (usuario == "Usuario:") //Usuario Vacío
            {
                txtUsuario.Clear();
                MessageBox.Show("Usuario no puede quedar vacío.", "Error Usuario Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = usuario;
                return false;
            }

            return true;
        }

        public static bool SoloNumero(string usuario) //Validación para solo números en la cadena
        {
            return usuario.All(char.IsDigit); // Verifica que todos los caracteres sean números en la cadena
        }

        public static bool CasoContraseña(string contraseña, TextBox txtContraseña)
        {
            if (contraseña == "Contraseña:")
            {
                txtContraseña.Clear();
                MessageBox.Show("Contraseña no puede quedar vacía, en caso de no obtener, consultar al administrador.", "Error Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Text = contraseña;
                return false;
            }

            if (contraseña != "Contraseña:" && contraseña.Length < 8)
            {
                MessageBox.Show("Su contraseña debe contener más de ocho caracteres.\nComuníquese con el Administrador, y espere a que le asigne contraseña", "Error del Admin.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public void ValidarCuenta(KeyPressEventArgs e, string textBox)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (string.Equals(textBox, "Usuario:"))
                    MessageBox.Show("Usuario no puede quedar vacío.", "Error Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (string.Equals(textBox, "Contraseña:"))
                    MessageBox.Show("Contraseña no puede quedar vacía, en caso de no obtener, consultar al administrador.", "Error Contraseña", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


