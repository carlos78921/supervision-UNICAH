namespace PreyectoDesarrollo_unicah
{
    partial class frmMigración
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
            btnLogout.Location = new Point(691, 551);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(144, 39);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "&CERRAR SESIÓN";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(561, 543);
            btnExcel.Margin = new Padding(3, 4, 3, 4);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(123, 56);
            btnExcel.TabIndex = 15;
            btnExcel.Text = "&EXPORTAR A EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(775, 1);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(815, 1);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(lblPersona);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-5, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(849, 116);
            panel1.TabIndex = 11;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(696, 85);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(163, 23);
            lblPersona.TabIndex = 16;
            lblPersona.Text = "Nombre_Persona";
            lblPersona.Click += lblPersona_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources.CircularFondoAzul;
            pictureBox3.Location = new Point(-29, 0);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(163, 108);
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
            dgvAdmin.Location = new Point(14, 165);
            dgvAdmin.Margin = new Padding(3, 4, 3, 4);
            dgvAdmin.Name = "dgvAdmin";
            dgvAdmin.ReadOnly = true;
            dgvAdmin.RowHeadersWidth = 51;
            dgvAdmin.Size = new Size(816, 357);
            dgvAdmin.TabIndex = 13;
            // 
            // clmAsignaturaFacu
            // 
            clmAsignaturaFacu.HeaderText = "Referencia";
            clmAsignaturaFacu.MinimumWidth = 6;
            clmAsignaturaFacu.Name = "clmAsignaturaFacu";
            clmAsignaturaFacu.ReadOnly = true;
            clmAsignaturaFacu.Width = 115;
            // 
            // clmCurso
            // 
            clmCurso.HeaderText = "Curso";
            clmCurso.MinimumWidth = 6;
            clmCurso.Name = "clmCurso";
            clmCurso.ReadOnly = true;
            clmCurso.Width = 150;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.MinimumWidth = 6;
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
            // 
            // clmAulaFull
            // 
            clmAulaFull.HeaderText = "Aula";
            clmAulaFull.MinimumWidth = 6;
            clmAulaFull.Name = "clmAulaFull";
            clmAulaFull.ReadOnly = true;
            clmAulaFull.Width = 125;
            // 
            // clmEmpleado
            // 
            clmEmpleado.HeaderText = "Empleado";
            clmEmpleado.MinimumWidth = 6;
            clmEmpleado.Name = "clmEmpleado";
            clmEmpleado.ReadOnly = true;
            clmEmpleado.Width = 125;
            // 
            // clmLunes
            // 
            clmLunes.HeaderText = "L";
            clmLunes.MinimumWidth = 6;
            clmLunes.Name = "clmLunes";
            clmLunes.ReadOnly = true;
            clmLunes.Width = 20;
            // 
            // clmMartes
            // 
            clmMartes.HeaderText = "M";
            clmMartes.MinimumWidth = 6;
            clmMartes.Name = "clmMartes";
            clmMartes.ReadOnly = true;
            clmMartes.Width = 22;
            // 
            // clmMiercoles
            // 
            clmMiercoles.HeaderText = "M";
            clmMiercoles.MinimumWidth = 6;
            clmMiercoles.Name = "clmMiercoles";
            clmMiercoles.ReadOnly = true;
            clmMiercoles.Width = 22;
            // 
            // clmJueves
            // 
            clmJueves.HeaderText = "J";
            clmJueves.MinimumWidth = 6;
            clmJueves.Name = "clmJueves";
            clmJueves.ReadOnly = true;
            clmJueves.Width = 20;
            // 
            // clmViernes
            // 
            clmViernes.HeaderText = "V";
            clmViernes.MinimumWidth = 6;
            clmViernes.Name = "clmViernes";
            clmViernes.ReadOnly = true;
            clmViernes.Width = 20;
            // 
            // clmSabado
            // 
            clmSabado.HeaderText = "S";
            clmSabado.MinimumWidth = 6;
            clmSabado.Name = "clmSabado";
            clmSabado.ReadOnly = true;
            clmSabado.Width = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(358, 135);
            label1.Name = "label1";
            label1.Size = new Size(163, 20);
            label1.TabIndex = 12;
            label1.Text = "MIGRACIÓN DE DATOS";
            // 
            // lblPeriodo
            // 
            lblPeriodo.AutoSize = true;
            lblPeriodo.Location = new Point(34, 551);
            lblPeriodo.Name = "lblPeriodo";
            lblPeriodo.Size = new Size(60, 20);
            lblPeriodo.TabIndex = 16;
            lblPeriodo.Text = "Periodo";
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Location = new Point(111, 551);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(62, 20);
            lblWeek.TabIndex = 17;
            lblWeek.Text = "Semana";
            // 
            // frmMigración
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(845, 605);
            Controls.Add(lblWeek);
            Controls.Add(lblPeriodo);
            Controls.Add(btnExcel);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(dgvAdmin);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmMigración";
            Text = "FrmReporte";
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
        private Label lblPeriodo;
        private Label lblWeek;
    }
}