﻿namespace PreyectoDesarrollo_unicah.FRMS_ADMIN
{
    partial class frmOrden
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
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btncargar = new Button();
            dgvMigrar = new DataGridView();
            btnGuardar = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvMigrar).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(lblPersona);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(12, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1348, 81);
            panel1.TabIndex = 6;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(1216, 60);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 12;
            lblPersona.Text = "Nombre_Persona";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources.CircularFondoAzul;
            pictureBox3.Location = new Point(-23, -3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 81);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(1281, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(1316, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // btncargar
            // 
            btncargar.Location = new Point(1239, 751);
            btncargar.Name = "btncargar";
            btncargar.Size = new Size(99, 35);
            btncargar.TabIndex = 7;
            btncargar.Text = "Cargar datos";
            btncargar.UseVisualStyleBackColor = true;
//            btncargar.Click += btncargar_Click;
            // 
            // dgvMigrar
            // 
            dgvMigrar.AllowUserToAddRows = false;
            dgvMigrar.AllowUserToDeleteRows = false;
            dgvMigrar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMigrar.Location = new Point(27, 99);
            dgvMigrar.Name = "dgvMigrar";
            dgvMigrar.ReadOnly = true;
            dgvMigrar.Size = new Size(1320, 646);
            dgvMigrar.TabIndex = 8;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(1122, 751);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(99, 35);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar datos";
            btnGuardar.UseVisualStyleBackColor = true;
//            btnGuardar.Click += btnGuardar_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1001, 751);
            button1.Name = "button1";
            button1.Size = new Size(99, 35);
            button1.TabIndex = 10;
            button1.Text = "Guardar datos";
            button1.UseVisualStyleBackColor = true;
            // 
            // FrmMigrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1359, 798);
            Controls.Add(button1);
            Controls.Add(btnGuardar);
            Controls.Add(dgvMigrar);
            Controls.Add(btncargar);
            Controls.Add(panel1);
            Name = "FrmMigrar";
            Text = "FrmMigrar";
//            Load += FrmMigrar_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvMigrar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblPersona;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btncargar;
        private DataGridView dgvMigrar;
        private Button btnGuardar;
        private DataGridViewTextBoxColumn Primer_nombre;
        private DataGridViewTextBoxColumn Segundo_nombre;
        private DataGridViewTextBoxColumn Primer_apellido;
        private DataGridViewTextBoxColumn Segundo_apellido;
        private DataGridViewTextBoxColumn facultad;
        private DataGridViewTextBoxColumn Codigo_facultad;
        private DataGridViewTextBoxColumn Codigo_clase;
        private DataGridViewTextBoxColumn Asignatura;
        private DataGridViewTextBoxColumn Seccion;
        private DataGridViewTextBoxColumn Aula;
        private DataGridViewTextBoxColumn Edificio;
        private DataGridViewTextBoxColumn Fecha_inicio;
        private DataGridViewTextBoxColumn Fecha_final;
        private Button button1;
    }
}