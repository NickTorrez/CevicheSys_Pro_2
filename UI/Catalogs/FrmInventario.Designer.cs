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
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            tcInventario = new TabControl();
            tabInsumos = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistroProducto = new Panel();
            button4 = new Button();
            btnEliminarProducto = new Button();
            btnEditarProducto = new Button();
            btnGuardarProducto = new Button();
            dtpFechaVencimiento = new DateTimePicker();
            cmbProveedor = new ComboBox();
            comboBox1 = new ComboBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            pnlListarProducto = new Panel();
            dataGridView1 = new DataGridView();
            pnlBuscarProducto = new Panel();
            txtBuscarProducto = new TextBox();
            label10 = new Label();
            tabPlatillos = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            pnlRegistrarPlatillo = new Panel();
            btnLimpiarPlatillo = new Button();
            btnEliminarPlatillo = new Button();
            btnEditarPlatillo = new Button();
            btnGuardarPlatillo = new Button();
            chkDisponible = new CheckBox();
            txtPrecio = new TextBox();
            txtTamaño = new TextBox();
            txtTipoPlatillo = new TextBox();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label2 = new Label();
            pnlListarPlatillo = new Panel();
            dgvPlatillos = new DataGridView();
            pnlBuscarPlatillo = new Panel();
            txtBuscarPlatillo = new TextBox();
            label14 = new Label();
            tcInventario.SuspendLayout();
            tabInsumos.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistroProducto.SuspendLayout();
            pnlListarProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlBuscarProducto.SuspendLayout();
            tabPlatillos.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            pnlRegistrarPlatillo.SuspendLayout();
            pnlListarPlatillo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).BeginInit();
            pnlBuscarPlatillo.SuspendLayout();
            SuspendLayout();
            // 
            // tcInventario
            // 
            tcInventario.Controls.Add(tabInsumos);
            tcInventario.Controls.Add(tabPlatillos);
            tcInventario.Dock = DockStyle.Fill;
            tcInventario.Location = new Point(0, 0);
            tcInventario.Name = "tcInventario";
            tcInventario.SelectedIndex = 0;
            tcInventario.Size = new Size(962, 603);
            tcInventario.TabIndex = 0;
            // 
            // tabInsumos
            // 
            tabInsumos.Controls.Add(tableLayoutPanel1);
            tabInsumos.Location = new Point(4, 29);
            tabInsumos.Name = "tabInsumos";
            tabInsumos.Padding = new Padding(3);
            tabInsumos.Size = new Size(954, 570);
            tabInsumos.TabIndex = 0;
            tabInsumos.Text = "Materia Prima / Insumos";
            tabInsumos.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = Color.White;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(pnlRegistroProducto, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlListarProducto, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(948, 564);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlRegistroProducto
            // 
            pnlRegistroProducto.BorderStyle = BorderStyle.FixedSingle;
            pnlRegistroProducto.Controls.Add(button4);
            pnlRegistroProducto.Controls.Add(btnEliminarProducto);
            pnlRegistroProducto.Controls.Add(btnEditarProducto);
            pnlRegistroProducto.Controls.Add(btnGuardarProducto);
            pnlRegistroProducto.Controls.Add(dtpFechaVencimiento);
            pnlRegistroProducto.Controls.Add(cmbProveedor);
            pnlRegistroProducto.Controls.Add(comboBox1);
            pnlRegistroProducto.Controls.Add(textBox4);
            pnlRegistroProducto.Controls.Add(textBox3);
            pnlRegistroProducto.Controls.Add(textBox2);
            pnlRegistroProducto.Controls.Add(textBox1);
            pnlRegistroProducto.Controls.Add(label9);
            pnlRegistroProducto.Controls.Add(label8);
            pnlRegistroProducto.Controls.Add(label7);
            pnlRegistroProducto.Controls.Add(label6);
            pnlRegistroProducto.Controls.Add(label5);
            pnlRegistroProducto.Controls.Add(label4);
            pnlRegistroProducto.Controls.Add(label3);
            pnlRegistroProducto.Controls.Add(label1);
            pnlRegistroProducto.Dock = DockStyle.Fill;
            pnlRegistroProducto.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlRegistroProducto.Location = new Point(3, 3);
            pnlRegistroProducto.Name = "pnlRegistroProducto";
            pnlRegistroProducto.Size = new Size(325, 558);
            pnlRegistroProducto.TabIndex = 0;
            // 
            // button4
            // 
            button4.Anchor = AnchorStyles.None;
            button4.BackColor = Color.FromArgb(108, 117, 125);
            button4.Cursor = Cursors.Hand;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            button4.ForeColor = Color.White;
            button4.Location = new Point(164, 480);
            button4.Name = "button4";
            button4.Size = new Size(140, 60);
            button4.TabIndex = 18;
            button4.Text = "Limpiar Campos";
            button4.UseVisualStyleBackColor = false;
            // 
            // btnEliminarProducto
            // 
            btnEliminarProducto.Anchor = AnchorStyles.None;
            btnEliminarProducto.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarProducto.Cursor = Cursors.Hand;
            btnEliminarProducto.FlatStyle = FlatStyle.Flat;
            btnEliminarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnEliminarProducto.ForeColor = Color.White;
            btnEliminarProducto.Location = new Point(18, 480);
            btnEliminarProducto.Name = "btnEliminarProducto";
            btnEliminarProducto.Size = new Size(140, 60);
            btnEliminarProducto.TabIndex = 17;
            btnEliminarProducto.Text = "Eliminar";
            btnEliminarProducto.UseVisualStyleBackColor = false;
            // 
            // btnEditarProducto
            // 
            btnEditarProducto.Anchor = AnchorStyles.None;
            btnEditarProducto.BackColor = Color.FromArgb(0, 123, 255);
            btnEditarProducto.Cursor = Cursors.Hand;
            btnEditarProducto.FlatStyle = FlatStyle.Flat;
            btnEditarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnEditarProducto.ForeColor = Color.White;
            btnEditarProducto.Location = new Point(164, 414);
            btnEditarProducto.Name = "btnEditarProducto";
            btnEditarProducto.Size = new Size(140, 60);
            btnEditarProducto.TabIndex = 16;
            btnEditarProducto.Text = "Actualizar";
            btnEditarProducto.UseVisualStyleBackColor = false;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.Anchor = AnchorStyles.None;
            btnGuardarProducto.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarProducto.Cursor = Cursors.Hand;
            btnGuardarProducto.FlatStyle = FlatStyle.Flat;
            btnGuardarProducto.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold);
            btnGuardarProducto.ForeColor = Color.White;
            btnGuardarProducto.Location = new Point(18, 414);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(140, 60);
            btnGuardarProducto.TabIndex = 15;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = false;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaVencimiento.Font = new Font("Century Gothic", 9F);
            dtpFechaVencimiento.Format = DateTimePickerFormat.Short;
            dtpFechaVencimiento.Location = new Point(119, 358);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(192, 26);
            dtpFechaVencimiento.TabIndex = 14;
            dtpFechaVencimiento.Enter += TextBox_Enter;
            dtpFechaVencimiento.Leave += TextBox_Leave;
            // 
            // cmbProveedor
            // 
            cmbProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            cmbProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProveedor.Font = new Font("Century Gothic", 9F);
            cmbProveedor.FormattingEnabled = true;
            cmbProveedor.Location = new Point(119, 207);
            cmbProveedor.Name = "cmbProveedor";
            cmbProveedor.Size = new Size(192, 28);
            cmbProveedor.TabIndex = 13;
            cmbProveedor.Enter += TextBox_Enter;
            cmbProveedor.Leave += TextBox_Leave;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Century Gothic", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(119, 155);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(192, 28);
            comboBox1.TabIndex = 12;
            comboBox1.Enter += TextBox_Enter;
            comboBox1.Leave += TextBox_Leave;
            // 
            // textBox4
            // 
            textBox4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox4.Font = new Font("Century Gothic", 9F);
            textBox4.Location = new Point(119, 309);
            textBox4.MaxLength = 12;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(192, 26);
            textBox4.TabIndex = 11;
            textBox4.Enter += TextBox_Enter;
            textBox4.Leave += TextBox_Leave;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Font = new Font("Century Gothic", 9F);
            textBox3.Location = new Point(119, 260);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(192, 26);
            textBox3.TabIndex = 10;
            textBox3.Enter += TextBox_Enter;
            textBox3.Leave += TextBox_Leave;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Font = new Font("Century Gothic", 9F);
            textBox2.Location = new Point(119, 106);
            textBox2.MaxLength = 100;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(192, 26);
            textBox2.TabIndex = 9;
            textBox2.Enter += TextBox_Enter;
            textBox2.Leave += TextBox_Leave;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Century Gothic", 9F);
            textBox1.Location = new Point(119, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(192, 26);
            textBox1.TabIndex = 8;
            textBox1.Enter += TextBox_Enter;
            textBox1.Leave += TextBox_Leave;
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(14, 354);
            label9.Name = "label9";
            label9.Size = new Size(103, 36);
            label9.TabIndex = 7;
            label9.Text = "Fecha de\r\nVencimiento\r\n";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(14, 211);
            label8.Name = "label8";
            label8.Size = new Size(84, 18);
            label8.TabIndex = 6;
            label8.Text = "Proveedor";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(14, 313);
            label7.Name = "label7";
            label7.Size = new Size(101, 18);
            label7.TabIndex = 5;
            label7.Text = "Stock Actual";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(14, 252);
            label6.Name = "label6";
            label6.Size = new Size(83, 36);
            label6.TabIndex = 4;
            label6.Text = "Precio de \r\nCompra";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(14, 159);
            label5.Name = "label5";
            label5.Size = new Size(83, 18);
            label5.TabIndex = 3;
            label5.Text = "Categoria";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(14, 96);
            label4.Name = "label4";
            label4.Size = new Size(100, 36);
            label4.TabIndex = 2;
            label4.Text = "Nombre del \r\nProducto";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(14, 60);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 1;
            label3.Text = "ID Producto";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 16);
            label1.Name = "label1";
            label1.Size = new Size(254, 27);
            label1.TabIndex = 0;
            label1.Text = "Registro de Inventario";
            // 
            // pnlListarProducto
            // 
            pnlListarProducto.BorderStyle = BorderStyle.FixedSingle;
            pnlListarProducto.Controls.Add(dataGridView1);
            pnlListarProducto.Controls.Add(pnlBuscarProducto);
            pnlListarProducto.Dock = DockStyle.Fill;
            pnlListarProducto.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnlListarProducto.Location = new Point(334, 3);
            pnlListarProducto.Name = "pnlListarProducto";
            pnlListarProducto.Size = new Size(611, 558);
            pnlListarProducto.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle5.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle5.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle6.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle6.ForeColor = Color.White;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(609, 488);
            dataGridView1.TabIndex = 1;
            // 
            // pnlBuscarProducto
            // 
            pnlBuscarProducto.Controls.Add(txtBuscarProducto);
            pnlBuscarProducto.Controls.Add(label10);
            pnlBuscarProducto.Dock = DockStyle.Top;
            pnlBuscarProducto.Location = new Point(0, 0);
            pnlBuscarProducto.Name = "pnlBuscarProducto";
            pnlBuscarProducto.Size = new Size(609, 68);
            pnlBuscarProducto.TabIndex = 0;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarProducto.Location = new Point(207, 20);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(275, 26);
            txtBuscarProducto.TabIndex = 1;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(127, 21);
            label10.Name = "label10";
            label10.Size = new Size(74, 22);
            label10.TabIndex = 0;
            label10.Text = "Buscar:";
            // 
            // tabPlatillos
            // 
            tabPlatillos.BackColor = Color.White;
            tabPlatillos.Controls.Add(tableLayoutPanel2);
            tabPlatillos.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabPlatillos.Location = new Point(4, 29);
            tabPlatillos.Name = "tabPlatillos";
            tabPlatillos.Padding = new Padding(3);
            tabPlatillos.Size = new Size(954, 570);
            tabPlatillos.TabIndex = 1;
            tabPlatillos.Text = "Menú de Platillos";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.Controls.Add(pnlRegistrarPlatillo, 0, 0);
            tableLayoutPanel2.Controls.Add(pnlListarPlatillo, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(948, 564);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // pnlRegistrarPlatillo
            // 
            pnlRegistrarPlatillo.BorderStyle = BorderStyle.FixedSingle;
            pnlRegistrarPlatillo.Controls.Add(btnLimpiarPlatillo);
            pnlRegistrarPlatillo.Controls.Add(btnEliminarPlatillo);
            pnlRegistrarPlatillo.Controls.Add(btnEditarPlatillo);
            pnlRegistrarPlatillo.Controls.Add(btnGuardarPlatillo);
            pnlRegistrarPlatillo.Controls.Add(chkDisponible);
            pnlRegistrarPlatillo.Controls.Add(txtPrecio);
            pnlRegistrarPlatillo.Controls.Add(txtTamaño);
            pnlRegistrarPlatillo.Controls.Add(txtTipoPlatillo);
            pnlRegistrarPlatillo.Controls.Add(label13);
            pnlRegistrarPlatillo.Controls.Add(label12);
            pnlRegistrarPlatillo.Controls.Add(label11);
            pnlRegistrarPlatillo.Controls.Add(label2);
            pnlRegistrarPlatillo.Dock = DockStyle.Fill;
            pnlRegistrarPlatillo.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            pnlRegistrarPlatillo.Location = new Point(3, 3);
            pnlRegistrarPlatillo.Name = "pnlRegistrarPlatillo";
            pnlRegistrarPlatillo.Size = new Size(325, 558);
            pnlRegistrarPlatillo.TabIndex = 0;
            // 
            // btnLimpiarPlatillo
            // 
            btnLimpiarPlatillo.Anchor = AnchorStyles.None;
            btnLimpiarPlatillo.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarPlatillo.Cursor = Cursors.Hand;
            btnLimpiarPlatillo.FlatStyle = FlatStyle.Flat;
            btnLimpiarPlatillo.ForeColor = Color.White;
            btnLimpiarPlatillo.Location = new Point(166, 468);
            btnLimpiarPlatillo.Name = "btnLimpiarPlatillo";
            btnLimpiarPlatillo.Size = new Size(150, 70);
            btnLimpiarPlatillo.TabIndex = 11;
            btnLimpiarPlatillo.Text = "Nuevo";
            btnLimpiarPlatillo.UseVisualStyleBackColor = false;
            // 
            // btnEliminarPlatillo
            // 
            btnEliminarPlatillo.Anchor = AnchorStyles.None;
            btnEliminarPlatillo.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarPlatillo.Cursor = Cursors.Hand;
            btnEliminarPlatillo.FlatStyle = FlatStyle.Flat;
            btnEliminarPlatillo.ForeColor = Color.White;
            btnEliminarPlatillo.Location = new Point(10, 468);
            btnEliminarPlatillo.Name = "btnEliminarPlatillo";
            btnEliminarPlatillo.Size = new Size(150, 70);
            btnEliminarPlatillo.TabIndex = 10;
            btnEliminarPlatillo.Text = "Dar de Baja";
            btnEliminarPlatillo.UseVisualStyleBackColor = false;
            // 
            // btnEditarPlatillo
            // 
            btnEditarPlatillo.Anchor = AnchorStyles.None;
            btnEditarPlatillo.BackColor = Color.FromArgb(0, 123, 255);
            btnEditarPlatillo.Cursor = Cursors.Hand;
            btnEditarPlatillo.FlatStyle = FlatStyle.Flat;
            btnEditarPlatillo.ForeColor = Color.White;
            btnEditarPlatillo.Location = new Point(166, 392);
            btnEditarPlatillo.Name = "btnEditarPlatillo";
            btnEditarPlatillo.Size = new Size(150, 70);
            btnEditarPlatillo.TabIndex = 9;
            btnEditarPlatillo.Text = "Modificar";
            btnEditarPlatillo.UseVisualStyleBackColor = false;
            // 
            // btnGuardarPlatillo
            // 
            btnGuardarPlatillo.Anchor = AnchorStyles.None;
            btnGuardarPlatillo.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarPlatillo.Cursor = Cursors.Hand;
            btnGuardarPlatillo.FlatStyle = FlatStyle.Flat;
            btnGuardarPlatillo.ForeColor = Color.White;
            btnGuardarPlatillo.Location = new Point(10, 392);
            btnGuardarPlatillo.Name = "btnGuardarPlatillo";
            btnGuardarPlatillo.Size = new Size(150, 70);
            btnGuardarPlatillo.TabIndex = 8;
            btnGuardarPlatillo.Text = "Guardar";
            btnGuardarPlatillo.UseVisualStyleBackColor = false;
            // 
            // chkDisponible
            // 
            chkDisponible.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            chkDisponible.AutoSize = true;
            chkDisponible.Checked = true;
            chkDisponible.CheckState = CheckState.Checked;
            chkDisponible.Location = new Point(56, 317);
            chkDisponible.Name = "chkDisponible";
            chkDisponible.Size = new Size(211, 22);
            chkDisponible.TabIndex = 7;
            chkDisponible.Text = "¿Disponible para Venta?";
            chkDisponible.UseVisualStyleBackColor = true;
            // 
            // txtPrecio
            // 
            txtPrecio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPrecio.Location = new Point(109, 245);
            txtPrecio.MaxLength = 12;
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(190, 26);
            txtPrecio.TabIndex = 6;
            txtPrecio.TextAlign = HorizontalAlignment.Right;
            txtPrecio.Enter += TextBox_Enter;
            txtPrecio.Leave += TextBox_Leave;
            // 
            // txtTamaño
            // 
            txtTamaño.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTamaño.Location = new Point(109, 182);
            txtTamaño.MaxLength = 30;
            txtTamaño.Name = "txtTamaño";
            txtTamaño.Size = new Size(190, 26);
            txtTamaño.TabIndex = 5;
            txtTamaño.Enter += TextBox_Enter;
            txtTamaño.Leave += TextBox_Leave;
            // 
            // txtTipoPlatillo
            // 
            txtTipoPlatillo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTipoPlatillo.Location = new Point(109, 120);
            txtTipoPlatillo.MaxLength = 50;
            txtTipoPlatillo.Name = "txtTipoPlatillo";
            txtTipoPlatillo.Size = new Size(190, 26);
            txtTipoPlatillo.TabIndex = 4;
            txtTipoPlatillo.Enter += TextBox_Enter;
            txtTipoPlatillo.Leave += TextBox_Leave;
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(24, 240);
            label13.Name = "label13";
            label13.Size = new Size(79, 36);
            label13.TabIndex = 3;
            label13.Text = "Precio de\r\nVenta";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(24, 185);
            label12.Name = "label12";
            label12.Size = new Size(67, 18);
            label12.TabIndex = 2;
            label12.Text = "Tamaño";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(24, 110);
            label11.Name = "label11";
            label11.Size = new Size(66, 36);
            label11.TabIndex = 1;
            label11.Text = "Tipo de \r\nPlatillo";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 42);
            label2.Name = "label2";
            label2.Size = new Size(210, 27);
            label2.TabIndex = 0;
            label2.Text = "Gestión del Menú";
            // 
            // pnlListarPlatillo
            // 
            pnlListarPlatillo.BorderStyle = BorderStyle.FixedSingle;
            pnlListarPlatillo.Controls.Add(dgvPlatillos);
            pnlListarPlatillo.Controls.Add(pnlBuscarPlatillo);
            pnlListarPlatillo.Dock = DockStyle.Fill;
            pnlListarPlatillo.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            pnlListarPlatillo.Location = new Point(334, 3);
            pnlListarPlatillo.Name = "pnlListarPlatillo";
            pnlListarPlatillo.Size = new Size(611, 558);
            pnlListarPlatillo.TabIndex = 1;
            // 
            // dgvPlatillos
            // 
            dgvPlatillos.AllowUserToAddRows = false;
            dataGridViewCellStyle7.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle7.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            dgvPlatillos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            dgvPlatillos.BackgroundColor = Color.WhiteSmoke;
            dgvPlatillos.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle8.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.White;
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dgvPlatillos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dgvPlatillos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPlatillos.Dock = DockStyle.Fill;
            dgvPlatillos.Location = new Point(0, 68);
            dgvPlatillos.Name = "dgvPlatillos";
            dgvPlatillos.RowHeadersWidth = 51;
            dgvPlatillos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPlatillos.Size = new Size(609, 488);
            dgvPlatillos.TabIndex = 1;
            // 
            // pnlBuscarPlatillo
            // 
            pnlBuscarPlatillo.Controls.Add(txtBuscarPlatillo);
            pnlBuscarPlatillo.Controls.Add(label14);
            pnlBuscarPlatillo.Dock = DockStyle.Top;
            pnlBuscarPlatillo.Location = new Point(0, 0);
            pnlBuscarPlatillo.Name = "pnlBuscarPlatillo";
            pnlBuscarPlatillo.Size = new Size(609, 68);
            pnlBuscarPlatillo.TabIndex = 0;
            // 
            // txtBuscarPlatillo
            // 
            txtBuscarPlatillo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarPlatillo.Location = new Point(201, 22);
            txtBuscarPlatillo.Name = "txtBuscarPlatillo";
            txtBuscarPlatillo.Size = new Size(293, 26);
            txtBuscarPlatillo.TabIndex = 1;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label14.AutoSize = true;
            label14.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.Location = new Point(114, 23);
            label14.Name = "label14";
            label14.Size = new Size(81, 23);
            label14.TabIndex = 0;
            label14.Text = "Buscar:";
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(962, 603);
            Controls.Add(tcInventario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventario";
            Text = "FrmInventario";
            tcInventario.ResumeLayout(false);
            tabInsumos.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            pnlRegistroProducto.ResumeLayout(false);
            pnlRegistroProducto.PerformLayout();
            pnlListarProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlBuscarProducto.ResumeLayout(false);
            pnlBuscarProducto.PerformLayout();
            tabPlatillos.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            pnlRegistrarPlatillo.ResumeLayout(false);
            pnlRegistrarPlatillo.PerformLayout();
            pnlListarPlatillo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPlatillos).EndInit();
            pnlBuscarPlatillo.ResumeLayout(false);
            pnlBuscarPlatillo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcInventario;
        private TabPage tabInsumos;
        private TabPage tabPlatillos;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistroProducto;
        private Panel pnlListarProducto;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel pnlRegistrarPlatillo;
        private Label label2;
        private Panel pnlListarPlatillo;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private DateTimePicker dtpFechaVencimiento;
        private ComboBox cmbProveedor;
        private ComboBox comboBox1;
        private Button btnGuardarProducto;
        private Button button4;
        private Button btnEliminarProducto;
        private Button btnEditarProducto;
        private Panel pnlBuscarProducto;
        private DataGridView dataGridView1;
        private TextBox txtBuscarProducto;
        private Label label10;
        private Panel pnlBuscarPlatillo;
        private CheckBox chkDisponible;
        private TextBox txtPrecio;
        private TextBox txtTamaño;
        private TextBox txtTipoPlatillo;
        private Label label13;
        private Label label12;
        private Label label11;
        private Button btnLimpiarPlatillo;
        private Button btnEliminarPlatillo;
        private Button btnEditarPlatillo;
        private Button btnGuardarPlatillo;
        private TextBox txtBuscarPlatillo;
        private Label label14;
        private DataGridView dgvPlatillos;
    }
}