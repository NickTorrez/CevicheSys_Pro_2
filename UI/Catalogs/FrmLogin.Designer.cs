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
            pbLogo = new PictureBox();
            pnlDerecho = new Panel();
            pnlTarjeta = new Panel();
            label4 = new Label();
            btnMostrarOcultar = new Button();
            btnIngresar = new Button();
            txtPassword = new TextBox();
            label3 = new Label();
            txtUsuario = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tlpPrincipal.SuspendLayout();
            pnlIzquierdo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbLogo).BeginInit();
            pnlDerecho.SuspendLayout();
            pnlTarjeta.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tlpPrincipal
            // 
            tlpPrincipal.ColumnCount = 2;
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPrincipal.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpPrincipal.Controls.Add(pnlIzquierdo, 0, 0);
            tlpPrincipal.Controls.Add(pnlDerecho, 1, 0);
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
            pnlIzquierdo.BackColor = Color.FromArgb(0, 33, 71);
            pnlIzquierdo.Controls.Add(pbLogo);
            pnlIzquierdo.Dock = DockStyle.Fill;
            pnlIzquierdo.ForeColor = SystemColors.ControlText;
            pnlIzquierdo.Location = new Point(3, 3);
            pnlIzquierdo.Name = "pnlIzquierdo";
            pnlIzquierdo.Size = new Size(943, 1023);
            pnlIzquierdo.TabIndex = 0;
            // 
            // pbLogo
            // 
            pbLogo.Anchor = AnchorStyles.None;
            pbLogo.Image = Properties.Resources.LOGO;
            pbLogo.Location = new Point(130, 161);
            pbLogo.Name = "pbLogo";
            pbLogo.Size = new Size(700, 700);
            pbLogo.SizeMode = PictureBoxSizeMode.Zoom;
            pbLogo.TabIndex = 0;
            pbLogo.TabStop = false;
            // 
            // pnlDerecho
            // 
            pnlDerecho.BackColor = Color.WhiteSmoke;
            pnlDerecho.Controls.Add(pnlTarjeta);
            pnlDerecho.Controls.Add(panel1);
            pnlDerecho.Dock = DockStyle.Fill;
            pnlDerecho.Location = new Point(952, 3);
            pnlDerecho.Name = "pnlDerecho";
            pnlDerecho.Size = new Size(943, 1023);
            pnlDerecho.TabIndex = 1;
            // 
            // pnlTarjeta
            // 
            pnlTarjeta.Anchor = AnchorStyles.None;
            pnlTarjeta.BackColor = Color.FromArgb(253, 246, 227);
            pnlTarjeta.Controls.Add(label4);
            pnlTarjeta.Controls.Add(btnMostrarOcultar);
            pnlTarjeta.Controls.Add(btnIngresar);
            pnlTarjeta.Controls.Add(txtPassword);
            pnlTarjeta.Controls.Add(label3);
            pnlTarjeta.Controls.Add(txtUsuario);
            pnlTarjeta.Controls.Add(label2);
            pnlTarjeta.Controls.Add(label1);
            pnlTarjeta.ForeColor = Color.FromArgb(64, 64, 64);
            pnlTarjeta.Location = new Point(258, 186);
            pnlTarjeta.Name = "pnlTarjeta";
            pnlTarjeta.Size = new Size(500, 650);
            pnlTarjeta.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(171, 610);
            label4.Name = "label4";
            label4.Size = new Size(162, 23);
            label4.TabIndex = 7;
            label4.Text = "CevicheSys-Pro";
            // 
            // btnMostrarOcultar
            // 
            btnMostrarOcultar.BackColor = Color.White;
            btnMostrarOcultar.Cursor = Cursors.Hand;
            btnMostrarOcultar.FlatAppearance.BorderColor = Color.DimGray;
            btnMostrarOcultar.FlatStyle = FlatStyle.Flat;
            btnMostrarOcultar.Font = new Font("Century Gothic", 13F, FontStyle.Bold);
            btnMostrarOcultar.Location = new Point(408, 303);
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
            btnIngresar.Location = new Point(50, 420);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(400, 55);
            btnIngresar.TabIndex = 5;
            btnIngresar.Text = "INICIAR SESIÓN";
            btnIngresar.UseVisualStyleBackColor = false;
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(50, 305);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(340, 32);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(50, 270);
            label3.Name = "label3";
            label3.Size = new Size(123, 23);
            label3.TabIndex = 3;
            label3.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.BorderStyle = BorderStyle.FixedSingle;
            txtUsuario.Location = new Point(50, 195);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(400, 32);
            txtUsuario.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(50, 160);
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
            // panel1
            // 
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 623);
            panel1.Name = "panel1";
            panel1.Size = new Size(943, 400);
            panel1.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.pngtree_digital_ocean_wave_painting_png_image_6564274;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(943, 400);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(12F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(240, 240, 245);
            ClientSize = new Size(1898, 1029);
            Controls.Add(tlpPrincipal);
            Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INICIO DE SESIÓN";
            WindowState = FormWindowState.Maximized;
            Load += FrmLogin_Load;
            tlpPrincipal.ResumeLayout(false);
            pnlIzquierdo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbLogo).EndInit();
            pnlDerecho.ResumeLayout(false);
            pnlTarjeta.ResumeLayout(false);
            pnlTarjeta.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPrincipal;
        private Panel pnlIzquierdo;
        private PictureBox pbLogo;
        private Panel pnlDerecho;
        private Panel pnlTarjeta;
        private Label label2;
        private Label label1;
        private Button btnIngresar;
        private TextBox txtPassword;
        private Label label3;
        private TextBox txtUsuario;
        private Button btnMostrarOcultar;
        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
    }
}