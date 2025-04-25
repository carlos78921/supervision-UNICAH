namespace PreyectoDesarrollo_unicah.FRMS_ADMIN
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
            btnGuardar = new Button();
            btncargar = new Button();
            button1 = new Button();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            dgvTablas = new DataGridView();
            btnAdd = new Button();
            btnNew = new Button();
            btnQuitar = new Button();
            btnBye = new Button();
            btnSigue = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTablas).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(lblPersona);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(btncargar);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(717, 81);
            panel1.TabIndex = 6;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(563, 60);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 12;
            lblPersona.Text = "Nombre_Persona";
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(356, 12);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(99, 35);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar datos";
            btnGuardar.UseVisualStyleBackColor = true;
            // 
            // btncargar
            // 
            btncargar.Location = new Point(471, 12);
            btncargar.Name = "btncargar";
            btncargar.Size = new Size(99, 35);
            btncargar.TabIndex = 7;
            btncargar.Text = "Cargar datos";
            btncargar.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(250, 12);
            button1.Name = "button1";
            button1.Size = new Size(90, 35);
            button1.TabIndex = 10;
            button1.Text = "Guardar datos";
            button1.UseVisualStyleBackColor = true;
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
            pictureBox2.Location = new Point(654, 1);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(28, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(689, 1);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(28, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += Salir;
            // 
            // dgvTablas
            // 
            dgvTablas.AllowUserToAddRows = false;
            dgvTablas.AllowUserToDeleteRows = false;
            dgvTablas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTablas.Location = new Point(12, 90);
            dgvTablas.Name = "dgvTablas";
            dgvTablas.ReadOnly = true;
            dgvTablas.Size = new Size(695, 330);
            dgvTablas.TabIndex = 8;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(388, 428);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 30);
            btnAdd.TabIndex = 11;
            btnAdd.Text = "&AGREGAR";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnNew
            // 
            btnNew.Location = new Point(388, 464);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(100, 30);
            btnNew.TabIndex = 12;
            btnNew.Text = "&MODIFICAR";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // btnQuitar
            // 
            btnQuitar.Location = new Point(494, 428);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(114, 30);
            btnQuitar.TabIndex = 13;
            btnQuitar.Text = "&ELIMINAR";
            btnQuitar.UseVisualStyleBackColor = true;
            // 
            // btnBye
            // 
            btnBye.Location = new Point(614, 445);
            btnBye.Name = "btnBye";
            btnBye.Size = new Size(81, 30);
            btnBye.TabIndex = 14;
            btnBye.Text = "&REGRESAR";
            btnBye.UseVisualStyleBackColor = true;
            btnBye.Click += Salir;
            // 
            // btnSigue
            // 
            btnSigue.Location = new Point(494, 464);
            btnSigue.Name = "btnSigue";
            btnSigue.Size = new Size(114, 30);
            btnSigue.TabIndex = 16;
            btnSigue.Text = "SIGUIENTE &TABLA";
            btnSigue.UseVisualStyleBackColor = true;
            // 
            // frmOrden
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 503);
            Controls.Add(btnBye);
            Controls.Add(btnSigue);
            Controls.Add(btnQuitar);
            Controls.Add(btnNew);
            Controls.Add(btnAdd);
            Controls.Add(dgvTablas);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmOrden";
            Text = "FrmMigrar";
            Load += frmOrden_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTablas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblPersona;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btncargar;
        private DataGridView dgvTablas;
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
        private Button btnAdd;
        private Button btnNew;
        private Button btnQuitar;
        private Button btnBye;
        private Button button2;
        private Button btnSigue;
    }
}