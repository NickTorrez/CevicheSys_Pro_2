namespace CevicheSys_Pro_2.UI.Catalogs
{
    partial class FrmGastos
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistro = new Panel();
            comboBox2 = new ComboBox();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label1 = new Label();
            dtpFechaGasto = new DateTimePicker();
            label2 = new Label();
            btnLimpiarEgreso = new Button();
            btnEliminarEgreso = new Button();
            btnGuardarEgreso = new Button();
            pnlLista = new Panel();
            dataGridView1 = new DataGridView();
            pnlFiltrar = new Panel();
            btnFiltrarEgreso = new Button();
            dtpFin = new DateTimePicker();
            dtpInicio = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistro.SuspendLayout();
            pnlLista.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlFiltrar.SuspendLayout();
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
            pnlRegistro.Controls.Add(comboBox2);
            pnlRegistro.Controls.Add(label6);
            pnlRegistro.Controls.Add(textBox2);
            pnlRegistro.Controls.Add(textBox1);
            pnlRegistro.Controls.Add(comboBox1);
            pnlRegistro.Controls.Add(label5);
            pnlRegistro.Controls.Add(label4);
            pnlRegistro.Controls.Add(label3);
            pnlRegistro.Controls.Add(label1);
            pnlRegistro.Controls.Add(dtpFechaGasto);
            pnlRegistro.Controls.Add(label2);
            pnlRegistro.Controls.Add(btnLimpiarEgreso);
            pnlRegistro.Controls.Add(btnEliminarEgreso);
            pnlRegistro.Controls.Add(btnGuardarEgreso);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Location = new Point(3, 3);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(330, 597);
            pnlRegistro.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Font = new Font("Century Gothic", 9F);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(123, 172);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(195, 28);
            comboBox2.TabIndex = 21;
            comboBox2.Enter += TextBox_Enter;
            comboBox2.Leave += TextBox_Leave;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 175);
            label6.Name = "label6";
            label6.Size = new Size(84, 18);
            label6.TabIndex = 20;
            label6.Text = "Proveedor";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Font = new Font("Century Gothic", 9F);
            textBox2.Location = new Point(123, 366);
            textBox2.MaxLength = 12;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(195, 26);
            textBox2.TabIndex = 19;
            textBox2.TextAlign = HorizontalAlignment.Right;
            textBox2.Enter += TextBox_Enter;
            textBox2.Leave += TextBox_Leave;
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Century Gothic", 9F);
            textBox1.Location = new Point(12, 245);
            textBox1.MaxLength = 255;
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 100);
            textBox1.TabIndex = 18;
            textBox1.Enter += TextBox_Enter;
            textBox1.Leave += TextBox_Leave;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Font = new Font("Century Gothic", 9F);
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Compras", "Servicios Basicos", "Salarios" });
            comboBox1.Location = new Point(123, 119);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 28);
            comboBox1.TabIndex = 17;
            comboBox1.Enter += TextBox_Enter;
            comboBox1.Leave += TextBox_Leave;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 370);
            label5.Name = "label5";
            label5.Size = new Size(93, 18);
            label5.TabIndex = 16;
            label5.Text = "Monto Total";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(9, 216);
            label4.Name = "label4";
            label4.Size = new Size(83, 18);
            label4.TabIndex = 15;
            label4.Text = "Concepto";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 123);
            label3.Name = "label3";
            label3.Size = new Size(109, 18);
            label3.TabIndex = 14;
            label3.Text = "Tipo de Gasto";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 75);
            label1.Name = "label1";
            label1.Size = new Size(54, 18);
            label1.TabIndex = 13;
            label1.Text = "Fecha";
            // 
            // dtpFechaGasto
            // 
            dtpFechaGasto.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dtpFechaGasto.Font = new Font("Century Gothic", 9F);
            dtpFechaGasto.Format = DateTimePickerFormat.Short;
            dtpFechaGasto.Location = new Point(123, 69);
            dtpFechaGasto.Name = "dtpFechaGasto";
            dtpFechaGasto.RightToLeft = RightToLeft.No;
            dtpFechaGasto.Size = new Size(195, 26);
            dtpFechaGasto.TabIndex = 12;
            dtpFechaGasto.Enter += TextBox_Enter;
            dtpFechaGasto.Leave += TextBox_Leave;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 17);
            label2.Name = "label2";
            label2.Size = new Size(218, 27);
            label2.TabIndex = 11;
            label2.Text = "Registro de Gastos";
            // 
            // btnLimpiarEgreso
            // 
            btnLimpiarEgreso.Anchor = AnchorStyles.None;
            btnLimpiarEgreso.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiarEgreso.Cursor = Cursors.Hand;
            btnLimpiarEgreso.FlatStyle = FlatStyle.Flat;
            btnLimpiarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiarEgreso.ForeColor = Color.White;
            btnLimpiarEgreso.Location = new Point(168, 512);
            btnLimpiarEgreso.Name = "btnLimpiarEgreso";
            btnLimpiarEgreso.Size = new Size(150, 70);
            btnLimpiarEgreso.TabIndex = 10;
            btnLimpiarEgreso.Text = "Limpiar";
            btnLimpiarEgreso.UseVisualStyleBackColor = false;
            // 
            // btnEliminarEgreso
            // 
            btnEliminarEgreso.Anchor = AnchorStyles.None;
            btnEliminarEgreso.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminarEgreso.Cursor = Cursors.Hand;
            btnEliminarEgreso.FlatStyle = FlatStyle.Flat;
            btnEliminarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminarEgreso.ForeColor = Color.White;
            btnEliminarEgreso.Location = new Point(12, 512);
            btnEliminarEgreso.Name = "btnEliminarEgreso";
            btnEliminarEgreso.Size = new Size(150, 70);
            btnEliminarEgreso.TabIndex = 9;
            btnEliminarEgreso.Text = "Anular Gasto";
            btnEliminarEgreso.UseVisualStyleBackColor = false;
            // 
            // btnGuardarEgreso
            // 
            btnGuardarEgreso.Anchor = AnchorStyles.None;
            btnGuardarEgreso.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardarEgreso.Cursor = Cursors.Hand;
            btnGuardarEgreso.FlatStyle = FlatStyle.Flat;
            btnGuardarEgreso.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardarEgreso.ForeColor = Color.White;
            btnGuardarEgreso.Location = new Point(90, 432);
            btnGuardarEgreso.Name = "btnGuardarEgreso";
            btnGuardarEgreso.Size = new Size(150, 70);
            btnGuardarEgreso.TabIndex = 8;
            btnGuardarEgreso.Text = "Registrar Egreso";
            btnGuardarEgreso.UseVisualStyleBackColor = false;
            // 
            // pnlLista
            // 
            pnlLista.BorderStyle = BorderStyle.FixedSingle;
            pnlLista.Controls.Add(dataGridView1);
            pnlLista.Controls.Add(pnlFiltrar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(339, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(620, 597);
            pnlLista.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.Black;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = Color.WhiteSmoke;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(0, 91, 150);
            dataGridViewCellStyle2.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(618, 480);
            dataGridView1.TabIndex = 1;
            // 
            // pnlFiltrar
            // 
            pnlFiltrar.Controls.Add(btnFiltrarEgreso);
            pnlFiltrar.Controls.Add(dtpFin);
            pnlFiltrar.Controls.Add(dtpInicio);
            pnlFiltrar.Dock = DockStyle.Top;
            pnlFiltrar.Location = new Point(0, 0);
            pnlFiltrar.Name = "pnlFiltrar";
            pnlFiltrar.Size = new Size(618, 115);
            pnlFiltrar.TabIndex = 0;
            // 
            // btnFiltrarEgreso
            // 
            btnFiltrarEgreso.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnFiltrarEgreso.BackColor = Color.FromArgb(247, 127, 0);
            btnFiltrarEgreso.FlatStyle = FlatStyle.Flat;
            btnFiltrarEgreso.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrarEgreso.ForeColor = Color.White;
            btnFiltrarEgreso.Location = new Point(233, 54);
            btnFiltrarEgreso.Name = "btnFiltrarEgreso";
            btnFiltrarEgreso.Size = new Size(154, 51);
            btnFiltrarEgreso.TabIndex = 2;
            btnFiltrarEgreso.Text = "Filtrar Gastos";
            btnFiltrarEgreso.UseVisualStyleBackColor = false;
            // 
            // dtpFin
            // 
            dtpFin.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dtpFin.Font = new Font("Century Gothic", 9F);
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(344, 17);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(250, 26);
            dtpFin.TabIndex = 1;
            // 
            // dtpInicio
            // 
            dtpInicio.Font = new Font("Century Gothic", 9F);
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(27, 17);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(250, 26);
            dtpInicio.TabIndex = 0;
            // 
            // FrmGastos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(962, 603);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmGastos";
            Text = "FrmGastos";
            tableLayoutPanel1.ResumeLayout(false);
            pnlRegistro.ResumeLayout(false);
            pnlRegistro.PerformLayout();
            pnlLista.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlFiltrar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistro;
        private Panel pnlLista;
        private Panel pnlFiltrar;
        private Button btnLimpiarEgreso;
        private Button btnEliminarEgreso;
        private Button btnGuardarEgreso;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DateTimePicker dtpFechaGasto;
        private Button btnFiltrarEgreso;
        private DateTimePicker dtpFin;
        private DateTimePicker dtpInicio;
        private DataGridView dataGridView1;
        private ComboBox comboBox2;
        private Label label6;
    }
}