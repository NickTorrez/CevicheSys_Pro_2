namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            btnIngresar = new Button();
            lblErrorMessage = new Label();
            lblPassword = new Label();
            lblUser = new Label();
            panel1 = new Panel();
            btnTogglePassword = new Button();
            pbPassword = new PictureBox();
            txtPassword = new TextBox();
            pnlInputUsuario = new Panel();
            txtUsername = new TextBox();
            pbUser = new PictureBox();
            lblBienvenida = new Label();
            pbLogo = new PictureBox();
            pnlLateral = new Panel();
            pnlRegistro = new Panel();
            pnlTarjetaLogin = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPassword).BeginInit();
            pnlInputUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            pnlRegistro.SuspendLayout();
            pnlTarjetaLogin.SuspendLayout();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(247, 127, 0);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(65, 498);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(320, 40);
            btnIngresar.TabIndex = 9;
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblErrorMessage.Location = new Point(80, 443);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(135, 18);
            lblErrorMessage.TabIndex = 7;
            lblErrorMessage.Text = "\"lblErrorMessage\"";
            lblErrorMessage.Visible = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.White;
            lblPassword.Location = new Point(65, 307);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(123, 23);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Contraseña";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.ForeColor = Color.White;
            lblUser.Location = new Point(65, 195);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(81, 23);
            lblUser.TabIndex = 5;
            lblUser.Text = "Usuario";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 180, 216);
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(btnTogglePassword);
            panel1.Controls.Add(pbPassword);
            panel1.Controls.Add(txtPassword);
            panel1.Location = new Point(65, 334);
            panel1.Name = "panel1";
            panel1.Size = new Size(320, 48);
            panel1.TabIndex = 4;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = SystemColors.Window;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Location = new Point(270, 6);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(32, 30);
            btnTogglePassword.TabIndex = 10;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // pbPassword
            // 
            pbPassword.Image = Properties.Resources.password_3715;
            pbPassword.Location = new Point(6, 5);
            pbPassword.Name = "pbPassword";
            pbPassword.Size = new Size(32, 32);
            pbPassword.TabIndex = 0;
            pbPassword.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Location = new Point(43, 5);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(262, 32);
            txtPassword.TabIndex = 1;
            // 
            // pnlInputUsuario
            // 
            pnlInputUsuario.BackColor = Color.FromArgb(0, 180, 216);
            pnlInputUsuario.BorderStyle = BorderStyle.Fixed3D;
            pnlInputUsuario.Controls.Add(txtUsername);
            pnlInputUsuario.Controls.Add(pbUser);
            pnlInputUsuario.Location = new Point(66, 223);
            pnlInputUsuario.Name = "pnlInputUsuario";
            pnlInputUsuario.Size = new Size(320, 48);
            pnlInputUsuario.TabIndex = 3;
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(43, 5);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(263, 33);
            txtUsername.TabIndex = 1;
            // 
            // pbUser
            // 
            pbUser.Image = Properties.Resources.name_user_3716;
            pbUser.Location = new Point(5, 6);
            pbUser.Name = "pbUser";
            pbUser.Size = new Size(32, 32);
            pbUser.TabIndex = 0;
            pbUser.TabStop = false;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenida.ForeColor = Color.White;
            lblBienvenida.Location = new Point(18, 141);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(415, 34);
            lblBienvenida.TabIndex = 2;
            lblBienvenida.Text = "Bienvenido a CevicheSys-Pro";
            lblBienvenida.Click += lblBienvenida_Click;
            // 
            // pbLogo
            // 
            pbLogo.Dock = DockStyle.Top;
            pbLogo.Image = Properties.Resources.LOGO;
            pbLogo.Location = new Point(0, 0);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(450, 148);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // pnlLateral
            // 
            pnlLateral.BackColor = Color.FromArgb(0, 48, 73);
            pnlLateral.Dock = DockStyle.Bottom;
            pnlLateral.ForeColor = Color.Coral;
            pnlLateral.Location = new Point(0, 618);
            pnlLateral.Name = "pnlLateral";
            pnlLateral.Size = new Size(1262, 55);
            pnlLateral.TabIndex = 1;
            // 
            // pnlRegistro
            // 
            pnlRegistro.Controls.Add(pnlTarjetaLogin);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Location = new Point(0, 0);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(1262, 618);
            pnlRegistro.TabIndex = 2;
            pnlRegistro.Paint += pnlRegistro_Paint;
            // 
            // pnlTarjetaLogin
            // 
            pnlTarjetaLogin.Anchor = AnchorStyles.None;
            pnlTarjetaLogin.BackColor = Color.FromArgb(0, 48, 73);
            pnlTarjetaLogin.Controls.Add(lblBienvenida);
            pnlTarjetaLogin.Controls.Add(btnIngresar);
            pnlTarjetaLogin.Controls.Add(pbLogo);
            pnlTarjetaLogin.Controls.Add(lblErrorMessage);
            pnlTarjetaLogin.Controls.Add(lblPassword);
            pnlTarjetaLogin.Controls.Add(lblUser);
            pnlTarjetaLogin.Controls.Add(panel1);
            pnlTarjetaLogin.Controls.Add(pnlInputUsuario);
            pnlTarjetaLogin.Location = new Point(406, 9);
            pnlTarjetaLogin.Name = "pnlTarjetaLogin";
            pnlTarjetaLogin.Size = new Size(450, 600);
            pnlTarjetaLogin.TabIndex = 0;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1262, 673);
            Controls.Add(pnlRegistro);
            Controls.Add(pnlLateral);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESIÓN";
            WindowState = FormWindowState.Maximized;
            Load += FrmLogin_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPassword).EndInit();
            pnlInputUsuario.ResumeLayout(false);
            pnlInputUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            pnlRegistro.ResumeLayout(false);
            pnlTarjetaLogin.ResumeLayout(false);
            pnlTarjetaLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pbLogo;
        private Label lblBienvenida;
        private Panel pnlInputUsuario;
        private PictureBox pbUser;
        private TextBox txtUsername;
        private Panel panel1;
        private PictureBox pbPassword;
        private TextBox txtPassword;
        private Label lblErrorMessage;
        private Label lblPassword;
        private Label lblUser;
        private Button btnIngresar;
        private Button btnTogglePassword;
        private Panel pnlLateral;
        private Panel pnlRegistro;
        private Panel pnlTarjetaLogin;
    }
}