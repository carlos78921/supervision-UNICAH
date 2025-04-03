namespace PreyectoDesarrollo_unicah
{
    partial class frmPierdoContraseña
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
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnEnviar = new Button();
            txtCode = new TextBox();
            label2 = new Label();
            lblCode = new Label();
            btnRecibir = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(765, 81);
            panel1.TabIndex = 5;
            panel1.MouseDown += MoveForm_MouseDown;
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
            pictureBox2.Location = new Point(698, 0);
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
            pictureBox1.Location = new Point(733, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = Color.White;
            btnEnviar.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnEnviar.FlatStyle = FlatStyle.Flat;
            btnEnviar.ForeColor = Color.Black;
            btnEnviar.Location = new Point(420, 171);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(139, 40);
            btnEnviar.TabIndex = 8;
            btnEnviar.Text = "&ENVIAR CÓDIGO";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtCode
            // 
            txtCode.Location = new Point(234, 115);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(307, 23);
            txtCode.TabIndex = 10;
            txtCode.Text = "Código:";
            txtCode.Enter += txtCode_Enter;
            txtCode.KeyPress += txtCode_KeyPress;
            txtCode.Leave += txtCode_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(336, 91);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 9;
            label2.Text = "Ingrese su código";
            label2.Visible = false;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Location = new Point(284, 147);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(209, 15);
            lblCode.TabIndex = 11;
            lblCode.Text = "Un código ha sido enviado a su correo";
            // 
            // btnRecibir
            // 
            btnRecibir.BackColor = Color.White;
            btnRecibir.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnRecibir.FlatStyle = FlatStyle.Flat;
            btnRecibir.ForeColor = Color.Black;
            btnRecibir.Location = new Point(220, 171);
            btnRecibir.Name = "btnRecibir";
            btnRecibir.Size = new Size(139, 40);
            btnRecibir.TabIndex = 13;
            btnRecibir.Text = "&GENERAR CÓDIGO";
            btnRecibir.UseVisualStyleBackColor = false;
            btnRecibir.Click += btnRecibir_Click;
            // 
            // frmPierdoContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 222);
            Controls.Add(btnRecibir);
            Controls.Add(lblCode);
            Controls.Add(txtCode);
            Controls.Add(label2);
            Controls.Add(btnEnviar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmPierdoContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frmolvidecontra";
            MouseDown += MoveForm_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Button btnEnviar;
        private TextBox txtCode;
        private Label label2;
        private Label lblCode;
        private Button btnRecibir;
    }
}