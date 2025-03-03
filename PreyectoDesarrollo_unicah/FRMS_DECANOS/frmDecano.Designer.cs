
namespace PreyectoDesarrollo_unicah
{
    partial class frmDecano
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
            btnLogOut = new Button();
            btnJustifica = new Button();
            btnReponer = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox3 = new PictureBox();
            label1 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogOut
            // 
            btnLogOut.Location = new Point(279, 87);
            btnLogOut.Name = "btnLogOut";
            btnLogOut.Size = new Size(123, 65);
            btnLogOut.TabIndex = 9;
            btnLogOut.Text = "&CERRAR SESIÓN";
            btnLogOut.UseVisualStyleBackColor = true;
            btnLogOut.Click += btnSalir_Click;
            // 
            // btnJustifica
            // 
            btnJustifica.Location = new Point(9, 87);
            btnJustifica.Name = "btnJustifica";
            btnJustifica.Size = new Size(123, 65);
            btnJustifica.TabIndex = 10;
            btnJustifica.Text = "&JUSTIFICACIONES";
            btnJustifica.UseVisualStyleBackColor = true;
            btnJustifica.Click += btnJustifica_Click;
            // 
            // btnReponer
            // 
            btnReponer.Location = new Point(144, 87);
            btnReponer.Name = "btnReponer";
            btnReponer.Size = new Size(123, 65);
            btnReponer.TabIndex = 11;
            btnReponer.Text = "&REPOSICIÓN DE CLASES";
            btnReponer.UseVisualStyleBackColor = true;
            btnReponer.Click += btnReponer_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(381, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(346, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(29, 20);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources.CircularFondoAzul;
            pictureBox3.Location = new Point(-21, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(143, 81);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(278, 56);
            label1.Name = "label1";
            label1.Size = new Size(132, 18);
            label1.TabIndex = 9;
            label1.Text = "Nombre_Persona";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(420, 81);
            panel1.TabIndex = 6;
            // 
            // frmDecano
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 166);
            Controls.Add(btnReponer);
            Controls.Add(btnJustifica);
            Controls.Add(btnLogOut);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDecano";
            Text = "Frm_Admin";
            Load += Frm_Admin_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        private void btnReponer_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnJustifica_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

#endregion
        private Button btnLogOut;
        private Button btnJustifica;
        private Button btnReponer;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private PictureBox pictureBox3;
        private Label label1;
        private Panel panel1;
    }
}