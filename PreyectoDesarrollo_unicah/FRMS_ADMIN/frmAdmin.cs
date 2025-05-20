using ClosedXML.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using PreyectoDesarrollo_unicah.CLASES;
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
    public partial class frmAdmin : Form
    {
        public frmAdmin()
        {
            InitializeComponent();
            dgvAdmin.ShowCellToolTips = false;
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void frmMigración_Load(object sender, EventArgs e)
        {
            lblPersona.Text = ACCIONES_BD.Persona();

            mesAdmin.MinDate = dtpInicio.Value;
            ACCIONES_BD.Periodo(dtpInicio, dtpFin, btnPeriodo, mesAdmin);
            ACCIONES_BD.tablaAdmin(dgvAdmin);
        }

        private void btnPeriodo_Click(object sender, EventArgs e)
        {

            if (!CONEXION_BD.ConexionPerdida(this))
                return;
            DateTime inicio = dtpInicio.Value;
            DateTime fin = dtpFin.Value;

            if (inicio > fin)
            {
                MessageBox.Show("La fecha de inicio no puede ser mayor a la fecha de fin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (inicio.Date == DateTime.Now.Date)
            {
                if (MessageBox.Show("¿Seguro que quiere definir el inicio hoy?" +
                "\nNo podrá definir de nuevo si no es el que desea", "Iniciar Periodo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    ACCIONES_BD.CrearPeriodo(inicio, fin);
                    dtpInicio.Enabled = false;
                    dtpFin.Enabled = false;
                    btnPeriodo.Enabled = false;
                    return;
                }
            }
            else
                ACCIONES_BD.CrearPeriodo(inicio, fin);

            //Ya se puede  el rango en el calendario
            mesAdmin.MinDate = inicio;
            mesAdmin.MaxDate = fin;
        }

        private void Salir(object sender, EventArgs e)
        {
            DialogResult opcion = MessageBox.Show("¿Desea guardar las asistencias actuales antes de cerrar sesión?\nPresione <<Cancelar>> para mantener sesión abierta", "Guardar Asistencia Antes de Salir", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
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
                Form1 Login = new Form1();
                Login.Show();
            }
            if (opcion == DialogResult.Cancel)
            {
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void mesAdmin_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime fechaSeleccionada = e.Start;

            DateTime fechaInicio = dtpInicio.Value;
            int offsetDias = (fechaSeleccionada - fechaInicio).Days;
            int indiceSemana = offsetDias / 7;
            int indiceParcial = indiceSemana / 4;
            int parcial = indiceParcial + 1;
            int semanaEnParcial = (indiceSemana % 4) + 1;
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
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            ACCIONES_BD.MigrarDatosNuevo();
            ACCIONES_BD.tablaAdmin(dgvAdmin);
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

        private void btnReinicioBDD_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;
            if (MessageBox.Show("¿Está seguro de que desea reiniciar la base de datos?\nEste acto hará que cierre sesión sin datos", "Reinicio de BDD", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (MessageBox.Show("¿Desea guardar las asistencias antes del reinicio?", "Guardar Asistencias", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RespaldoExcel();
                    ACCIONES_BD.ReiniciarBDD("Supervision_Unicah");
                }
                else
                    ACCIONES_BD.ReiniciarBDD("Supervision_Unicah");
                MessageBox.Show("Base de datos reiniciada exitosamente.", "éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Cerrando Sesión", "Cierre de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 Login = new Form1();
                Login.Show();
                this.Close();
            }
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
            ACCIONES_BD.tablaAdmin(dgvAdmin);
            dgvAdmin.Refresh();
        }

        private void btnListaSave_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            RespaldoExcel();
        }

        private void btnName_Click(object sender, EventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            TextBox valido = new TextBox();

            switch (dgvAdmin.CurrentCell.ColumnIndex)
            {
                case 1:
                    valido.Text = dgvAdmin.CurrentRow.Cells[1].Value.ToString();
                    if (!Validaciones.ValeAdmin(valido.Text, 1))
                    {
                        dgvAdmin.Enabled = true;
                        dgvAdmin.Focus();
                        dgvAdmin.BeginEdit(true);
                        return;
                    }
                    break;
                case 2:
                    valido.Text = dgvAdmin.CurrentRow.Cells[2].Value.ToString();
                    if (!Validaciones.ValeAdmin(valido.Text, 2))
                    {
                        dgvAdmin.Enabled = true;
                        dgvAdmin.Focus();
                        dgvAdmin.BeginEdit(true);
                        return;
                    }
                    break;
                case 3:
                    valido.Text = dgvAdmin.CurrentRow.Cells[3].Value.ToString();
                    if (!Validaciones.ValeAdmin(valido.Text, 3))
                    {
                        dgvAdmin.Enabled = true;
                        dgvAdmin.Focus();
                        dgvAdmin.BeginEdit(true);
                        return;
                    }
                    break;
                case 4:
                    valido.Text = dgvAdmin.CurrentRow.Cells[4].Value.ToString();
                    if (!Validaciones.Usuario(sender, e, valido.Text, "4", valido))
                    {
                        dgvAdmin.Enabled = true;
                        dgvAdmin.Focus();
                        dgvAdmin.BeginEdit(true);
                        return;
                    }
                    break;
                case 5:
                    valido.Text = dgvAdmin.CurrentRow.Cells[5].Value.ToString();
                    if (!Validaciones.Contraseña(sender, e, "", valido.Text, this, null, null, ""))
                    {
                        dgvAdmin.Enabled = true;
                        dgvAdmin.Focus();
                        dgvAdmin.BeginEdit(true);
                        return;
                    }
                    break;
            }

            using (var conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Datos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    for (int row = 0; row < dgvAdmin.Rows.Count; row++)
                    {
                        cmd.Parameters.Clear(); //Evita error de parámetros
                        cmd.Parameters.AddWithValue("@ID", dgvAdmin.Rows[row].Cells[0].Value);
                        cmd.Parameters.AddWithValue("@Nombre", dgvAdmin.Rows[row].Cells[1].Value);
                        cmd.Parameters.AddWithValue("@Apellido", dgvAdmin.Rows[row].Cells[2].Value);
                        cmd.Parameters.AddWithValue("@rol", dgvAdmin.Rows[row].Cells[3].Value);
                        cmd.Parameters.AddWithValue("@usuario", dgvAdmin.Rows[row].Cells[4].Value);
                        cmd.Parameters.AddWithValue("@Contraseña", dgvAdmin.Rows[row].Cells[5].Value.ToString().Trim());
                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();
            }
            MessageBox.Show("Datos del usuario actualizado en la base de datos", "Datos cambiados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnSQL.Enabled = true;
            btnListaSave.Enabled = true;
            btnListaLoad.Enabled = true;
            btnReinicioBDD.Enabled = true;
            dgvAdmin.Enabled = true; //Para que se pueda editar después de guardar
        }

        private void dgvAdmin_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5 && e.Value != null) //Al cargar el formulario, se observa el texto de contraseña cubierta con asteríscos
            {
                e.Value = new string('*', e.Value.ToString().Length);
                e.FormattingApplied = true; //Esto para no afectar después por "contra" como valor sin asterísco
            }
        }

        private void dgvAdmin_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is TextBox celdatxt)
            {
//                nombres.KeyPress -= Nombres_KeyPress; Cuestión de seguridad para desvinculación en uso del método
                int celda = dgvAdmin.CurrentCell.ColumnIndex;
                if (celda >= 1 && celda <= 5)
                    celdatxt.KeyPress += Celda_KeyPress;
            }

            if (dgvAdmin.CurrentCell.ColumnIndex == 5)
            {
                TextBox txtContra = e.Control as TextBox;
                if (txtContra != null)
                    txtContra.UseSystemPasswordChar = true;
            }
        }

        private void Celda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (dgvAdmin.CurrentCell.ColumnIndex < 3)
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && !"áéíóúÁÉÍÓÚüÜ'".Contains(e.KeyChar))
                    e.Handled = true;
            if (dgvAdmin.CurrentCell.ColumnIndex == 3)
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            if (dgvAdmin.CurrentCell.ColumnIndex == 4)
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
            if (dgvAdmin.CurrentCell.ColumnIndex == 5)
                if (!char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != (char)Keys.Back)
                    e.Handled = true;
        }

        private void txtBusca_KeyDown(object sender, KeyEventArgs e)
        {
            if (!CONEXION_BD.ConexionPerdida(this))
                return;

            using (var conn = new SqlConnection(CONEXION_BD.conectarBDD.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("PA_Admin_Busca", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Dato", txtBusca.Text);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAdmin.DataSource = dt;
                }
                conn.Close();
            }
        }

        private void dgvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAdmin.Columns[e.ColumnIndex].Name == "Contraseña")
            {
                if (MessageBox.Show("¿Desea cambiar la contraseña?", "Cambiar contraseña", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvAdmin.Columns[5].ReadOnly = false;
                    dgvAdmin.CurrentRow.Cells[5].Value = ""; //Con esto descartamos el problema que al actualizar, los valores sean asteríscos
                }
                else
                    dgvAdmin.Columns[5].ReadOnly = true;
            }
        }

        private void dgvAdmin_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string valorActual = dgvAdmin.Rows[e.RowIndex].Cells[4].Value.ToString();

            for (int i = 0; i < dgvAdmin.Rows.Count; i++)
            {
                if (i == e.RowIndex) continue; // Ignorar la misma fila

                string valorComparar = dgvAdmin.Rows[i].Cells[4].Value.ToString();

                if (!string.IsNullOrEmpty(valorComparar) && valorComparar.Equals(valorActual))
                {
                    MessageBox.Show($"Código existente entre fila actual {e.RowIndex + 1} con fila {i + 1}.\nPor favor cambiar código diferente", "Valor duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dgvAdmin.Rows[e.RowIndex].Cells[4].Value = "";
                    break; //Para el for
                }
            }

            // Aunque la edición se termine, este método ejecuta además para el DataGridView al enfocar
            // El administrador solo edita una celda por botón
            this.BeginInvoke((Action)(() =>
            {
                dgvAdmin.ClearSelection();
                dgvAdmin.CurrentCell = dgvAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvAdmin.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = true;
                dgvAdmin.RefreshEdit();
                dgvAdmin.Focus();
                dgvAdmin.Enabled = false;
                btnSQL.Enabled = false;
                btnListaSave.Enabled = false;
                btnListaLoad.Enabled = false;
                btnReinicioBDD.Enabled = false;
                MessageBox.Show("Haga clic en el botón de <<ACTUALIZAR DATOS EMPLEADO>> para validar su cambio", "Validar cambio", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }));
        }
    }
}