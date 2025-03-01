namespace PreyectoDesarrollo_unicah
{
    partial class FrmDocente
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
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            clmClase = new DataGridViewTextBoxColumn();
            clmFecha = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmDocente = new DataGridViewTextBoxColumn();
            clmRepo = new DataGridViewTextBoxColumn();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(546, 402);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(126, 23);
            btnLogout.TabIndex = 14;
            btnLogout.Text = "&CERRAR SESIÓN";
            btnLogout.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(614, 3);
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
            pictureBox1.Location = new Point(649, 3);
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
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-4, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 85);
            panel1.TabIndex = 11;
            panel1.Paint += panel1_Paint;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(544, 63);
            label4.Name = "label4";
            label4.Size = new Size(132, 18);
            label4.TabIndex = 21;
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
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clmClase, clmFecha, clmSeccion, clmDocente, clmRepo });
            dataGridView1.Location = new Point(61, 128);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(611, 268);
            dataGridView1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(313, 101);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 12;
            label1.Text = "ASISTENCIA PERSONAL";
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
            clmSeccion.HeaderText = "Sección";
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
            clmRepo.HeaderText = "Fecha de Reposición";
            clmRepo.Name = "clmRepo";
            clmRepo.ReadOnly = true;
            clmRepo.Width = 138;
            // 
            // FrmDocente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(706, 435);
            Controls.Add(panel1);
            Controls.Add(btnLogout);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "FrmDocente";
            Text = "FrmDocente";
            Load += FrmDocente_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label4;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmFecha;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewTextBoxColumn clmDocente;
        private DataGridViewTextBoxColumn clmRepo;
    }
}