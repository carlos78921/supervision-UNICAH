﻿namespace PreyectoDesarrollo_unicah
{
    partial class frmAsistencia
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
            components = new System.ComponentModel.Container();
            btnSalir = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            dgvAsiste = new DataGridView();
            clmDoc = new DataGridViewTextBoxColumn();
            clmClase = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmLunes = new DataGridViewCheckBoxColumn();
            clmMartes = new DataGridViewCheckBoxColumn();
            clmMiercoles = new DataGridViewCheckBoxColumn();
            clmJueves = new DataGridViewCheckBoxColumn();
            clmViernes = new DataGridViewCheckBoxColumn();
            clmSabado = new DataGridViewCheckBoxColumn();
            nudWeeks = new NumericUpDown();
            label2 = new Label();
            label5 = new Label();
            txtClase = new TextBox();
            btnBusca = new Button();
            cmbHora = new ComboBox();
            cmbAula = new ComboBox();
            cmbEdificio = new ComboBox();
            gbFiltro = new GroupBox();
            label6 = new Label();
            txtDoc = new TextBox();
            btnLogout = new Button();
            tmrFecha = new System.Windows.Forms.Timer(components);
            lblMeses = new Label();
            lblFecha = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsiste).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).BeginInit();
            gbFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(0, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 37;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(450, 2);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(485, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 21);
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
            panel1.Size = new Size(517, 87);
            panel1.TabIndex = 11;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(382, 63);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 23;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(209, 99);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
            label1.TabIndex = 12;
            label1.Text = "TOMA DE ASISTENCIA";
            // 
            // dgvAsiste
            // 
            dgvAsiste.AllowUserToAddRows = false;
            dgvAsiste.AllowUserToDeleteRows = false;
            dgvAsiste.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAsiste.Columns.AddRange(new DataGridViewColumn[] { clmDoc, clmClase, clmSeccion, clmLunes, clmMartes, clmMiercoles, clmJueves, clmViernes, clmSabado });
            dgvAsiste.Location = new Point(20, 222);
            dgvAsiste.Name = "dgvAsiste";
            dgvAsiste.Size = new Size(474, 216);
            dgvAsiste.TabIndex = 17;
            dgvAsiste.CellContentClick += dgvAsiste_CellContentClick;
            // 
            // clmDoc
            // 
            clmDoc.HeaderText = "Docente";
            clmDoc.Name = "clmDoc";
            clmDoc.ReadOnly = true;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.Name = "clmClase";
            clmClase.ReadOnly = true;
            clmClase.Width = 150;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
            // 
            // clmLunes
            // 
            clmLunes.HeaderText = "L";
            clmLunes.Name = "clmLunes";
            clmLunes.Width = 20;
            // 
            // clmMartes
            // 
            clmMartes.HeaderText = "M";
            clmMartes.Name = "clmMartes";
            clmMartes.Width = 22;
            // 
            // clmMiercoles
            // 
            clmMiercoles.HeaderText = "X";
            clmMiercoles.Name = "clmMiercoles";
            clmMiercoles.Width = 22;
            // 
            // clmJueves
            // 
            clmJueves.HeaderText = "J";
            clmJueves.Name = "clmJueves";
            clmJueves.Width = 20;
            // 
            // clmViernes
            // 
            clmViernes.HeaderText = "V";
            clmViernes.Name = "clmViernes";
            clmViernes.Width = 20;
            // 
            // clmSabado
            // 
            clmSabado.HeaderText = "S";
            clmSabado.Name = "clmSabado";
            clmSabado.Resizable = DataGridViewTriState.True;
            clmSabado.SortMode = DataGridViewColumnSortMode.Automatic;
            clmSabado.Width = 20;
            // 
            // nudWeeks
            // 
            nudWeeks.Location = new Point(101, 185);
            nudWeeks.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudWeeks.Name = "nudWeeks";
            nudWeeks.Size = new Size(49, 23);
            nudWeeks.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(43, 189);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 22;
            label2.Text = "Semana:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(184, 130);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 26;
            label5.Text = "Asignatura:";
            // 
            // txtClase
            // 
            txtClase.Location = new Point(257, 127);
            txtClase.Name = "txtClase";
            txtClase.Size = new Size(168, 23);
            txtClase.TabIndex = 27;
            // 
            // btnBusca
            // 
            btnBusca.Location = new Point(431, 115);
            btnBusca.Name = "btnBusca";
            btnBusca.Size = new Size(75, 39);
            btnBusca.TabIndex = 28;
            btnBusca.Text = "&Buscar Asignatura";
            btnBusca.UseVisualStyleBackColor = true;
            // 
            // cmbHora
            // 
            cmbHora.FormattingEnabled = true;
            cmbHora.Items.AddRange(new object[] { "Sección:" });
            cmbHora.Location = new Point(232, 22);
            cmbHora.Name = "cmbHora";
            cmbHora.Size = new Size(85, 23);
            cmbHora.TabIndex = 30;
            // 
            // cmbAula
            // 
            cmbAula.FormattingEnabled = true;
            cmbAula.Items.AddRange(new object[] { "Aula:" });
            cmbAula.Location = new Point(130, 22);
            cmbAula.Name = "cmbAula";
            cmbAula.Size = new Size(85, 23);
            cmbAula.TabIndex = 31;
            // 
            // cmbEdificio
            // 
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Items.AddRange(new object[] { "Edificio:" });
            cmbEdificio.Location = new Point(27, 22);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(85, 23);
            cmbEdificio.TabIndex = 32;
            // 
            // gbFiltro
            // 
            gbFiltro.Controls.Add(cmbEdificio);
            gbFiltro.Controls.Add(cmbHora);
            gbFiltro.Controls.Add(cmbAula);
            gbFiltro.Location = new Point(182, 157);
            gbFiltro.Name = "gbFiltro";
            gbFiltro.Size = new Size(324, 55);
            gbFiltro.TabIndex = 33;
            gbFiltro.TabStop = false;
            gbFiltro.Text = "Filtros";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(43, 119);
            label6.Name = "label6";
            label6.Size = new Size(120, 30);
            label6.TabIndex = 34;
            label6.Text = "Nombre y/o apellido \r\n         del docente";
            // 
            // txtDoc
            // 
            txtDoc.Location = new Point(43, 153);
            txtDoc.Name = "txtDoc";
            txtDoc.Size = new Size(118, 23);
            txtDoc.TabIndex = 35;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(414, 444);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(86, 23);
            btnLogout.TabIndex = 38;
            btnLogout.Text = "Cerrar &Sesión";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // tmrFecha
            // 
            tmrFecha.Enabled = true;
            tmrFecha.Tick += tmrFecha_Tick;
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(6, 92);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(48, 15);
            lblMeses.TabIndex = 41;
            lblMeses.Text = "Periodo";
            lblMeses.Visible = false;
            // 
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(444, 92);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(41, 15);
            lblFecha.TabIndex = 40;
            lblFecha.Text = "Fecha ";
            // 
            // frmReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 475);
            Controls.Add(lblMeses);
            Controls.Add(lblFecha);
            Controls.Add(btnLogout);
            Controls.Add(txtDoc);
            Controls.Add(label6);
            Controls.Add(gbFiltro);
            Controls.Add(btnBusca);
            Controls.Add(txtClase);
            Controls.Add(label5);
            Controls.Add(nudWeeks);
            Controls.Add(label2);
            Controls.Add(dgvAsiste);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReporte";
            Text = "FrmReporte";
            Load += FrmReporte_Load;
            MouseDown += frmSupervisor_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsiste).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).EndInit();
            gbFiltro.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label1;
        private DataGridView dgvAsiste;
        private Label lblPersona;
        private NumericUpDown nudWeeks;
        private Label label2;
        private Label label5;
        private TextBox txtClase;
        private Button btnBusca;
        private Label label6;
        private ComboBox cmbHora;
        private ComboBox cmbAula;
        private ComboBox cmbEdificio;
        private GroupBox gbFiltro;
        private TextBox txtDoc;
        private Button btnLogout;
        private System.Windows.Forms.Timer tmrFecha;
        private Label lblMeses;
        private Label lblFecha;
        private DataGridViewTextBoxColumn clmDoc;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewCheckBoxColumn clmLunes;
        private DataGridViewCheckBoxColumn clmMartes;
        private DataGridViewCheckBoxColumn clmMiercoles;
        private DataGridViewCheckBoxColumn clmJueves;
        private DataGridViewCheckBoxColumn clmViernes;
        private DataGridViewCheckBoxColumn clmSabado;
        private Button btnSalir;
    }
}