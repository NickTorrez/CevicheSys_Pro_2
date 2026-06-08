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
            txtNombreCliente = new TextBox();
            txtTelefono = new TextBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbTipoCompra = new ComboBox();
            cmbMetodoPago = new ComboBox();
            label4 = new Label();
            lblTotalPagar = new Label();
            pnlEfectivo = new Panel();
            txtMontoEntregado = new TextBox();
            label5 = new Label();
            lblCambio = new Label();
            btnGenerarFactura = new Button();
            btnCancelar = new Button();
            groupBox1.SuspendLayout();
            pnlEfectivo.SuspendLayout();
            SuspendLayout();
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(201, 46);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(226, 27);
            txtNombreCliente.TabIndex = 0;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(201, 99);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(226, 27);
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
            groupBox1.Location = new Point(402, 27);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(459, 589);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Factura";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label1.Location = new Point(123, 47);
            label1.Name = "label1";
            label1.Size = new Size(72, 22);
            label1.TabIndex = 2;
            label1.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label2.Location = new Point(109, 100);
            label2.Name = "label2";
            label2.Size = new Size(86, 22);
            label2.TabIndex = 3;
            label2.Text = "Telefono";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label3.Location = new Point(42, 148);
            label3.Name = "label3";
            label3.Size = new Size(153, 22);
            label3.TabIndex = 4;
            label3.Text = "Tipo de Compra";
            // 
            // cmbTipoCompra
            // 
            cmbTipoCompra.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoCompra.FormattingEnabled = true;
            cmbTipoCompra.Items.AddRange(new object[] { "Local", "Delivery" });
            cmbTipoCompra.Location = new Point(201, 145);
            cmbTipoCompra.Name = "cmbTipoCompra";
            cmbTipoCompra.Size = new Size(226, 28);
            cmbTipoCompra.TabIndex = 5;
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Items.AddRange(new object[] { "Efectivo", "Tarjeta" });
            cmbMetodoPago.Location = new Point(201, 189);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(226, 28);
            cmbMetodoPago.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label4.Location = new Point(31, 191);
            label4.Name = "label4";
            label4.Size = new Size(164, 22);
            label4.TabIndex = 7;
            label4.Text = " Metodo de Pago";
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPagar.Location = new Point(180, 241);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(99, 34);
            lblTotalPagar.TabIndex = 8;
            lblTotalPagar.Text = "label5";
            // 
            // pnlEfectivo
            // 
            pnlEfectivo.Controls.Add(lblCambio);
            pnlEfectivo.Controls.Add(label5);
            pnlEfectivo.Controls.Add(txtMontoEntregado);
            pnlEfectivo.Location = new Point(11, 302);
            pnlEfectivo.Name = "pnlEfectivo";
            pnlEfectivo.Size = new Size(442, 125);
            pnlEfectivo.TabIndex = 9;
            // 
            // txtMontoEntregado
            // 
            txtMontoEntregado.Location = new Point(192, 15);
            txtMontoEntregado.Name = "txtMontoEntregado";
            txtMontoEntregado.Size = new Size(226, 27);
            txtMontoEntregado.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            label5.Location = new Point(24, 18);
            label5.Name = "label5";
            label5.Size = new Size(162, 22);
            label5.TabIndex = 10;
            label5.Text = "Monto Entregado";
            // 
            // lblCambio
            // 
            lblCambio.AutoSize = true;
            lblCambio.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCambio.Location = new Point(100, 71);
            lblCambio.Name = "lblCambio";
            lblCambio.Size = new Size(242, 34);
            lblCambio.TabIndex = 10;
            lblCambio.Text = "Cambio: C$ 0.00";
            // 
            // btnGenerarFactura
            // 
            btnGenerarFactura.BackColor = Color.Green;
            btnGenerarFactura.FlatStyle = FlatStyle.Flat;
            btnGenerarFactura.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnGenerarFactura.ForeColor = Color.White;
            btnGenerarFactura.Location = new Point(11, 487);
            btnGenerarFactura.Name = "btnGenerarFactura";
            btnGenerarFactura.Size = new Size(215, 64);
            btnGenerarFactura.TabIndex = 10;
            btnGenerarFactura.Text = "Generar Factura";
            btnGenerarFactura.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(238, 487);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(215, 64);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // FrmFacturacion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1262, 673);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmFacturacion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Facturación del Producto";
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