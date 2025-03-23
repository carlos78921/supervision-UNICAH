using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreyectoDesarrollo_unicah.CLASES
{
    internal class Validaciones
    {
     
            public void ValidarEntrada(KeyPressEventArgs e, TextBox textBox)
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
                if (string.IsNullOrWhiteSpace(textBox.Text) && e.KeyChar == (char)Keys.Enter)
                {
                    MessageBox.Show("El campo no puede quedar en blanco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        public void ValidarContraseña (KeyPressEventArgs e, TextBox textBox)
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
            if (string.IsNullOrWhiteSpace(textBox.Text) && e.KeyChar == (char)Keys.Enter)
            {
                MessageBox.Show("Ingrese una contraseña, este campo no puede estar vacio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        }


    }


