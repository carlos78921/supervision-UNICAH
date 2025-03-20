namespace PreyectoDesarrollo_unicah
{
    partial class frmJustificación
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
            Button btnAgregar;
            Button btnVoy;
            Button btnBusco;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            dgvJustificacion = new DataGridView();
            clmClase = new DataGridViewTextBoxColumn();
            clmFecha = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmDoc = new DataGridViewTextBoxColumn();
            clmJustifica = new DataGridViewTextBoxColumn();
            label1 = new Label();
            txtJustifica = new TextBox();
            lblCaracteres = new Label();
            label3 = new Label();
            cmbEdificio = new ComboBox();
            txtBusco = new TextBox();
            label4 = new Label();
            lblMeses = new Label();
            dtpFecha = new DateTimePicker();
            btnAgregar = new Button();
            btnVoy = new Button();
            btnBusco = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvJustificacion).BeginInit();
            SuspendLayout();
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(527, 592);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(126, 44);
            btnAgregar.TabIndex = 29;
            btnAgregar.Text = "INSERT&AR JUSTIFICACIÓN";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnVoy
            // 
            btnVoy.Location = new Point(659, 602);
            btnVoy.Name = "btnVoy";
            btnVoy.Size = new Size(126, 24);
            btnVoy.TabIndex = 27;
            btnVoy.Text = "&Regresar";
            btnVoy.UseVisualStyleBackColor = true;
            btnVoy.Click += btnVoy_Click;
            // 
            // btnBusco
            // 
            btnBusco.Location = new Point(210, 146);
            btnBusco.Name = "btnBusco";
            btnBusco.Size = new Size(67, 23);
            btnBusco.TabIndex = 39;
            btnBusco.Text = "&Buscar";
            btnBusco.UseVisualStyleBackColor = true;
            btnBusco.Click += btnBusco_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(734, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(769, 0);
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
            panel1.Size = new Size(809, 87);
            panel1.TabIndex = 11;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(663, 63);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 10;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(310, 123);
            label2.Name = "label2";
            label2.Size = new Size(123, 15);
            label2.TabIndex = 30;
            label2.Text = "Justificación detallada";
            // 
            // dgvJustificacion
            // 
            dgvJustificacion.AllowUserToAddRows = false;
            dgvJustificacion.AllowUserToDeleteRows = false;
            dgvJustificacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJustificacion.Columns.AddRange(new DataGridViewColumn[] { clmClase, clmFecha, clmSeccion, clmDoc, clmJustifica });
            dgvJustificacion.Location = new Point(13, 272);
            dgvJustificacion.Name = "dgvJustificacion";
            dgvJustificacion.ReadOnly = true;
            dgvJustificacion.Size = new Size(773, 304);
            dgvJustificacion.TabIndex = 26;
            dgvJustificacion.CellContentClick += dgvJustificacion_CellContentClick;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.Name = "clmClase";
            clmClase.ReadOnly = true;
            // 
            // clmFecha
            // 
            clmFecha.HeaderText = "Fecha de Ausencia";
            clmFecha.Name = "clmFecha";
            clmFecha.ReadOnly = true;
            clmFecha.Width = 80;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 66;
            // 
            // clmDoc
            // 
            clmDoc.HeaderText = "Docente";
            clmDoc.Name = "clmDoc";
            clmDoc.ReadOnly = true;
            clmDoc.Width = 120;
            // 
            // clmJustifica
            // 
            clmJustifica.HeaderText = "Justificación";
            clmJustifica.Name = "clmJustifica";
            clmJustifica.ReadOnly = true;
            clmJustifica.Width = 364;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(310, 93);
            label1.Name = "label1";
            label1.Size = new Size(173, 15);
            label1.TabIndex = 25;
            label1.Text = "JUSTIFICACIÓN DE ASISTENCIA";
            // 
            // txtJustifica
            // 
            txtJustifica.Location = new Point(447, 119);
            txtJustifica.Multiline = true;
            txtJustifica.Name = "txtJustifica";
            txtJustifica.Size = new Size(338, 147);
            txtJustifica.TabIndex = 37;
            txtJustifica.TextChanged += txtJustifica_TextChanged;
            // 
            // lblCaracteres
            // 
            lblCaracteres.AutoSize = true;
            lblCaracteres.BackColor = SystemColors.Window;
            lblCaracteres.Location = new Point(451, 122);
            lblCaracteres.Name = "lblCaracteres";
            lblCaracteres.Size = new Size(112, 15);
            lblCaracteres.TabIndex = 38;
            lblCaracteres.Text = "Límite de caracteres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 182);
            label3.Name = "label3";
            label3.Size = new Size(40, 15);
            label3.TabIndex = 42;
            label3.Text = "Filtrar:";
            // 
            // cmbEdificio
            // 
            cmbEdificio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Items.AddRange(new object[] { "Edificio:", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" });
            cmbEdificio.Location = new Point(59, 175);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(78, 23);
            cmbEdificio.TabIndex = 41;
            // 
            // txtBusco
            // 
            txtBusco.Location = new Point(14, 146);
            txtBusco.Name = "txtBusco";
            txtBusco.Size = new Size(190, 23);
            txtBusco.TabIndex = 40;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 126);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 43;
            label4.Text = "Docente:";
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(738, 93);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(48, 15);
            lblMeses.TabIndex = 44;
            lblMeses.Text = "Periodo";
            lblMeses.Visible = false;
            // 
            // dtpFecha
            // 
            dtpFecha.Location = new Point(14, 221);
            dtpFecha.Name = "dtpFecha";
            dtpFecha.Size = new Size(229, 23);
            dtpFecha.TabIndex = 45;
            dtpFecha.ValueChanged += dtpFecha_ValueChanged;
            // 
            // frmJustificación
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 642);
            Controls.Add(dtpFecha);
            Controls.Add(lblMeses);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbEdificio);
            Controls.Add(txtBusco);
            Controls.Add(btnBusco);
            Controls.Add(lblCaracteres);
            Controls.Add(txtJustifica);
            Controls.Add(label2);
            Controls.Add(btnAgregar);
            Controls.Add(btnVoy);
            Controls.Add(dgvJustificacion);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmJustificación";
            Text = "FrmReporte";
            Load += frmJustificación_Load;
            MouseDown += frmJustificación_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvJustificacion).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label2;
        private DataGridView dgvJustificacion;
        private Label label1;
        private TextBox txtJustifica;
        private Label lblCaracteres;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmFecha;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewTextBoxColumn clmDoc;
        private DataGridViewTextBoxColumn clmJustifica;
        private Label lblPersona;
        private Label label3;
        private ComboBox cmbEdificio;
        private TextBox txtBusco;
        private Label label4;
        private Label lblMeses;
        private DateTimePicker dtpFecha;
    }
}