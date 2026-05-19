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
            tlpPrincipal = new TableLayoutPanel();
            pnlIzquierdo = new Panel();
            pnlTarjeta = new Panel();
            btnSalir = new Button();
            btnMostrarOcultar = new Button();
            btnIngresar = new Button();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUsuario = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pbLogo = new PictureBox();
            tlpPrincipal.SuspendLayout();
            pnlIzquierdo.SuspendLayout();
            pnlTarjeta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            SuspendLayout();
            // 
            // tlpPrincipal
            // 
            tlpPrincipal.ColumnCount = 1;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPrincipal.Controls.Add(pnlIzquierdo, 0, 0);
            tlpPrincipal.Dock = DockStyle.Fill;
            tlpPrincipal.Location = new Point(0, 0);
            tlpPrincipal.Name = "tlpPrincipal";
            tlpPrincipal.RowCount = 1;
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPrincipal.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPrincipal.Size = new Size(1898, 1029);
            tlpPrincipal.TabIndex = 0;
            // 
            // pnlIzquierdo
            // 
            pnlIzquierdo.BackColor = Color.LightSeaGreen;
            pnlIzquierdo.Controls.Add(pnlTarjeta);
            pnlIzquierdo.Controls.Add(pbLogo);
            pnlIzquierdo.Dock = DockStyle.Fill;
            pnlIzquierdo.ForeColor = SystemColors.ControlText;
            pnlIzquierdo.Location = new Point(3, 3);
            pnlIzquierdo.Name = "pnlIzquierdo";
            pnlIzquierdo.Size = new Size(1892, 1023);
            pnlIzquierdo.TabIndex = 0;
            // 
            // pnlTarjeta
            // 
            pnlTarjeta.Anchor = AnchorStyles.None;
            pnlTarjeta.BackColor = Color.FromArgb(253, 246, 227);
            pnlTarjeta.Controls.Add(btnSalir);
            pnlTarjeta.Controls.Add(btnMostrarOcultar);
            pnlTarjeta.Controls.Add(btnIngresar);
            pnlTarjeta.Controls.Add(txtPassword);
            pnlTarjeta.Controls.Add(label3);
            pnlTarjeta.Controls.Add(txtUsuario);
            pnlTarjeta.Controls.Add(label2);
            pnlTarjeta.Controls.Add(label1);
            pnlTarjeta.ForeColor = Color.FromArgb(64, 64, 64);
            pnlTarjeta.Location = new Point(696, 316);
            pnlTarjeta.Name = "pnlTarjeta";
            pnlTarjeta.Size = new Size(500, 650);
            pnlTarjeta.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.FlatAppearance.BorderColor = Color.DarkGray;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Location = new Point(119, 550);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(262, 61);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir de CevicheSys-Pro";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnMostrarOcultar
            // 
            btnMostrarOcultar.BackColor = Color.White;
            btnMostrarOcultar.Cursor = Cursors.Hand;
            btnMostrarOcultar.FlatAppearance.BorderColor = Color.DimGray;
            btnMostrarOcultar.FlatStyle = FlatStyle.Flat;
            btnMostrarOcultar.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            btnMostrarOcultar.Location = new Point(408, 349);
            btnMostrarOcultar.Name = "btnMostrarOcultar";
            btnMostrarOcultar.Size = new Size(50, 35);
            btnMostrarOcultar.TabIndex = 6;
            btnMostrarOcultar.Text = "👁";
            btnMostrarOcultar.UseVisualStyleBackColor = false;
            btnMostrarOcultar.Click += btnMostrarOcultar_Click;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(255, 130, 0);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(50, 447);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(400, 55);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(50, 351);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(340, 32);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 316);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Location = new Point(50, 241);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(400, 32);
            txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 206);
            label2.Name = "label2";
            label2.Size = new Size(198, 23);
            label2.TabIndex = 1;
            label2.Text = "Nombre de Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 33, 71);
            label1.Location = new Point(50, 60);
            label1.Name = "label1";
            label1.Size = new Size(361, 47);
            label1.TabIndex = 0;
            label1.Text = "¡HOLA DE NUEVO!";
            label1.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = Properties.Resources.LOGO;
            pbLogo.Location = new Point(596, 40);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(700, 285);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            ClientSize = new Size(1898, 1029);
            Controls.Add(tlpPrincipal);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESIÓN";
            WindowState = FormWindowState.Maximized;
            Load += FrmLogin_Load;
            tlpPrincipal.ResumeLayout(false);
            pnlIzquierdo.ResumeLayout(false);
            pnlTarjeta.ResumeLayout(false);
            pnlTarjeta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel pnlIzquierdo;
        private PictureBox pbLogo;
        private Panel pnlTarjeta;
        private Button btnMostrarOcultar;
        private Button btnIngresar;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsuario;
        private Label label2;
        private Label label1;
        private Button btnSalir;
    }
}