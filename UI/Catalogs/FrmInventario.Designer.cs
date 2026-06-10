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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistro = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            pnlLista = new Panel();
            dgvInventario = new DataGridView();
            pnlBuscar = new Panel();
            txtBuscarProducto = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtCodigo = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistro.SuspendLayout();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
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
            pnlRegistro.Controls.Add(label7);
            pnlRegistro.Controls.Add(label6);
            pnlRegistro.Controls.Add(label5);
            pnlRegistro.Controls.Add(label4);
            pnlRegistro.Controls.Add(label3);
            pnlRegistro.Controls.Add(comboBox1);
            pnlRegistro.Controls.Add(textBox4);
            pnlRegistro.Controls.Add(textBox3);
            pnlRegistro.Controls.Add(textBox2);
            pnlRegistro.Controls.Add(txtCodigo);
            pnlRegistro.Controls.Add(label2);
            pnlRegistro.Controls.Add(btnLimpiar);
            pnlRegistro.Controls.Add(btnEliminar);
            pnlRegistro.Controls.Add(btnEditar);
            pnlRegistro.Controls.Add(btnGuardar);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            pnlRegistro.Location = new Point(3, 3);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(330, 597);
            pnlRegistro.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(165, 504);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(150, 70);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(9, 504);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 70);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar/\r\nInactivar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(0, 123, 255);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(165, 428);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 70);
            btnEditar.TabIndex = 1;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(9, 428);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 70);
            btnGuardar.TabIndex = 0;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // pnlLista
            // 
            pnlLista.Controls.Add(dgvInventario);
            pnlLista.Controls.Add(pnlBuscar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(339, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(620, 597);
            pnlLista.TabIndex = 1;
            // 
            // dgvInventario
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvInventario.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Dock = DockStyle.Fill;
            dgvInventario.Location = new Point(0, 68);
            dgvInventario.Name = "dgvInventario";
            dgvInventario.RowHeadersWidth = 51;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(620, 529);
            dgvInventario.TabIndex = 1;
            // 
            // pnlBuscar
            // 
            pnlBuscar.Controls.Add(txtBuscarProducto);
            pnlBuscar.Controls.Add(label1);
            pnlBuscar.Dock = DockStyle.Top;
            pnlBuscar.Location = new Point(0, 0);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(620, 68);
            pnlBuscar.TabIndex = 0;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(189, 19);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(329, 27);
            txtBuscarProducto.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 20);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 0;
            label1.Text = "Buscar:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(38, 20);
            label2.Name = "label2";
            label2.Size = new Size(254, 27);
            label2.TabIndex = 4;
            label2.Text = "Registro de Inventario";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(120, 94);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(195, 26);
            txtCodigo.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(120, 153);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(195, 26);
            textBox2.TabIndex = 6;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(120, 269);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(195, 26);
            textBox3.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(120, 335);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(195, 26);
            textBox4.TabIndex = 8;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Insumos", "Platillos", "Bebidas" });
            comboBox1.Location = new Point(120, 213);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 26);
            comboBox1.TabIndex = 9;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(21, 97);
            label3.Name = "label3";
            label3.Size = new Size(93, 18);
            label3.TabIndex = 10;
            label3.Text = "ID Producto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(21, 150);
            label4.Name = "label4";
            label4.Size = new Size(74, 36);
            label4.TabIndex = 11;
            label4.Text = "Nombre \r\nProducto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(21, 216);
            label5.Name = "label5";
            label5.Size = new Size(83, 18);
            label5.TabIndex = 12;
            label5.Text = "Categoria";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label6.Location = new Point(21, 269);
            label6.Name = "label6";
            label6.Size = new Size(79, 36);
            label6.TabIndex = 13;
            label6.Text = "Precio de\r\nVenta";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label7.Location = new Point(21, 338);
            label7.Name = "label7";
            label7.Size = new Size(91, 18);
            label7.TabIndex = 14;
            label7.Text = "Stock Atual";
            // 
            // FrmInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmInventario";
            Text = "FrmInventario";
            tableLayoutPanel1.ResumeLayout(false);
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistro;
        private Panel pnlLista;
        private DataGridView dgvInventario;
        private Panel pnlBuscar;
        private TextBox txtBuscarProducto;
        private Label label1;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnEditar;
        private Button btnGuardar;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private TextBox textBox2;
        private TextBox txtCodigo;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private ComboBox comboBox1;
    }
}