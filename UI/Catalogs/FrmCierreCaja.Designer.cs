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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCierreCaja));
            gbCierreAutomatico = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            lblIngresosCalculados = new Label();
            lblCambiosEntregados = new Label();
            lblTotalVentasEfectivo = new Label();
            lblEfectivoInicial = new Label();
            gbCierreManual = new GroupBox();
            txtObservaciones = new TextBox();
            label2 = new Label();
            lblDescuadre = new Label();
            txtEfectivoReal = new TextBox();
            label1 = new Label();
            btnRegistrarCierre = new Button();
            btnCancelar = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label7 = new Label();
            lblTotalVentasTransferencia = new Label();
            gbCierreAutomatico.SuspendLayout();
            gbCierreManual.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // gbCierreAutomatico
            // 
            gbCierreAutomatico.Controls.Add(lblTotalVentasTransferencia);
            gbCierreAutomatico.Controls.Add(label7);
            gbCierreAutomatico.Controls.Add(label6);
            gbCierreAutomatico.Controls.Add(label5);
            gbCierreAutomatico.Controls.Add(label4);
            gbCierreAutomatico.Controls.Add(label3);
            gbCierreAutomatico.Controls.Add(lblIngresosCalculados);
            gbCierreAutomatico.Controls.Add(lblCambiosEntregados);
            gbCierreAutomatico.Controls.Add(lblTotalVentasEfectivo);
            gbCierreAutomatico.Controls.Add(lblEfectivoInicial);
            gbCierreAutomatico.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbCierreAutomatico.Location = new Point(12, 36);
            gbCierreAutomatico.Name = "gbCierreAutomatico";
            gbCierreAutomatico.Size = new Size(281, 253);
            gbCierreAutomatico.TabIndex = 0;
            gbCierreAutomatico.TabStop = false;
            gbCierreAutomatico.Text = "Resumen del Sistema";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label6.Location = new Point(7, 192);
            label6.Name = "label6";
            label6.Size = new Size(157, 18);
            label6.TabIndex = 7;
            label6.Text = "Ingresos Calculados";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(7, 156);
            label5.Name = "label5";
            label5.Size = new Size(160, 18);
            label5.TabIndex = 6;
            label5.Text = "Cambios Entregados";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(5, 70);
            label4.Name = "label4";
            label4.Size = new Size(143, 18);
            label4.TabIndex = 5;
            label4.Text = "Ventas en Efectivo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(7, 32);
            label3.Name = "label3";
            label3.Size = new Size(106, 18);
            label3.TabIndex = 4;
            label3.Text = "Dinero Inicial";
            // 
            // lblIngresosCalculados
            // 
            lblIngresosCalculados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIngresosCalculados.AutoSize = true;
            lblIngresosCalculados.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            lblIngresosCalculados.Location = new Point(219, 192);
            lblIngresosCalculados.Name = "lblIngresosCalculados";
            lblIngresosCalculados.Size = new Size(48, 18);
            lblIngresosCalculados.TabIndex = 3;
            lblIngresosCalculados.Text = "C$ IC";
            // 
            // lblCambiosEntregados
            // 
            lblCambiosEntregados.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCambiosEntregados.AutoSize = true;
            lblCambiosEntregados.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            lblCambiosEntregados.Location = new Point(215, 156);
            lblCambiosEntregados.Name = "lblCambiosEntregados";
            lblCambiosEntregados.Size = new Size(52, 18);
            lblCambiosEntregados.TabIndex = 2;
            lblCambiosEntregados.Text = "C$ CE";
            // 
            // lblTotalVentasEfectivo
            // 
            lblTotalVentasEfectivo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalVentasEfectivo.AutoSize = true;
            lblTotalVentasEfectivo.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            lblTotalVentasEfectivo.Location = new Point(210, 70);
            lblTotalVentasEfectivo.Name = "lblTotalVentasEfectivo";
            lblTotalVentasEfectivo.Size = new Size(58, 18);
            lblTotalVentasEfectivo.TabIndex = 1;
            lblTotalVentasEfectivo.Text = "C$ VEF";
            // 
            // lblEfectivoInicial
            // 
            lblEfectivoInicial.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblEfectivoInicial.AutoSize = true;
            lblEfectivoInicial.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            lblEfectivoInicial.Location = new Point(190, 33);
            lblEfectivoInicial.Name = "lblEfectivoInicial";
            lblEfectivoInicial.Size = new Size(77, 18);
            lblEfectivoInicial.TabIndex = 0;
            lblEfectivoInicial.Text = "C$ Inicial";
            // 
            // gbCierreManual
            // 
            gbCierreManual.Controls.Add(txtObservaciones);
            gbCierreManual.Controls.Add(label2);
            gbCierreManual.Controls.Add(lblDescuadre);
            gbCierreManual.Controls.Add(txtEfectivoReal);
            gbCierreManual.Controls.Add(label1);
            gbCierreManual.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbCierreManual.Location = new Point(310, 36);
            gbCierreManual.Name = "gbCierreManual";
            gbCierreManual.Size = new Size(290, 477);
            gbCierreManual.TabIndex = 1;
            gbCierreManual.TabStop = false;
            gbCierreManual.Text = "Conteo Manual";
            // 
            // txtObservaciones
            // 
            txtObservaciones.Font = new Font("Century Gothic", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtObservaciones.Location = new Point(9, 213);
            txtObservaciones.MaxLength = 0;
            txtObservaciones.Multiline = true;
            txtObservaciones.Name = "txtObservaciones";
            txtObservaciones.Size = new Size(273, 258);
            txtObservaciones.TabIndex = 4;
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
            // lblDescuadre
            // 
            lblDescuadre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblDescuadre.AutoSize = true;
            lblDescuadre.Location = new Point(39, 133);
            lblDescuadre.Name = "lblDescuadre";
            lblDescuadre.Size = new Size(172, 19);
            lblDescuadre.TabIndex = 2;
            lblDescuadre.Text = "Descuadre: C$ 0.00";
            // 
            // txtEfectivoReal
            // 
            txtEfectivoReal.Location = new Point(39, 78);
            txtEfectivoReal.MaxLength = 12;
            txtEfectivoReal.Name = "txtEfectivoReal";
            txtEfectivoReal.Size = new Size(213, 28);
            txtEfectivoReal.TabIndex = 1;
            txtEfectivoReal.TextAlign = HorizontalAlignment.Right;
            txtEfectivoReal.TextChanged += txtEfectivoReal_TextChanged;
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
            // 
            // btnRegistrarCierre
            // 
            btnRegistrarCierre.BackColor = Color.FromArgb(40, 167, 69);
            btnRegistrarCierre.Cursor = Cursors.Hand;
            btnRegistrarCierre.FlatStyle = FlatStyle.Flat;
            btnRegistrarCierre.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnRegistrarCierre.ForeColor = Color.White;
            btnRegistrarCierre.Location = new Point(18, 18);
            btnRegistrarCierre.Name = "btnRegistrarCierre";
            btnRegistrarCierre.Size = new Size(210, 79);
            btnRegistrarCierre.TabIndex = 2;
            btnRegistrarCierre.Text = "Registrar Cierre";
            btnRegistrarCierre.UseVisualStyleBackColor = false;
            btnRegistrarCierre.Click += btnRegistrarCierre_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.Cursor = Cursors.Hand;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            btnCancelar.ForeColor = Color.White;
            btnCancelar.Location = new Point(18, 103);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(210, 79);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(btnRegistrarCierre);
            flowLayoutPanel1.Controls.Add(btnCancelar);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(27, 306);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(15);
            flowLayoutPanel1.Size = new Size(251, 201);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(7, 101);
            label7.Name = "label7";
            label7.Size = new Size(106, 36);
            label7.TabIndex = 8;
            label7.Text = "Ventas por \r\nTransferencia";
            // 
            // lblTotalVentasTransferencia
            // 
            lblTotalVentasTransferencia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblTotalVentasTransferencia.AutoSize = true;
            lblTotalVentasTransferencia.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalVentasTransferencia.Location = new Point(209, 112);
            lblTotalVentasTransferencia.Name = "lblTotalVentasTransferencia";
            lblTotalVentasTransferencia.Size = new Size(57, 18);
            lblTotalVentasTransferencia.TabIndex = 9;
            lblTotalVentasTransferencia.Text = "C$ VPT";
            // 
            // FrmCierreCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(612, 553);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(gbCierreManual);
            Controls.Add(gbCierreAutomatico);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FrmCierreCaja";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Cierre de Caja";
            Load += FrmCierreCaja_Load;
            gbCierreAutomatico.ResumeLayout(false);
            gbCierreAutomatico.PerformLayout();
            gbCierreManual.ResumeLayout(false);
            gbCierreManual.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox gbCierreAutomatico;
        private Label lblIngresosCalculados;
        private Label lblCambiosEntregados;
        private Label lblTotalVentasEfectivo;
        private Label lblEfectivoInicial;
        private GroupBox gbCierreManual;
        private Label label1;
        private TextBox txtEfectivoReal;
        private Label lblDescuadre;
        private TextBox txtObservaciones;
        private Label label2;
        private Button btnRegistrarCierre;
        private Button btnCancelar;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label lblTotalVentasTransferencia;
        private Label label7;
    }
}