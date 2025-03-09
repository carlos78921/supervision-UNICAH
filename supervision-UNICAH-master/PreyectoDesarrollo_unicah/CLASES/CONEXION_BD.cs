

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace PreyectoDesarrollo_unicah.CLASES
{

    internal class CONEXION_BD
    {

        string conexion = "DATA SOURCE = LAB7-9\\SQLEXPRESS2017; Initial Catalog=Supervision_Unicah; Integrated Security=True";
        public SqlConnection conectar = new SqlConnection();


        public CONEXION_BD()
        {
            conectar.ConnectionString = conexion;
        }

        

        public void abrir() //aqui se habre la conexion de la BDD
        {

            try
            {
                if (conectar.State == ConnectionState.Closed)
                {
                    conectar.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"ERROR AL ABRIR LA CONEXIÓN: {ex.Message}", "ERROR");  //captura los errores y los envia en un messagebox
            }

        }


        public void cerrar()    //aqui se cierra la conexion de la BDD
        {
            try {

                if (conectar.State == ConnectionState.Open)
                {
                   conectar.Close();
                }
            }
            catch (Exception ex)    
            {

                MessageBox.Show($"ERROR AL CERRAR LA CONEXIÓN: {ex.Message}", "ERROR"); //captura los errores y los envia en un messagebox
            }

        }
    }
}


