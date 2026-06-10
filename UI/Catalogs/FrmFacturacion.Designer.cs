namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFacturacion));
            txtNombreCliente = new TextBox();
            txtTelefono = new TextBox();
            groupBox1 = new GroupBox();
            btnCancelar = new Button();
            btnGenerarFactura = new Button();
            pnlEfectivo = new Panel();
            lblCambio = new Label();
            label5 = new Label();
            txtMontoEntregado = new TextBox();
            lblTotalPagar = new Label();
            label4 = new Label();
            cmbMetodoPago = new ComboBox();
            cmbTipoCompra = new ComboBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox1.SuspendLayout();
            pnlEfectivo.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(152, 27);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(186, 28);
            txtNombreCliente.TabIndex = 0;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(152, 61);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(186, 28);
            txtTelefono.TabIndex = 1;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnCancelar);
            groupBox1.Controls.Add(btnGenerarFactura);
            groupBox1.Controls.Add(pnlEfectivo);
            groupBox1.Controls.Add(lblTotalPagar);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(cmbMetodoPago);
            groupBox1.Controls.Add(cmbTipoCompra);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtNombreCliente);
            groupBox1.Controls.Add(txtTelefono);
            groupBox1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(35, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(366, 434);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Ingresar Datos de la Compra";
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(188, 354);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(170, 64);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // btnGenerarFactura
            // 
            btnGenerarFactura.BackColor = Color.FromArgb(40, 167, 69);
            btnGenerarFactura.Cursor = Cursors.Hand;
            btnGenerarFactura.FlatStyle = FlatStyle.Flat;
            btnGenerarFactura.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerarFactura.ForeColor = Color.White;
            btnGenerarFactura.Location = new Point(12, 354);
            btnGenerarFactura.Name = "btnGenerarFactura";
            btnGenerarFactura.Size = new Size(170, 64);
            btnGenerarFactura.TabIndex = 10;
            btnGenerarFactura.Text = "Generar Factura";
            btnGenerarFactura.UseVisualStyleBackColor = false;
            btnGenerarFactura.Click += btnGenerarFactura_Click;
            // 
            // pnlEfectivo
            // 
            pnlEfectivo.Controls.Add(lblCambio);
            pnlEfectivo.Controls.Add(label5);
            pnlEfectivo.Controls.Add(txtMontoEntregado);
            pnlEfectivo.Location = new Point(12, 213);
            pnlEfectivo.Name = "pnlEfectivo";
            pnlEfectivo.Size = new Size(348, 125);
            pnlEfectivo.TabIndex = 9;
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCambio.Location = new Point(88, 70);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(173, 23);
            lblCambio.TabIndex = 10;
            lblCambio.Text = "Cambio: C$ 0.00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(19, 19);
            label5.Name = "label5";
            label5.Size = new Size(135, 18);
            label5.TabIndex = 10;
            label5.Text = "Monto Entregado";
            // 
            // txtMontoEntregado
            // 
            txtMontoEntregado.Location = new Point(156, 15);
            txtMontoEntregado.Name = "txtMontoEntregado";
            txtMontoEntregado.Size = new Size(171, 28);
            txtMontoEntregado.TabIndex = 0;
            txtMontoEntregado.TextChanged += txtMontoEntregado_TextChanged;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPagar.ForeColor = SystemColors.Highlight;
            lblTotalPagar.Location = new Point(134, 167);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(99, 34);
            lblTotalPagar.TabIndex = 8;
            lblTotalPagar.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(6, 132);
            label4.Name = "label4";
            label4.Size = new Size(152, 19);
            label4.TabIndex = 7;
            label4.Text = " Metodo de Pago";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Transferencia" });
            cmbMetodoPago.Location = new Point(167, 128);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(171, 27);
            cmbMetodoPago.TabIndex = 6;
            // 
            // cmbTipoCompra
            // 
            cmbTipoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoCompra.FormattingEnabled = true;
            cmbTipoCompra.Items.AddRange(new object[] { "Local", "Delivery" });
            cmbTipoCompra.Location = new Point(167, 95);
            cmbTipoCompra.Name = "cmbTipoCompra";
            cmbTipoCompra.Size = new Size(171, 27);
            cmbTipoCompra.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 98);
            label3.Name = "label3";
            label3.Size = new Size(141, 19);
            label3.TabIndex = 4;
            label3.Text = "Tipo de Compra";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 64);
            label2.Name = "label2";
            label2.Size = new Size(79, 19);
            label2.TabIndex = 3;
            label2.Text = "Telefono";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 30);
            label1.Name = "label1";
            label1.Size = new Size(66, 19);
            label1.TabIndex = 2;
            label1.Text = "Cliente";
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(432, 503);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmFacturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturación de la Compra";
            Load += FrmFacturacion_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            pnlEfectivo.ResumeLayout(false);
            pnlEfectivo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox txtNombreCliente;
        private TextBox txtTelefono;
        private GroupBox groupBox1;
        private Label label4;
        private ComboBox cmbMetodoPago;
        private ComboBox cmbTipoCompra;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblTotalPagar;
        private Panel pnlEfectivo;
        private Label lblCambio;
        private Label label5;
        private TextBox txtMontoEntregado;
        private Button btnCancelar;
        private Button btnGenerarFactura;
    }
}