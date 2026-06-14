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
            btnVerPassword = new Button();
            btnBajaUsuario = new Button();
            btnLimpiarUsuario = new Button();
            btnGuardarUsuario = new Button();
            comboBox1 = new ComboBox();
            label3 = new Label();
            txtPassword = new TextBox();
            label2 = new Label();
            txtUsername = new TextBox();
            label1 = new Label();
            dgvUsuarios = new DataGridView();
            pnlRegistroUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // pnlRegistroUsuario
            // 
            pnlRegistroUsuario.BackColor = Color.FromArgb(248, 249, 250);
            pnlRegistroUsuario.Controls.Add(btnVerPassword);
            pnlRegistroUsuario.Controls.Add(btnBajaUsuario);
            pnlRegistroUsuario.Controls.Add(btnLimpiarUsuario);
            pnlRegistroUsuario.Controls.Add(btnGuardarUsuario);
            pnlRegistroUsuario.Controls.Add(comboBox1);
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
            // btnVerPassword
            // 
            btnVerPassword.FlatAppearance.BorderSize = 0;
            btnVerPassword.FlatStyle = FlatStyle.Flat;
            btnVerPassword.Location = new Point(250, 175);
            btnVerPassword.Name = "btnVerPassword";
            btnVerPassword.Size = new Size(39, 29);
            btnVerPassword.TabIndex = 9;
            btnVerPassword.Text = "👁";
            btnVerPassword.UseVisualStyleBackColor = true;
            // 
            // btnBajaUsuario
            // 
            btnBajaUsuario.BackColor = Color.FromArgb(220, 53, 69);
            btnBajaUsuario.FlatStyle = FlatStyle.Flat;
            btnBajaUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBajaUsuario.ForeColor = Color.White;
            btnBajaUsuario.Location = new Point(59, 521);
            btnBajaUsuario.Name = "btnBajaUsuario";
            btnBajaUsuario.Size = new Size(203, 70);
            btnBajaUsuario.TabIndex = 8;
            btnBajaUsuario.Text = "Dar de Baja";
            btnBajaUsuario.UseVisualStyleBackColor = false;
            // 
            // btnLimpiarUsuario
            // 
            btnLimpiarUsuario.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarUsuario.FlatStyle = FlatStyle.Flat;
            btnLimpiarUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLimpiarUsuario.ForeColor = Color.White;
            btnLimpiarUsuario.Location = new Point(59, 437);
            btnLimpiarUsuario.Name = "btnLimpiarUsuario";
            btnLimpiarUsuario.Size = new Size(203, 70);
            btnLimpiarUsuario.TabIndex = 7;
            btnLimpiarUsuario.Text = "Nuevo";
            btnLimpiarUsuario.UseVisualStyleBackColor = false;
            // 
            // btnGuardarUsuario
            // 
            btnGuardarUsuario.BackColor = Color.FromArgb(0, 91, 150);
            btnGuardarUsuario.FlatStyle = FlatStyle.Flat;
            btnGuardarUsuario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarUsuario.ForeColor = Color.White;
            btnGuardarUsuario.Location = new Point(59, 351);
            btnGuardarUsuario.Name = "btnGuardarUsuario";
            btnGuardarUsuario.Size = new Size(203, 70);
            btnGuardarUsuario.TabIndex = 6;
            btnGuardarUsuario.Text = "Guardar Usuario";
            btnGuardarUsuario.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Admin", "", "Vendedor" });
            comboBox1.Location = new Point(29, 277);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(233, 26);
            comboBox1.TabIndex = 5;
            comboBox1.Enter += InputControl_Enter;
            comboBox1.Leave += InputControl_Leave;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(94, 240);
            label3.Name = "label3";
            label3.Size = new Size(132, 18);
            label3.TabIndex = 4;
            label3.Text = "Rol en el Sistema";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(31, 175);
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
            label2.Location = new Point(114, 140);
            label2.Name = "label2";
            label2.Size = new Size(93, 18);
            label2.TabIndex = 2;
            label2.Text = "Contraseña";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(29, 82);
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
            label1.Location = new Point(85, 36);
            label1.Name = "label1";
            label1.Size = new Size(150, 18);
            label1.TabIndex = 0;
            label1.Text = "Nombre de Usuario";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dgvUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
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
            dgvUsuarios.Location = new Point(320, 0);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(642, 603);
            dgvUsuarios.TabIndex = 1;
            // 
            // FrmUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(dgvUsuarios);
            Controls.Add(pnlRegistroUsuario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmUsuarios";
            Text = "FrmUsuarios";
            pnlRegistroUsuario.ResumeLayout(false);
            pnlRegistroUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlRegistroUsuario;
        private Label label1;
        private DataGridView dgvUsuarios;
        private Label label3;
        private TextBox txtPassword;
        private Label label2;
        private TextBox txtUsername;
        private Button btnBajaUsuario;
        private Button btnLimpiarUsuario;
        private Button btnGuardarUsuario;
        private ComboBox comboBox1;
        private Button btnVerPassword;
    }
}