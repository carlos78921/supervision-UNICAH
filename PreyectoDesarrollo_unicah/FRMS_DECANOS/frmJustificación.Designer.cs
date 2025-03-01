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
            Button btnExcel;
            Button btnAgregar;
            Button btnEnviar;
            Button btnLogOut;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            btnbuscar = new Button();
            textBox2 = new TextBox();
            label3 = new Label();
            cmbJustifica = new ComboBox();
            lblCaracteres = new Label();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            label1 = new Label();
            btnExcel = new Button();
            btnAgregar = new Button();
            btnEnviar = new Button();
            btnLogOut = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 87);
            panel1.TabIndex = 11;
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
            // btnbuscar
            // 
            btnbuscar.Location = new Point(710, 117);
            btnbuscar.Name = "btnbuscar";
            btnbuscar.Size = new Size(75, 23);
            btnbuscar.TabIndex = 36;
            btnbuscar.Text = "Buscar";
            btnbuscar.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(594, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 35;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(539, 120);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 34;
            label3.Text = "Edificio:";
            // 
            // btnExcel
            // 
            btnExcel.Location = new Point(264, 600);
            btnExcel.Name = "btnExcel";
            btnExcel.Size = new Size(126, 29);
            btnExcel.TabIndex = 33;
            btnExcel.Text = "&EXPORTAR A EXCEL";
            btnExcel.UseVisualStyleBackColor = true;
            // 
            // cmbJustifica
            // 
            cmbJustifica.FormattingEnabled = true;
            cmbJustifica.Location = new Point(149, 117);
            cmbJustifica.Name = "cmbJustifica";
            cmbJustifica.Size = new Size(178, 23);
            cmbJustifica.TabIndex = 32;
            // 
            // lblCaracteres
            // 
            lblCaracteres.AutoSize = true;
            lblCaracteres.Location = new Point(333, 120);
            lblCaracteres.Name = "lblCaracteres";
            lblCaracteres.Size = new Size(112, 15);
            lblCaracteres.TabIndex = 31;
            lblCaracteres.Text = "Límite de caracteres";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 120);
            label2.Name = "label2";
            label2.Size = new Size(131, 15);
            label2.TabIndex = 30;
            label2.Text = "Observación Específica:";
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(396, 592);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(126, 44);
            btnAgregar.TabIndex = 29;
            btnAgregar.Text = "&AGREGAR JUSTIFICACIÓN";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(528, 592);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(126, 44);
            btnEnviar.TabIndex = 28;
            btnEnviar.Text = "ENVIAR &JUSTIFICACIÓN";
            btnEnviar.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(659, 602);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(126, 24);
            btnLogOut.TabIndex = 27;
            btnLogOut.Text = "&CERRAR SESIÓN";
            btnLogOut.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 148);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(774, 428);
            dataGridView1.TabIndex = 26;
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
            // frmReposicion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 642);
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
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmReposicion";
            Text = "FrmReporte";
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
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
        private Button btnbuscar;
        private TextBox textBox2;
        private Label label3;
        private ComboBox cmbJustifica;
        private Label lblCaracteres;
        private Label label2;
        private DataGridView dataGridView1;
        private Label label1;
    }
}