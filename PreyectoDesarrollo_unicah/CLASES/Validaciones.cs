using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoDesarrollo_unicah.CLASES
{
    internal class Validaciones
    {

        public static bool CasoDato (string usuario, string contraseña, TextBox txtUsuario)
        {
            if ((usuario == "Usuario:" || string.IsNullOrWhiteSpace(usuario)) && 
                (contraseña == "Contraseña:" || contraseña == "Contraseña nueva:" || string.IsNullOrWhiteSpace(contraseña))) 
            {
                MessageBox.Show("Datos no ingresados, ingrese sus datos", "Error Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (usuario == "Usuario:") 
            {
                txtUsuario.Clear();
                MessageBox.Show("Usuario no puede quedar vacío.", "Usuario Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsuario.Text = usuario;
                return false;
            }

            if (usuario != "Usuario:" && usuario.Length > 4)
            {
                MessageBox.Show("Su usuario debe contener cuatro o menos caracteres.\nComuníquese con el Administrador, y espere a que le asigne contraseña", "Contraseña Corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool SoloNumero(string usuario) 
        {
            return usuario.All(char.IsDigit); 
        }

        public static bool CasoContraseña(string contraseña, TextBox txtContraseña)
        {
            if (contraseña == "Contraseña:")
            {
                txtContraseña.Clear();
                MessageBox.Show("Contraseña no puede quedar vacía, en caso de no obtener, consultar al administrador.", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Text = contraseña;
                return false;
            }

            if (contraseña != "Contraseña:" && contraseña.Length < 8)
            {
                MessageBox.Show("Su contraseña debe contener más de ocho caracteres.\nComuníquese con el Administrador, y espere a que le asigne contraseña", "Contraseña Corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool CasoContraseñaNueva(string contraseña, TextBox txtContraseña)
        {
            if (contraseña == "Contraseña nueva:")
            {
                txtContraseña.Clear();
                MessageBox.Show("Contraseña no puede quedar vacía.", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtContraseña.Text = contraseña;
                return false;
            }

            if (contraseña != "Contraseña nueva:" && contraseña.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Contraseña Corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool ValidarUsuario(KeyPressEventArgs e, string usuario, string contraseña, TextBox txtusuario)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; // Bloquea caracteres no permitidos
            else
                e.Handled = false;

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (usuario == "") 
                {
                    MessageBox.Show("Usuario no puede quedar vacío.", "Usuario Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!Validaciones.SoloNumero(usuario))
                {
                    MessageBox.Show("El usuario corresponde a números", "Error Letras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtusuario.Focus();
                    return false;
                }

                if (contraseña == "Contraseña:" || contraseña == "Contraseña nueva:")
                {
                    MessageBox.Show("No ingresó su contraseña, ingrese su contraseña", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            return true;
        }
        public static bool ValidarContraseña(KeyPressEventArgs e, string usuario, string contraseña)
        {
            if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                e.Handled = true; 
            else
                e.Handled = false;

            if (e.KeyChar == (char)Keys.Enter)
            {
                if (contraseña == "")
                {
                    MessageBox.Show("Contraseña vacía, ingrese su contraseña", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (contraseña != "" && contraseña.Length<8)
                {
                    MessageBox.Show("La contraseña debe contener más de 8 caracteres", "Contraseña Corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (usuario == "Usuario:")
                {
                    MessageBox.Show("Usuario no detectado, ingrese usuario correcto", "No Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
    }
}


