

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
        public static string ConexionServidor = "Server=tcp:mssql-193001-0.cloudclusters.net,10058;User ID=BD;Password=Changeme00!+;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";
        public static string conexionBDD = "Server=tcp:mssql-193001-0.cloudclusters.net,10058;Initial Catalog=Supervision_Unicah;User ID=BD;Password=Changeme00!+;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;";

        public static SqlConnection conectarServidor = new SqlConnection(ConexionServidor);
        public static SqlConnection conectarBDD = new SqlConnection(conexionBDD);
    

        public CONEXION_BD() 
        {
        }
    }
}


