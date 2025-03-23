namespace PreyectoDesarrollo_unicah
{
    partial class frmContraseña
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
            txtContraseña = new TextBox();
            btnContra = new Button();
            txtUsuario = new TextBox();
            btnSale = new Button();
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
            panel1.MouseDown += panel1_MouseDown;
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
            // txtContraseña
            // 
            txtContraseña.BackColor = Color.White;
            txtContraseña.BorderStyle = BorderStyle.None;
            txtContraseña.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.ForeColor = Color.Black;
            txtContraseña.Location = new Point(179, 144);
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(408, 20);
            txtContraseña.TabIndex = 9;
            txtContraseña.Text = "Contraseña nueva:";
            txtContraseña.Enter += txtContraseña_Enter;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            txtContraseña.Leave += txtContraseña_Leave;
            // 
            // btnContra
            // 
            btnContra.BackColor = Color.White;
            btnContra.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnContra.FlatStyle = FlatStyle.Flat;
            btnContra.ForeColor = Color.Black;
            btnContra.Location = new Point(179, 182);
            btnContra.Name = "btnContra";
            btnContra.Size = new Size(408, 40);
            btnContra.TabIndex = 8;
            btnContra.Text = "&REGISTRAR CONTRASEÑA";
            btnContra.UseVisualStyleBackColor = false;
            btnContra.Click += btnContra_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = Color.White;
            txtUsuario.BorderStyle = BorderStyle.None;
            txtUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUsuario.ForeColor = Color.Black;
            txtUsuario.Location = new Point(179, 101);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(408, 20);
            txtUsuario.TabIndex = 6;
            txtUsuario.Text = "Usuario:";
            txtUsuario.Enter += txtUsuario_Enter;
            txtUsuario.KeyPress += txtUsuario_KeyPress;
            txtUsuario.Leave += txtUsuario_Leave;
            // 
            // btnSale
            // 
            btnSale.BackColor = Color.White;
            btnSale.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnSale.FlatStyle = FlatStyle.Flat;
            btnSale.ForeColor = Color.Black;
            btnSale.Location = new Point(671, 87);
            btnSale.Name = "btnSale";
            btnSale.Size = new Size(81, 40);
            btnSale.TabIndex = 11;
            btnSale.Text = "&REGRESAR";
            btnSale.UseVisualStyleBackColor = false;
            btnSale.Click += btnSale_Click;
            // 
            // frmContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 236);
            Controls.Add(btnSale);
            Controls.Add(txtContraseña);
            Controls.Add(btnContra);
            Controls.Add(txtUsuario);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmContraseña";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Frmolvidecontra";
            Load += Frmolvidecontra_Load;
            MouseDown += frmContraseña_MouseDown;
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
        private TextBox txtContraseña;
        private Button btnContra;
        private TextBox txtUsuario;
        private Button btnSale;
    }
}