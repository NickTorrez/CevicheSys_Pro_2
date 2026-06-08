namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmCierreCaja
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
            groupBox1 = new GroupBox();
            lblEfectivoInicial = new Label();
            lblTotalVentasEfectivo = new Label();
            lblCambiosEntregados = new Label();
            lblIngresosCalculados = new Label();
            groupBox2 = new GroupBox();
            label1 = new Label();
            txtEfectivoReal = new TextBox();
            lblDescuadre = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            btnRegistrarCierre = new Button();
            btnCancelar = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(lblIngresosCalculados);
            groupBox1.Controls.Add(lblCambiosEntregados);
            groupBox1.Controls.Add(lblTotalVentasEfectivo);
            groupBox1.Controls.Add(lblEfectivoInicial);
            groupBox1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(12, 36);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(251, 253);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Resumen del Sistema";
            // 
            // lblEfectivoInicial
            // 
            lblEfectivoInicial.AutoSize = true;
            lblEfectivoInicial.Location = new Point(70, 41);
            lblEfectivoInicial.Name = "lblEfectivoInicial";
            lblEfectivoInicial.Size = new Size(111, 19);
            lblEfectivoInicial.TabIndex = 0;
            lblEfectivoInicial.Text = "DineroInicial";
            // 
            // lblTotalVentasEfectivo
            // 
            lblTotalVentasEfectivo.AutoSize = true;
            lblTotalVentasEfectivo.Location = new Point(60, 87);
            lblTotalVentasEfectivo.Name = "lblTotalVentasEfectivo";
            lblTotalVentasEfectivo.Size = new Size(130, 19);
            lblTotalVentasEfectivo.TabIndex = 1;
            lblTotalVentasEfectivo.Text = "VentasEfectivo";
            // 
            // lblCambiosEntregados
            // 
            lblCambiosEntregados.AutoSize = true;
            lblCambiosEntregados.Location = new Point(18, 135);
            lblCambiosEntregados.Name = "lblCambiosEntregados";
            lblCambiosEntregados.Size = new Size(174, 19);
            lblCambiosEntregados.TabIndex = 2;
            lblCambiosEntregados.Text = "CambiosEntregados";
            // 
            // lblIngresosCalculados
            // 
            lblIngresosCalculados.AutoSize = true;
            lblIngresosCalculados.Location = new Point(18, 181);
            lblIngresosCalculados.Name = "lblIngresosCalculados";
            lblIngresosCalculados.Size = new Size(177, 19);
            lblIngresosCalculados.TabIndex = 3;
            lblIngresosCalculados.Text = "IngresosCalculados ";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(textBox1);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(lblDescuadre);
            groupBox2.Controls.Add(txtEfectivoReal);
            groupBox2.Controls.Add(label1);
            groupBox2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox2.Location = new Point(280, 36);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(290, 477);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Conteo Manual";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 41);
            label1.Name = "label1";
            label1.Size = new Size(242, 18);
            label1.TabIndex = 0;
            label1.Text = "Ingrese el efectivo real en caja:";
            label1.Click += label1_Click;
            // 
            // txtEfectivoReal
            // 
            txtEfectivoReal.Location = new Point(39, 78);
            txtEfectivoReal.Name = "txtEfectivoReal";
            txtEfectivoReal.Size = new Size(213, 28);
            txtEfectivoReal.TabIndex = 1;
            // 
            // lblDescuadre
            // 
            lblDescuadre.AutoSize = true;
            lblDescuadre.Location = new Point(59, 135);
            lblDescuadre.Name = "lblDescuadre";
            lblDescuadre.Size = new Size(172, 19);
            lblDescuadre.TabIndex = 2;
            lblDescuadre.Text = "Descuadre: C$ 0.00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(9, 181);
            label2.Name = "label2";
            label2.Size = new Size(273, 19);
            label2.TabIndex = 3;
            label2.Text = "Observaciones o Recordatorios:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(9, 213);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(273, 258);
            textBox1.TabIndex = 4;
            // 
            // btnRegistrarCierre
            // 
            btnRegistrarCierre.BackColor = Color.Green;
            btnRegistrarCierre.FlatStyle = FlatStyle.Flat;
            btnRegistrarCierre.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnRegistrarCierre.ForeColor = Color.White;
            btnRegistrarCierre.Location = new Point(18, 18);
            btnRegistrarCierre.Name = "btnRegistrarCierre";
            btnRegistrarCierre.Size = new Size(210, 79);
            btnRegistrarCierre.TabIndex = 2;
            btnRegistrarCierre.Text = "Registrar Cierre";
            btnRegistrarCierre.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(18, 103);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(210, 79);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnRegistrarCierre);
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 312);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(15);
            flowLayoutPanel1.Size = new Size(251, 201);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // FrmCierreCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(582, 553);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmCierreCaja";
            StartPosition = FormStartPosition.CenterParent;
            Text = "FrmCierreCaja";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label lblIngresosCalculados;
        private Label lblCambiosEntregados;
        private Label lblTotalVentasEfectivo;
        private Label lblEfectivoInicial;
        private GroupBox groupBox2;
        private Label label1;
        private TextBox txtEfectivoReal;
        private Label lblDescuadre;
        private TextBox textBox1;
        private Label label2;
        private Button btnRegistrarCierre;
        private Button btnCancelar;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}