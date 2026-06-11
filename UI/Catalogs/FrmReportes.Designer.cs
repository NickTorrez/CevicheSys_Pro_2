namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmReportes
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
            tcReportes = new TabControl();
            tabDashboard = new TabPage();
            tlpReportes = new TableLayoutPanel();
            panel1 = new Panel();
            lblTotalIngresos = new Label();
            label3 = new Label();
            panel2 = new Panel();
            lblTotalGastos = new Label();
            label4 = new Label();
            panel3 = new Panel();
            lblUtilidadNeta = new Label();
            label5 = new Label();
            pnlFiltro = new Panel();
            btnGenerarReporte = new Button();
            label2 = new Label();
            label1 = new Label();
            dateTimePicker2 = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            tabHistorial = new TabPage();
            dgvHistorial = new DataGridView();
            pnlTipoReporte = new Panel();
            btnExportarExcel = new Button();
            cmbTipoReporte = new ComboBox();
            label6 = new Label();
            btnAnularVenta = new Button();
            tcReportes.SuspendLayout();
            tabDashboard.SuspendLayout();
            tlpReportes.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            pnlFiltro.SuspendLayout();
            tabHistorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).BeginInit();
            pnlTipoReporte.SuspendLayout();
            SuspendLayout();
            // 
            // tcReportes
            // 
            tcReportes.Controls.Add(tabDashboard);
            tcReportes.Controls.Add(tabHistorial);
            tcReportes.Dock = DockStyle.Fill;
            tcReportes.Location = new Point(0, 0);
            tcReportes.Name = "tcReportes";
            tcReportes.SelectedIndex = 0;
            tcReportes.Size = new Size(962, 603);
            tcReportes.TabIndex = 0;
            // 
            // tabDashboard
            // 
            tabDashboard.BackColor = Color.White;
            tabDashboard.Controls.Add(tlpReportes);
            tabDashboard.Controls.Add(pnlFiltro);
            tabDashboard.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabDashboard.Location = new Point(4, 29);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Padding = new Padding(3);
            tabDashboard.Size = new Size(954, 570);
            tabDashboard.TabIndex = 0;
            tabDashboard.Text = "Dashboard Financiero";
            // 
            // tlpReportes
            // 
            tlpReportes.ColumnCount = 3;
            tlpReportes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpReportes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpReportes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tlpReportes.Controls.Add(panel1, 0, 0);
            tlpReportes.Controls.Add(panel2, 1, 0);
            tlpReportes.Controls.Add(panel3, 2, 0);
            tlpReportes.Dock = DockStyle.Top;
            tlpReportes.Location = new Point(3, 73);
            tlpReportes.Name = "tlpReportes";
            tlpReportes.RowCount = 1;
            tlpReportes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpReportes.Size = new Size(948, 120);
            tlpReportes.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(232, 245, 233);
            panel1.Controls.Add(lblTotalIngresos);
            panel1.Controls.Add(label3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(309, 114);
            panel1.TabIndex = 0;
            // 
            // lblTotalIngresos
            // 
            lblTotalIngresos.AutoSize = true;
            lblTotalIngresos.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalIngresos.ForeColor = Color.FromArgb(40, 167, 69);
            lblTotalIngresos.Location = new Point(107, 60);
            lblTotalIngresos.Name = "lblTotalIngresos";
            lblTotalIngresos.Size = new Size(94, 27);
            lblTotalIngresos.TabIndex = 1;
            lblTotalIngresos.Text = "C$ 0.00";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(47, 11);
            label3.Name = "label3";
            label3.Size = new Size(215, 34);
            label3.TabIndex = 0;
            label3.Text = "Ingresos Brutos";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 235, 238);
            panel2.Controls.Add(lblTotalGastos);
            panel2.Controls.Add(label4);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(318, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(309, 114);
            panel2.TabIndex = 1;
            // 
            // lblTotalGastos
            // 
            lblTotalGastos.AutoSize = true;
            lblTotalGastos.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalGastos.ForeColor = Color.FromArgb(220, 53, 69);
            lblTotalGastos.Location = new Point(107, 60);
            lblTotalGastos.Name = "lblTotalGastos";
            lblTotalGastos.Size = new Size(94, 27);
            lblTotalGastos.TabIndex = 1;
            lblTotalGastos.Text = "C$ 0.00";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(50, 11);
            label4.Name = "label4";
            label4.Size = new Size(208, 34);
            label4.TabIndex = 0;
            label4.Text = "Gastos Totales";
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(227, 242, 253);
            panel3.Controls.Add(lblUtilidadNeta);
            panel3.Controls.Add(label5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(633, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(312, 114);
            panel3.TabIndex = 2;
            // 
            // lblUtilidadNeta
            // 
            lblUtilidadNeta.AutoSize = true;
            lblUtilidadNeta.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUtilidadNeta.ForeColor = Color.FromArgb(0, 91, 150);
            lblUtilidadNeta.Location = new Point(109, 60);
            lblUtilidadNeta.Name = "lblUtilidadNeta";
            lblUtilidadNeta.Size = new Size(94, 27);
            lblUtilidadNeta.TabIndex = 1;
            lblUtilidadNeta.Text = "C$ 0.00";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(62, 11);
            label5.Name = "label5";
            label5.Size = new Size(189, 34);
            label5.TabIndex = 0;
            label5.Text = "Utilidad Neta";
            // 
            // pnlFiltro
            // 
            pnlFiltro.Controls.Add(btnGenerarReporte);
            pnlFiltro.Controls.Add(label2);
            pnlFiltro.Controls.Add(label1);
            pnlFiltro.Controls.Add(dateTimePicker2);
            pnlFiltro.Controls.Add(dateTimePicker1);
            pnlFiltro.Dock = DockStyle.Top;
            pnlFiltro.Location = new Point(3, 3);
            pnlFiltro.Name = "pnlFiltro";
            pnlFiltro.Size = new Size(948, 70);
            pnlFiltro.TabIndex = 0;
            // 
            // btnGenerarReporte
            // 
            btnGenerarReporte.BackColor = Color.FromArgb(0, 123, 255);
            btnGenerarReporte.Cursor = Cursors.Hand;
            btnGenerarReporte.FlatStyle = FlatStyle.Flat;
            btnGenerarReporte.ForeColor = Color.White;
            btnGenerarReporte.Location = new Point(728, 10);
            btnGenerarReporte.Name = "btnGenerarReporte";
            btnGenerarReporte.Size = new Size(170, 50);
            btnGenerarReporte.TabIndex = 4;
            btnGenerarReporte.Text = "Generar Reporte";
            btnGenerarReporte.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(378, 29);
            label2.Name = "label2";
            label2.Size = new Size(48, 18);
            label2.TabIndex = 3;
            label2.Text = "Hasta";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(46, 29);
            label1.Name = "label1";
            label1.Size = new Size(55, 18);
            label1.TabIndex = 2;
            label1.Text = "Desde";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Location = new Point(432, 25);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(250, 26);
            dateTimePicker2.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Location = new Point(107, 25);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(250, 26);
            dateTimePicker1.TabIndex = 0;
            // 
            // tabHistorial
            // 
            tabHistorial.BackColor = Color.White;
            tabHistorial.Controls.Add(dgvHistorial);
            tabHistorial.Controls.Add(pnlTipoReporte);
            tabHistorial.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabHistorial.Location = new Point(4, 29);
            tabHistorial.Name = "tabHistorial";
            tabHistorial.Padding = new Padding(3);
            tabHistorial.Size = new Size(954, 570);
            tabHistorial.TabIndex = 1;
            tabHistorial.Text = "Historial de Transacciones";
            // 
            // dgvHistorial
            // 
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistorial.Dock = DockStyle.Fill;
            dgvHistorial.Location = new Point(3, 63);
            dgvHistorial.Name = "dgvHistorial";
            dgvHistorial.ReadOnly = true;
            dgvHistorial.RowHeadersWidth = 51;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.Size = new Size(948, 504);
            dgvHistorial.TabIndex = 1;
            // 
            // pnlTipoReporte
            // 
            pnlTipoReporte.Controls.Add(btnAnularVenta);
            pnlTipoReporte.Controls.Add(btnExportarExcel);
            pnlTipoReporte.Controls.Add(cmbTipoReporte);
            pnlTipoReporte.Controls.Add(label6);
            pnlTipoReporte.Dock = DockStyle.Top;
            pnlTipoReporte.Location = new Point(3, 3);
            pnlTipoReporte.Name = "pnlTipoReporte";
            pnlTipoReporte.Size = new Size(948, 60);
            pnlTipoReporte.TabIndex = 0;
            // 
            // btnExportarExcel
            // 
            btnExportarExcel.BackColor = Color.FromArgb(40, 167, 69);
            btnExportarExcel.Cursor = Cursors.Hand;
            btnExportarExcel.FlatStyle = FlatStyle.Flat;
            btnExportarExcel.ForeColor = Color.White;
            btnExportarExcel.Location = new Point(470, 11);
            btnExportarExcel.Name = "btnExportarExcel";
            btnExportarExcel.Size = new Size(171, 40);
            btnExportarExcel.TabIndex = 2;
            btnExportarExcel.Text = "Exportar a Excel";
            btnExportarExcel.UseVisualStyleBackColor = false;
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Items.AddRange(new object[] { "Ventas Realizadas", "Gastos Operativos", "Cierres de Caja" });
            cmbTipoReporte.Location = new Point(234, 18);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(202, 26);
            cmbTipoReporte.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(65, 18);
            label6.Name = "label6";
            label6.Size = new Size(163, 23);
            label6.TabIndex = 0;
            label6.Text = "Tipo de Reporte";
            // 
            // btnAnularVenta
            // 
            btnAnularVenta.BackColor = Color.FromArgb(220, 53, 69);
            btnAnularVenta.Cursor = Cursors.Hand;
            btnAnularVenta.FlatStyle = FlatStyle.Flat;
            btnAnularVenta.ForeColor = Color.White;
            btnAnularVenta.Location = new Point(661, 11);
            btnAnularVenta.Name = "btnAnularVenta";
            btnAnularVenta.Size = new Size(237, 40);
            btnAnularVenta.TabIndex = 3;
            btnAnularVenta.Text = "Anular Venta Seleccionada";
            btnAnularVenta.UseVisualStyleBackColor = false;
            // 
            // FrmReportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(tcReportes);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmReportes";
            Text = "FrmReportes";
            tcReportes.ResumeLayout(false);
            tabDashboard.ResumeLayout(false);
            tlpReportes.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            pnlFiltro.ResumeLayout(false);
            pnlFiltro.PerformLayout();
            tabHistorial.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistorial).EndInit();
            pnlTipoReporte.ResumeLayout(false);
            pnlTipoReporte.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tcReportes;
        private TabPage tabDashboard;
        private TabPage tabHistorial;
        private Panel pnlFiltro;
        private Label label2;
        private Label label1;
        private DateTimePicker dateTimePicker2;
        private DateTimePicker dateTimePicker1;
        private Button btnGenerarReporte;
        private TableLayoutPanel tlpReportes;
        private Panel panel1;
        private Label lblTotalIngresos;
        private Label label3;
        private Panel panel2;
        private Label lblTotalGastos;
        private Label label4;
        private Panel panel3;
        private Label lblUtilidadNeta;
        private Label label5;
        private Panel pnlTipoReporte;
        private Label label6;
        private ComboBox cmbTipoReporte;
        private DataGridView dgvHistorial;
        private Button btnExportarExcel;
        private Button btnAnularVenta;
    }
}