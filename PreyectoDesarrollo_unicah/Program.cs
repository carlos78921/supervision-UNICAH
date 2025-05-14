using PreyectoDesarrollo_unicah.CLASES;

namespace PreyectoDesarrollo_unicah
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static string RolExe = "desconocido";

        [STAThread]
        static void Main(string[] args)
        {
            string Rol = Path.GetFileName(Application.ExecutablePath).ToLower();
            MessageBox.Show("Ejecutable detectado: " + Rol);

            if (Rol.Contains("administrador"))
                RolExe = "administrador";
            else if (Rol.Contains("supervisor"))
                RolExe = "supervisor";
            else if (Rol.Contains("decano"))
                RolExe = "decano";
            else if (Rol.Contains("docente"))
                RolExe = "docente";


            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}