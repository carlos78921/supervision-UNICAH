using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using PreyectoDesarrollo_unicah.CLASES;
using PreyectoDesarrollo_unicah.FRMS_SUPERV;
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
    public partial class frmAsistencia : Form
    {
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture(); //Externo por la importación realizada en comando

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;

        public frmAsistencia()
        {
            InitializeComponent();
        }

        private void Cerrar(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Desea guardar las asistencias antes de cerrar sesión?\nPresione <<Cancelar>> para mantener sesión abierta", "Guardar Asistencia Antes de Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (opcion == DialogResult.Yes)
            {
                if (!RespaldoExcel())
                    return;
                this.Close();
                Form1 Login = new Form1();
                Login.Show();
            }
            if (opcion == DialogResult.No)
            {
                this.Close();
                frmSupervisor Menu = new frmSupervisor();
                Menu.Show();
            }
            if (opcion == DialogResult.Cancel)
                return;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FrmAsiste_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.Persona();

            dgvAsiste = (dgvAsiste as DataGridView);

            dgvAsiste.CurrentCellDirtyStateChanged += (s, ev)
            =>
            {
                if (dgvAsiste.IsCurrentCellDirty)
                    dgvAsiste.CommitEdit(DataGridViewDataErrorContexts.Commit);
            };

            ACCIONES_BD.tablaSupervisor(dgvAsiste);
        }


        private void MoveForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }

        private void Filtros(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;
            ACCIONES_BD.FiltrarDatosSuperv(txtDoc.Text, txtClase.Text, cmbAula.Text, cmbEdificio.Text, cmbSeccion.Text, dgvAsiste);
        }

        private void dgvAsiste_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var columna = dgvAsiste.Columns[e.ColumnIndex];
            if (columna.Name == "AsistenciaHoy")
            {
                var fila = dgvAsiste.Rows[e.RowIndex];

                string docente = fila.Cells[0].Value?.ToString();
                string asignatura = fila.Cells[1].Value?.ToString();
                string seccion = fila.Cells[2].Value?.ToString();
                string aula = fila.Cells[3].Value?.ToString();
                string edificio = fila.Cells[4].Value?.ToString();
                bool marca = Convert.ToBoolean(fila.Cells["AsistenciaHoy"].Value);

                ACCIONES_BD.RegistrarAsistencia(dgvAsiste, docente, asignatura, seccion, aula, edificio, marca);
            }
        }

        private void dgvAsiste_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAsiste.Columns[e.ColumnIndex].Name == "AsistenciaHoy" && e.RowIndex >= 0)
                dgvAsiste.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void btnListaSave_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            RespaldoExcel();
        }

        private static bool RespaldoExcel()
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

                            // ¿Es un bloqueo por "being used by another process"?
                            if (ex is IOException ||
                                ex is Win32Exception ||
                                ex.Message.Contains("being used by another process"))
                                MessageBox.Show("Por favor cerrar el archivo seleccionado para guardar", "Interrupción de Archivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnListaLoad_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

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
            ACCIONES_BD.tablaSupervisor(dgvAsiste);
            dgvAsiste.Refresh();
        }
    }
}
