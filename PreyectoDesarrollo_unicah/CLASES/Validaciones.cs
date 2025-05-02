using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoDesarrollo_unicah.CLASES
{
    internal class Validaciones
    {
        public static bool Usuario (object sender, EventArgs e, string usuario, string contraseña, TextBox user)
        {
            if ((usuario == "Usuario:" || usuario == "") && 
               (contraseña == "Contraseña:" || contraseña == "Contraseña nueva:" || contraseña == "")) 
            {
                MessageBox.Show("Datos no ingresados, ingrese sus datos", "Error Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user.Focus();
                return false;
            }

            if (!SoloNumero(usuario) && usuario.Length <= 4)
            {
                MessageBox.Show("El usuario corresponde a números", "Error Letras", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                user.Focus();
                return false;
            }

            if (usuario != "Usuario:" && usuario.Length > 4)
            {
                MessageBox.Show("Su usuario debe contener cuatro o menos caracteres.", "Usuario Largo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user.Focus();
                return false;
            }

            if (usuario == "Usuario:" || usuario == "")
            {
                MessageBox.Show("Usuario no ingresado, ingrese su usuario", "Error Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                user.Focus();
                return false;
            }

            return true;
        }

        private static bool SoloNumero(string usuario)
        {
            return usuario.All(char.IsDigit);
        }

        public static bool Contraseña(object sender, EventArgs e, string usuario, string contraseña, Form Login, TextBox user, TextBox contra)
        {
            if (user != null)
                if (!ACCIONES_BD.AdminCasoContra(usuario, contraseña, Login))
                    return false;

            if (contraseña == "Contraseña:" || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Contraseña no puede quedar vacía, en caso de no obtener, consultar al administrador.", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contra.Focus();
                return false;
            }

            if (contraseña.Length < 8 && user == null)
            {
                MessageBox.Show("La contraseña debe tener al menos 8 caracteres.", "Contraseña Corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (contraseña.Length < 8)
            {
                MessageBox.Show("Su contraseña debe contener más de ocho caracteres.\nComuníquese con el Administrador, y espere a que le asigne contraseña correcta", "Contraseña Corta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contra.Focus();
                return false;
            }

            if (contraseña.Length > 150 && user == null) //Al actualizar el límite, recompilar esta solución y el setup
            {
                MessageBox.Show("Contraseña difícil de recordar", "Contraseña pasó límite máximo de 150 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (contraseña == "Contraseña nueva:" || string.IsNullOrWhiteSpace(contraseña))
            {
                MessageBox.Show("Contraseña no puede quedar vacía.", "Contraseña Vacía", MessageBoxButtons.OK, MessageBoxIcon.Error);
                contra.Focus();
                return false;
            }

            return true;
        }

        public static bool Correo(object sender, EventArgs e, TextBox txtCorreo)
        {
            int arroba = txtCorreo.Text.IndexOf('@');
            if (txtCorreo.Text == "Correo:" || txtCorreo.Text == "")
            {
                MessageBox.Show("Correo no ingresado, ingresar correo", "Correo Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return false;
            }

            string rtrim = txtCorreo.Text.Substring(arroba + 1);
            if (txtCorreo.Text == "@" || !txtCorreo.Text.Contains("@") ||
                string.IsNullOrWhiteSpace(rtrim))
            {
                MessageBox.Show("Correo no válido", "Correo no detectado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCorreo.Focus();
                return false;
            }
            return true;
        }

        public static bool Codigo(object sender, EventArgs e, TextBox txtCodigo)
        {
            if (txtCodigo.Text == "Código:" || txtCodigo.Text == "") 
            {
                MessageBox.Show("Código no ingresado, ingresar código", "Código Vacío", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }

            if (txtCodigo.Text != "Código:" && txtCodigo.Text.Length != 5)
            {
                MessageBox.Show("El código debe contener cinco caracteres", "Error Cantidad Código", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigo.Focus();
                return false;
            }


            return true;
        }
    }
}