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
            label1 = new Label();
            btnRestablecer = new Button();
            txtCodigo = new TextBox();
            label2 = new Label();
            label3 = new Label();
            txtUser = new TextBox();
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(335, 94);
            label1.Name = "label1";
            label1.Size = new Size(103, 15);
            label1.TabIndex = 6;
            label1.Text = "Ingrese su Usuario";
            // 
            // btnRestablecer
            // 
            btnRestablecer.BackColor = Color.White;
            btnRestablecer.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnRestablecer.FlatStyle = FlatStyle.Flat;
            btnRestablecer.ForeColor = Color.Black;
            btnRestablecer.Location = new Point(298, 244);
            btnRestablecer.Name = "btnRestablecer";
            btnRestablecer.Size = new Size(186, 40);
            btnRestablecer.TabIndex = 8;
            btnRestablecer.Text = "&RESTABLECER CUENTA";
            btnRestablecer.UseVisualStyleBackColor = false;
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(233, 183);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(307, 23);
            txtCodigo.TabIndex = 10;
            txtCodigo.Text = "Código:";
            txtCodigo.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(335, 159);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 9;
            label2.Text = "Ingrese su código";
            label2.Visible = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(283, 215);
            label3.Name = "label3";
            label3.Size = new Size(209, 15);
            label3.TabIndex = 11;
            label3.Text = "Un código ha sido enviado a su correo";
            label3.Visible = false;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(233, 122);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(307, 23);
            txtUser.TabIndex = 12;
            txtUser.Text = "Usuario:";
            txtUser.Visible = false;
            // 
            // frmOlvideDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 291);
            Controls.Add(txtUser);
            Controls.Add(label3);
            Controls.Add(txtCodigo);
            Controls.Add(label2);
            Controls.Add(btnRestablecer);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmOlvideDatos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frmolvidecontra";
            Load += Frmolvidecontra_Load;
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
        private Label label1;
        private Button btnRestablecer;
        private TextBox txtCodigo;
        private Label label2;
        private Label label3;
        private TextBox txtUser;
    }
}