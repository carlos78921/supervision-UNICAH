using ClosedXML.Excel;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_ADMIN;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreyectoDesarrollo_unicah
{
    public partial class frmMigracion : Form
    {
        public frmMigracion()
        {
            InitializeComponent();
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmMigraci�n_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.Persona();

            mesAdmin.MinDate = dtpInicio.Value;
            ACCIONES_BD.Periodo(dtpInicio, dtpFin, btnPeriodo, mesAdmin);
            ACCIONES_BD.tablaAdmin(dgvAdmin);
            if (dgvAdmin.Rows.Count > 0)
                ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, (string)dgvAdmin.CurrentRow.Cells[0].Value, (string)dgvAdmin.CurrentRow.Cells[1].Value, (string)dgvAdmin.CurrentRow.Cells[2].Value, (string)dgvAdmin.CurrentRow.Cells[3].Value, (string)dgvAdmin.CurrentRow.Cells[4].Value);
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {
            DateTime inicio = dtpInicio.Value;
            DateTime fin = dtpFin.Value;

            // Establecer el rango en el calendario
            mesAdmin.MinDate = inicio;
            mesAdmin.MaxDate = fin;

            if (inicio.Date == DateTime.Now.Date)
                if (MessageBox.Show("�Seguro que quiere definir el inicio hoy?" +
                "\nNo podr� definir de nuevo si no es el que desea", "Iniciar Periodo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ACCIONES_BD.CrearPeriodo(inicio, fin);
                    dtpInicio.Enabled = false;
                    dtpFin.Enabled = false;
                    btnPeriodo.Enabled = false;
                }
            if (inicio.Date != DateTime.Now.Date)
                ACCIONES_BD.CrearPeriodo(inicio, fin);
        }

        private void Salir(object sender, EventArgs e)
        {
            this.Close();
            frmAdmin Admin = new frmAdmin();
            Admin.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dgvAdmin_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvAdmin.CurrentRow != null)
            {
                string refiero = dgvAdmin.CurrentRow.Cells[0].Value.ToString();
                string curso = dgvAdmin.CurrentRow.Cells[1].Value.ToString();
                string seccion = dgvAdmin.CurrentRow.Cells[2].Value.ToString();
                string aula = dgvAdmin.CurrentRow.Cells[3].Value.ToString();
                string empleo = dgvAdmin.CurrentRow.Cells[4].Value.ToString();

                mesAdmin.RemoveAllBoldedDates();

                ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, refiero, curso, seccion, aula, empleo);
            }

        }

        private void mesAdmin_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start;

            DateTime fechaInicio = dtpInicio.Value;
            int offsetDias = (fechaSeleccionada - fechaInicio).Days;
            int indiceSemana = offsetDias / 7;
            int indiceParcial = indiceSemana / 4;
            int parcial = indiceParcial + 1; int semanaEnParcial = (indiceSemana % 4) + 1;
            lblParcial.Text = $"Parcial {parcial}";
            lblWeek.Text = $"Semana {semanaEnParcial}";
        }

        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnSQL_Click(object sender, EventArgs e)
        {
            ACCIONES_BD.MigrarDatosNuevo();
            ACCIONES_BD.tablaAdmin(dgvAdmin);
            if (dgvAdmin.Rows.Count > 0)
                ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, (string)dgvAdmin.CurrentRow.Cells[0].Value, (string)dgvAdmin.CurrentRow.Cells[1].Value, (string)dgvAdmin.CurrentRow.Cells[2].Value, (string)dgvAdmin.CurrentRow.Cells[3].Value, (string)dgvAdmin.CurrentRow.Cells[4].Value);
        }

        private static void RespaldoExcel()
        {
            DataTable dt = ACCIONES_BD.RespaldoBDD();

            using (var wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt, "Asistencia");

                using (var sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo Excel (*.xlsx)|*.xlsx";
                    sfd.Title = "Guardar respaldo de Asistencia";
                    sfd.FileName = "Respaldo_Asistencia.xlsx";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show(
                                "Respaldo guardado correctamente.",
                                "Respaldo exitoso",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information
                            );
                        }
                        catch (Exception ex)
                        {
                            // �Es un bloqueo por "being used by another process"?
                            if (ex is IOException ||
                                ex is Win32Exception ||
                                ex.Message.Contains("being used by another process"))
                                MessageBox.Show("Por favor cerrar el archivo seleccionado para guardar", "Interrupci�n de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
        }

        private void btnReinicioBDD_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("�Est� seguro de que desea reiniciar la base de datos?\nEste acto har� que salga por completo del programa para iniciar de nuevo sus datos", "Reinicio de BDD", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show("�Desea guardar las asistencias antes del reinicio?", "Guardar Asistencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RespaldoExcel();
                    ACCIONES_BD.ReiniciarBDD("Supervision_Unicah");
                }
                else              
                    ACCIONES_BD.ReiniciarBDD("Supervision_Unicah");                                    
                MessageBox.Show("Base de datos reiniciada exitosamente.", "�xito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Saliendo del programa", "Cerrando Programa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
        }

        private void btnListaLoad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Seleccione el archivo Excel original", "Excel original");
            ACCIONES_BD.MigrarDatosViejo();
            MessageBox.Show("Ahora seleccione el archivo Excel con la asistencia", "Cargar Asistencia");
            string rutaExcel = ""; 
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos Excel (*.xlsx)|*.xlsx";
                ofd.Title = "Seleccionar archivo Excel";
                var dr = ofd.ShowDialog();
                if (dr != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    rutaExcel = ofd.FileName;

                    string Excel = System.IO.Path.GetExtension(rutaExcel);
                    if (string.IsNullOrEmpty(Excel))
                    {
                        return;
                    }
                }
            }

            string tempFile = System.IO.Path.Combine(
                                      System.IO.Path.GetTempPath(),
                                      Guid.NewGuid().ToString() + ".xlsx"
                                      );
            try
            {
                File.Copy(rutaExcel, tempFile, overwrite: true);
                DataTable dtLista = ACCIONES_BD.CrearDatos(tempFile, "Asistencia");

                using (var conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
                {
                    conn.Open();

                    using (var cmd = new SqlCommand("PA_CargaRespaldo", conn))
                    {
                        foreach (DataRow row in dtLista.Rows)
                        {
                            cmd.Parameters.Clear();

                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID_Clase", row["ID_Clase"]);
                            cmd.Parameters.AddWithValue("@ID_Sitio", row["ID_Sitio"]);
                            cmd.Parameters.AddWithValue("@ID_Empleado", row["ID_Empleado"]);
                            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = row.Field<DateTime>("Fecha"); 
                            cmd.Parameters.AddWithValue("@Observa", row["Observacion"]);
                            if (row.IsNull("Fecha_Reposicion"))
                                cmd.Parameters.Add("@Repone", SqlDbType.Date).Value = DBNull.Value;
                            else
                                cmd.Parameters.Add("@Repone", SqlDbType.Date).
                                Value = row.Field<DateTime>("Fecha_Reposicion");
                            cmd.Parameters.Add("@Marca", SqlDbType.Bit)
                               .Value = row.Field<bool>("Presente");

                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            finally
            {
                try { File.Delete(tempFile); }
                catch { }
            }
            ACCIONES_BD.tablaAdmin(dgvAdmin);
            ACCIONES_BD.CargarAsistenciaAdmin(mesAdmin, (string)dgvAdmin.CurrentRow.Cells[0].Value, (string)dgvAdmin.CurrentRow.Cells[1].Value, (string)dgvAdmin.CurrentRow.Cells[2].Value, (string)dgvAdmin.CurrentRow.Cells[3].Value, (string)dgvAdmin.CurrentRow.Cells[4].Value);
            dgvAdmin.Refresh();
        }

        private void btnListaSave_Click(object sender, EventArgs e)
        {
            RespaldoExcel();
        }
    }
}