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
            pnlTarjetaLogin = new Panel();
            pnlInputUsuario = new Panel();
            pbUser = new PictureBox();
            lblBienvenida = new Label();
            pbLogo = new PictureBox();
            txtUsername = new TextBox();
            panel1 = new Panel();
            pbPassword = new PictureBox();
            txtPassword = new TextBox();
            lblUser = new Label();
            lblPassword = new Label();
            lblErrorMessage = new Label();
            lnkOlvidePassword = new LinkLabel();
            btnIngresar = new Button();
            pnlTarjetaLogin.SuspendLayout();
            pnlInputUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPassword).BeginInit();
            SuspendLayout();
            // 
            // pnlTarjetaLogin
            // 
            pnlTarjetaLogin.Anchor = AnchorStyles.None;
            pnlTarjetaLogin.BackColor = Color.White;
            pnlTarjetaLogin.Controls.Add(btnIngresar);
            pnlTarjetaLogin.Controls.Add(lnkOlvidePassword);
            pnlTarjetaLogin.Controls.Add(lblErrorMessage);
            pnlTarjetaLogin.Controls.Add(lblPassword);
            pnlTarjetaLogin.Controls.Add(lblUser);
            pnlTarjetaLogin.Controls.Add(panel1);
            pnlTarjetaLogin.Controls.Add(pnlInputUsuario);
            pnlTarjetaLogin.Controls.Add(lblBienvenida);
            pnlTarjetaLogin.Controls.Add(pbLogo);
            pnlTarjetaLogin.Location = new Point(406, 36);
            pnlTarjetaLogin.Name = "pnlTarjetaLogin";
            pnlTarjetaLogin.Size = new Size(450, 600);
            pnlTarjetaLogin.TabIndex = 0;
            // 
            // pnlInputUsuario
            // 
            pnlInputUsuario.BorderStyle = BorderStyle.FixedSingle;
            pnlInputUsuario.Controls.Add(txtUsername);
            pnlInputUsuario.Controls.Add(pbUser);
            pnlInputUsuario.Location = new Point(65, 270);
            pnlInputUsuario.Name = "pnlInputUsuario";
            pnlInputUsuario.Size = new Size(320, 45);
            pnlInputUsuario.TabIndex = 3;
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
            lblBienvenida.ForeColor = Color.FromArgb(15, 23, 42);
            lblBienvenida.Location = new Point(65, 185);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(321, 34);
            lblBienvenida.TabIndex = 2;
            lblBienvenida.Text = "¡Bienvenido de nuevo!";
            // 
            // pbLogo
            // 
            pbLogo.Dock = DockStyle.Top;
            pbLogo.Image = Properties.Resources.LOGO;
            pbLogo.Location = new Point(0, 0);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(450, 150);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Century Gothic", 11F, FontStyle.Bold);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(43, 7);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(263, 30);
            txtUsername.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(pbPassword);
            panel1.Location = new Point(66, 375);
            panel1.Name = "panel1";
            panel1.Size = new Size(320, 45);
            panel1.TabIndex = 4;
            // 
            // pbPassword
            // 
            pbPassword.Image = Properties.Resources.password_3715;
            pbPassword.Location = new Point(6, 7);
            pbPassword.Name = "pbPassword";
            pbPassword.Size = new Size(32, 32);
            pbPassword.TabIndex = 0;
            pbPassword.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(44, 7);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(263, 32);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.Location = new Point(72, 244);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(81, 23);
            lblUser.TabIndex = 5;
            lblUser.Text = "Usuario";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(72, 339);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(123, 23);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Contraseña";
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblErrorMessage.Location = new Point(213, 437);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(21, 19);
            lblErrorMessage.TabIndex = 7;
            lblErrorMessage.Text = "\"\"";
            lblErrorMessage.Visible = false;
            // 
            // lnkOlvidePassword
            // 
            lnkOlvidePassword.AutoSize = true;
            lnkOlvidePassword.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lnkOlvidePassword.LinkColor = Color.FromArgb(14, 165, 233);
            lnkOlvidePassword.Location = new Point(114, 468);
            lnkOlvidePassword.Name = "lnkOlvidePassword";
            lnkOlvidePassword.Size = new Size(222, 19);
            lnkOlvidePassword.TabIndex = 8;
            lnkOlvidePassword.TabStop = true;
            lnkOlvidePassword.Text = "¿Olvidaste tu contraseña?";
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(14, 165, 233);
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(65, 524);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(320, 40);
            btnIngresar.TabIndex = 9;
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1262, 673);
            Controls.Add(pnlTarjetaLogin);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESIÓN";
            WindowState = FormWindowState.Maximized;
            Load += FrmLogin_Load;
            pnlTarjetaLogin.ResumeLayout(false);
            pnlTarjetaLogin.PerformLayout();
            pnlInputUsuario.ResumeLayout(false);
            pnlInputUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPassword).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTarjetaLogin;
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
        private LinkLabel lnkOlvidePassword;
    }
}