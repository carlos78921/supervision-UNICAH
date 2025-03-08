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
            pictureBox3 = new PictureBox();
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
            btnLogout = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).BeginInit();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(283, 387);
            btnLogout.Margin = new Padding(3, 4, 3, 4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(144, 31);
            btnLogout.TabIndex = 17;
            btnLogout.Text = "&CERRAR SESI�N";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(361, 4);
            pictureBox2.Margin = new Padding(3, 4, 3, 4);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(33, 27);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 7;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.CERRAR;
            pictureBox1.Location = new Point(401, 4);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(33, 27);
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
            panel1.Location = new Point(-5, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(440, 116);
            panel1.TabIndex = 11;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(285, 84);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(163, 23);
            lblPersona.TabIndex = 22;
            lblPersona.Text = "Nombre_Persona";
            lblPersona.Click += lblPersona_Click;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImageLayout = ImageLayout.None;
            pictureBox3.Image = Properties.Resources.CircularFondoAzul;
            pictureBox3.Location = new Point(-29, 0);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(163, 108);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 8;
            pictureBox3.TabStop = false;
            // 
            // dgvDoc
            // 
            dgvDoc.AllowUserToAddRows = false;
            dgvDoc.AllowUserToDeleteRows = false;
            dgvDoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoc.Columns.AddRange(new DataGridViewColumn[] { clmClase, clmSeccion, clmLunes, clmMartes, clmMiercoles, clmJueves, clmViernes, clmSabado });
            dgvDoc.Location = new Point(17, 184);
            dgvDoc.Margin = new Padding(3, 4, 3, 4);
            dgvDoc.Name = "dgvDoc";
            dgvDoc.ReadOnly = true;
            dgvDoc.RowHeadersWidth = 51;
            dgvDoc.Size = new Size(400, 192);
            dgvDoc.TabIndex = 16;
            dgvDoc.CellContentClick += dgvDoc_CellContentClick;
            // 
            // clmClase
            // 
            clmClase.HeaderText = "Asignatura";
            clmClase.MinimumWidth = 6;
            clmClase.Name = "clmClase";
            clmClase.ReadOnly = true;
            clmClase.Width = 125;
            // 
            // clmSeccion
            // 
            clmSeccion.HeaderText = "Secci�n";
            clmSeccion.MinimumWidth = 6;
            clmSeccion.Name = "clmSeccion";
            clmSeccion.ReadOnly = true;
            clmSeccion.Width = 58;
            // 
            // clmLunes
            // 
            clmLunes.HeaderText = "L";
            clmLunes.MinimumWidth = 6;
            clmLunes.Name = "clmLunes";
            clmLunes.ReadOnly = true;
            clmLunes.Width = 20;
            // 
            // clmMartes
            // 
            clmMartes.HeaderText = "M";
            clmMartes.MinimumWidth = 6;
            clmMartes.Name = "clmMartes";
            clmMartes.ReadOnly = true;
            clmMartes.Width = 22;
            // 
            // clmMiercoles
            // 
            clmMiercoles.HeaderText = "X";
            clmMiercoles.MinimumWidth = 6;
            clmMiercoles.Name = "clmMiercoles";
            clmMiercoles.ReadOnly = true;
            clmMiercoles.Width = 22;
            // 
            // clmJueves
            // 
            clmJueves.HeaderText = "J";
            clmJueves.MinimumWidth = 6;
            clmJueves.Name = "clmJueves";
            clmJueves.ReadOnly = true;
            clmJueves.Width = 20;
            // 
            // clmViernes
            // 
            clmViernes.HeaderText = "V";
            clmViernes.MinimumWidth = 6;
            clmViernes.Name = "clmViernes";
            clmViernes.ReadOnly = true;
            clmViernes.Width = 20;
            // 
            // clmSabado
            // 
            clmSabado.HeaderText = "S";
            clmSabado.MinimumWidth = 6;
            clmSabado.Name = "clmSabado";
            clmSabado.ReadOnly = true;
            clmSabado.Resizable = DataGridViewTriState.True;
            clmSabado.SortMode = DataGridViewColumnSortMode.Automatic;
            clmSabado.Width = 20;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(145, 123);
            label1.Name = "label1";
            label1.Size = new Size(165, 20);
            label1.TabIndex = 15;
            label1.Text = "ASISTENCIA PERSONAL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(149, 153);
            label2.Name = "label2";
            label2.Size = new Size(65, 20);
            label2.TabIndex = 18;
            label2.Text = "Semana:";
            // 
            // nudWeeks
            // 
            nudWeeks.Location = new Point(213, 147);
            nudWeeks.Margin = new Padding(3, 4, 3, 4);
            nudWeeks.Name = "nudWeeks";
            nudWeeks.Size = new Size(56, 27);
            nudWeeks.TabIndex = 19;
            // 
            // lblDoc
            // 
            lblDoc.AutoSize = true;
            lblDoc.Location = new Point(14, 392);
            lblDoc.Name = "lblDoc";
            lblDoc.Size = new Size(65, 20);
            lblDoc.TabIndex = 20;
            lblDoc.Text = "Docente";
            lblDoc.Visible = false;
            // 
            // lblMeses
            // 
            lblMeses.AutoSize = true;
            lblMeses.Location = new Point(369, 123);
            lblMeses.Name = "lblMeses";
            lblMeses.Size = new Size(60, 20);
            lblMeses.TabIndex = 21;
            lblMeses.Text = "Periodo";
            lblMeses.Visible = false;
            // 
            // frmDocente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 424);
            Controls.Add(lblMeses);
            Controls.Add(lblDoc);
            Controls.Add(nudWeeks);
            Controls.Add(label2);
            Controls.Add(btnLogout);
            Controls.Add(dgvDoc);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "frmDocente";
            Text = "FrmReporte";
            Load += frmDocente_Load;
            MouseDown += frmDocente_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDoc).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudWeeks).EndInit();
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
        private Label label2;
        private NumericUpDown nudWeeks;
        private Label lblDoc;
        private Label lblMeses;
        private PictureBox pictureBox3;
        private DataGridViewTextBoxColumn clmClase;
        private DataGridViewTextBoxColumn clmSeccion;
        private DataGridViewCheckBoxColumn clmLunes;
        private DataGridViewCheckBoxColumn clmMartes;
        private DataGridViewCheckBoxColumn clmMiercoles;
        private DataGridViewCheckBoxColumn clmJueves;
        private DataGridViewCheckBoxColumn clmViernes;
        private DataGridViewCheckBoxColumn clmSabado;
    }
}