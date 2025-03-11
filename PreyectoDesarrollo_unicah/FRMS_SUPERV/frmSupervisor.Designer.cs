namespace PreyectoDesarrollo_unicah
{
    partial class frmSupervisor
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
            Button btnSalir;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            dgvDoc = new DataGridView();
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
            label7 = new Label();
            btnLogout = new Button();
            tmrFecha = new System.Windows.Forms.Timer(components);
            lblFecha = new Label();
            lblMeses = new Label();
            btnSalir = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).BeginInit();
            gbFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(0, 0);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(86, 31);
            btnSalir.TabIndex = 37;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(514, 3);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 28);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(554, 3);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 28);
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
            panel1.Location = new Point(-5, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(591, 116);
            panel1.TabIndex = 11;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(437, 84);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(163, 23);
            lblPersona.TabIndex = 23;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(239, 132);
            label1.Name = "label1";
            label1.Size = new Size(176, 20);
            label1.TabIndex = 12;
            label1.Text = "REPORTE DE ASISTENCIA";
            // 
            // dgvDoc
            // 
            dgvDoc.AllowUserToAddRows = false;
            dgvDoc.AllowUserToDeleteRows = false;
            dgvDoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoc.Columns.AddRange(new DataGridViewColumn[] { clmDoc, clmClase, clmSeccion, clmLunes, clmMartes, clmMiercoles, clmJueves, clmViernes, clmSabado });
            dgvDoc.Location = new Point(23, 296);
            dgvDoc.Margin = new Padding(3, 4, 3, 4);
            dgvDoc.Name = "dgvDoc";
            dgvDoc.ReadOnly = true;
            dgvDoc.RowHeadersWidth = 51;
            dgvDoc.Size = new Size(542, 288);
            dgvDoc.TabIndex = 17;
            // 
            // clmDoc
            // 
            clmDoc.HeaderText = "Docente";
            clmDoc.MinimumWidth = 6;
            clmDoc.Name = "clmDoc";
            clmDoc.ReadOnly = true;
            clmDoc.Width = 125;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.MinimumWidth = 6;
            clmClase.Name = "clmClase";
            clmClase.ReadOnly = true;
            clmClase.Width = 150;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.MinimumWidth = 6;
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
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
            clmMiercoles.HeaderText = "X";
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
            clmSabado.Resizable = DataGridViewTriState.True;
            clmSabado.SortMode = DataGridViewColumnSortMode.Automatic;
            clmSabado.Width = 20;
            // 
            // nudWeeks
            // 
            nudWeeks.Location = new Point(115, 247);
            nudWeeks.Margin = new Padding(3, 4, 3, 4);
            nudWeeks.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            nudWeeks.Name = "nudWeeks";
            nudWeeks.Size = new Size(56, 27);
            nudWeeks.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 252);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 22;
            label2.Text = "Semana:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(210, 173);
            label5.Name = "label5";
            label5.Size = new Size(83, 20);
            label5.TabIndex = 26;
            label5.Text = "Asignatura:";
            // 
            // txtClase
            // 
            txtClase.Location = new Point(294, 169);
            txtClase.Margin = new Padding(3, 4, 3, 4);
            txtClase.Name = "txtClase";
            txtClase.Size = new Size(191, 27);
            txtClase.TabIndex = 27;
            // 
            // btnBusca
            // 
            btnBusca.Location = new Point(493, 153);
            btnBusca.Margin = new Padding(3, 4, 3, 4);
            btnBusca.Name = "btnBusca";
            btnBusca.Size = new Size(86, 52);
            btnBusca.TabIndex = 28;
            btnBusca.Text = "&Buscar Asignatura";
            btnBusca.UseVisualStyleBackColor = true;
            // 
            // cmbHora
            // 
            cmbHora.FormattingEnabled = true;
            cmbHora.Items.AddRange(new object[] { "Sección:" });
            cmbHora.Location = new Point(265, 29);
            cmbHora.Margin = new Padding(3, 4, 3, 4);
            cmbHora.Name = "cmbHora";
            cmbHora.Size = new Size(97, 28);
            cmbHora.TabIndex = 30;
            // 
            // cmbAula
            // 
            cmbAula.FormattingEnabled = true;
            cmbAula.Items.AddRange(new object[] { "Aula:" });
            cmbAula.Location = new Point(149, 29);
            cmbAula.Margin = new Padding(3, 4, 3, 4);
            cmbAula.Name = "cmbAula";
            cmbAula.Size = new Size(97, 28);
            cmbAula.TabIndex = 31;
            // 
            // cmbEdificio
            // 
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Items.AddRange(new object[] { "Edificio:" });
            cmbEdificio.Location = new Point(31, 29);
            cmbEdificio.Margin = new Padding(3, 4, 3, 4);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(97, 28);
            cmbEdificio.TabIndex = 32;
            // 
            // gbFiltro
            // 
            gbFiltro.Controls.Add(cmbEdificio);
            gbFiltro.Controls.Add(cmbHora);
            gbFiltro.Controls.Add(cmbAula);
            gbFiltro.Location = new Point(208, 209);
            gbFiltro.Margin = new Padding(3, 4, 3, 4);
            gbFiltro.Name = "gbFiltro";
            gbFiltro.Padding = new Padding(3, 4, 3, 4);
            gbFiltro.Size = new Size(370, 73);
            gbFiltro.TabIndex = 33;
            gbFiltro.TabStop = false;
            gbFiltro.Text = "Filtros";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 159);
            label6.Name = "label6";
            label6.Size = new Size(153, 20);
            label6.TabIndex = 34;
            label6.Text = "Nombre y/o apellido ";
            // 
            // txtDoc
            // 
            txtDoc.Location = new Point(49, 204);
            txtDoc.Margin = new Padding(3, 4, 3, 4);
            txtDoc.Name = "txtDoc";
            txtDoc.Size = new Size(134, 27);
            txtDoc.TabIndex = 35;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(74, 180);
            label7.Name = "label7";
            label7.Size = new Size(91, 20);
            label7.TabIndex = 36;
            label7.Text = "del docente:";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(473, 592);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(98, 31);
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
            // lblFecha
            // 
            lblFecha.AutoSize = true;
            lblFecha.Location = new Point(507, 123);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(51, 20);
            lblFecha.TabIndex = 40;
            lblFecha.Text = "Fecha ";
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(7, 123);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(60, 20);
            lblMeses.TabIndex = 41;
            lblMeses.Text = "Periodo";
            lblMeses.Visible = false;
            // 
            // frmSupervisor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 633);
            Controls.Add(lblMeses);
            Controls.Add(lblFecha);
            Controls.Add(btnLogout);
            Controls.Add(label7);
            Controls.Add(txtDoc);
            Controls.Add(label6);
            Controls.Add(gbFiltro);
            Controls.Add(btnBusca);
            Controls.Add(txtClase);
            Controls.Add(label5);
            Controls.Add(nudWeeks);
            Controls.Add(label2);
            Controls.Add(dgvDoc);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmSupervisor";
            Text = "FrmReporte";
            Load += FrmReporte_Load;
            MouseDown += frmSupervisor_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).EndInit();
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
        private DataGridView dgvDoc;
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
        private Label label7;
        private Button btnLogout;
        private System.Windows.Forms.Timer tmrFecha;
        private Label lblFecha;
        private Label lblMeses;
        private DataGridViewTextBoxColumn clmDoc;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewCheckBoxColumn clmLunes;
        private DataGridViewCheckBoxColumn clmMartes;
        private DataGridViewCheckBoxColumn clmMiercoles;
        private DataGridViewCheckBoxColumn clmJueves;
        private DataGridViewCheckBoxColumn clmViernes;
        private DataGridViewCheckBoxColumn clmSabado;
    }
}
