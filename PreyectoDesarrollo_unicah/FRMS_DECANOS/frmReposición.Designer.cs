namespace PreyectoDesarrollo_unicah
{
    partial class frmReposici�n
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
            Button btnDay;
            Button btnVoy;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            label2 = new Label();
            nudReposicion = new NumericUpDown();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            clmClase = new DataGridViewTextBoxColumn();
            clmFecha = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmDocente = new DataGridViewTextBoxColumn();
            clmRepo = new DataGridViewTextBoxColumn();
            btnDay = new Button();
            btnVoy = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudReposicion).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDay
            // 
            btnDay.Location = new Point(170, 121);
            btnDay.Name = "btnDay";
            btnDay.Size = new Size(67, 23);
            btnDay.TabIndex = 21;
            btnDay.Text = "INSERT&AR";
            btnDay.UseVisualStyleBackColor = true;
            // 
            // btnVoy
            // 
            btnVoy.Location = new Point(524, 424);
            btnVoy.Name = "btnVoy";
            btnVoy.Size = new Size(102, 29);
            btnVoy.TabIndex = 20;
            btnVoy.Text = "&Regresar";
            btnVoy.UseVisualStyleBackColor = true;
            btnVoy.Click += btnVoy_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(575, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(610, 4);
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
            lblPersona.Location = new Point(507, 63);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 25;
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
            label2.Location = new Point(16, 125);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 23;
            label2.Text = "D�a de reposici�n:";
            // 
            // nudReposicion
            // 
            nudReposicion.Location = new Point(120, 123);
            nudReposicion.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            nudReposicion.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudReposicion.Name = "nudReposicion";
            nudReposicion.Size = new Size(40, 23);
            nudReposicion.TabIndex = 22;
            nudReposicion.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(266, 97);
            label1.Name = "label1";
            label1.Size = new Size(142, 15);
            label1.TabIndex = 18;
            label1.Text = "REPORTE DE REPOSICI�N";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clmClase, clmFecha, clmSeccion, clmDocente, clmRepo });
            dataGridView1.Location = new Point(16, 150);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(610, 268);
            dataGridView1.TabIndex = 24;
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
            clmFecha.Width = 130;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Secci�n";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            // 
            // clmDocente
            // 
            clmDocente.HeaderText = "Docente";
            clmDocente.Name = "clmDocente";
            clmDocente.ReadOnly = true;
            // 
            // clmRepo
            // 
            clmRepo.HeaderText = "Fecha de Reposici�n";
            clmRepo.Name = "clmRepo";
            clmRepo.ReadOnly = true;
            clmRepo.Width = 138;
            // 
            // frmReposici�n
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(636, 464);
            Controls.Add(dataGridView1);
            Controls.Add(label2);
            Controls.Add(nudReposicion);
            Controls.Add(btnDay);
            Controls.Add(btnVoy);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReposici�n";
            Text = "FrmReporte";
            Load += frmReposici�n_Load;
            MouseDown += frmReposici�n_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudReposicion).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private Label label2;
        private NumericUpDown nudReposicion;
        private Label label1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmFecha;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewTextBoxColumn clmDocente;
        private DataGridViewTextBoxColumn clmRepo;
        private Label lblPersona;
    }
}