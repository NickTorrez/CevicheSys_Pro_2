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
            splitContainer1 = new SplitContainer();
            pnlFacturacion = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            txtClienteNombre = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            txtClienteTelefono = new TextBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label4 = new Label();
            cmbMetodoPago = new ComboBox();
            btnAgregarPedido = new Button();
            numCantidadPlatillo = new NumericUpDown();
            label1 = new Label();
            dgvCatalogoPlatillos = new DataGridView();
            Type = new DataGridViewTextBoxColumn();
            Size = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Enable = new DataGridViewTextBoxColumn();
            txtBuscarPlatillo = new TextBox();
            btnProcesarVenta = new Button();
            lblTotalPagar = new Label();
            button1 = new Button();
            dgvTicket = new DataGridView();
            Dish = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            CashClosure = new TabPage();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label5 = new Label();
            cmbTipoCompra = new ComboBox();
            numEfectivoRecibido = new NumericUpDown();
            lblVueltoCambio = new Label();
            btnFinalizarVenta = new Button();
            groupBox1 = new GroupBox();
            rdbCierreAutomatico = new RadioButton();
            rdbCierreManual = new RadioButton();
            flowLayoutPanel5 = new FlowLayoutPanel();
            numFondoInicial = new NumericUpDown();
            label6 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            label7 = new Label();
            numIngresosVentas = new NumericUpDown();
            numEfectivoEntregado = new NumericUpDown();
            label8 = new Label();
            lblTotalEsperado = new Label();
            label9 = new Label();
            numEfectivoReal = new NumericUpDown();
            label10 = new Label();
            lblDescuadre = new Label();
            rtbObservaciones = new RichTextBox();
            label11 = new Label();
            btnEjecutarCierre = new Button();
            tbControlPOS.SuspendLayout();
            POS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlFacturacion.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadPlatillo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogoPlatillos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).BeginInit();
            CashClosure.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEfectivoRecibido).BeginInit();
            groupBox1.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFondoInicial).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numIngresosVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoEntregado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoReal).BeginInit();
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
            // pnlFacturacion
            // 
            pnlFacturacion.Controls.Add(btnFinalizarVenta);
            pnlFacturacion.Controls.Add(lblVueltoCambio);
            pnlFacturacion.Controls.Add(numEfectivoRecibido);
            pnlFacturacion.Controls.Add(flowLayoutPanel1);
            pnlFacturacion.Controls.Add(flowLayoutPanel2);
            pnlFacturacion.Controls.Add(flowLayoutPanel4);
            pnlFacturacion.Controls.Add(flowLayoutPanel3);
            pnlFacturacion.Location = new Point(66, 390);
            pnlFacturacion.Name = "pnlFacturacion";
            pnlFacturacion.Padding = new Padding(30);
            pnlFacturacion.Size = new Size(729, 275);
            pnlFacturacion.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label2);
            flowLayoutPanel1.Controls.Add(txtClienteNombre);
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
            // txtClienteNombre
            // 
            txtClienteNombre.Location = new Point(178, 3);
            txtClienteNombre.Name = "txtClienteNombre";
            txtClienteNombre.Size = new Size(222, 26);
            txtClienteNombre.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(txtClienteTelefono);
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
            // txtClienteTelefono
            // 
            txtClienteTelefono.Location = new Point(88, 3);
            txtClienteTelefono.Name = "txtClienteTelefono";
            txtClienteTelefono.Size = new Size(222, 26);
            txtClienteTelefono.TabIndex = 1;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.Controls.Add(label4);
            flowLayoutPanel3.Controls.Add(cmbMetodoPago);
            flowLayoutPanel3.Location = new Point(33, 110);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(389, 34);
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
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(156, 3);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(221, 26);
            cmbMetodoPago.TabIndex = 1;
            // 
            // btnAgregarPedido
            // 
            btnAgregarPedido.BackColor = Color.PaleTurquoise;
            btnAgregarPedido.FlatAppearance.BorderSize = 0;
            btnAgregarPedido.FlatAppearance.MouseOverBackColor = Color.Cyan;
            btnAgregarPedido.FlatStyle = FlatStyle.Flat;
            btnAgregarPedido.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarPedido.Location = new Point(326, 321);
            btnAgregarPedido.Name = "btnAgregarPedido";
            btnAgregarPedido.Size = new Size(212, 37);
            btnAgregarPedido.TabIndex = 4;
            btnAgregarPedido.Text = "➕ Agregar al Pedido";
            btnAgregarPedido.UseVisualStyleBackColor = false;
            // 
            // numCantidadPlatillo
            // 
            numCantidadPlatillo.Location = new Point(341, 271);
            numCantidadPlatillo.Name = "numCantidadPlatillo";
            numCantidadPlatillo.Size = new Size(261, 26);
            numCantidadPlatillo.TabIndex = 3;
            numCantidadPlatillo.TextAlign = HorizontalAlignment.Center;
            numCantidadPlatillo.Value = new decimal(new int[] { 1, 0, 0, 0 });
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
            // dgvCatalogoPlatillos
            // 
            dgvCatalogoPlatillos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCatalogoPlatillos.Columns.AddRange(new DataGridViewColumn[] { Type, Size, Price, Enable });
            dgvCatalogoPlatillos.Location = new Point(66, 97);
            dgvCatalogoPlatillos.Name = "dgvCatalogoPlatillos";
            dgvCatalogoPlatillos.ReadOnly = true;
            dgvCatalogoPlatillos.RowHeadersWidth = 51;
            dgvCatalogoPlatillos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCatalogoPlatillos.Size = new Size(729, 146);
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
            // txtBuscarPlatillo
            // 
            txtBuscarPlatillo.Location = new Point(258, 27);
            txtBuscarPlatillo.Multiline = true;
            txtBuscarPlatillo.Name = "txtBuscarPlatillo";
            txtBuscarPlatillo.Size = new Size(344, 34);
            txtBuscarPlatillo.TabIndex = 0;
            txtBuscarPlatillo.Text = "Buscar por tipo o tamaño...";
            // 
            // btnProcesarVenta
            // 
            btnProcesarVenta.BackColor = Color.FromArgb(247, 127, 0);
            btnProcesarVenta.FlatAppearance.BorderSize = 0;
            btnProcesarVenta.FlatAppearance.MouseOverBackColor = Color.FromArgb(255, 128, 0);
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
            // button1
            // 
            button1.Location = new Point(353, 14);
            button1.Name = "button1";
            button1.Size = new Size(35, 29);
            button1.TabIndex = 1;
            button1.Text = "❌​";
            button1.UseVisualStyleBackColor = true;
            // 
            // dgvTicket
            // 
            dgvTicket.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTicket.Columns.AddRange(new DataGridViewColumn[] { Dish, Amount, SubTotal });
            dgvTicket.Location = new Point(15, 49);
            dgvTicket.Name = "dgvTicket";
            dgvTicket.RowHeadersWidth = 51;
            dgvTicket.Size = new Size(370, 188);
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
            // CashClosure
            // 
            CashClosure.Controls.Add(groupBox1);
            CashClosure.Cursor = Cursors.Hand;
            CashClosure.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            CashClosure.Location = new Point(4, 29);
            CashClosure.Name = "CashClosure";
            CashClosure.Padding = new Padding(3);
            CashClosure.Size = new Size(1272, 687);
            CashClosure.TabIndex = 1;
            CashClosure.Text = "Cierre de Caja";
            CashClosure.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel4
            // 
            flowLayoutPanel4.Controls.Add(label5);
            flowLayoutPanel4.Controls.Add(cmbTipoCompra);
            flowLayoutPanel4.Location = new Point(39, 152);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            flowLayoutPanel4.Size = new Size(384, 34);
            flowLayoutPanel4.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(141, 19);
            label5.TabIndex = 0;
            label5.Text = "Tipo de Compra";
            // 
            // cmbTipoCompra
            // 
            cmbTipoCompra.FormattingEnabled = true;
            cmbTipoCompra.Location = new Point(150, 3);
            cmbTipoCompra.Name = "cmbTipoCompra";
            cmbTipoCompra.Size = new Size(221, 26);
            cmbTipoCompra.TabIndex = 1;
            // 
            // numEfectivoRecibido
            // 
            numEfectivoRecibido.DecimalPlaces = 2;
            numEfectivoRecibido.Location = new Point(439, 114);
            numEfectivoRecibido.Name = "numEfectivoRecibido";
            numEfectivoRecibido.Size = new Size(150, 26);
            numEfectivoRecibido.TabIndex = 5;
            numEfectivoRecibido.TextAlign = HorizontalAlignment.Center;
            // 
            // lblVueltoCambio
            // 
            lblVueltoCambio.AutoSize = true;
            lblVueltoCambio.Location = new Point(450, 152);
            lblVueltoCambio.Name = "lblVueltoCambio";
            lblVueltoCambio.Size = new Size(128, 18);
            lblVueltoCambio.TabIndex = 6;
            lblVueltoCambio.Text = "Cambio: C$ 0.00";
            // 
            // btnFinalizarVenta
            // 
            btnFinalizarVenta.BackColor = Color.MediumSeaGreen;
            btnFinalizarVenta.FlatAppearance.BorderSize = 0;
            btnFinalizarVenta.FlatAppearance.MouseOverBackColor = Color.Lime;
            btnFinalizarVenta.FlatStyle = FlatStyle.Flat;
            btnFinalizarVenta.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFinalizarVenta.ForeColor = SystemColors.ButtonFace;
            btnFinalizarVenta.Location = new Point(191, 203);
            btnFinalizarVenta.Name = "btnFinalizarVenta";
            btnFinalizarVenta.Size = new Size(346, 56);
            btnFinalizarVenta.TabIndex = 7;
            btnFinalizarVenta.Text = "✅ Finalizar e Imprimir Boucher";
            btnFinalizarVenta.UseVisualStyleBackColor = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEjecutarCierre);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(rtbObservaciones);
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Controls.Add(flowLayoutPanel5);
            groupBox1.Location = new Point(282, 31);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(708, 648);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Desglose de Caja";
            // 
            // rdbCierreAutomatico
            // 
            rdbCierreAutomatico.AutoSize = true;
            rdbCierreAutomatico.Location = new Point(33, 33);
            rdbCierreAutomatico.Name = "rdbCierreAutomatico";
            rdbCierreAutomatico.Size = new Size(179, 23);
            rdbCierreAutomatico.TabIndex = 0;
            rdbCierreAutomatico.TabStop = true;
            rdbCierreAutomatico.Text = "Cierre Automatico\r\n";
            rdbCierreAutomatico.UseVisualStyleBackColor = true;
            // 
            // rdbCierreManual
            // 
            rdbCierreManual.AutoSize = true;
            rdbCierreManual.Location = new Point(218, 33);
            rdbCierreManual.Name = "rdbCierreManual";
            rdbCierreManual.Size = new Size(145, 23);
            rdbCierreManual.TabIndex = 1;
            rdbCierreManual.TabStop = true;
            rdbCierreManual.Text = "Cierre Manual";
            rdbCierreManual.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel5
            // 
            flowLayoutPanel5.Controls.Add(rdbCierreAutomatico);
            flowLayoutPanel5.Controls.Add(rdbCierreManual);
            flowLayoutPanel5.Location = new Point(156, 13);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            flowLayoutPanel5.Padding = new Padding(30);
            flowLayoutPanel5.Size = new Size(397, 90);
            flowLayoutPanel5.TabIndex = 2;
            // 
            // numFondoInicial
            // 
            numFondoInicial.DecimalPlaces = 2;
            numFondoInicial.Location = new Point(253, 23);
            numFondoInicial.Name = "numFondoInicial";
            numFondoInicial.Size = new Size(224, 28);
            numFondoInicial.TabIndex = 3;
            numFondoInicial.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 20);
            label6.Name = "label6";
            label6.Size = new Size(114, 19);
            label6.TabIndex = 4;
            label6.Text = "Fondo Inicial";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label8, 0, 2);
            tableLayoutPanel1.Controls.Add(label7, 0, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 0);
            tableLayoutPanel1.Controls.Add(numFondoInicial, 1, 0);
            tableLayoutPanel1.Controls.Add(numIngresosVentas, 1, 1);
            tableLayoutPanel1.Controls.Add(numEfectivoEntregado, 1, 2);
            tableLayoutPanel1.Controls.Add(lblTotalEsperado, 1, 3);
            tableLayoutPanel1.Controls.Add(label9, 0, 3);
            tableLayoutPanel1.Controls.Add(numEfectivoReal, 1, 4);
            tableLayoutPanel1.Controls.Add(label10, 0, 4);
            tableLayoutPanel1.Controls.Add(lblDescuadre, 1, 5);
            tableLayoutPanel1.Location = new Point(105, 109);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666666F));
            tableLayoutPanel1.Size = new Size(500, 252);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(23, 55);
            label7.Name = "label7";
            label7.Size = new Size(65, 19);
            label7.TabIndex = 5;
            label7.Text = "Ventas";
            // 
            // numIngresosVentas
            // 
            numIngresosVentas.Location = new Point(253, 58);
            numIngresosVentas.Name = "numIngresosVentas";
            numIngresosVentas.Size = new Size(224, 28);
            numIngresosVentas.TabIndex = 6;
            numIngresosVentas.TextAlign = HorizontalAlignment.Center;
            // 
            // numEfectivoEntregado
            // 
            numEfectivoEntregado.DecimalPlaces = 2;
            numEfectivoEntregado.Location = new Point(253, 93);
            numEfectivoEntregado.Name = "numEfectivoEntregado";
            numEfectivoEntregado.Size = new Size(224, 28);
            numEfectivoEntregado.TabIndex = 7;
            numEfectivoEntregado.TextAlign = HorizontalAlignment.Center;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 90);
            label8.Name = "label8";
            label8.Size = new Size(162, 19);
            label8.TabIndex = 8;
            label8.Text = "Efectivo Entregado";
            // 
            // lblTotalEsperado
            // 
            lblTotalEsperado.AutoSize = true;
            lblTotalEsperado.Location = new Point(253, 125);
            lblTotalEsperado.Name = "lblTotalEsperado";
            lblTotalEsperado.Size = new Size(72, 19);
            lblTotalEsperado.TabIndex = 9;
            lblTotalEsperado.Text = "C$ 0.00";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(23, 125);
            label9.Name = "label9";
            label9.Size = new Size(46, 19);
            label9.TabIndex = 10;
            label9.Text = "Total";
            // 
            // numEfectivoReal
            // 
            numEfectivoReal.DecimalPlaces = 2;
            numEfectivoReal.Location = new Point(253, 163);
            numEfectivoReal.Name = "numEfectivoReal";
            numEfectivoReal.Size = new Size(224, 28);
            numEfectivoReal.TabIndex = 11;
            numEfectivoReal.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(23, 160);
            label10.Name = "label10";
            label10.Size = new Size(150, 19);
            label10.TabIndex = 12;
            label10.Text = "Efectivo Existente";
            // 
            // lblDescuadre
            // 
            lblDescuadre.AutoSize = true;
            lblDescuadre.ForeColor = Color.Red;
            lblDescuadre.Location = new Point(253, 195);
            lblDescuadre.Name = "lblDescuadre";
            lblDescuadre.Size = new Size(167, 19);
            lblDescuadre.TabIndex = 14;
            lblDescuadre.Text = "Faltante de C$ 0.00";
            // 
            // rtbObservaciones
            // 
            rtbObservaciones.Location = new Point(105, 406);
            rtbObservaciones.Name = "rtbObservaciones";
            rtbObservaciones.Size = new Size(500, 133);
            rtbObservaciones.TabIndex = 6;
            rtbObservaciones.Text = "";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(128, 377);
            label11.Name = "label11";
            label11.Size = new Size(134, 19);
            label11.TabIndex = 7;
            label11.Text = "Observaciones";
            // 
            // btnEjecutarCierre
            // 
            btnEjecutarCierre.BackColor = Color.FromArgb(0, 0, 192);
            btnEjecutarCierre.FlatAppearance.BorderSize = 0;
            btnEjecutarCierre.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            btnEjecutarCierre.FlatStyle = FlatStyle.Flat;
            btnEjecutarCierre.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEjecutarCierre.ForeColor = Color.White;
            btnEjecutarCierre.Location = new Point(202, 558);
            btnEjecutarCierre.Name = "btnEjecutarCierre";
            btnEjecutarCierre.Size = new Size(304, 67);
            btnEjecutarCierre.TabIndex = 8;
            btnEjecutarCierre.Text = "🔒 Registrar Cierre de Caja";
            btnEjecutarCierre.UseVisualStyleBackColor = false;
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
            pnlFacturacion.ResumeLayout(false);
            pnlFacturacion.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadPlatillo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCatalogoPlatillos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).EndInit();
            CashClosure.ResumeLayout(false);
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numEfectivoRecibido).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFondoInicial).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numIngresosVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoEntregado).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoReal).EndInit();
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
        private TextBox txtClienteNombre;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label3;
        private TextBox txtClienteTelefono;
        private FlowLayoutPanel flowLayoutPanel3;
        private Label label4;
        private ComboBox cmbMetodoPago;
        private FlowLayoutPanel flowLayoutPanel4;
        private Label label5;
        private ComboBox cmbTipoCompra;
        private Label lblVueltoCambio;
        private NumericUpDown numEfectivoRecibido;
        private Button btnFinalizarVenta;
        private GroupBox groupBox1;
        private RadioButton rdbCierreManual;
        private RadioButton rdbCierreAutomatico;
        private FlowLayoutPanel flowLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel1;
        private Label label6;
        private NumericUpDown numFondoInicial;
        private Label label7;
        private Label label8;
        private NumericUpDown numIngresosVentas;
        private NumericUpDown numEfectivoEntregado;
        private Label lblTotalEsperado;
        private Label label9;
        private NumericUpDown numEfectivoReal;
        private Label label10;
        private Label lblDescuadre;
        private RichTextBox rtbObservaciones;
        private Button btnEjecutarCierre;
        private Label label11;
    }
}