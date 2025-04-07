namespace PreyectoDesarrollo_unicah
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
            clmAula = new DataGridViewTextBoxColumn();
            clmEdificio = new DataGridViewTextBoxColumn();
            clmFecha = new DataGridViewCheckBoxColumn();
            label5 = new Label();
            txtClase = new TextBox();
            cmbAula = new ComboBox();
            cmbEdificio = new ComboBox();
            gbFiltro = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            txtDoc = new TextBox();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsiste).BeginInit();
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
            pictureBox2.Location = new Point(937, 3);
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
            pictureBox1.Location = new Point(972, 3);
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
            panel1.Size = new Size(1003, 87);
            panel1.TabIndex = 11;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(869, 63);
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
            label1.Location = new Point(487, 97);
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
            dgvAsiste.Columns.AddRange(new DataGridViewColumn[] { clmDoc, clmClase, clmSeccion, clmAula, clmEdificio, clmFecha });
            dgvAsiste.Location = new Point(20, 224);
            dgvAsiste.Name = "dgvAsiste";
            dgvAsiste.Size = new Size(877, 245);
            dgvAsiste.TabIndex = 17;
            dgvAsiste.CellContentClick += dgvAsiste_CellContentClick;
            dgvAsiste.CellValueChanged += dgvAsiste_CellValueChanged;
            // 
            // clmDoc
            // 
            clmDoc.HeaderText = "Docente";
            clmDoc.Name = "clmDoc";
            clmDoc.Width = 300;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.Name = "clmClase";
            clmClase.Width = 250;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.Width = 60;
            // 
            // clmAula
            // 
            clmAula.HeaderText = "Aula";
            clmAula.Name = "clmAula";
            clmAula.Width = 150;
            // 
            // clmEdificio
            // 
            clmEdificio.HeaderText = "Edificio";
            clmEdificio.Name = "clmEdificio";
            // 
            // clmFecha
            // 
            clmFecha.HeaderText = "Presente";
            clmFecha.Name = "clmFecha";
            clmFecha.Resizable = DataGridViewTriState.True;
            clmFecha.SortMode = DataGridViewColumnSortMode.Automatic;
            clmFecha.Width = 55;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 188);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 26;
            label5.Text = "Asignatura:";
            // 
            // txtClase
            // 
            txtClase.Location = new Point(106, 180);
            txtClase.Name = "txtClase";
            txtClase.Size = new Size(304, 23);
            txtClase.TabIndex = 27;
            txtClase.KeyUp += Filtros;
            // 
            // cmbAula
            // 
            cmbAula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAula.FormattingEnabled = true;
            cmbAula.Items.AddRange(new object[] { "", "101", "102", "106", "107", "202" });
            cmbAula.Location = new Point(268, 22);
            cmbAula.Name = "cmbAula";
            cmbAula.Size = new Size(85, 23);
            cmbAula.TabIndex = 31;
            cmbAula.SelectedIndexChanged += Filtros;
            // 
            // cmbEdificio
            // 
            cmbEdificio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Items.AddRange(new object[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" });
            cmbEdificio.Location = new Point(70, 22);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(85, 23);
            cmbEdificio.TabIndex = 32;
            cmbEdificio.SelectedIndexChanged += Filtros;
            // 
            // gbFiltro
            // 
            gbFiltro.Controls.Add(label4);
            gbFiltro.Controls.Add(label3);
            gbFiltro.Controls.Add(cmbEdificio);
            gbFiltro.Controls.Add(cmbAula);
            gbFiltro.Location = new Point(440, 121);
            gbFiltro.Name = "gbFiltro";
            gbFiltro.Size = new Size(370, 55);
            gbFiltro.TabIndex = 33;
            gbFiltro.TabStop = false;
            gbFiltro.Text = "Filtros";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(228, 25);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 44;
            label4.Text = "Aula:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 25);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 43;
            label3.Text = "Edificio:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(20, 121);
            label6.Name = "label6";
            label6.Size = new Size(120, 30);
            label6.TabIndex = 34;
            label6.Text = "Nombre y/o apellido \r\n         del docente:";
            // 
            // txtDoc
            // 
            txtDoc.Location = new Point(156, 131);
            txtDoc.Name = "txtDoc";
            txtDoc.Size = new Size(254, 23);
            txtDoc.TabIndex = 35;
            txtDoc.KeyUp += Filtros;
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(907, 440);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(86, 23);
            btnLogout.TabIndex = 38;
            btnLogout.Text = "REGRESAR";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // frmAsistencia
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(999, 475);
            Controls.Add(btnLogout);
            Controls.Add(txtDoc);
            Controls.Add(label6);
            Controls.Add(gbFiltro);
            Controls.Add(txtClase);
            Controls.Add(label5);
            Controls.Add(dgvAsiste);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmAsistencia";
            Text = "FrmReporte";
            Load += FrmAsiste_Load;
            MouseDown += frmSupervisor_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAsiste).EndInit();
            gbFiltro.ResumeLayout(false);
            gbFiltro.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label1;
        public DataGridView dgvAsiste;
        private Label lblPersona;
        private Label label5;
        private TextBox txtClase;
        private Label label6;
        private ComboBox cmbAula;
        private ComboBox cmbEdificio;
        private GroupBox gbFiltro;
        private TextBox txtDoc;
        private Button btnLogout;
        private Button btnSalir;
        private Label label4;
        private Label label3;
        private DataGridViewTextBoxColumn clmDoc;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewTextBoxColumn clmAula;
        private DataGridViewTextBoxColumn clmEdificio;
        private DataGridViewCheckBoxColumn clmFecha;
    }
}