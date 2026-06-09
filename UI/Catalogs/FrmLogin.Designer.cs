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
            txtUsername = new TextBox();
            pbUser = new PictureBox();
            lblBienvenida = new Label();
            pbLogo = new PictureBox();
            pnlTarjetaLogin = new Panel();
            panel3 = new Panel();
            panel1 = new Panel();
            btnTogglePassword = new Button();
            lblSubtitulo = new Label();
            pbPassword = new PictureBox();
            txtPassword = new TextBox();
            panel2 = new Panel();
            label2 = new Label();
            label1 = new Label();
            btnCerrarApp = new Button();
            pnlRegistro = new Panel();
            ((System.ComponentModel.ISupportInitialize)pbUser).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            pnlTarjetaLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPassword).BeginInit();
            panel2.SuspendLayout();
            pnlRegistro.SuspendLayout();
            SuspendLayout();
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(247, 127, 0);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor = Color.DarkOrange;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(105, 470);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(340, 70);
            btnIngresar.TabIndex = 9;
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblErrorMessage.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblErrorMessage.ForeColor = Color.FromArgb(239, 68, 68);
            lblErrorMessage.Location = new Point(124, 407);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(302, 18);
            lblErrorMessage.TabIndex = 7;
            lblErrorMessage.Text = "\"lblErrorMessage\"";
            lblErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblErrorMessage.Visible = false;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.FromArgb(0, 5, 22, 21);
            lblPassword.Location = new Point(115, 297);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(123, 23);
            lblPassword.TabIndex = 6;
            lblPassword.Text = "Contraseña";
            // 
            // lblUser
            // 
            lblUser.AutoSize = true;
            lblUser.ForeColor = Color.FromArgb(0, 5, 22, 21);
            lblUser.Location = new Point(115, 205);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(81, 23);
            lblUser.TabIndex = 5;
            lblUser.Text = "Usuario";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.None;
            txtUsername.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            txtUsername.ForeColor = Color.FromArgb(15, 23, 42);
            txtUsername.Location = new Point(161, 240);
            txtUsername.Multiline = true;
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(265, 30);
            txtUsername.TabIndex = 1;
            // 
            // pbUser
            // 
            pbUser.Image = Properties.Resources.name_user_3716;
            pbUser.Location = new Point(124, 240);
            pbUser.Name = "pbUser";
            pbUser.Size = new Size(32, 32);
            pbUser.TabIndex = 0;
            pbUser.TabStop = false;
            // 
            // lblBienvenida
            // 
            lblBienvenida.AutoSize = true;
            lblBienvenida.Font = new Font("Century Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBienvenida.ForeColor = Color.FromArgb(0, 5, 22, 21);
            lblBienvenida.Location = new Point(56, 51);
            lblBienvenida.Name = "lblBienvenida";
            lblBienvenida.Size = new Size(390, 56);
            lblBienvenida.TabIndex = 2;
            lblBienvenida.Text = "¡Hola de Nuevo!";
            // 
            // pbLogo
            // 
            pbLogo.Image = Properties.Resources.LOGO;
            pbLogo.Location = new Point(0, 164);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(500, 344);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // pnlTarjetaLogin
            // 
            pnlTarjetaLogin.Anchor = AnchorStyles.None;
            pnlTarjetaLogin.BackColor = Color.White;
            pnlTarjetaLogin.Controls.Add(panel3);
            pnlTarjetaLogin.Controls.Add(pbUser);
            pnlTarjetaLogin.Controls.Add(txtUsername);
            pnlTarjetaLogin.Controls.Add(panel1);
            pnlTarjetaLogin.Controls.Add(btnTogglePassword);
            pnlTarjetaLogin.Controls.Add(lblSubtitulo);
            pnlTarjetaLogin.Controls.Add(pbPassword);
            pnlTarjetaLogin.Controls.Add(lblBienvenida);
            pnlTarjetaLogin.Controls.Add(txtPassword);
            pnlTarjetaLogin.Controls.Add(btnIngresar);
            pnlTarjetaLogin.Controls.Add(lblErrorMessage);
            pnlTarjetaLogin.Controls.Add(lblPassword);
            pnlTarjetaLogin.Controls.Add(lblUser);
            pnlTarjetaLogin.Location = new Point(106, 24);
            pnlTarjetaLogin.Name = "pnlTarjetaLogin";
            pnlTarjetaLogin.Size = new Size(550, 625);
            pnlTarjetaLogin.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Turquoise;
            panel3.Location = new Point(161, 267);
            panel3.Name = "panel3";
            panel3.Size = new Size(265, 5);
            panel3.TabIndex = 12;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Turquoise;
            panel1.Location = new Point(162, 359);
            panel1.Name = "panel1";
            panel1.Size = new Size(265, 5);
            panel1.TabIndex = 11;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = SystemColors.Window;
            btnTogglePassword.Cursor = Cursors.Hand;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Location = new Point(392, 333);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(32, 28);
            btnTogglePassword.TabIndex = 10;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSubtitulo.ForeColor = Color.FromArgb(0, 5, 22, 21);
            lblSubtitulo.Location = new Point(62, 118);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(263, 37);
            lblSubtitulo.TabIndex = 10;
            lblSubtitulo.Text = "Ingresa tus Datos";
            // 
            // pbPassword
            // 
            pbPassword.Image = Properties.Resources.password_3715;
            pbPassword.Location = new Point(124, 332);
            pbPassword.Name = "pbPassword";
            pbPassword.Size = new Size(32, 32);
            pbPassword.TabIndex = 0;
            pbPassword.TabStop = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Location = new Point(161, 332);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(265, 30);
            txtPassword.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(10, 25, 47);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(pbLogo);
            panel2.Dock = DockStyle.Left;
            panel2.ForeColor = SystemColors.ControlText;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 673);
            panel2.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(61, 513);
            label2.Name = "label2";
            label2.Size = new Size(379, 56);
            label2.TabIndex = 3;
            label2.Text = "CevicheSys-Pro";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(53, 471);
            label1.Name = "label1";
            label1.Size = new Size(395, 47);
            label1.TabIndex = 2;
            label1.Text = "Sistema de Gestion";
            // 
            // btnCerrarApp
            // 
            btnCerrarApp.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCerrarApp.BackColor = Color.Red;
            btnCerrarApp.FlatStyle = FlatStyle.Flat;
            btnCerrarApp.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarApp.ForeColor = Color.White;
            btnCerrarApp.Location = new Point(625, 0);
            btnCerrarApp.Name = "btnCerrarApp";
            btnCerrarApp.Size = new Size(137, 60);
            btnCerrarApp.TabIndex = 1;
            btnCerrarApp.Text = "❌​ Close";
            btnCerrarApp.UseVisualStyleBackColor = false;
            btnCerrarApp.Click += button1_Click;
            // 
            // pnlRegistro
            // 
            pnlRegistro.BackColor = Color.Linen;
            pnlRegistro.Controls.Add(btnCerrarApp);
            pnlRegistro.Controls.Add(pnlTarjetaLogin);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Location = new Point(500, 0);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(762, 673);
            pnlRegistro.TabIndex = 2;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1262, 673);
            Controls.Add(pnlRegistro);
            Controls.Add(panel2);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESIÓN CEVICHESYS-PRO";
            WindowState = FormWindowState.Maximized;
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pbUser).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            pnlTarjetaLogin.ResumeLayout(false);
            pnlTarjetaLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPassword).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            pnlRegistro.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PictureBox pbLogo;
        private Label lblBienvenida;
        private PictureBox pbUser;
        private TextBox txtUsername;
        private Label lblErrorMessage;
        private Label lblPassword;
        private Label lblUser;
        private Button btnIngresar;
        private Panel pnlTarjetaLogin;
        private Panel panel2;
        private Label label2;
        private Label label1;
        private Label lblSubtitulo;
        private Panel pnlRegistro;
        private Panel panel1;
        private Button btnTogglePassword;
        private PictureBox pbPassword;
        private TextBox txtPassword;
        private Panel panel3;
        private Button btnCerrarApp;
    }
}