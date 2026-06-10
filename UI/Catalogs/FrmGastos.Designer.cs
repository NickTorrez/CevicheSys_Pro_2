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
            tableLayoutPanel1 = new TableLayoutPanel();
            pnlRegistro = new Panel();
            pnlLista = new Panel();
            pnlFiltrar = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnGuardar = new Button();
            label2 = new Label();
            dtpFechaGasto = new DateTimePicker();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dtpInicio = new DateTimePicker();
            dtpFin = new DateTimePicker();
            btnFiltrar = new Button();
            dataGridView1 = new DataGridView();
            tableLayoutPanel1.SuspendLayout();
            pnlRegistro.SuspendLayout();
            pnlLista.SuspendLayout();
            pnlFiltrar.SuspendLayout();
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
            pnlRegistro.Controls.Add(textBox2);
            pnlRegistro.Controls.Add(textBox1);
            pnlRegistro.Controls.Add(comboBox1);
            pnlRegistro.Controls.Add(label5);
            pnlRegistro.Controls.Add(label4);
            pnlRegistro.Controls.Add(label3);
            pnlRegistro.Controls.Add(label1);
            pnlRegistro.Controls.Add(dtpFechaGasto);
            pnlRegistro.Controls.Add(label2);
            pnlRegistro.Controls.Add(btnLimpiar);
            pnlRegistro.Controls.Add(btnEliminar);
            pnlRegistro.Controls.Add(btnGuardar);
            pnlRegistro.Dock = DockStyle.Fill;
            pnlRegistro.Location = new Point(3, 3);
            pnlRegistro.Name = "pnlRegistro";
            pnlRegistro.Size = new Size(330, 597);
            pnlRegistro.TabIndex = 0;
            pnlRegistro.Paint += pnlRegistro_Paint;
            // 
            // pnlLista
            // 
            pnlLista.Controls.Add(dataGridView1);
            pnlLista.Controls.Add(pnlFiltrar);
            pnlLista.Dock = DockStyle.Fill;
            pnlLista.Location = new Point(339, 3);
            pnlLista.Name = "pnlLista";
            pnlLista.Size = new Size(620, 597);
            pnlLista.TabIndex = 1;
            // 
            // pnlFiltrar
            // 
            pnlFiltrar.Controls.Add(btnFiltrar);
            pnlFiltrar.Controls.Add(dtpFin);
            pnlFiltrar.Controls.Add(dtpInicio);
            pnlFiltrar.Dock = DockStyle.Top;
            pnlFiltrar.Location = new Point(0, 0);
            pnlFiltrar.Name = "pnlFiltrar";
            pnlFiltrar.Size = new Size(620, 115);
            pnlFiltrar.TabIndex = 0;
            // 
            // btnLimpiar
            // 
            btnLimpiar.BackColor = Color.FromArgb(108, 117, 125);
            btnLimpiar.Cursor = Cursors.Hand;
            btnLimpiar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnLimpiar.ForeColor = Color.White;
            btnLimpiar.Location = new Point(168, 512);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(150, 70);
            btnLimpiar.TabIndex = 10;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(220, 53, 69);
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnEliminar.ForeColor = Color.White;
            btnEliminar.Location = new Point(12, 512);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(150, 70);
            btnEliminar.TabIndex = 9;
            btnEliminar.Text = "Anular Gasto";
            btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(90, 432);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(150, 70);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Registrar Egreso";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(56, 28);
            label2.Name = "label2";
            label2.Size = new Size(218, 27);
            label2.TabIndex = 11;
            label2.Text = "Registro de Gastos";
            // 
            // dtpFechaGasto
            // 
            dtpFechaGasto.Format = DateTimePickerFormat.Short;
            dtpFechaGasto.Location = new Point(123, 109);
            dtpFechaGasto.Name = "dtpFechaGasto";
            dtpFechaGasto.RightToLeft = RightToLeft.No;
            dtpFechaGasto.Size = new Size(195, 27);
            dtpFechaGasto.TabIndex = 12;
            dtpFechaGasto.ValueChanged += dtpFechaGasto_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label1.Location = new Point(12, 115);
            label1.Name = "label1";
            label1.Size = new Size(54, 18);
            label1.TabIndex = 13;
            label1.Text = "Fecha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label3.Location = new Point(12, 165);
            label3.Name = "label3";
            label3.Size = new Size(109, 18);
            label3.TabIndex = 14;
            label3.Text = "Tipo de Gasto";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label4.Location = new Point(9, 216);
            label4.Name = "label4";
            label4.Size = new Size(97, 18);
            label4.TabIndex = 15;
            label4.Text = "Descripción";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            label5.Location = new Point(12, 370);
            label5.Name = "label5";
            label5.Size = new Size(93, 18);
            label5.TabIndex = 16;
            label5.Text = "Monto Total";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(123, 161);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(195, 28);
            comboBox1.TabIndex = 17;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 245);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(306, 100);
            textBox1.TabIndex = 18;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(123, 366);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(195, 27);
            textBox2.TabIndex = 19;
            // 
            // dtpInicio
            // 
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Location = new Point(27, 17);
            dtpInicio.Name = "dtpInicio";
            dtpInicio.Size = new Size(250, 27);
            dtpInicio.TabIndex = 0;
            // 
            // dtpFin
            // 
            dtpFin.Format = DateTimePickerFormat.Short;
            dtpFin.Location = new Point(344, 17);
            dtpFin.Name = "dtpFin";
            dtpFin.Size = new Size(250, 27);
            dtpFin.TabIndex = 1;
            // 
            // btnFiltrar
            // 
            btnFiltrar.BackColor = Color.FromArgb(247, 127, 0);
            btnFiltrar.Font = new Font("Century Gothic", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFiltrar.ForeColor = Color.White;
            btnFiltrar.Location = new Point(233, 54);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(154, 51);
            btnFiltrar.TabIndex = 2;
            btnFiltrar.Text = "Filtrar Gastos";
            btnFiltrar.UseVisualStyleBackColor = false;
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
            dataGridView1.Location = new Point(0, 115);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(620, 482);
            dataGridView1.TabIndex = 1;
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
            pnlFiltrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel pnlRegistro;
        private Panel pnlLista;
        private Panel pnlFiltrar;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnGuardar;
        private Label label2;
        private TextBox textBox2;
        private TextBox textBox1;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label1;
        private DateTimePicker dtpFechaGasto;
        private Button btnFiltrar;
        private DateTimePicker dtpFin;
        private DateTimePicker dtpInicio;
        private DataGridView dataGridView1;
    }
}