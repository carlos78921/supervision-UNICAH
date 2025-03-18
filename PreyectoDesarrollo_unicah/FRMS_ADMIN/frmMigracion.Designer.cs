namespace PreyectoDesarrollo_unicah
{
    partial class frmMigracion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Button btnLogout;
            Button btnExcel;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            dgvAdmin = new DataGridView();
            clmAsignaturaFacu = new DataGridViewTextBoxColumn();
            clmCurso = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmAulaFull = new DataGridViewTextBoxColumn();
            clmEmpleado = new DataGridViewTextBoxColumn();
            clmLunes = new DataGridViewCheckBoxColumn();
            clmMartes = new DataGridViewCheckBoxColumn();
            clmMiercoles = new DataGridViewCheckBoxColumn();
            clmJueves = new DataGridViewCheckBoxColumn();
            clmViernes = new DataGridViewCheckBoxColumn();
            clmSabado = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            lblPeriodo = new Label();
            lblWeek = new Label();
            btnLogout = new Button();
            btnExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdmin).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(904, 413);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(126, 29);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "&CERRAR SESIÓN";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(790, 407);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(108, 42);
            btnExcel.TabIndex = 15;
            btnExcel.Text = "&EXPORTAR A EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(980, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(1015, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(lblPersona);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1047, 87);
            panel1.TabIndex = 11;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(912, 63);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 16;
            lblPersona.Text = "Nombre_Persona";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources.CircularFondoAzul;
            pictureBox3.Location = new Point(-25, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 81);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // dgvAdmin
            // 
            dgvAdmin.AllowUserToAddRows = false;
            dgvAdmin.AllowUserToDeleteRows = false;
            dgvAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdmin.Columns.AddRange(new DataGridViewColumn[] { clmAsignaturaFacu, clmCurso, clmSeccion, clmAulaFull, clmEmpleado, clmLunes, clmMartes, clmMiercoles, clmJueves, clmViernes, clmSabado });
            dgvAdmin.Location = new Point(13, 124);
            dgvAdmin.Name = "dgvAdmin";
            dgvAdmin.ReadOnly = true;
            dgvAdmin.Size = new Size(1017, 268);
            dgvAdmin.TabIndex = 13;
            // 
            // clmAsignaturaFacu
            // 
            clmAsignaturaFacu.HeaderText = "Referencia";
            clmAsignaturaFacu.Name = "clmAsignaturaFacu";
            clmAsignaturaFacu.ReadOnly = true;
            clmAsignaturaFacu.Width = 115;
            // 
            // clmCurso
            // 
            clmCurso.HeaderText = "Curso";
            clmCurso.Name = "clmCurso";
            clmCurso.ReadOnly = true;
            clmCurso.Width = 170;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
            // 
            // clmAulaFull
            // 
            clmAulaFull.HeaderText = "Aula";
            clmAulaFull.Name = "clmAulaFull";
            clmAulaFull.ReadOnly = true;
            clmAulaFull.Width = 183;
            // 
            // clmEmpleado
            // 
            clmEmpleado.HeaderText = "Empleado";
            clmEmpleado.Name = "clmEmpleado";
            clmEmpleado.ReadOnly = true;
            clmEmpleado.Width = 325;
            // 
            // clmLunes
            // 
            clmLunes.HeaderText = "L";
            clmLunes.Name = "clmLunes";
            clmLunes.ReadOnly = true;
            clmLunes.Width = 20;
            // 
            // clmMartes
            // 
            clmMartes.HeaderText = "M";
            clmMartes.Name = "clmMartes";
            clmMartes.ReadOnly = true;
            clmMartes.Width = 22;
            // 
            // clmMiercoles
            // 
            clmMiercoles.HeaderText = "X";
            clmMiercoles.Name = "clmMiercoles";
            clmMiercoles.ReadOnly = true;
            clmMiercoles.Width = 22;
            // 
            // clmJueves
            // 
            clmJueves.HeaderText = "J";
            clmJueves.Name = "clmJueves";
            clmJueves.ReadOnly = true;
            clmJueves.Width = 20;
            // 
            // clmViernes
            // 
            clmViernes.HeaderText = "V";
            clmViernes.Name = "clmViernes";
            clmViernes.ReadOnly = true;
            clmViernes.Width = 20;
            // 
            // clmSabado
            // 
            clmSabado.HeaderText = "S";
            clmSabado.Name = "clmSabado";
            clmSabado.ReadOnly = true;
            clmSabado.Width = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(453, 99);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 12;
            label1.Text = "MIGRACIÓN DE DATOS";
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new Point(30, 413);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(48, 15);
            lblPeriodo.TabIndex = 16;
            lblPeriodo.Text = "Periodo";
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Location = new Point(97, 413);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(49, 15);
            lblWeek.TabIndex = 17;
            lblWeek.Text = "Semana";
            // 
            // frmMigración
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1042, 454);
            Controls.Add(lblWeek);
            Controls.Add(lblPeriodo);
            Controls.Add(btnExcel);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(dgvAdmin);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMigración";
            Text = "FrmReporte";
            Load += frmMigración_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdmin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private DataGridView dgvAdmin;
        private Label label1;
        private Label lblPersona;
        private Label lblPeriodo;
        private Label lblWeek;
        private DataGridViewTextBoxColumn clmAsignaturaFacu;
        private DataGridViewTextBoxColumn clmCurso;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewTextBoxColumn clmAulaFull;
        private DataGridViewTextBoxColumn clmEmpleado;
        private DataGridViewCheckBoxColumn clmLunes;
        private DataGridViewCheckBoxColumn clmMartes;
        private DataGridViewCheckBoxColumn clmMiercoles;
        private DataGridViewCheckBoxColumn clmJueves;
        private DataGridViewCheckBoxColumn clmViernes;
        private DataGridViewCheckBoxColumn clmSabado;
    }
}