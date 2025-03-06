namespace PreyectoDesarrollo_unicah
{
    partial class frmDocente
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
            Button btnLogout;
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            dgvDoc = new DataGridView();
            clmClase = new DataGridViewTextBoxColumn();
            clmSeccion = new DataGridViewTextBoxColumn();
            clmLunes = new DataGridViewCheckBoxColumn();
            clmMartes = new DataGridViewCheckBoxColumn();
            clmMiercoles = new DataGridViewCheckBoxColumn();
            clmJueves = new DataGridViewCheckBoxColumn();
            clmViernes = new DataGridViewCheckBoxColumn();
            clmSabado = new DataGridViewCheckBoxColumn();
            label1 = new Label();
            label2 = new Label();
            nudWeeks = new NumericUpDown();
            lblDoc = new Label();
            lblMeses = new Label();
            pictureBox3 = new PictureBox();
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(248, 290);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(126, 23);
            btnLogout.TabIndex = 17;
            btnLogout.Text = "&CERRAR SESIÓN";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(316, 3);
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
            pictureBox1.Location = new Point(351, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.HotTrack;
            panel1.Controls.Add(lblPersona);
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-4, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 87);
            panel1.TabIndex = 11;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(249, 63);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 22;
            lblPersona.Text = "Nombre_Persona";
            // 
            // dgvDoc
            // 
            dgvDoc.AllowUserToAddRows = false;
            dgvDoc.AllowUserToDeleteRows = false;
            dgvDoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoc.Columns.AddRange(new DataGridViewColumn[] { clmClase, clmSeccion, clmLunes, clmMartes, clmMiercoles, clmJueves, clmViernes, clmSabado });
            dgvDoc.Enabled = false;
            dgvDoc.Location = new Point(15, 138);
            dgvDoc.Name = "dgvDoc";
            dgvDoc.ReadOnly = true;
            dgvDoc.Size = new Size(350, 144);
            dgvDoc.TabIndex = 16;
            dgvDoc.CellContentClick += dgvDoc_CellContentClick;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.Name = "clmClase";
            clmClase.ReadOnly = true;
            clmClase.Width = 125;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Sección";
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
            // 
            // clmLunes
            // 
            clmLunes.HeaderText = "L";
            clmLunes.Name = "clmLunes";
            clmLunes.ReadOnly = true;
            clmLunes.Width = 20;
            // 
            // clmMartes
            // 
            clmMartes.HeaderText = "M";
            clmMartes.Name = "clmMartes";
            clmMartes.ReadOnly = true;
            clmMartes.Width = 22;
            // 
            // clmMiercoles
            // 
            clmMiercoles.HeaderText = "M";
            clmMiercoles.Name = "clmMiercoles";
            clmMiercoles.ReadOnly = true;
            clmMiercoles.Width = 22;
            // 
            // clmJueves
            // 
            clmJueves.HeaderText = "J";
            clmJueves.Name = "clmJueves";
            clmJueves.ReadOnly = true;
            clmJueves.Width = 20;
            // 
            // clmViernes
            // 
            clmViernes.HeaderText = "V";
            clmViernes.Name = "clmViernes";
            clmViernes.ReadOnly = true;
            clmViernes.Width = 20;
            // 
            // clmSabado
            // 
            clmSabado.HeaderText = "S";
            clmSabado.Name = "clmSabado";
            clmSabado.ReadOnly = true;
            clmSabado.Resizable = DataGridViewTriState.True;
            clmSabado.SortMode = DataGridViewColumnSortMode.Automatic;
            clmSabado.Width = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(127, 92);
            label1.Name = "label1";
            label1.Size = new Size(132, 15);
            label1.TabIndex = 15;
            label1.Text = "ASISTENCIA PERSONAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(130, 115);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 18;
            label2.Text = "Semana:";
            // 
            // nudWeeks
            // 
            nudWeeks.Location = new Point(186, 110);
            nudWeeks.Name = "nudWeeks";
            nudWeeks.Size = new Size(49, 23);
            nudWeeks.TabIndex = 19;
            // 
            // lblDoc
            // 
            lblDoc.AutoSize = true;
            lblDoc.Location = new Point(12, 294);
            lblDoc.Name = "lblDoc";
            lblDoc.Size = new Size(51, 15);
            lblDoc.TabIndex = 20;
            lblDoc.Text = "Docente";
            lblDoc.Visible = false;
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(323, 92);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(48, 15);
            lblMeses.TabIndex = 21;
            lblMeses.Text = "Periodo";
            lblMeses.Visible = false;
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
            // frmDocente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 318);
            Controls.Add(lblMeses);
            Controls.Add(lblDoc);
            Controls.Add(nudWeeks);
            Controls.Add(label2);
            Controls.Add(btnLogout);
            Controls.Add(dgvDoc);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDocente";
            Text = "FrmReporte";
            Load += frmDocente_Load;
            MouseDown += frmDocente_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private DataGridView dgvDoc;
        private Label label1;
        private Label lblPersona;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewCheckBoxColumn clmLunes;
        private DataGridViewCheckBoxColumn clmMartes;
        private DataGridViewCheckBoxColumn clmMiercoles;
        private DataGridViewCheckBoxColumn clmJueves;
        private DataGridViewCheckBoxColumn clmViernes;
        private DataGridViewCheckBoxColumn clmSabado;
        private Label label2;
        private NumericUpDown nudWeeks;
        private Label lblDoc;
        private Label lblMeses;
        private PictureBox pictureBox3;
    }
}