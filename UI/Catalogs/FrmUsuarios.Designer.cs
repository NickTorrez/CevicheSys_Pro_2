namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmUsuarios
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            pnlRegistroUsuario = new Panel();
            label4 = new Label();
            btnEditarUsuario = new Button();
            btnVerPassword = new Button();
            btnDarBajaUsuario = new Button();
            btnLimpiarCampos = new Button();
            btnGuardarUsuario = new Button();
            cmbRol = new ComboBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            pnlBuscar = new Panel();
            txtBuscarUsuario = new TextBox();
            label5 = new Label();
            dgvUsuarios = new DataGridView();
            pnlRegistroUsuario.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // pnlRegistroUsuario
            // 
            pnlRegistroUsuario.BackColor = Color.White;
            pnlRegistroUsuario.Controls.Add(label4);
            pnlRegistroUsuario.Controls.Add(btnEditarUsuario);
            pnlRegistroUsuario.Controls.Add(btnVerPassword);
            pnlRegistroUsuario.Controls.Add(btnDarBajaUsuario);
            pnlRegistroUsuario.Controls.Add(btnLimpiarCampos);
            pnlRegistroUsuario.Controls.Add(btnGuardarUsuario);
            pnlRegistroUsuario.Controls.Add(cmbRol);
            pnlRegistroUsuario.Controls.Add(label3);
            pnlRegistroUsuario.Controls.Add(txtPassword);
            pnlRegistroUsuario.Controls.Add(label2);
            pnlRegistroUsuario.Controls.Add(txtUsername);
            pnlRegistroUsuario.Controls.Add(label1);
            pnlRegistroUsuario.Dock = DockStyle.Left;
            pnlRegistroUsuario.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlRegistroUsuario.Location = new Point(0, 0);
            pnlRegistroUsuario.Name = "pnlRegistroUsuario";
            pnlRegistroUsuario.Size = new Size(320, 603);
            pnlRegistroUsuario.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(14, 53);
            label4.Name = "label4";
            label4.Size = new Size(292, 23);
            label4.TabIndex = 11;
            label4.Text = "Registro o Edición de Usuario";
            // 
            // btnEditarUsuario
            // 
            btnEditarUsuario.BackColor = Color.FromArgb(0, 123, 255);
            btnEditarUsuario.FlatStyle = FlatStyle.Flat;
            btnEditarUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEditarUsuario.ForeColor = Color.White;
            btnEditarUsuario.Location = new Point(164, 445);
            btnEditarUsuario.Name = "btnEditarUsuario";
            btnEditarUsuario.Size = new Size(150, 70);
            btnEditarUsuario.TabIndex = 10;
            btnEditarUsuario.Text = "Editar Usuario";
            btnEditarUsuario.UseVisualStyleBackColor = false;
            btnEditarUsuario.Click += btnEditarUsuario_Click;
            // 
            // btnVerPassword
            // 
            btnVerPassword.FlatAppearance.BorderSize = 0;
            btnVerPassword.FlatStyle = FlatStyle.Flat;
            btnVerPassword.Location = new Point(251, 268);
            btnVerPassword.Name = "btnVerPassword";
            btnVerPassword.Size = new Size(39, 29);
            btnVerPassword.TabIndex = 9;
            btnVerPassword.Text = "👁";
            btnVerPassword.UseVisualStyleBackColor = true;
            btnVerPassword.Click += btnVerPassword_Click;
            // 
            // btnDarBajaUsuario
            // 
            btnDarBajaUsuario.BackColor = Color.FromArgb(220, 53, 69);
            btnDarBajaUsuario.FlatStyle = FlatStyle.Flat;
            btnDarBajaUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDarBajaUsuario.ForeColor = Color.White;
            btnDarBajaUsuario.Location = new Point(8, 521);
            btnDarBajaUsuario.Name = "btnDarBajaUsuario";
            btnDarBajaUsuario.Size = new Size(150, 70);
            btnDarBajaUsuario.TabIndex = 8;
            btnDarBajaUsuario.Text = "Dar de Baja";
            btnDarBajaUsuario.UseVisualStyleBackColor = false;
            btnDarBajaUsuario.Click += btnBajaUsuario_Click;
            // 
            // btnLimpiarCampos
            // 
            btnLimpiarCampos.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarCampos.FlatStyle = FlatStyle.Flat;
            btnLimpiarCampos.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiarCampos.ForeColor = Color.White;
            btnLimpiarCampos.Location = new Point(164, 521);
            btnLimpiarCampos.Name = "btnLimpiarCampos";
            btnLimpiarCampos.Size = new Size(150, 70);
            btnLimpiarCampos.TabIndex = 7;
            btnLimpiarCampos.Text = "Nuevo";
            btnLimpiarCampos.UseVisualStyleBackColor = false;
            btnLimpiarCampos.Click += btnLimpiarUsuario_Click;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = Color.FromArgb(0, 91, 150);
            btnGuardarUsuario.FlatStyle = FlatStyle.Flat;
            btnGuardarUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarUsuario.ForeColor = Color.White;
            btnGuardarUsuario.Location = new Point(8, 445);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(150, 70);
            btnGuardarUsuario.TabIndex = 6;
            btnGuardarUsuario.Text = "Guardar Usuario";
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            btnGuardarUsuario.Click += btnGuardarUsuario_Click;
            // 
            // cmbRol
            // 
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.FormattingEnabled = true;
            cmbRol.Items.AddRange(new object[] { "Admin", "", "Vendedor" });
            cmbRol.Location = new Point(30, 370);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(233, 26);
            cmbRol.TabIndex = 5;
            cmbRol.Enter += InputControl_Enter;
            cmbRol.Leave += InputControl_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(95, 333);
            label3.Name = "label3";
            label3.Size = new Size(132, 18);
            label3.TabIndex = 4;
            label3.Text = "Rol en el Sistema";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(32, 268);
            txtPassword.MaxLength = 255;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(258, 26);
            txtPassword.TabIndex = 3;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Enter += InputControl_Enter;
            txtPassword.Leave += InputControl_Leave;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 233);
            label2.Name = "label2";
            label2.Size = new Size(93, 18);
            label2.TabIndex = 2;
            label2.Text = "Contraseña";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(30, 175);
            txtUsername.MaxLength = 50;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(233, 26);
            txtUsername.TabIndex = 1;
            txtUsername.Enter += InputControl_Enter;
            txtUsername.Leave += InputControl_Leave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(86, 129);
            label1.Name = "label1";
            label1.Size = new Size(150, 18);
            label1.TabIndex = 0;
            label1.Text = "Nombre de Usuario";
            // 
            // pnlBuscar
            // 
            pnlBuscar.Controls.Add(txtBuscarUsuario);
            pnlBuscar.Controls.Add(label5);
            pnlBuscar.Dock = DockStyle.Top;
            pnlBuscar.Location = new Point(320, 0);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(642, 75);
            pnlBuscar.TabIndex = 2;
            // 
            // txtBuscarUsuario
            // 
            txtBuscarUsuario.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarUsuario.Location = new Point(229, 25);
            txtBuscarUsuario.Name = "txtBuscarUsuario";
            txtBuscarUsuario.Size = new Size(268, 26);
            txtBuscarUsuario.TabIndex = 1;
            txtBuscarUsuario.TextChanged += txtBuscarUsuario_TextChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(146, 27);
            label5.Name = "label5";
            label5.Size = new Size(74, 22);
            label5.TabIndex = 0;
            label5.Text = "Buscar:";
            // 
            // dgvUsuarios
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.GridColor = Color.LightGray;
            dgvUsuarios.Location = new Point(320, 75);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(642, 528);
            dgvUsuarios.TabIndex = 3;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(dgvUsuarios);
            Controls.Add(pnlBuscar);
            Controls.Add(pnlRegistroUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmUsuarios";
            Text = "FrmUsuarios";
            Load += FrmUsuarios_Load;
            pnlRegistroUsuario.ResumeLayout(false);
            pnlRegistroUsuario.PerformLayout();
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRegistroUsuario;
        private Label label1;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUsername;
        private Button btnDarBajaUsuario;
        private Button btnLimpiarCampos;
        private Button btnGuardarUsuario;
        private ComboBox cmbRol;
        private Button btnVerPassword;
        private Button btnEditarUsuario;
        private Label label4;
        private Panel pnlBuscar;
        private DataGridView dgvUsuarios;
        private TextBox txtBuscarUsuario;
        private Label label5;
    }
}