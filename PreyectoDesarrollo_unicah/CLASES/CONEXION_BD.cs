

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PreyectoDesarrollo_unicah.CLASES
{

    internal class CONEXION_BD
    {
        public static string ConexionServidor = "DATA SOURCE= Servidor de SQL Local; Integrated Security=True"; 
        public static string conexionBDD = "DATA SOURCE= Servidor de SQL Local; Initial Catalog=Supervision_Unicah; Integrated Security=True";

        public static SqlConnection conectarServidor = new SqlConnection(ConexionServidor);
        public static SqlConnection conectarBDD = new SqlConnection(conexionBDD);

        public static bool ConexionPerdida(Form MiForm)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                MessageBox.Show(
                    "No hay conexión de red. Se requiere de Internet para trabajar en el programa",
                    "Sin conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                if (MiForm is Form1)
                    return false;
                else
                {
                    // No existe: creas uno nuevo
                    Form Login = new Form1();
                    Login.Show();
                    MiForm.Close();
                }
                return false;
            }
            return true;
        }
        public CONEXION_BD() 
        {
        }
    }
}


