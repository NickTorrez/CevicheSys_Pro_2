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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistro = new Panel();
            pnlLista = new Panel();
            pnlBuscar = new Panel();
            txtBuscarProveedor = new TextBox();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnEditar = new Button();
            btnGuardar = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtCedulaRuc = new TextBox();
            txtNombreProveedor = new TextBox();
            txtTelefono = new TextBox();
            txtDireccion = new TextBox();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistro.SuspendLayout();
            pnlLista.SuspendLayout();
            pnlBuscar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // pnlLista
            // 
            pnlLista.Controls.Add(dataGridView1);
            pnlLista.Controls.Add(pnlBuscar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(339, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(620, 597);
            pnlLista.TabIndex = 1;
            // 
            // pnlBuscar
            // 
            pnlBuscar.Controls.Add(txtBuscarProveedor);
            pnlBuscar.Controls.Add(label1);
            pnlBuscar.Dock = DockStyle.Top;
            pnlBuscar.Location = new Point(0, 0);
            pnlBuscar.Name = "pnlBuscar";
            pnlBuscar.Size = new Size(620, 68);
            pnlBuscar.TabIndex = 0;
            // 
            // txtBuscarProveedor
            // 
            txtBuscarProveedor.Location = new Point(189, 21);
            txtBuscarProveedor.Name = "txtBuscarProveedor";
            txtBuscarProveedor.Size = new Size(329, 27);
            txtBuscarProveedor.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(102, 22);
            label1.Name = "label1";
            label1.Size = new Size(81, 23);
            label1.TabIndex = 2;
            label1.Text = "Buscar:";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 68);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(620, 529);
            dataGridView1.TabIndex = 1;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(168, 503);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(150, 70);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Nuevo";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(12, 503);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 70);
            btnEliminar.TabIndex = 6;
            btnEliminar.Text = "Eliminar/\r\nInactivar";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = Color.FromArgb(0, 123, 255);
            btnEditar.Cursor = Cursors.Hand;
            btnEditar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEditar.ForeColor = Color.White;
            btnEditar.Location = new Point(168, 427);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(150, 70);
            btnEditar.TabIndex = 5;
            btnEditar.Text = "Modificar";
            btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(12, 427);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 70);
            btnGuardar.TabIndex = 4;
            btnGuardar.Text = "Registrar Proveedor";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(46, 21);
            label2.Name = "label2";
            label2.Size = new Size(238, 27);
            label2.TabIndex = 8;
            label2.Text = "Datos del Proveedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 99);
            label3.Name = "label3";
            label3.Size = new Size(98, 18);
            label3.TabIndex = 9;
            label3.Text = "Cédula/Ruc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(12, 145);
            label4.Name = "label4";
            label4.Size = new Size(96, 36);
            label4.TabIndex = 10;
            label4.Text = "Nombre del\r\nProveedor";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 210);
            label5.Name = "label5";
            label5.Size = new Size(71, 18);
            label5.TabIndex = 11;
            label5.Text = "Telefono";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label6.Location = new Point(12, 262);
            label6.Name = "label6";
            label6.Size = new Size(81, 18);
            label6.TabIndex = 12;
            label6.Text = "Dirección";
            // 
            // txtCedulaRuc
            // 
            txtCedulaRuc.Location = new Point(116, 95);
            txtCedulaRuc.Name = "txtCedulaRuc";
            txtCedulaRuc.Size = new Size(202, 27);
            txtCedulaRuc.TabIndex = 13;
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(116, 150);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(202, 27);
            txtNombreProveedor.TabIndex = 14;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(116, 204);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(202, 27);
            txtTelefono.TabIndex = 15;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(12, 288);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(306, 74);
            txtDireccion.TabIndex = 16;
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
            tableLayoutPanel1.ResumeLayout(false);
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            pnlLista.ResumeLayout(false);
            pnlBuscar.ResumeLayout(false);
            pnlBuscar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistro;
        private Panel pnlLista;
        private Panel pnlBuscar;
        private TextBox txtBuscarProveedor;
        private Label label1;
        private DataGridView dataGridView1;
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
    }
}