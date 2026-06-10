namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmMainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMainMenu));
            pnlMenuLateral = new Panel();
            btnUsuarios = new Button();
            btnCerrarSesion = new Button();
            btnReportes = new Button();
            btnGastos = new Button();
            btnProveedores = new Button();
            btnInventario = new Button();
            btnPuntoVenta = new Button();
            picLogo = new PictureBox();
            pnlEncabezado = new Panel();
            btnCerrarModulo = new Button();
            lblFecha = new Label();
            lblHora = new Label();
            panel1 = new Panel();
            lblUsuarioActivo = new Label();
            pnlContenedorPrincipal = new Panel();
            tmrReloj = new System.Windows.Forms.Timer(components);
            pnlMenuLateral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
            pnlEncabezado.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenuLateral
            // 
            pnlMenuLateral.BackColor = Color.FromArgb(10, 25, 47);
            pnlMenuLateral.Controls.Add(btnUsuarios);
            pnlMenuLateral.Controls.Add(btnCerrarSesion);
            pnlMenuLateral.Controls.Add(btnReportes);
            pnlMenuLateral.Controls.Add(btnGastos);
            pnlMenuLateral.Controls.Add(btnProveedores);
            pnlMenuLateral.Controls.Add(btnInventario);
            pnlMenuLateral.Controls.Add(btnPuntoVenta);
            pnlMenuLateral.Controls.Add(picLogo);
            pnlMenuLateral.Dock = DockStyle.Left;
            pnlMenuLateral.Location = new Point(0, 0);
            pnlMenuLateral.Name = "pnlMenuLateral";
            pnlMenuLateral.Size = new Size(300, 673);
            pnlMenuLateral.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatAppearance.BorderSize = 0;
            btnUsuarios.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 216);
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuarios.ForeColor = Color.White;
            btnUsuarios.Location = new Point(0, 480);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(20, 0, 0, 0);
            btnUsuarios.Size = new Size(300, 68);
            btnUsuarios.TabIndex = 7;
            btnUsuarios.Text = "👤​ Gestión de Perfiles";
            btnUsuarios.TextAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            btnCerrarSesion.BackColor = Color.FromArgb(217, 4, 41);
            btnCerrarSesion.Cursor = Cursors.Hand;
            btnCerrarSesion.Dock = DockStyle.Bottom;
            btnCerrarSesion.FlatAppearance.BorderSize = 0;
            btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            btnCerrarSesion.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarSesion.ForeColor = Color.White;
            btnCerrarSesion.Location = new Point(0, 604);
            btnCerrarSesion.Name = "btnCerrarSesion";
            btnCerrarSesion.Padding = new Padding(20, 0, 0, 0);
            btnCerrarSesion.Size = new Size(300, 69);
            btnCerrarSesion.TabIndex = 5;
            btnCerrarSesion.Text = "​​ ❌​ Cerrar Cesión";
            btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
            btnCerrarSesion.UseVisualStyleBackColor = false;
            btnCerrarSesion.Click += btnCerrarSesion_Click;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatAppearance.BorderSize = 0;
            btnReportes.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 216);
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = Color.White;
            btnReportes.Location = new Point(0, 412);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(20, 0, 0, 0);
            btnReportes.Size = new Size(300, 68);
            btnReportes.TabIndex = 4;
            btnReportes.Text = "​​​📜​​ Reportes Financieros";
            btnReportes.TextAlign = ContentAlignment.MiddleLeft;
            btnReportes.UseVisualStyleBackColor = true;
            // 
            // btnGastos
            // 
            btnGastos.Cursor = Cursors.Hand;
            btnGastos.Dock = DockStyle.Top;
            btnGastos.FlatAppearance.BorderSize = 0;
            btnGastos.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 216);
            btnGastos.FlatStyle = FlatStyle.Flat;
            btnGastos.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGastos.ForeColor = Color.White;
            btnGastos.Location = new Point(0, 344);
            btnGastos.Name = "btnGastos";
            btnGastos.Padding = new Padding(20, 0, 0, 0);
            btnGastos.Size = new Size(300, 68);
            btnGastos.TabIndex = 3;
            btnGastos.Text = "💸 ​Gastos";
            btnGastos.TextAlign = ContentAlignment.MiddleLeft;
            btnGastos.UseVisualStyleBackColor = true;
            btnGastos.Click += btnGastos_Click;
            // 
            // btnProveedores
            // 
            btnProveedores.Cursor = Cursors.Hand;
            btnProveedores.Dock = DockStyle.Top;
            btnProveedores.FlatAppearance.BorderSize = 0;
            btnProveedores.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 216);
            btnProveedores.FlatStyle = FlatStyle.Flat;
            btnProveedores.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProveedores.ForeColor = Color.White;
            btnProveedores.Location = new Point(0, 276);
            btnProveedores.Name = "btnProveedores";
            btnProveedores.Padding = new Padding(20, 0, 0, 0);
            btnProveedores.Size = new Size(300, 68);
            btnProveedores.TabIndex = 2;
            btnProveedores.Text = "🚚 ​Proveedores";
            btnProveedores.TextAlign = ContentAlignment.MiddleLeft;
            btnProveedores.UseVisualStyleBackColor = true;
            btnProveedores.Click += btnProveedores_Click;
            // 
            // btnInventario
            // 
            btnInventario.Cursor = Cursors.Hand;
            btnInventario.Dock = DockStyle.Top;
            btnInventario.FlatAppearance.BorderSize = 0;
            btnInventario.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 216);
            btnInventario.FlatStyle = FlatStyle.Flat;
            btnInventario.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnInventario.ForeColor = Color.White;
            btnInventario.Location = new Point(0, 208);
            btnInventario.Name = "btnInventario";
            btnInventario.Padding = new Padding(20, 0, 0, 0);
            btnInventario.Size = new Size(300, 68);
            btnInventario.TabIndex = 1;
            btnInventario.Text = "📦 ​Inventario";
            btnInventario.TextAlign = ContentAlignment.MiddleLeft;
            btnInventario.UseVisualStyleBackColor = true;
            btnInventario.Click += btnInventario_Click;
            // 
            // btnPuntoVenta
            // 
            btnPuntoVenta.Cursor = Cursors.Hand;
            btnPuntoVenta.Dock = DockStyle.Top;
            btnPuntoVenta.FlatAppearance.BorderSize = 0;
            btnPuntoVenta.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 180, 216);
            btnPuntoVenta.FlatStyle = FlatStyle.Flat;
            btnPuntoVenta.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPuntoVenta.ForeColor = Color.White;
            btnPuntoVenta.Location = new Point(0, 140);
            btnPuntoVenta.Name = "btnPuntoVenta";
            btnPuntoVenta.Padding = new Padding(20, 0, 0, 0);
            btnPuntoVenta.Size = new Size(300, 68);
            btnPuntoVenta.TabIndex = 0;
            btnPuntoVenta.Text = "\U0001f6d2 ​Punto de Venta";
            btnPuntoVenta.TextAlign = ContentAlignment.MiddleLeft;
            btnPuntoVenta.UseVisualStyleBackColor = true;
            btnPuntoVenta.Click += btnPuntoVenta_Click;
            // 
            // picLogo
            // 
            picLogo.Dock = DockStyle.Top;
            picLogo.Image = Properties.Resources.LOGO;
            picLogo.Location = new Point(0, 0);
            picLogo.Name = "picLogo";
            picLogo.Size = new Size(300, 140);
            picLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picLogo.TabIndex = 6;
            picLogo.TabStop = false;
            // 
            // pnlEncabezado
            // 
            pnlEncabezado.BackColor = Color.White;
            pnlEncabezado.Controls.Add(btnCerrarModulo);
            pnlEncabezado.Controls.Add(lblFecha);
            pnlEncabezado.Controls.Add(lblHora);
            pnlEncabezado.Controls.Add(panel1);
            pnlEncabezado.Controls.Add(lblUsuarioActivo);
            pnlEncabezado.Dock = DockStyle.Top;
            pnlEncabezado.Location = new Point(300, 0);
            pnlEncabezado.Name = "pnlEncabezado";
            pnlEncabezado.Size = new Size(962, 70);
            pnlEncabezado.TabIndex = 0;
            // 
            // btnCerrarModulo
            // 
            btnCerrarModulo.BackColor = Color.Red;
            btnCerrarModulo.Cursor = Cursors.Hand;
            btnCerrarModulo.FlatStyle = FlatStyle.Flat;
            btnCerrarModulo.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrarModulo.ForeColor = Color.White;
            btnCerrarModulo.Location = new Point(6, 12);
            btnCerrarModulo.Name = "btnCerrarModulo";
            btnCerrarModulo.Size = new Size(164, 43);
            btnCerrarModulo.TabIndex = 4;
            btnCerrarModulo.Text = "❌​ Cerrar Módulo";
            btnCerrarModulo.UseVisualStyleBackColor = false;
            btnCerrarModulo.Visible = false;
            btnCerrarModulo.Click += btnCerrarModulo_Click;
            // 
            // lblFecha
            // 
            lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblFecha.AutoSize = true;
            lblFecha.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFecha.ForeColor = Color.FromArgb(119, 119, 119);
            lblFecha.Location = new Point(837, 47);
            lblFecha.Name = "lblFecha";
            lblFecha.Size = new Size(60, 19);
            lblFecha.TabIndex = 3;
            lblFecha.Text = "label1";
            // 
            // lblHora
            // 
            lblHora.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHora.ForeColor = Color.FromArgb(0, 180, 216);
            lblHora.Location = new Point(796, 6);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(107, 37);
            lblHora.TabIndex = 2;
            lblHora.Text = "label1";
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(962, 1);
            panel1.TabIndex = 1;
            // 
            // lblUsuarioActivo
            // 
            lblUsuarioActivo.Anchor = AnchorStyles.None;
            lblUsuarioActivo.AutoSize = true;
            lblUsuarioActivo.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUsuarioActivo.ForeColor = Color.FromArgb(51, 51, 51);
            lblUsuarioActivo.Location = new Point(319, 24);
            lblUsuarioActivo.Name = "lblUsuarioActivo";
            lblUsuarioActivo.Size = new Size(324, 23);
            lblUsuarioActivo.TabIndex = 0;
            lblUsuarioActivo.Text = "Sesión iniciada como: [Nombre]";
            // 
            // pnlContenedorPrincipal
            // 
            pnlContenedorPrincipal.BackColor = Color.FromArgb(244, 246, 249);
            pnlContenedorPrincipal.Dock = DockStyle.Fill;
            pnlContenedorPrincipal.Location = new Point(300, 70);
            pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            pnlContenedorPrincipal.Size = new Size(962, 603);
            pnlContenedorPrincipal.TabIndex = 1;
            // 
            // tmrReloj
            // 
            tmrReloj.Enabled = true;
            tmrReloj.Interval = 1000;
            tmrReloj.Tick += tmrReloj_Tick;
            // 
            // FrmMainMenu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(pnlContenedorPrincipal);
            Controls.Add(pnlEncabezado);
            Controls.Add(pnlMenuLateral);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FrmMainMenu";
            Text = "CEVICHESYS-PRO";
            WindowState = FormWindowState.Maximized;
            Load += FrmMainMenu_Load;
            pnlMenuLateral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
            pnlEncabezado.ResumeLayout(false);
            pnlEncabezado.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMenuLateral;
        private Panel pnlEncabezado;
        private Label lblUsuarioActivo;
        private Panel pnlContenedorPrincipal;
        private Button btnReportes;
        private Button btnGastos;
        private Button btnProveedores;
        private Button btnInventario;
        private Button btnPuntoVenta;
        private Button btnCerrarSesion;
        private Panel panel1;
        private PictureBox picLogo;
        private Label lblHora;
        private Label lblFecha;
        private System.Windows.Forms.Timer tmrReloj;
        private Button btnUsuarios;
        private Button btnCerrarModulo;
    }
}