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
            flpCatalogo = new FlowLayoutPanel();
            pnlFacturacion = new Panel();
            textBox1 = new TextBox();
            btnFinalizarVenta = new Button();
            lblVueltoCambio = new Label();
            numEfectivoRecibido = new NumericUpDown();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label2 = new Label();
            txtClienteNombre = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label3 = new Label();
            txtClienteTelefono = new TextBox();
            flowLayoutPanel4 = new FlowLayoutPanel();
            label5 = new Label();
            cmbTipoCompra = new ComboBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label4 = new Label();
            cmbMetodoPago = new ComboBox();
            btnAgregarPedido = new Button();
            numCantidadPlatillo = new NumericUpDown();
            label1 = new Label();
            txtBuscarPlatillo = new TextBox();
            btnProcesarVenta = new Button();
            lblTotalPagar = new Label();
            button1 = new Button();
            dgvTicket = new DataGridView();
            Dish = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            CashClosure = new TabPage();
            groupBox1 = new GroupBox();
            btnEjecutarCierre = new Button();
            label11 = new Label();
            flowLayoutPanel5 = new FlowLayoutPanel();
            rdbCierreAutomatico = new RadioButton();
            rdbCierreManual = new RadioButton();
            rtbObservaciones = new RichTextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            numFondoInicial = new NumericUpDown();
            numIngresosVentas = new NumericUpDown();
            numEfectivoEntregado = new NumericUpDown();
            label9 = new Label();
            numEfectivoReal = new NumericUpDown();
            label10 = new Label();
            lblDescuadre = new Label();
            lblTotalEsperado = new Label();
            label12 = new Label();
            numIngresosTransferencia = new NumericUpDown();
            tbControlPOS.SuspendLayout();
            POS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            pnlFacturacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numEfectivoRecibido).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadPlatillo).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).BeginInit();
            CashClosure.SuspendLayout();
            groupBox1.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numFondoInicial).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIngresosVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoEntregado).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoReal).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numIngresosTransferencia).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(flpCatalogo);
            splitContainer1.Panel1.Controls.Add(pnlFacturacion);
            splitContainer1.Panel1.Controls.Add(btnAgregarPedido);
            splitContainer1.Panel1.Controls.Add(numCantidadPlatillo);
            splitContainer1.Panel1.Controls.Add(label1);
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
            // flpCatalogo
            // 
            flpCatalogo.Location = new Point(66, 92);
            flpCatalogo.Name = "flpCatalogo";
            flpCatalogo.Size = new Size(729, 132);
            flpCatalogo.TabIndex = 5;
            // 
            // pnlFacturacion
            // 
            pnlFacturacion.Controls.Add(textBox1);
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
            // textBox1
            // 
            textBox1.Location = new Point(439, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(257, 26);
            textBox1.TabIndex = 8;
            textBox1.Text = "Cuenta Banpro: 10021500581239";
            textBox1.TextAlign = HorizontalAlignment.Center;
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
            // lblVueltoCambio
            // 
            lblVueltoCambio.AutoSize = true;
            lblVueltoCambio.Location = new Point(450, 152);
            lblVueltoCambio.Name = "lblVueltoCambio";
            lblVueltoCambio.Size = new Size(128, 18);
            lblVueltoCambio.TabIndex = 6;
            lblVueltoCambio.Text = "Cambio: C$ 0.00";
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
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Transferencia" });
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
            dgvTicket.RowHeadersVisible = false;
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
            // groupBox1
            // 
            groupBox1.Controls.Add(btnEjecutarCierre);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(flowLayoutPanel5);
            groupBox1.Controls.Add(rtbObservaciones);
            groupBox1.Controls.Add(tableLayoutPanel1);
            groupBox1.Location = new Point(282, 6);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(708, 673);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Desglose de Caja";
            // 
            // btnEjecutarCierre
            // 
            btnEjecutarCierre.BackColor = Color.FromArgb(0, 0, 192);
            btnEjecutarCierre.FlatAppearance.BorderSize = 0;
            btnEjecutarCierre.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 192, 192);
            btnEjecutarCierre.FlatStyle = FlatStyle.Flat;
            btnEjecutarCierre.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEjecutarCierre.ForeColor = Color.White;
            btnEjecutarCierre.Location = new Point(202, 596);
            btnEjecutarCierre.Name = "btnEjecutarCierre";
            btnEjecutarCierre.Size = new Size(304, 67);
            btnEjecutarCierre.TabIndex = 8;
            btnEjecutarCierre.Text = "🔒 Registrar Cierre de Caja";
            btnEjecutarCierre.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(123, 423);
            label11.Name = "label11";
            label11.Size = new Size(134, 19);
            label11.TabIndex = 7;
            label11.Text = "Observaciones";
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
            // rtbObservaciones
            // 
            rtbObservaciones.Location = new Point(104, 451);
            rtbObservaciones.Name = "rtbObservaciones";
            rtbObservaciones.Size = new Size(500, 133);
            rtbObservaciones.TabIndex = 6;
            rtbObservaciones.Text = "";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 53.695652F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 46.304348F));
            tableLayoutPanel1.Controls.Add(label8, 0, 3);
            tableLayoutPanel1.Controls.Add(label7, 0, 1);
            tableLayoutPanel1.Controls.Add(label6, 0, 0);
            tableLayoutPanel1.Controls.Add(numFondoInicial, 1, 0);
            tableLayoutPanel1.Controls.Add(numIngresosVentas, 1, 1);
            tableLayoutPanel1.Controls.Add(numEfectivoEntregado, 1, 3);
            tableLayoutPanel1.Controls.Add(label9, 0, 4);
            tableLayoutPanel1.Controls.Add(numEfectivoReal, 1, 5);
            tableLayoutPanel1.Controls.Add(label10, 0, 5);
            tableLayoutPanel1.Controls.Add(lblDescuadre, 1, 6);
            tableLayoutPanel1.Controls.Add(lblTotalEsperado, 1, 4);
            tableLayoutPanel1.Controls.Add(label12, 0, 2);
            tableLayoutPanel1.Controls.Add(numIngresosTransferencia, 1, 2);
            tableLayoutPanel1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            tableLayoutPanel1.Location = new Point(100, 111);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(20);
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1702137F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.1702137F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2241383F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 19.3965511F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66667F));
            tableLayoutPanel1.Size = new Size(509, 322);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label8.Location = new Point(23, 137);
            label8.Name = "label8";
            label8.Size = new Size(175, 22);
            label8.TabIndex = 8;
            label8.Text = "Efectivo Entregado";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label7.Location = new Point(23, 59);
            label7.Name = "label7";
            label7.Size = new Size(70, 22);
            label7.TabIndex = 5;
            label7.Text = "Ventas";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label6.Location = new Point(23, 20);
            label6.Name = "label6";
            label6.Size = new Size(123, 22);
            label6.TabIndex = 4;
            label6.Text = "Fondo Inicial";
            // 
            // numFondoInicial
            // 
            numFondoInicial.DecimalPlaces = 2;
            numFondoInicial.Location = new Point(274, 23);
            numFondoInicial.Name = "numFondoInicial";
            numFondoInicial.Size = new Size(212, 30);
            numFondoInicial.TabIndex = 3;
            numFondoInicial.TextAlign = HorizontalAlignment.Center;
            // 
            // numIngresosVentas
            // 
            numIngresosVentas.Location = new Point(274, 62);
            numIngresosVentas.Name = "numIngresosVentas";
            numIngresosVentas.Size = new Size(212, 30);
            numIngresosVentas.TabIndex = 6;
            numIngresosVentas.TextAlign = HorizontalAlignment.Center;
            // 
            // numEfectivoEntregado
            // 
            numEfectivoEntregado.DecimalPlaces = 2;
            numEfectivoEntregado.Location = new Point(274, 140);
            numEfectivoEntregado.Name = "numEfectivoEntregado";
            numEfectivoEntregado.Size = new Size(212, 30);
            numEfectivoEntregado.TabIndex = 7;
            numEfectivoEntregado.TextAlign = HorizontalAlignment.Center;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label9.Location = new Point(23, 177);
            label9.Name = "label9";
            label9.Size = new Size(51, 22);
            label9.TabIndex = 10;
            label9.Text = "Total";
            // 
            // numEfectivoReal
            // 
            numEfectivoReal.DecimalPlaces = 2;
            numEfectivoReal.Location = new Point(274, 214);
            numEfectivoReal.Name = "numEfectivoReal";
            numEfectivoReal.Size = new Size(212, 30);
            numEfectivoReal.TabIndex = 11;
            numEfectivoReal.TextAlign = HorizontalAlignment.Center;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label10.Location = new Point(23, 211);
            label10.Name = "label10";
            label10.Size = new Size(160, 22);
            label10.TabIndex = 12;
            label10.Text = "Efectivo Existente";
            // 
            // lblDescuadre
            // 
            lblDescuadre.AutoSize = true;
            lblDescuadre.ForeColor = Color.Red;
            lblDescuadre.Location = new Point(274, 258);
            lblDescuadre.Name = "lblDescuadre";
            lblDescuadre.Size = new Size(178, 22);
            lblDescuadre.TabIndex = 14;
            lblDescuadre.Text = "Faltante de C$ 0.00";
            // 
            // lblTotalEsperado
            // 
            lblTotalEsperado.AutoSize = true;
            lblTotalEsperado.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalEsperado.ForeColor = Color.FromArgb(0, 0, 192);
            lblTotalEsperado.Location = new Point(274, 177);
            lblTotalEsperado.Name = "lblTotalEsperado";
            lblTotalEsperado.Size = new Size(82, 23);
            lblTotalEsperado.TabIndex = 9;
            lblTotalEsperado.Text = "C$ 0.00";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label12.Location = new Point(23, 98);
            label12.Name = "label12";
            label12.Size = new Size(229, 22);
            label12.TabIndex = 15;
            label12.Text = "Ventas por Transferencia";
            // 
            // numIngresosTransferencia
            // 
            numIngresosTransferencia.Location = new Point(274, 101);
            numIngresosTransferencia.Name = "numIngresosTransferencia";
            numIngresosTransferencia.ReadOnly = true;
            numIngresosTransferencia.Size = new Size(212, 30);
            numIngresosTransferencia.TabIndex = 16;
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
            ((System.ComponentModel.ISupportInitialize)numEfectivoRecibido).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCantidadPlatillo).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTicket).EndInit();
            CashClosure.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numFondoInicial).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIngresosVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoEntregado).EndInit();
            ((System.ComponentModel.ISupportInitialize)numEfectivoReal).EndInit();
            ((System.ComponentModel.ISupportInitialize)numIngresosTransferencia).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tbControlPOS;
        private TabPage POS;
        private TabPage CashClosure;
        private SplitContainer splitContainer1;
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
        private TextBox textBox1;
        private Label label12;
        private NumericUpDown numIngresosTransferencia;
        private FlowLayoutPanel flpCatalogo;
    }
}