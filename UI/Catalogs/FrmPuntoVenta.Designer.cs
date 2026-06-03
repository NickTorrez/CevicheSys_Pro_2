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
            tbControlPOS = new TabControl();
            POS = new TabPage();
            CashClosure = new TabPage();
            splitContainer1 = new SplitContainer();
            txtBuscarPlatillo = new TextBox();
            dgvCatalogoPlatillos = new DataGridView();
            Type = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Enable = new DataGridViewTextBoxColumn();
            label1 = new Label();
            numCantidadPlatillo = new NumericUpDown();
            btnAgregarPedido = new Button();
            dgvTicket = new DataGridView();
            Dish = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            button1 = new Button();
            lblTotalPagar = new Label();
            btnProcesarVenta = new Button();
            pnlFacturacion = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            textBox1 = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            textBox2 = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label4 = new Label();
            comboBox1 = new ComboBox();
            tbControlPOS.SuspendLayout();
            POS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogoPlatillos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadPlatillo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).BeginInit();
            pnlFacturacion.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tbControlPOS
            // 
            tbControlPOS.Controls.Add(POS);
            tbControlPOS.Controls.Add(CashClosure);
            tbControlPOS.Dock = DockStyle.Fill;
            tbControlPOS.Location = new Point(0, 0);
            tbControlPOS.Name = "tbControlPOS";
            tbControlPOS.SelectedIndex = 0;
            tbControlPOS.Size = new Size(1280, 720);
            tbControlPOS.TabIndex = 0;
            // 
            // POS
            // 
            POS.Controls.Add(splitContainer1);
            POS.Cursor = Cursors.Hand;
            POS.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            POS.Location = new Point(4, 29);
            POS.Name = "POS";
            POS.Padding = new Padding(3);
            POS.Size = new Size(1272, 687);
            POS.TabIndex = 0;
            POS.Text = "Punto de Venta";
            POS.UseVisualStyleBackColor = true;
            // 
            // CashClosure
            // 
            CashClosure.Cursor = Cursors.Hand;
            CashClosure.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            CashClosure.Location = new Point(4, 29);
            CashClosure.Name = "CashClosure";
            CashClosure.Padding = new Padding(3);
            CashClosure.Size = new Size(792, 417);
            CashClosure.TabIndex = 1;
            CashClosure.Text = "Cierre de Caja";
            CashClosure.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(3, 3);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(pnlFacturacion);
            splitContainer1.Panel1.Controls.Add(btnAgregarPedido);
            splitContainer1.Panel1.Controls.Add(numCantidadPlatillo);
            splitContainer1.Panel1.Controls.Add(label1);
            splitContainer1.Panel1.Controls.Add(dgvCatalogoPlatillos);
            splitContainer1.Panel1.Controls.Add(txtBuscarPlatillo);
            splitContainer1.Panel1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(btnProcesarVenta);
            splitContainer1.Panel2.Controls.Add(lblTotalPagar);
            splitContainer1.Panel2.Controls.Add(button1);
            splitContainer1.Panel2.Controls.Add(dgvTicket);
            splitContainer1.Size = new Size(1266, 681);
            splitContainer1.SplitterDistance = 861;
            splitContainer1.TabIndex = 0;
            // 
            // txtBuscarPlatillo
            // 
            txtBuscarPlatillo.Location = new Point(258, 47);
            txtBuscarPlatillo.Name = "txtBuscarPlatillo";
            txtBuscarPlatillo.Size = new Size(344, 26);
            txtBuscarPlatillo.TabIndex = 0;
            txtBuscarPlatillo.Text = "Buscar por tipo o tamaño...";
            // 
            // dgvCatalogoPlatillos
            // 
            dgvCatalogoPlatillos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalogoPlatillos.Columns.AddRange(new DataGridViewColumn[] { Type, Size, Price, Enable });
            dgvCatalogoPlatillos.Location = new Point(197, 97);
            dgvCatalogoPlatillos.Name = "dgvCatalogoPlatillos";
            dgvCatalogoPlatillos.ReadOnly = true;
            dgvCatalogoPlatillos.RowHeadersWidth = 51;
            dgvCatalogoPlatillos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogoPlatillos.Size = new Size(466, 146);
            dgvCatalogoPlatillos.TabIndex = 1;
            // 
            // Type
            // 
            Type.HeaderText = "Tipo";
            Type.MinimumWidth = 6;
            Type.Name = "Type";
            Type.ReadOnly = true;
            Type.Width = 125;
            // 
            // Size
            // 
            Size.HeaderText = "Tamaño";
            Size.MinimumWidth = 6;
            Size.Name = "Size";
            Size.ReadOnly = true;
            Size.Width = 125;
            // 
            // Price
            // 
            Price.HeaderText = "Precio (C$)";
            Price.MinimumWidth = 6;
            Price.Name = "Price";
            Price.ReadOnly = true;
            Price.Width = 125;
            // 
            // Enable
            // 
            Enable.HeaderText = "Disponibilidad";
            Enable.MinimumWidth = 6;
            Enable.Name = "Enable";
            Enable.ReadOnly = true;
            Enable.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(258, 273);
            label1.Name = "label1";
            label1.Size = new Size(77, 18);
            label1.TabIndex = 2;
            label1.Text = "Cantidad";
            // 
            // numCantidadPlatillo
            // 
            numCantidadPlatillo.Location = new Point(341, 271);
            numCantidadPlatillo.Name = "numCantidadPlatillo";
            numCantidadPlatillo.Size = new Size(261, 26);
            numCantidadPlatillo.TabIndex = 3;
            numCantidadPlatillo.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAgregarPedido
            // 
            btnAgregarPedido.Location = new Point(324, 342);
            btnAgregarPedido.Name = "btnAgregarPedido";
            btnAgregarPedido.Size = new Size(212, 29);
            btnAgregarPedido.TabIndex = 4;
            btnAgregarPedido.Text = "➕ Agregar al Pedido";
            btnAgregarPedido.UseVisualStyleBackColor = true;
            // 
            // dgvTicket
            // 
            dgvTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTicket.Columns.AddRange(new DataGridViewColumn[] { Dish, Amount, SubTotal });
            dgvTicket.Location = new Point(20, 19);
            dgvTicket.Name = "dgvTicket";
            dgvTicket.RowHeadersWidth = 51;
            dgvTicket.Size = new Size(321, 188);
            dgvTicket.TabIndex = 0;
            // 
            // Dish
            // 
            Dish.HeaderText = "Platillo (Tipo + Tamaño)";
            Dish.MinimumWidth = 6;
            Dish.Name = "Dish";
            Dish.Width = 125;
            // 
            // Amount
            // 
            Amount.HeaderText = "Cantidad";
            Amount.MinimumWidth = 6;
            Amount.Name = "Amount";
            Amount.Width = 125;
            // 
            // SubTotal
            // 
            SubTotal.HeaderText = "SubTotal";
            SubTotal.MinimumWidth = 6;
            SubTotal.Name = "SubTotal";
            SubTotal.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(353, 20);
            button1.Name = "button1";
            button1.Size = new Size(35, 29);
            button1.TabIndex = 1;
            button1.Text = "❌​";
            button1.UseVisualStyleBackColor = true;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPagar.Location = new Point(87, 492);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(226, 37);
            lblTotalPagar.TabIndex = 2;
            lblTotalPagar.Text = "TOTAL: C$ 0.00";
            // 
            // btnProcesarVenta
            // 
            btnProcesarVenta.BackColor = Color.FromArgb(247, 127, 0);
            btnProcesarVenta.FlatStyle = FlatStyle.Flat;
            btnProcesarVenta.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProcesarVenta.ForeColor = Color.White;
            btnProcesarVenta.Location = new Point(38, 567);
            btnProcesarVenta.Name = "btnProcesarVenta";
            btnProcesarVenta.Size = new Size(325, 71);
            btnProcesarVenta.TabIndex = 3;
            btnProcesarVenta.Text = "\U0001f6d2 Procesar Facturación";
            btnProcesarVenta.UseVisualStyleBackColor = false;
            // 
            // pnlFacturacion
            // 
            pnlFacturacion.Controls.Add(flowLayoutPanel1);
            pnlFacturacion.Controls.Add(flowLayoutPanel2);
            pnlFacturacion.Controls.Add(flowLayoutPanel3);
            pnlFacturacion.Location = new Point(219, 388);
            pnlFacturacion.Name = "pnlFacturacion";
            pnlFacturacion.Padding = new Padding(30);
            pnlFacturacion.Size = new Size(432, 275);
            pnlFacturacion.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(textBox1);
            flowLayoutPanel1.Location = new Point(10, 21);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(412, 34);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Name = "label2";
            label2.Size = new Size(169, 19);
            label2.TabIndex = 0;
            label2.Text = "Nombre del Cliente";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(178, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(222, 26);
            textBox1.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(textBox2);
            flowLayoutPanel2.Location = new Point(100, 67);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(322, 34);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(79, 19);
            label3.TabIndex = 0;
            label3.Text = "Telefono";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(88, 3);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(222, 26);
            textBox2.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.Controls.Add(comboBox1);
            flowLayoutPanel3.Location = new Point(38, 107);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(384, 34);
            flowLayoutPanel3.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(147, 19);
            label4.TabIndex = 0;
            label4.Text = "Metodo de Pago";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(156, 3);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(214, 26);
            comboBox1.TabIndex = 1;
            // 
            // FrmPuntoVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1280, 720);
            Controls.Add(tbControlPOS);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmPuntoVenta";
            Text = "FrmPuntoVenta";
            tbControlPOS.ResumeLayout(false);
            POS.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCatalogoPlatillos).EndInit();
            ((System.ComponentModel.ISupportInitialize)numCantidadPlatillo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).EndInit();
            pnlFacturacion.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbControlPOS;
        private TabPage POS;
        private TabPage CashClosure;
        private SplitContainer splitContainer1;
        private DataGridView dgvCatalogoPlatillos;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Size;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Enable;
        private TextBox txtBuscarPlatillo;
        private NumericUpDown numCantidadPlatillo;
        private Label label1;
        private Button btnAgregarPedido;
        private DataGridView dgvTicket;
        private DataGridViewTextBoxColumn Dish;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn SubTotal;
        private Button btnProcesarVenta;
        private Label lblTotalPagar;
        private Button button1;
        private Panel pnlFacturacion;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label2;
        private TextBox textBox1;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private TextBox textBox2;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label4;
        private ComboBox comboBox1;
    }
}