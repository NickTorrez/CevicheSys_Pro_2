namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmPuntoVenta
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
            tlpPuntoVenta = new TableLayoutPanel();
            pnlPlatillo = new Panel();
            flpPlatillos = new FlowLayoutPanel();
            label1 = new Label();
            pnlCompra = new Panel();
            pnlCobro = new Panel();
            flpBotones = new FlowLayoutPanel();
            btnFinalizarVenta = new Button();
            btnCierreCaja = new Button();
            lblTotal = new Label();
            dgvCarrito = new DataGridView();
            label2 = new Label();
            tlpPuntoVenta.SuspendLayout();
            pnlPlatillo.SuspendLayout();
            pnlCompra.SuspendLayout();
            pnlCobro.SuspendLayout();
            flpBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).BeginInit();
            SuspendLayout();
            // 
            // tlpPuntoVenta
            // 
            tlpPuntoVenta.ColumnCount = 2;
            tlpPuntoVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tlpPuntoVenta.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tlpPuntoVenta.Controls.Add(pnlPlatillo, 0, 0);
            tlpPuntoVenta.Controls.Add(pnlCompra, 1, 0);
            tlpPuntoVenta.Dock = DockStyle.Fill;
            tlpPuntoVenta.Location = new Point(0, 0);
            tlpPuntoVenta.Name = "tlpPuntoVenta";
            tlpPuntoVenta.RowCount = 1;
            tlpPuntoVenta.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpPuntoVenta.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpPuntoVenta.Size = new Size(962, 603);
            tlpPuntoVenta.TabIndex = 0;
            // 
            // pnlPlatillo
            // 
            pnlPlatillo.BorderStyle = BorderStyle.FixedSingle;
            pnlPlatillo.Controls.Add(flpPlatillos);
            pnlPlatillo.Controls.Add(label1);
            pnlPlatillo.Dock = DockStyle.Fill;
            pnlPlatillo.Location = new Point(3, 3);
            pnlPlatillo.Name = "pnlPlatillo";
            pnlPlatillo.Size = new Size(571, 597);
            pnlPlatillo.TabIndex = 0;
            // 
            // flpPlatillos
            // 
            flpPlatillos.AutoScroll = true;
            flpPlatillos.BackColor = Color.White;
            flpPlatillos.Dock = DockStyle.Fill;
            flpPlatillos.Location = new Point(0, 37);
            flpPlatillos.Name = "flpPlatillos";
            flpPlatillos.Size = new Size(569, 558);
            flpPlatillos.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(260, 37);
            label1.TabIndex = 0;
            label1.Text = "Menú de Platillos";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlCompra
            // 
            pnlCompra.BorderStyle = BorderStyle.FixedSingle;
            pnlCompra.Controls.Add(pnlCobro);
            pnlCompra.Controls.Add(dgvCarrito);
            pnlCompra.Controls.Add(label2);
            pnlCompra.Dock = DockStyle.Fill;
            pnlCompra.Location = new Point(580, 3);
            pnlCompra.Name = "pnlCompra";
            pnlCompra.Size = new Size(379, 597);
            pnlCompra.TabIndex = 1;
            // 
            // pnlCobro
            // 
            pnlCobro.BackColor = Color.FromArgb(248, 249, 250);
            pnlCobro.BorderStyle = BorderStyle.FixedSingle;
            pnlCobro.Controls.Add(flpBotones);
            pnlCobro.Controls.Add(lblTotal);
            pnlCobro.Dock = DockStyle.Bottom;
            pnlCobro.Location = new Point(0, 445);
            pnlCobro.Name = "pnlCobro";
            pnlCobro.Size = new Size(377, 150);
            pnlCobro.TabIndex = 2;
            // 
            // flpBotones
            // 
            flpBotones.Anchor = AnchorStyles.None;
            flpBotones.Controls.Add(btnFinalizarVenta);
            flpBotones.Controls.Add(btnCierreCaja);
            flpBotones.Location = new Point(1, 67);
            flpBotones.Name = "flpBotones";
            flpBotones.Size = new Size(372, 73);
            flpBotones.TabIndex = 3;
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.BackColor = Color.FromArgb(40, 167, 69);
            btnFinalizarVenta.Cursor = Cursors.Hand;
            btnFinalizarVenta.FlatStyle = FlatStyle.Flat;
            btnFinalizarVenta.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFinalizarVenta.ForeColor = Color.White;
            btnFinalizarVenta.Location = new Point(3, 3);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(180, 64);
            btnFinalizarVenta.TabIndex = 1;
            btnFinalizarVenta.Text = "Finalizar Venta";
            btnFinalizarVenta.UseVisualStyleBackColor = false;
            btnFinalizarVenta.Click += btnFinalizarVenta_Click;
            // 
            // btnCierreCaja
            // 
            btnCierreCaja.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCierreCaja.BackColor = Color.FromArgb(10, 25, 47);
            btnCierreCaja.Cursor = Cursors.Hand;
            btnCierreCaja.FlatStyle = FlatStyle.Flat;
            btnCierreCaja.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCierreCaja.ForeColor = Color.White;
            btnCierreCaja.Location = new Point(189, 3);
            btnCierreCaja.Name = "btnCierreCaja";
            btnCierreCaja.Size = new Size(180, 64);
            btnCierreCaja.TabIndex = 2;
            btnCierreCaja.Text = "Cierre de Caja";
            btnCierreCaja.UseVisualStyleBackColor = false;
            btnCierreCaja.Click += btnCierreCaja_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.None;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotal.Location = new Point(89, 16);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(196, 34);
            lblTotal.TabIndex = 0;
            lblTotal.Text = "Total: C$ 0.00";
            // 
            // dgvCarrito
            // 
            dgvCarrito.AllowUserToAddRows = false;
            dgvCarrito.AllowUserToDeleteRows = false;
            dgvCarrito.BackgroundColor = Color.White;
            dgvCarrito.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCarrito.Dock = DockStyle.Fill;
            dgvCarrito.Location = new Point(0, 37);
            dgvCarrito.Name = "dgvCarrito";
            dgvCarrito.RowHeadersWidth = 51;
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCarrito.Size = new Size(377, 558);
            dgvCarrito.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Top;
            label2.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.RoyalBlue;
            label2.Location = new Point(0, 0);
            label2.Name = "label2";
            label2.Size = new Size(290, 37);
            label2.TabIndex = 0;
            label2.Text = "Carrito de Compra";
            // 
            // FrmPuntoVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 603);
            Controls.Add(tlpPuntoVenta);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPuntoVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmPuntoVenta";
            tlpPuntoVenta.ResumeLayout(false);
            pnlPlatillo.ResumeLayout(false);
            pnlPlatillo.PerformLayout();
            pnlCompra.ResumeLayout(false);
            pnlCompra.PerformLayout();
            pnlCobro.ResumeLayout(false);
            pnlCobro.PerformLayout();
            flpBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCarrito).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpPuntoVenta;
        private Panel pnlPlatillo;
        private FlowLayoutPanel flpPlatillos;
        private Label label1;
        private Panel pnlCompra;
        private DataGridView dgvCarrito;
        private Label label2;
        private Panel pnlCobro;
        private Label lblTotal;
        private Button btnCierreCaja;
        private Button btnFinalizarVenta;
        private FlowLayoutPanel flpBotones;
    }
}