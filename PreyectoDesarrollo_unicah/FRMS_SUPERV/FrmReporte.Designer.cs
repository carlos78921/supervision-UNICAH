namespace PreyectoDesarrollo_unicah
{
    partial class FrmReporte
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
            Button btnSalir;
            Button btnExcel;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            dgvDoc = new DataGridView();
            clmClase = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmSemana = new DataGridViewTextBoxColumn();
            clmLunes = new DataGridViewCheckBoxColumn();
            clmMartes = new DataGridViewCheckBoxColumn();
            clmMiercoles = new DataGridViewCheckBoxColumn();
            clmJueves = new DataGridViewCheckBoxColumn();
            clmViernes = new DataGridViewCheckBoxColumn();
            clmSabado = new DataGridViewCheckBoxColumn();
            nudMeses = new NumericUpDown();
            label3 = new Label();
            nudWeeks = new NumericUpDown();
            label2 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            btnBusca = new Button();
            cmbHora = new ComboBox();
            cmbAula = new ComboBox();
            cmbEdificio = new ComboBox();
            gbFiltro = new GroupBox();
            btnSalir = new Button();
            btnExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMeses).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).BeginInit();
            gbFiltro.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(325, 466);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(105, 29);
            btnSalir.TabIndex = 14;
            btnSalir.Text = "&REGRESAR";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(189, 466);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(126, 29);
            btnExcel.TabIndex = 15;
            btnExcel.Text = "&EXPORTAR A EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(376, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 21);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(411, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 21);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(445, 87);
            panel1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(308, 63);
            label4.Name = "label4";
            label4.Size = new Size(132, 18);
            label4.TabIndex = 23;
            label4.Text = "Nombre_Persona";
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
            label1.Location = new Point(148, 96);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 12;
            label1.Text = "REPORTE DE ASISTENCIA";
            // 
            // dgvDoc
            // 
            dgvDoc.AllowUserToAddRows = false;
            dgvDoc.AllowUserToDeleteRows = false;
            dgvDoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoc.Columns.AddRange(new DataGridViewColumn[] { clmClase, clmSeccion, clmSemana, clmLunes, clmMartes, clmMiercoles, clmJueves, clmViernes, clmSabado });
            dgvDoc.Location = new Point(19, 219);
            dgvDoc.Name = "dgvDoc";
            dgvDoc.ReadOnly = true;
            dgvDoc.Size = new Size(409, 241);
            dgvDoc.TabIndex = 17;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.Name = "clmClase";
            clmClase.ReadOnly = true;
            clmClase.Width = 125;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
            // 
            // clmSemana
            // 
            clmSemana.HeaderText = "Semana";
            clmSemana.Name = "clmSemana";
            clmSemana.ReadOnly = true;
            clmSemana.Width = 60;
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
            clmMiercoles.HeaderText = "M";
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
            clmSabado.Resizable = DataGridViewTriState.True;
            clmSabado.SortMode = DataGridViewColumnSortMode.Automatic;
            clmSabado.Width = 20;
            // 
            // nudMeses
            // 
            nudMeses.Location = new Point(81, 155);
            nudMeses.Name = "nudMeses";
            nudMeses.Size = new Size(49, 23);
            nudMeses.TabIndex = 25;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 160);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 24;
            label3.Text = "Periodo:";
            // 
            // nudWeeks
            // 
            nudWeeks.Location = new Point(81, 126);
            nudWeeks.Name = "nudWeeks";
            nudWeeks.Size = new Size(49, 23);
            nudWeeks.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 131);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 22;
            label2.Text = "Semana:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(136, 128);
            label5.Name = "label5";
            label5.Size = new Size(67, 15);
            label5.TabIndex = 26;
            label5.Text = "Asignatura:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(209, 125);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(140, 23);
            textBox1.TabIndex = 27;
            // 
            // btnBusca
            // 
            btnBusca.Location = new Point(361, 126);
            btnBusca.Name = "btnBusca";
            btnBusca.Size = new Size(75, 23);
            btnBusca.TabIndex = 28;
            btnBusca.Text = "Buscar";
            btnBusca.UseVisualStyleBackColor = true;
            // 
            // cmbHora
            // 
            cmbHora.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbHora.FormattingEnabled = true;
            cmbHora.Location = new Point(203, 22);
            cmbHora.Name = "cmbHora";
            cmbHora.Size = new Size(85, 23);
            cmbHora.TabIndex = 30;
            // 
            // cmbAula
            // 
            cmbAula.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAula.FormattingEnabled = true;
            cmbAula.Location = new Point(104, 22);
            cmbAula.Name = "cmbAula";
            cmbAula.Size = new Size(85, 23);
            cmbAula.TabIndex = 31;
            // 
            // cmbEdificio
            // 
            cmbEdificio.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEdificio.FormattingEnabled = true;
            cmbEdificio.Location = new Point(7, 22);
            cmbEdificio.Name = "cmbEdificio";
            cmbEdificio.Size = new Size(85, 23);
            cmbEdificio.TabIndex = 32;
            // 
            // gbFiltro
            // 
            gbFiltro.Controls.Add(cmbEdificio);
            gbFiltro.Controls.Add(cmbHora);
            gbFiltro.Controls.Add(cmbAula);
            gbFiltro.Location = new Point(134, 155);
            gbFiltro.Name = "gbFiltro";
            gbFiltro.Size = new Size(293, 55);
            gbFiltro.TabIndex = 33;
            gbFiltro.TabStop = false;
            gbFiltro.Text = "Filtros";
            // 
            // FrmReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 502);
            Controls.Add(gbFiltro);
            Controls.Add(btnBusca);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(nudMeses);
            Controls.Add(label3);
            Controls.Add(nudWeeks);
            Controls.Add(label2);
            Controls.Add(dgvDoc);
            Controls.Add(btnExcel);
            Controls.Add(panel1);
            Controls.Add(btnSalir);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReporte";
            Text = "FrmReporte";
            Load += FrmReporte_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMeses).EndInit();
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
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewTextBoxColumn clmSemana;
        private DataGridViewCheckBoxColumn clmLunes;
        private DataGridViewCheckBoxColumn clmMartes;
        private DataGridViewCheckBoxColumn clmMiercoles;
        private DataGridViewCheckBoxColumn clmJueves;
        private DataGridViewCheckBoxColumn clmViernes;
        private DataGridViewCheckBoxColumn clmSabado;
        private Label label4;
        private NumericUpDown nudMeses;
        private Label label3;
        private NumericUpDown nudWeeks;
        private Label label2;
        private Label label5;
        private TextBox textBox1;
        private Button btnBusca;
        private Label label6;
        private ComboBox cmbHora;
        private ComboBox cmbAula;
        private ComboBox cmbEdificio;
        private GroupBox gbFiltro;
    }
}