namespace PreyectoDesarrollo_unicah
{
    partial class frmAdmin
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
            Button btnLogout;
            Button btnName;
            Button btnSQL;
            Button btnReinicioBDD;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel1 = new Panel();
            lblPersona = new Label();
            pictureBox3 = new PictureBox();
            dgvAdmin = new DataGridView();
            label1 = new Label();
            lblParcial = new Label();
            lblWeek = new Label();
            mesAdmin = new MonthCalendar();
            dtpInicio = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            dtpFin = new DateTimePicker();
            groupBox1 = new GroupBox();
            btnPeriodo = new Button();
            groupBox2 = new GroupBox();
            lblBusca = new Label();
            txtBusca = new TextBox();
            toolTip1 = new ToolTip(components);
            btnLogout = new Button();
            btnName = new Button();
            btnSQL = new Button();
            btnReinicioBDD = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdmin).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // btnLogout
            // 
            btnLogout.Font = new Font("Segoe UI", 9F);
            btnLogout.Location = new Point(17, 270);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(117, 32);
            btnLogout.TabIndex = 8;
            btnLogout.Text = "CERRAR &SESIÓN";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += Salir;
            // 
            // btnName
            // 
            btnName.Font = new Font("Segoe UI", 9F);
            btnName.Location = new Point(17, 124);
            btnName.Name = "btnName";
            btnName.Size = new Size(117, 47);
            btnName.TabIndex = 25;
            btnName.Text = "&ACTUALIZAR \r\nDATOS EMPLEADO";
            btnName.UseVisualStyleBackColor = true;
            btnName.Click += btnName_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.minimizar_signo;
            pictureBox2.Location = new Point(944, 3);
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
            pictureBox1.Location = new Point(979, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(29, 20);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.Click += Salir;
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
            panel1.Size = new Size(1026, 87);
            panel1.TabIndex = 11;
            panel1.MouseDown += MoveForm_MouseDown;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.ForeColor = Color.White;
            lblPersona.Location = new Point(876, 63);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(132, 18);
            lblPersona.TabIndex = 16;
            lblPersona.Text = "Nombre_Persona";
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
            // dgvAdmin
            // 
            dgvAdmin.AllowUserToAddRows = false;
            dgvAdmin.AllowUserToDeleteRows = false;
            dgvAdmin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAdmin.Location = new Point(13, 160);
            dgvAdmin.MultiSelect = false;
            dgvAdmin.Name = "dgvAdmin";
            dgvAdmin.Size = new Size(582, 400);
            dgvAdmin.TabIndex = 13;
            dgvAdmin.CellClick += dgvAdmin_CellClick;
            dgvAdmin.CellEndEdit += dgvAdmin_CellEndEdit;
            dgvAdmin.CellFormatting += dgvAdmin_CellFormatting;
            dgvAdmin.EditingControlShowing += dgvAdmin_EditingControlShowing;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(453, 99);
            label1.Name = "label1";
            label1.Size = new Size(129, 15);
            label1.TabIndex = 12;
            label1.Text = "MIGRACIÓN DE DATOS";
            // 
            // lblParcial
            // 
            lblParcial.AutoSize = true;
            lblParcial.Font = new Font("Segoe UI", 10F);
            lblParcial.Location = new Point(650, 229);
            lblParcial.Name = "lblParcial";
            lblParcial.Size = new Size(48, 19);
            lblParcial.TabIndex = 16;
            lblParcial.Text = "Parcial";
            // 
            // lblWeek
            // 
            lblWeek.AutoSize = true;
            lblWeek.Font = new Font("Segoe UI", 10F);
            lblWeek.Location = new Point(761, 229);
            lblWeek.Name = "lblWeek";
            lblWeek.Size = new Size(57, 19);
            lblWeek.TabIndex = 17;
            lblWeek.Text = "Semana";
            // 
            // mesAdmin
            // 
            mesAdmin.CalendarDimensions = new Size(1, 2);
            mesAdmin.Location = new Point(607, 253);
            mesAdmin.Name = "mesAdmin";
            mesAdmin.TabIndex = 19;
            mesAdmin.DateSelected += mesAdmin_DateSelected;
            // 
            // dtpInicio
            // 
            dtpInicio.Location = new Point(60, 22);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(210, 23);
            dtpInicio.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(7, 28);
            label2.Name = "label2";
            label2.Size = new Size(39, 15);
            label2.TabIndex = 21;
            label2.Text = "Inicio:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 66);
            label3.Name = "label3";
            label3.Size = new Size(35, 15);
            label3.TabIndex = 23;
            label3.Text = "Final:";
            // 
            // dtpFin
            // 
            dtpFin.Location = new Point(59, 60);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(210, 23);
            dtpFin.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpInicio);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(dtpFin);
            groupBox1.Location = new Point(611, 124);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(276, 100);
            groupBox1.TabIndex = 24;
            groupBox1.TabStop = false;
            groupBox1.Text = "Periodo";
            // 
            // btnPeriodo
            // 
            btnPeriodo.Location = new Point(898, 152);
            btnPeriodo.Name = "btnPeriodo";
            btnPeriodo.Size = new Size(106, 44);
            btnPeriodo.TabIndex = 3;
            btnPeriodo.Text = "&DEFINIR\r\nPERIODO";
            btnPeriodo.UseVisualStyleBackColor = true;
            btnPeriodo.Click += btnPeriodo_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnName);
            groupBox2.Controls.Add(btnSQL);
            groupBox2.Controls.Add(btnReinicioBDD);
            groupBox2.Controls.Add(btnLogout);
            groupBox2.Font = new Font("Segoe UI", 11F);
            groupBox2.Location = new Point(862, 244);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(149, 316);
            groupBox2.TabIndex = 25;
            groupBox2.TabStop = false;
            groupBox2.Text = "Opciones";
            // 
            // btnSQL
            // 
            btnSQL.Font = new Font("Segoe UI", 9F);
            btnSQL.Location = new Point(17, 48);
            btnSQL.Name = "btnSQL";
            btnSQL.Size = new Size(117, 59);
            btnSQL.TabIndex = 4;
            btnSQL.Text = "&MIGRAR DATOS \r\nDE EXCEL A LA \r\nBASE DE DATOS";
            btnSQL.UseVisualStyleBackColor = true;
            btnSQL.Click += btnSQL_Click;
            // 
            // btnReinicioBDD
            // 
            btnReinicioBDD.Font = new Font("Segoe UI", 9F);
            btnReinicioBDD.Location = new Point(17, 209);
            btnReinicioBDD.Name = "btnReinicioBDD";
            btnReinicioBDD.Size = new Size(117, 46);
            btnReinicioBDD.TabIndex = 5;
            btnReinicioBDD.Text = "&REINICIAR \r\nBASE DE DATOS";
            btnReinicioBDD.UseVisualStyleBackColor = true;
            btnReinicioBDD.Click += btnReinicioBDD_Click;
            // 
            // lblBusca
            // 
            lblBusca.AutoSize = true;
            lblBusca.Location = new Point(12, 136);
            lblBusca.Name = "lblBusca";
            lblBusca.Size = new Size(45, 15);
            lblBusca.TabIndex = 26;
            lblBusca.Text = "Buscar:";
            // 
            // txtBusca
            // 
            txtBusca.Location = new Point(63, 131);
            txtBusca.Name = "txtBusca";
            txtBusca.Size = new Size(532, 23);
            txtBusca.TabIndex = 27;
            toolTip1.SetToolTip(txtBusca, "Presiona Enter para mayor efecto");
            txtBusca.KeyDown += txtBusca_KeyDown;
            // 
            // frmAdmin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1020, 576);
            Controls.Add(txtBusca);
            Controls.Add(lblBusca);
            Controls.Add(btnPeriodo);
            Controls.Add(groupBox1);
            Controls.Add(mesAdmin);
            Controls.Add(lblWeek);
            Controls.Add(lblParcial);
            Controls.Add(panel1);
            Controls.Add(dgvAdmin);
            Controls.Add(label1);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmAdmin";
            Text = "FrmReporte";
            Load += frmMigración_Load;
            MouseDown += MoveForm_MouseDown;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdmin).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Panel panel1;
        private PictureBox pictureBox3;
        private DataGridView dgvAdmin;
        private Label label1;
        private Label lblPersona;
        private Label lblParcial;
        private Label lblWeek;
        private MonthCalendar mesAdmin;
        private DateTimePicker dtpInicio;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpFin;
        private GroupBox groupBox1;
        private Button btnPeriodo;
        private Button btnName;
        private Button btnSQL;
        private Button btnReinicioBDD;
        private GroupBox groupBox2;
        private Label lblBusca;
        private TextBox txtBusca;
        private ToolTip toolTip1;
    }
}