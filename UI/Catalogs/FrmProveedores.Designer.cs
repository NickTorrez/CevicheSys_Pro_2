namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmProveedores
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistro = new Panel();
            txtCorreo = new TextBox();
            txtApellidoProveedor = new TextBox();
            label8 = new Label();
            label7 = new Label();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            txtNombreProveedor = new TextBox();
            txtCedulaRuc = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            pnlLista = new Panel();
            dgvProveedores = new DataGridView();
            pnlBuscar = new Panel();
            txtBuscarProveedor = new TextBox();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistro.SuspendLayout();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).BeginInit();
            pnlBuscar.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.Controls.Add(pnlRegistro, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlLista, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(962, 603);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlRegistro
            // 
            pnlRegistro.BorderStyle = BorderStyle.FixedSingle;
            pnlRegistro.Controls.Add(txtCorreo);
            pnlRegistro.Controls.Add(txtApellidoProveedor);
            pnlRegistro.Controls.Add(label8);
            pnlRegistro.Controls.Add(label7);
            pnlRegistro.Controls.Add(txtDireccion);
            pnlRegistro.Controls.Add(txtTelefono);
            pnlRegistro.Controls.Add(txtNombreProveedor);
            pnlRegistro.Controls.Add(txtCedulaRuc);
            pnlRegistro.Controls.Add(label6);
            pnlRegistro.Controls.Add(label5);
            pnlRegistro.Controls.Add(label4);
            pnlRegistro.Controls.Add(label3);
            pnlRegistro.Controls.Add(label2);
            pnlRegistro.Controls.Add(btnLimpiar);
            pnlRegistro.Controls.Add(btnEliminar);
            pnlRegistro.Controls.Add(btnEditar);
            pnlRegistro.Controls.Add(btnGuardar);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Location = new Point(3, 3);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(330, 597);
            pnlRegistro.TabIndex = 0;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.Font = new Font("Century Gothic", 9F);
            txtCorreo.Location = new Point(116, 270);
            txtCorreo.MaxLength = 100;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(202, 26);
            txtCorreo.TabIndex = 20;
            txtCorreo.Enter += TextBox_Enter;
            txtCorreo.Leave += TextBox_Leave;
            // 
            // txtApellidoProveedor
            // 
            txtApellidoProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtApellidoProveedor.Font = new Font("Century Gothic", 9F);
            txtApellidoProveedor.Location = new Point(116, 170);
            txtApellidoProveedor.MaxLength = 50;
            txtApellidoProveedor.Name = "txtApellidoProveedor";
            txtApellidoProveedor.Size = new Size(202, 26);
            txtApellidoProveedor.TabIndex = 19;
            txtApellidoProveedor.Enter += TextBox_Enter;
            txtApellidoProveedor.Leave += TextBox_Leave;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label8.Location = new Point(12, 274);
            label8.Name = "label8";
            label8.Size = new Size(48, 18);
            label8.TabIndex = 18;
            label8.Text = "Email";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 170);
            label7.Name = "label7";
            label7.Size = new Size(103, 36);
            label7.TabIndex = 17;
            label7.Text = "Apellido del \r\nProveedor";
            // 
            // txtDireccion
            // 
            txtDireccion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDireccion.Font = new Font("Century Gothic", 9F);
            txtDireccion.Location = new Point(12, 335);
            txtDireccion.MaxLength = 255;
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(306, 74);
            txtDireccion.TabIndex = 16;
            txtDireccion.Enter += TextBox_Enter;
            txtDireccion.Leave += TextBox_Leave;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Font = new Font("Century Gothic", 9F);
            txtTelefono.Location = new Point(116, 223);
            txtTelefono.MaxLength = 20;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(202, 26);
            txtTelefono.TabIndex = 15;
            txtTelefono.Enter += TextBox_Enter;
            txtTelefono.Leave += TextBox_Leave;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNombreProveedor.Font = new Font("Century Gothic", 9F);
            txtNombreProveedor.Location = new Point(114, 111);
            txtNombreProveedor.MaxLength = 50;
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(202, 26);
            txtNombreProveedor.TabIndex = 14;
            txtNombreProveedor.Enter += TextBox_Enter;
            txtNombreProveedor.Leave += TextBox_Leave;
            // 
            // txtCedulaRuc
            // 
            txtCedulaRuc.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCedulaRuc.Font = new Font("Century Gothic", 9F);
            txtCedulaRuc.Location = new Point(116, 61);
            txtCedulaRuc.MaxLength = 20;
            txtCedulaRuc.Name = "txtCedulaRuc";
            txtCedulaRuc.Size = new Size(202, 26);
            txtCedulaRuc.TabIndex = 13;
            txtCedulaRuc.Enter += TextBox_Enter;
            txtCedulaRuc.Leave += TextBox_Leave;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 309);
            label6.Name = "label6";
            label6.Size = new Size(81, 18);
            label6.TabIndex = 12;
            label6.Text = "Dirección";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 227);
            label5.Name = "label5";
            label5.Size = new Size(71, 18);
            label5.TabIndex = 11;
            label5.Text = "Telefono";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 111);
            label4.Name = "label4";
            label4.Size = new Size(96, 36);
            label4.TabIndex = 10;
            label4.Text = "Nombre del\r\nProveedor";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 65);
            label3.Name = "label3";
            label3.Size = new Size(98, 18);
            label3.TabIndex = 9;
            label3.Text = "Cédula/Ruc";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 12);
            label2.Name = "label2";
            label2.Size = new Size(238, 27);
            label2.TabIndex = 8;
            label2.Text = "Datos del Proveedor";
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.None;
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.FlatStyle = FlatStyle.Flat;
            btnLimpiar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(168, 511);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(150, 70);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Nuevo";
            btnLimpiar.UseVisualStyleBackColor = false;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.None;
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.FlatStyle = FlatStyle.Flat;
            btnEliminar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(12, 511);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 70);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar/\r\nInactivar";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Anchor = AnchorStyles.None;
            btnEditar.BackColor = Color.FromArgb(0, 123, 255);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(168, 435);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 70);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Modificar";
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.None;
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 435);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 70);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Registrar Proveedor";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // pnlLista
            // 
            pnlLista.BorderStyle = BorderStyle.FixedSingle;
            pnlLista.Controls.Add(dgvProveedores);
            pnlLista.Controls.Add(pnlBuscar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(339, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(620, 597);
            pnlLista.TabIndex = 1;
            // 
            // dgvProveedores
            // 
            dataGridViewCellStyle3.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dgvProveedores.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvProveedores.BackgroundColor = Color.WhiteSmoke;
            dgvProveedores.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle4.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.White;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvProveedores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvProveedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProveedores.Dock = DockStyle.Fill;
            dgvProveedores.Location = new Point(0, 68);
            dgvProveedores.Name = "dgvProveedores";
            dgvProveedores.RowHeadersWidth = 51;
            dgvProveedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProveedores.Size = new Size(618, 527);
            dgvProveedores.TabIndex = 1;
            dgvProveedores.CellContentClick += dgvProveedores_CellContentClick;
            // 
            // pnlBuscar
            // 
            pnlBuscar.Controls.Add(txtBuscarProveedor);
            pnlBuscar.Controls.Add(label1);
            pnlBuscar.Dock = DockStyle.Top;
            pnlBuscar.Location = new Point(0, 0);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(618, 68);
            pnlBuscar.TabIndex = 0;
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarProveedor.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtBuscarProveedor.Location = new Point(189, 21);
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.Size = new Size(329, 26);
            txtBuscarProveedor.TabIndex = 3;
            txtBuscarProveedor.TextChanged += txtBuscarProveedor_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 22);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 2;
            label1.Text = "Buscar:";
            // 
            // FrmProveedores
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmProveedores";
            Text = "FrmProveedores";
            Load += FrmProveedores_Load;
            tableLayoutPanel1.ResumeLayout(false);
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProveedores).EndInit();
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistro;
        private Panel pnlLista;
        private Panel pnlBuscar;
        private TextBox txtBuscarProveedor;
        private Label label1;
        private DataGridView dgvProveedores;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private TextBox txtNombreProveedor;
        private TextBox txtCedulaRuc;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox txtCorreo;
        private TextBox txtApellidoProveedor;
        private Label label8;
        private Label label7;
    }
}