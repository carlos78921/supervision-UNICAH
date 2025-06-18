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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPierdoContraseña));
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            btnEnviar = new Button();
            txtCode = new TextBox();
            label2 = new Label();
            lblCode = new Label();
            btnRecibir = new Button();
            txtMail = new TextBox();
            label1 = new Label();
            toolTip1 = new ToolTip(components);
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
            btnEnviar.Location = new Point(419, 254);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(139, 40);
            btnEnviar.TabIndex = 4;
            btnEnviar.Text = "&ENVIAR CÓDIGO";
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtCode
            // 
            txtCode.Font = new Font("Century Gothic", 12F);
            txtCode.Location = new Point(231, 176);
            txtCode.Name = "txtCode";
            txtCode.Size = new Size(307, 27);
            txtCode.TabIndex = 2;
            txtCode.Text = "Código:";
            toolTip1.SetToolTip(txtCode, "Presione tecla \"Enter\" para \"Enviar\" código");
            txtCode.Enter += txtCode_Enter;
            txtCode.KeyPress += txtCode_KeyPress;
            txtCode.Leave += txtCode_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12F);
            label2.Location = new Point(310, 152);
            label2.Name = "label2";
            label2.Size = new Size(146, 21);
            label2.TabIndex = 9;
            label2.Text = "Ingrese su código";
            label2.Visible = false;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Century Gothic", 12F);
            lblCode.Location = new Point(234, 216);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(307, 21);
            lblCode.TabIndex = 11;
            lblCode.Text = "Un código ha sido enviado a su correo";
            lblCode.Visible = false;
            // 
            // btnRecibir
            // 
            btnRecibir.BackColor = Color.White;
            btnRecibir.FlatAppearance.BorderColor = SystemColors.HotTrack;
            btnRecibir.FlatStyle = FlatStyle.Flat;
            btnRecibir.ForeColor = Color.Black;
            btnRecibir.Location = new Point(219, 254);
            btnRecibir.Name = "btnRecibir";
            btnRecibir.Size = new Size(139, 40);
            btnRecibir.TabIndex = 3;
            btnRecibir.Text = "&GENERAR CÓDIGO";
            btnRecibir.UseVisualStyleBackColor = false;
            btnRecibir.Click += btnRecibir_Click;
            // 
            // txtMail
            // 
            txtMail.Font = new Font("Century Gothic", 12F);
            txtMail.Location = new Point(231, 112);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(307, 27);
            txtMail.TabIndex = 1;
            txtMail.Text = "Correo:";
            toolTip1.SetToolTip(txtMail, "Presione tecla \"Enter\" para generar código");
            txtMail.Enter += txtMail_Enter;
            txtMail.KeyPress += txtMail_KeyPress;
            txtMail.Leave += txtMail_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F);
            label1.Location = new Point(310, 88);
            label1.Name = "label1";
            label1.Size = new Size(141, 21);
            label1.TabIndex = 13;
            label1.Text = "Ingrese su correo";
            label1.Visible = false;
            // 
            // frmPierdoContraseña
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(764, 306);
            Controls.Add(txtMail);
            Controls.Add(label1);
            Controls.Add(btnRecibir);
            Controls.Add(lblCode);
            Controls.Add(txtCode);
            Controls.Add(label2);
            Controls.Add(btnEnviar);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private TextBox txtMail;
        private Label label1;
        private ToolTip toolTip1;
    }
}