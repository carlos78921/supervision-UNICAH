namespace PreyectoDesarrollo_unicah
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            txtusuario = new TextBox();
            btnLogin = new Button();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            txtcontraseña = new TextBox();
            pbMostrar = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            llReestablecer = new LinkLabel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbMostrar).BeginInit();
            SuspendLayout();
            // 
            // txtusuario
            // 
            txtusuario.BackColor = Color.Silver;
            txtusuario.BorderStyle = BorderStyle.None;
            txtusuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtusuario.ForeColor = Color.Black;
            txtusuario.Location = new Point(168, 111);
            txtusuario.Name = "txtusuario";
            txtusuario.Size = new Size(408, 20);
            txtusuario.TabIndex = 1;
            txtusuario.Text = "Usuario:";
            txtusuario.Enter += txtusuario_Enter;
            txtusuario.KeyPress += txtusuario_KeyPress;
            txtusuario.Leave += txtusuario_Leave;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.White;
            btnLogin.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(168, 231);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(408, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "&INGRESAR";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(801, 81);
            panel1.TabIndex = 4;
            panel1.MouseDown += MoveForm_MouseDown;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources.CircularFondoAzul;
            pictureBox3.Location = new Point(-22, -3);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 81);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(719, 0);
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
            pictureBox1.Location = new Point(754, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // txtcontraseña
            // 
            txtcontraseña.BackColor = Color.Silver;
            txtcontraseña.BorderStyle = BorderStyle.None;
            txtcontraseña.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtcontraseña.ForeColor = Color.Black;
            txtcontraseña.Location = new Point(168, 154);
            txtcontraseña.Name = "txtcontraseña";
            txtcontraseña.Size = new Size(408, 20);
            txtcontraseña.TabIndex = 2;
            txtcontraseña.Text = "Contraseña:";
            txtcontraseña.Enter += txtcontraseña_Enter;
            txtcontraseña.KeyPress += txtcontraseña_KeyPress;
            txtcontraseña.Leave += txtcontraseña_Leave;
            // 
            // pbMostrar
            // 
            pbMostrar.Image = (Image)resources.GetObject("pbMostrar.Image");
            pbMostrar.Location = new Point(582, 143);
            pbMostrar.Name = "pbMostrar";
            pbMostrar.Size = new Size(50, 43);
            pbMostrar.SizeMode = PictureBoxSizeMode.Zoom;
            pbMostrar.TabIndex = 5;
            pbMostrar.TabStop = false;
            pbMostrar.Click += pbMostrar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label1.Location = new Point(86, 111);
            label1.Name = "label1";
            label1.Size = new Size(69, 19);
            label1.TabIndex = 6;
            label1.Text = "Usuario:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            label2.Location = new Point(49, 153);
            label2.Name = "label2";
            label2.Size = new Size(102, 19);
            label2.TabIndex = 7;
            label2.Text = "Contraseña:";
            // 
            // llReestablecer
            // 
            llReestablecer.AutoSize = true;
            llReestablecer.Font = new Font("Segoe UI", 12F);
            llReestablecer.Location = new Point(243, 192);
            llReestablecer.Name = "llReestablecer";
            llReestablecer.Size = new Size(257, 21);
            llReestablecer.TabIndex = 8;
            llReestablecer.TabStop = true;
            llReestablecer.Text = "Perdí mi contraseña, necesito ayuda";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(780, 287);
            Controls.Add(llReestablecer);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pbMostrar);
            Controls.Add(txtcontraseña);
            Controls.Add(panel1);
            Controls.Add(btnLogin);
            Controls.Add(txtusuario);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            MouseDown += MoveForm_MouseDown;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbMostrar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtusuario;
        private Button btnLogin;
        private Panel panel1;
        private TextBox txtcontraseña;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private PictureBox pbMostrar;
        private Label label1;
        private Label label2;
        private LinkLabel llReestablecer;
    }
}
