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
            pbLogo = new PictureBox();
            pnlTarjeta = new Panel();
            btnSalir = new Button();
            btnMostrarOcultar = new Button();
            btnIngresar = new Button();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUsuario = new TextBox();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            pnlTarjeta.SuspendLayout();
            SuspendLayout();
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = Properties.Resources.LOGO;
            pbLogo.Location = new Point(284, 47);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(600, 228);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 1;
            pbLogo.TabStop = false;
            // 
            // pnlTarjeta
            // 
            pnlTarjeta.Anchor = AnchorStyles.None;
            pnlTarjeta.BackColor = Color.FromArgb(253, 246, 227);
            pnlTarjeta.Controls.Add(btnSalir);
            pnlTarjeta.Controls.Add(btnMostrarOcultar);
            pnlTarjeta.Controls.Add(txtUsuario);
            pnlTarjeta.Controls.Add(txtPassword);
            pnlTarjeta.Controls.Add(btnIngresar);
            pnlTarjeta.Controls.Add(label3);
            pnlTarjeta.Controls.Add(label2);
            pnlTarjeta.Controls.Add(label1);
            pnlTarjeta.ForeColor = Color.FromArgb(64, 64, 64);
            pnlTarjeta.Location = new Point(359, 262);
            pnlTarjeta.Name = "pnlTarjeta";
            pnlTarjeta.Size = new Size(451, 538);
            pnlTarjeta.TabIndex = 2;
            // 
            // btnSalir
            // 
            btnSalir.FlatAppearance.BorderColor = Color.DarkGray;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(91, 436);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(262, 61);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir de CevicheSys-Pro";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnMostrarOcultar
            // 
            btnMostrarOcultar.BackColor = Color.White;
            btnMostrarOcultar.Cursor = Cursors.Hand;
            btnMostrarOcultar.FlatAppearance.BorderColor = Color.DimGray;
            btnMostrarOcultar.FlatStyle = FlatStyle.Flat;
            btnMostrarOcultar.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            btnMostrarOcultar.Location = new Point(362, 274);
            btnMostrarOcultar.Name = "btnMostrarOcultar";
            btnMostrarOcultar.Size = new Size(50, 30);
            btnMostrarOcultar.TabIndex = 6;
            btnMostrarOcultar.Text = "👁";
            btnMostrarOcultar.UseVisualStyleBackColor = false;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(255, 130, 0);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(39, 353);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(373, 55);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(39, 274);
            txtPassword.Multiline = true;
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(314, 30);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 240);
            label3.Name = "label3";
            label3.Size = new Size(98, 19);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Location = new Point(39, 164);
            txtUsuario.Multiline = true;
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(314, 30);
            txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 130);
            label2.Name = "label2";
            label2.Size = new Size(158, 19);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 33, 71);
            label1.Location = new Point(39, 41);
            label1.Name = "label1";
            label1.Size = new Size(289, 38);
            label1.TabIndex = 0;
            label1.Text = "¡HOLA DE NUEVO!";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkSeaGreen;
            ClientSize = new Size(1169, 830);
            Controls.Add(pnlTarjeta);
            Controls.Add(pbLogo);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESIÓN";
            WindowState = FormWindowState.Maximized;
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            pnlTarjeta.ResumeLayout(false);
            pnlTarjeta.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pbLogo;
        private Panel pnlTarjeta;
        private Button btnSalir;
        private Button btnMostrarOcultar;
        private Button btnIngresar;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsuario;
        private Label label2;
        private Label label1;
    }
}