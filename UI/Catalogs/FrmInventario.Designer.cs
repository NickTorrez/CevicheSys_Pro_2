namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmInventario
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tabControl1 = new TabControl();
            tabInsumos = new TabPage();
            tabPlatillos = new TabPage();
            label1 = new Label();
            pnlBuscar = new Panel();
            txtBuscarProducto = new TextBox();
            pnlLista = new Panel();
            dgvInventario = new DataGridView();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            cmbCategoria = new ComboBox();
            txtStockActual = new TextBox();
            txtPrecioVenta = new TextBox();
            txtNombreProducto = new TextBox();
            txtCodigo = new TextBox();
            label2 = new Label();
            btnLimpiarProducto = new Button();
            btnEliminarProducto = new Button();
            btnEditarProducto = new Button();
            btnGuardarProducto = new Button();
            pnlRegistro = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            dtpFechaVencimiento = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            cmbProveedor = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            panel1 = new Panel();
            panel2 = new Panel();
            label13 = new Label();
            label15 = new Label();
            label16 = new Label();
            txtPrecio = new TextBox();
            txtTamaño = new TextBox();
            txtTipoPlatillo = new TextBox();
            label17 = new Label();
            this.btnLimpiarPlatillo = new Button();
            this.btnEliminarPlatillo = new Button();
            this.btnEditarPlatillo = new Button();
            btnGuardarPlatillo = new Button();
            chkDisponible = new CheckBox();
            pnlSearch = new Panel();
            txtBuscarPlatillo = new TextBox();
            label10 = new Label();
            dgvPlatillos = new DataGridView();
            tabControl1.SuspendLayout();
            tabInsumos.SuspendLayout();
            tabPlatillos.SuspendLayout();
            pnlBuscar.SuspendLayout();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            pnlRegistro.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabInsumos);
            tabControl1.Controls.Add(tabPlatillos);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(962, 603);
            tabControl1.TabIndex = 0;
            // 
            // tabInsumos
            // 
            tabInsumos.BackColor = Color.White;
            tabInsumos.Controls.Add(tableLayoutPanel1);
            tabInsumos.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabInsumos.Location = new Point(4, 29);
            tabInsumos.Name = "tabInsumos";
            tabInsumos.Padding = new Padding(3);
            tabInsumos.Size = new Size(954, 570);
            tabInsumos.TabIndex = 0;
            tabInsumos.Text = "Materia Prima / Insumos";
            // 
            // tabPlatillos
            // 
            tabPlatillos.Controls.Add(tableLayoutPanel2);
            tabPlatillos.Location = new Point(4, 29);
            tabPlatillos.Name = "tabPlatillos";
            tabPlatillos.Padding = new Padding(3);
            tabPlatillos.Size = new Size(954, 570);
            tabPlatillos.TabIndex = 1;
            tabPlatillos.Text = "Menú de Platillos";
            tabPlatillos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 20);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // pnlBuscar
            // 
            pnlBuscar.Controls.Add(txtBuscarProducto);
            pnlBuscar.Controls.Add(label1);
            pnlBuscar.Dock = DockStyle.Top;
            pnlBuscar.Location = new Point(0, 0);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(609, 68);
            pnlBuscar.TabIndex = 0;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarProducto.Location = new Point(189, 19);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(329, 26);
            txtBuscarProducto.TabIndex = 1;
            // 
            // pnlLista
            // 
            pnlLista.BorderStyle = BorderStyle.FixedSingle;
            pnlLista.Controls.Add(dgvInventario);
            pnlLista.Controls.Add(pnlBuscar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(334, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(611, 558);
            pnlLista.TabIndex = 1;
            // 
            // dgvInventario
            // 
            dgvInventario.BackgroundColor = Color.WhiteSmoke;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(0, 68);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.RowHeadersWidth = 51;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(609, 488);
            dgvInventario.TabIndex = 1;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label7.Location = new Point(21, 251);
            label7.Name = "label7";
            label7.Size = new Size(91, 18);
            label7.TabIndex = 14;
            label7.Text = "Stock Atual";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label6.Location = new Point(21, 199);
            label6.Name = "label6";
            label6.Size = new Size(79, 36);
            label6.TabIndex = 13;
            label6.Text = "Precio de\r\nVenta";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(21, 159);
            label5.Name = "label5";
            label5.Size = new Size(83, 18);
            label5.TabIndex = 12;
            label5.Text = "Categoria";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(21, 107);
            label4.Name = "label4";
            label4.Size = new Size(74, 36);
            label4.TabIndex = 11;
            label4.Text = "Nombre \r\nProducto";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(21, 71);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 10;
            label3.Text = "ID Producto";
            // 
            // cmbCategoria
            // 
            cmbCategoria.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoria.Font = new Font("Century Gothic", 9F);
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Items.AddRange(new object[] { "Insumos", "Platillos", "Bebidas" });
            cmbCategoria.Location = new Point(120, 156);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(195, 28);
            cmbCategoria.TabIndex = 9;
            // 
            // txtStockActual
            // 
            txtStockActual.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtStockActual.Font = new Font("Century Gothic", 9F);
            txtStockActual.Location = new Point(120, 248);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(195, 26);
            txtStockActual.TabIndex = 8;
            // 
            // txtPrecioVenta
            // 
            txtPrecioVenta.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrecioVenta.Font = new Font("Century Gothic", 9F);
            txtPrecioVenta.Location = new Point(120, 199);
            txtPrecioVenta.Name = "txtPrecioVenta";
            txtPrecioVenta.Size = new Size(195, 26);
            txtPrecioVenta.TabIndex = 7;
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombreProducto.Font = new Font("Century Gothic", 9F);
            txtNombreProducto.Location = new Point(120, 110);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(195, 26);
            txtNombreProducto.TabIndex = 6;
            // 
            // txtCodigo
            // 
            txtCodigo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCodigo.Font = new Font("Century Gothic", 9F);
            txtCodigo.Location = new Point(120, 68);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(195, 26);
            txtCodigo.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 20);
            label2.Name = "label2";
            label2.Size = new Size(254, 27);
            label2.TabIndex = 4;
            label2.Text = "Registro de Inventario";
            // 
            // btnLimpiarProducto
            // 
            btnLimpiarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiarProducto.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarProducto.Cursor = Cursors.Hand;
            btnLimpiarProducto.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiarProducto.ForeColor = Color.White;
            btnLimpiarProducto.Location = new Point(165, 475);
            btnLimpiarProducto.Name = "btnLimpiarProducto";
            btnLimpiarProducto.Size = new Size(150, 70);
            btnLimpiarProducto.TabIndex = 3;
            btnLimpiarProducto.Text = "Limpiar Campos";
            btnLimpiarProducto.UseVisualStyleBackColor = false;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEliminarProducto.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarProducto.Cursor = Cursors.Hand;
            btnEliminarProducto.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminarProducto.ForeColor = Color.White;
            btnEliminarProducto.Location = new Point(9, 475);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(150, 70);
            btnEliminarProducto.TabIndex = 2;
            btnEliminarProducto.Text = "Eliminar/\r\nInactivar";
            btnEliminarProducto.UseVisualStyleBackColor = false;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnEditarProducto.BackColor = Color.FromArgb(0, 123, 255);
            btnEditarProducto.Cursor = Cursors.Hand;
            btnEditarProducto.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEditarProducto.ForeColor = Color.White;
            btnEditarProducto.Location = new Point(165, 399);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(150, 70);
            btnEditarProducto.TabIndex = 1;
            btnEditarProducto.Text = "Editar";
            btnEditarProducto.UseVisualStyleBackColor = false;
            btnEditarProducto.Click += btnEditar_Click;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnGuardarProducto.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarProducto.Cursor = Cursors.Hand;
            btnGuardarProducto.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(9, 399);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(150, 70);
            btnGuardarProducto.TabIndex = 0;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // pnlRegistro
            // 
            pnlRegistro.BorderStyle = BorderStyle.FixedSingle;
            pnlRegistro.Controls.Add(cmbProveedor);
            pnlRegistro.Controls.Add(label9);
            pnlRegistro.Controls.Add(label8);
            pnlRegistro.Controls.Add(dtpFechaVencimiento);
            pnlRegistro.Controls.Add(label7);
            pnlRegistro.Controls.Add(label6);
            pnlRegistro.Controls.Add(label5);
            pnlRegistro.Controls.Add(label4);
            pnlRegistro.Controls.Add(label3);
            pnlRegistro.Controls.Add(cmbCategoria);
            pnlRegistro.Controls.Add(txtStockActual);
            pnlRegistro.Controls.Add(txtPrecioVenta);
            pnlRegistro.Controls.Add(txtNombreProducto);
            pnlRegistro.Controls.Add(txtCodigo);
            pnlRegistro.Controls.Add(label2);
            pnlRegistro.Controls.Add(btnLimpiarProducto);
            pnlRegistro.Controls.Add(btnEliminarProducto);
            pnlRegistro.Controls.Add(btnEditarProducto);
            pnlRegistro.Controls.Add(btnGuardarProducto);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            pnlRegistro.Location = new Point(3, 3);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(325, 558);
            pnlRegistro.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(pnlRegistro, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlLista, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(948, 564);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaVencimiento.Font = new Font("Century Gothic", 9F);
            dtpFechaVencimiento.Format = DateTimePickerFormat.Short;
            dtpFechaVencimiento.Location = new Point(120, 296);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(195, 26);
            dtpFechaVencimiento.TabIndex = 15;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(21, 290);
            label8.Name = "label8";
            label8.Size = new Size(72, 36);
            label8.TabIndex = 16;
            label8.Text = "Fecha a \r\nVencer";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(21, 349);
            label9.Name = "label9";
            label9.Size = new Size(84, 18);
            label9.TabIndex = 17;
            label9.Text = "Proveedor";
            // 
            // cmbProveedor
            // 
            cmbProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Century Gothic", 9F);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(120, 346);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(195, 28);
            cmbProveedor.TabIndex = 18;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.BackColor = Color.White;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.Controls.Add(panel1, 0, 0);
            tableLayoutPanel2.Controls.Add(panel2, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(948, 564);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(chkDisponible);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label16);
            panel1.Controls.Add(txtPrecio);
            panel1.Controls.Add(txtTamaño);
            panel1.Controls.Add(txtTipoPlatillo);
            panel1.Controls.Add(label17);
            panel1.Controls.Add(this.btnLimpiarPlatillo);
            panel1.Controls.Add(this.btnEliminarPlatillo);
            panel1.Controls.Add(this.btnEditarPlatillo);
            panel1.Controls.Add(btnGuardarPlatillo);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Century Gothic", 9F);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(325, 558);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(dgvPlatillos);
            panel2.Controls.Add(pnlSearch);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(334, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(611, 558);
            panel2.TabIndex = 1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label13.Location = new Point(20, 238);
            label13.Name = "label13";
            label13.Size = new Size(55, 18);
            label13.TabIndex = 32;
            label13.Text = "Precio";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label15.Location = new Point(20, 186);
            label15.Name = "label15";
            label15.Size = new Size(67, 18);
            label15.TabIndex = 30;
            label15.Text = "Tamaño";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label16.Location = new Point(20, 127);
            label16.Name = "label16";
            label16.Size = new Size(62, 36);
            label16.TabIndex = 29;
            label16.Text = "Tipo de\r\nPlatillo";
            // 
            // txtPrecio
            // 
            txtPrecio.Font = new Font("Century Gothic", 9F);
            txtPrecio.Location = new Point(93, 234);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(221, 26);
            txtPrecio.TabIndex = 26;
            txtPrecio.TextAlign = HorizontalAlignment.Right;
            // 
            // txtTamaño
            // 
            txtTamaño.Font = new Font("Century Gothic", 9F);
            txtTamaño.Location = new Point(93, 182);
            txtTamaño.MaxLength = 20;
            txtTamaño.Name = "txtTamaño";
            txtTamaño.Size = new Size(221, 26);
            txtTamaño.TabIndex = 25;
            // 
            // txtTipoPlatillo
            // 
            txtTipoPlatillo.Font = new Font("Century Gothic", 9F);
            txtTipoPlatillo.Location = new Point(93, 133);
            txtTipoPlatillo.MaxLength = 50;
            txtTipoPlatillo.Name = "txtTipoPlatillo";
            txtTipoPlatillo.Size = new Size(221, 26);
            txtTipoPlatillo.TabIndex = 24;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label17.Location = new Point(56, 63);
            label17.Name = "label17";
            label17.Size = new Size(210, 27);
            label17.TabIndex = 23;
            label17.Text = "Gestión del Menú";
            // 
            // btnLimpiarPlatillo
            // 
            this.btnLimpiarPlatillo.BackColor = Color.FromArgb(108, 117, 125);
            this.btnLimpiarPlatillo.Cursor = Cursors.Hand;
            this.btnLimpiarPlatillo.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            this.btnLimpiarPlatillo.ForeColor = Color.White;
            this.btnLimpiarPlatillo.Location = new Point(164, 451);
            this.btnLimpiarPlatillo.Name = "btnLimpiarPlatillo";
            this.btnLimpiarPlatillo.Size = new Size(150, 70);
            this.btnLimpiarPlatillo.TabIndex = 22;
            this.btnLimpiarPlatillo.Text = "Nuevo";
            this.btnLimpiarPlatillo.UseVisualStyleBackColor = false;
            // 
            // btnEliminarPlatillo
            // 
            this.btnEliminarPlatillo.BackColor = Color.FromArgb(220, 53, 69);
            this.btnEliminarPlatillo.Cursor = Cursors.Hand;
            this.btnEliminarPlatillo.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            this.btnEliminarPlatillo.ForeColor = Color.White;
            this.btnEliminarPlatillo.Location = new Point(8, 451);
            this.btnEliminarPlatillo.Name = "btnEliminarPlatillo";
            this.btnEliminarPlatillo.Size = new Size(150, 70);
            this.btnEliminarPlatillo.TabIndex = 21;
            this.btnEliminarPlatillo.Text = "Dar de Baja";
            this.btnEliminarPlatillo.UseVisualStyleBackColor = false;
            // 
            // btnEditarPlatillo
            // 
            this.btnEditarPlatillo.BackColor = Color.FromArgb(0, 123, 255);
            this.btnEditarPlatillo.Cursor = Cursors.Hand;
            this.btnEditarPlatillo.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            this.btnEditarPlatillo.ForeColor = Color.White;
            this.btnEditarPlatillo.Location = new Point(164, 375);
            this.btnEditarPlatillo.Name = "btnEditarPlatillo";
            this.btnEditarPlatillo.Size = new Size(150, 70);
            this.btnEditarPlatillo.TabIndex = 20;
            this.btnEditarPlatillo.Text = "Modificar";
            this.btnEditarPlatillo.UseVisualStyleBackColor = false;
            // 
            // btnGuardarPlatillo
            // 
            btnGuardarPlatillo.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarPlatillo.Cursor = Cursors.Hand;
            btnGuardarPlatillo.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardarPlatillo.ForeColor = Color.White;
            btnGuardarPlatillo.Location = new Point(8, 375);
            btnGuardarPlatillo.Name = "btnGuardarPlatillo";
            btnGuardarPlatillo.Size = new Size(150, 70);
            btnGuardarPlatillo.TabIndex = 19;
            btnGuardarPlatillo.Text = "Guardar";
            btnGuardarPlatillo.UseVisualStyleBackColor = false;
            // 
            // chkDisponible
            // 
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chkDisponible.Location = new Point(56, 305);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(211, 22);
            chkDisponible.TabIndex = 37;
            chkDisponible.Text = "¿Disponible para Venta?";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // pnlSearch
            // 
            pnlSearch.Controls.Add(txtBuscarPlatillo);
            pnlSearch.Controls.Add(label10);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 0);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(609, 68);
            pnlSearch.TabIndex = 0;
            // 
            // txtBuscarPlatillo
            // 
            txtBuscarPlatillo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarPlatillo.Location = new Point(183, 21);
            txtBuscarPlatillo.Name = "txtBuscarPlatillo";
            txtBuscarPlatillo.Size = new Size(329, 27);
            txtBuscarPlatillo.TabIndex = 3;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(96, 22);
            label10.Name = "label10";
            label10.Size = new Size(81, 23);
            label10.TabIndex = 2;
            label10.Text = "Buscar:";
            // 
            // dgvPlatillos
            // 
            dgvPlatillos.AllowUserToAddRows = false;
            dgvPlatillos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatillos.Dock = DockStyle.Fill;
            dgvPlatillos.Location = new Point(0, 68);
            dgvPlatillos.Name = "dgvPlatillos";
            dgvPlatillos.RowHeadersWidth = 51;
            dgvPlatillos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatillos.Size = new Size(609, 488);
            dgvPlatillos.TabIndex = 1;
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventario";
            Text = "FrmInventario";
            tabControl1.ResumeLayout(false);
            tabInsumos.ResumeLayout(false);
            tabPlatillos.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabInsumos;
        private TabPage tabPlatillos;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistro;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox cmbCategoria;
        private TextBox txtStockActual;
        private TextBox txtPrecioVenta;
        private TextBox txtNombreProducto;
        private TextBox txtCodigo;
        private Label label2;
        private Button btnLimpiarProducto;
        private Button btnEliminarProducto;
        private Button btnEditarProducto;
        private Button btnGuardarProducto;
        private Panel pnlLista;
        private DataGridView dgvInventario;
        private Panel pnlBuscar;
        private TextBox txtBuscarProducto;
        private Label label1;
        private Label label8;
        private DateTimePicker dtpFechaVencimiento;
        private ComboBox cmbProveedor;
        private Label label9;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private Panel panel2;
        private ComboBox comboBox1;
        private Label label11;
        private DateTimePicker dateTimePicker1;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label label16;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private TextBox txtPrecio;
        private TextBox txtTamaño;
        private TextBox txtTipoPlatillo;
        private Label label17;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button btnGuardarPlatillo;
        private CheckBox chkDisponible;
        private Panel pnlSearch;
        private TextBox txtBuscarPlatillo;
        private Label label10;
        private DataGridView dgvPlatillos;
    }
}