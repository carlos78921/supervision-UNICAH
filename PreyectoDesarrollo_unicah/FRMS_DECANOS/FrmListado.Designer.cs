namespace PreyectoDesarrollo_unicah.FRMS_DECANOS
{
    partial class FrmListado
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
            Button btnLogOut;
            Button btnEnviar;
            Button btnAgregar;
            Button btnExcel;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            label4 = new Label();
            pictureBox3 = new PictureBox();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            lblCaracteres = new Label();
            cmbJustifica = new ComboBox();
            label3 = new Label();
            textBox2 = new TextBox();
            btnbuscar = new Button();
            btnLogOut = new Button();
            btnEnviar = new Button();
            btnAgregar = new Button();
            btnExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(662, 610);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(126, 24);
            btnLogOut.TabIndex = 14;
            btnLogOut.Text = "&CERRAR SESIÓN";
            btnLogOut.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(531, 600);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(126, 44);
            btnEnviar.TabIndex = 15;
            btnEnviar.Text = "ENVIAR &JUSTIFICACIÓN";
            btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(399, 600);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(126, 44);
            btnAgregar.TabIndex = 16;
            btnAgregar.Text = "&AGREGAR JUSTIFICACIÓN";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(267, 608);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(126, 29);
            btnExcel.TabIndex = 21;
            btnExcel.Text = "&EXPORTAR A EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
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
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-4, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 81);
            panel1.TabIndex = 11;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(666, 54);
            label4.Name = "label4";
            label4.Size = new Size(132, 18);
            label4.TabIndex = 20;
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
            dataGridView1.Location = new Point(15, 156);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(774, 428);
            dataGridView1.TabIndex = 13;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(313, 101);
            label1.Name = "label1";
            label1.Size = new Size(171, 15);
            label1.TabIndex = 12;
            label1.Text = "JUSTIFICACIÓN DE ASISTENCIA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 128);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 18;
            label2.Text = "Observación Específica:";
            // 
            // lblCaracteres
            // 
            lblCaracteres.AutoSize = true;
            lblCaracteres.Location = new Point(336, 128);
            lblCaracteres.Name = "lblCaracteres";
            lblCaracteres.Size = new Size(112, 15);
            lblCaracteres.TabIndex = 19;
            lblCaracteres.Text = "Límite de caracteres";
            // 
            // cmbJustifica
            // 
            cmbJustifica.FormattingEnabled = true;
            cmbJustifica.Location = new Point(152, 125);
            cmbJustifica.Name = "cmbJustifica";
            cmbJustifica.Size = new Size(178, 23);
            cmbJustifica.TabIndex = 20;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(542, 128);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 22;
            label3.Text = "Edificio:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(597, 125);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 23;
            // 
            // btnbuscar
            // 
            btnbuscar.Location = new Point(713, 125);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(75, 23);
            btnbuscar.TabIndex = 24;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = true;
            // 
            // FrmListado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 646);
            Controls.Add(btnbuscar);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(btnExcel);
            Controls.Add(cmbJustifica);
            Controls.Add(lblCaracteres);
            Controls.Add(label2);
            Controls.Add(btnAgregar);
            Controls.Add(btnEnviar);
            Controls.Add(btnLogOut);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Name = "FrmListado";
            Text = "FrmListado";
            Load += FrmListado_Load;
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
        private TextBox textBox1;
        private Label label2;
        private Label lblCaracteres;
        private Label label4;
        private ComboBox cmbJustifica;
        private Label label3;
        private TextBox textBox2;
        private Button btnbuscar;
    }
}