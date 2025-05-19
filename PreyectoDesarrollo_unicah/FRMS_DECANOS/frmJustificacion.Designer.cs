namespace PreyectoDesarrollo_unicah
{
    partial class frmJustificacion
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
            Button btnReporta;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJustificacion));
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            dgvJustificacion = new DataGridView();
            label1 = new Label();
            txtJustifica = new TextBox();
            lblCaracteres = new Label();
            label3 = new Label();
            cmbEdificio = new ComboBox();
            txtBusco = new TextBox();
            label4 = new Label();
            label5 = new Label();
            dtpAusencia = new DateTimePicker();
            pnlAusencia = new Panel();
            btnAgregar = new Button();
            btnVoy = new Button();
            btnReporta = new Button();
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
            btnAgregar.Text = "&INSERTAR JUSTIFICACIÓN";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnVoy
            // 
            btnVoy.Location = new Point(659, 602);
            btnVoy.Name = "btnVoy";
            btnVoy.Size = new Size(126, 24);
            btnVoy.TabIndex = 27;
            btnVoy.Text = "&REGRESAR";
            btnVoy.UseVisualStyleBackColor = true;
            btnVoy.Click += Cerrar;
            // 
            // btnReporta
            // 
            btnReporta.Location = new Point(391, 592);
            btnReporta.Name = "btnReporta";
            btnReporta.Size = new Size(126, 44);
            btnReporta.TabIndex = 44;
            btnReporta.Text = "&REPORTAR JUSTIFICACIONES";
            btnReporta.UseVisualStyleBackColor = true;
            btnReporta.Click += btnReporta_Click;
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
            pictureBox1.Click += Cerrar;
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
            panel1.MouseDown += MoveForm_MouseDown;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(592, 65);
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
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(280, 121);
            label2.Name = "label2";
            label2.Size = new Size(164, 21);
            label2.TabIndex = 30;
            label2.Text = "Justificación detallada:";
            // 
            // dgvJustificacion
            // 
            dgvJustificacion.AllowUserToAddRows = false;
            dgvJustificacion.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvJustificacion.Location = new Point(13, 272);
            dgvJustificacion.Name = "dgvJustificacion";
            dgvJustificacion.ReadOnly = true;
            dgvJustificacion.RowHeadersWidth = 51;
            dgvJustificacion.Size = new Size(773, 304);
            dgvJustificacion.TabIndex = 26;
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
            txtJustifica.Location = new Point(449, 119);
            txtJustifica.Multiline = true;
            txtJustifica.Name = "txtJustifica";
            txtJustifica.Size = new Size(337, 147);
            txtJustifica.TabIndex = 37;
            txtJustifica.Text = "\r\n";
            txtJustifica.TextChanged += txtJustifica_TextChanged;
            // 
            // lblCaracteres
            // 
            lblCaracteres.AutoSize = true;
            lblCaracteres.BackColor = SystemColors.Window;
            lblCaracteres.BorderStyle = BorderStyle.FixedSingle;
            lblCaracteres.Location = new Point(449, 119);
            lblCaracteres.Name = "lblCaracteres";
            lblCaracteres.Size = new Size(114, 17);
            lblCaracteres.TabIndex = 38;
            lblCaracteres.Text = "Límite de caracteres";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 182);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 42;
            label3.Text = "Filtrar Edificio:";
            // 
            // cmbEdificio
            // 
            cmbEdificio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Items.AddRange(new object[] { "", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M" });
            cmbEdificio.Location = new Point(102, 179);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(78, 23);
            cmbEdificio.TabIndex = 41;
            cmbEdificio.SelectedIndexChanged += Filtros;
            // 
            // txtBusco
            // 
            txtBusco.Location = new Point(14, 146);
            txtBusco.Name = "txtBusco";
            txtBusco.Size = new Size(190, 23);
            txtBusco.TabIndex = 40;
            txtBusco.KeyDown += Filtros;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(244, 224);
            label5.Name = "label5";
            label5.Size = new Size(109, 30);
            label5.TabIndex = 50;
            label5.Text = "Seleccionar fecha \r\nde ausencia pasada";
            // 
            // dtpAusencia
            // 
            dtpAusencia.Location = new Point(23, 228);
            dtpAusencia.Name = "dtpAusencia";
            dtpAusencia.Size = new Size(215, 23);
            dtpAusencia.TabIndex = 49;
            dtpAusencia.ValueChanged += Filtros;
            // 
            // pnlAusencia
            // 
            pnlAusencia.Location = new Point(18, 220);
            pnlAusencia.Name = "pnlAusencia";
            pnlAusencia.Size = new Size(343, 39);
            pnlAusencia.TabIndex = 51;
            // 
            // frmJustificacion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 645);
            Controls.Add(label5);
            Controls.Add(dtpAusencia);
            Controls.Add(pnlAusencia);
            Controls.Add(btnReporta);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbEdificio);
            Controls.Add(txtBusco);
            Controls.Add(lblCaracteres);
            Controls.Add(txtJustifica);
            Controls.Add(label2);
            Controls.Add(btnAgregar);
            Controls.Add(btnVoy);
            Controls.Add(dgvJustificacion);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmJustificacion";
            Text = "FrmReporte";
            Load += frmJustificación_Load;
            MouseDown += MoveForm_MouseDown;
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
        private Label lblPersona;
        private Label label3;
        private ComboBox cmbEdificio;
        private TextBox txtBusco;
        private Label label4;
        private Label label5;
        private DateTimePicker dtpAusencia;
        private Panel pnlAusencia;
    }
}