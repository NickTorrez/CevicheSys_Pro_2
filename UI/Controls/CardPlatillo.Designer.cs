namespace CevicheSys_Pro_2.UI.Controls
{
    partial class CardPlatillo
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            lblTipo = new Label();
            lblTamaño = new Label();
            lblPrecio = new Label();
            SuspendLayout();
            // 
            // lblTipo
            // 
            lblTipo.AutoSize = true;
            lblTipo.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTipo.Location = new Point(11, 11);
            lblTipo.Name = "lblTipo";
            lblTipo.Size = new Size(137, 22);
            lblTipo.TabIndex = 0;
            lblTipo.Text = "Ceviche Mixto";
            // 
            // lblTamaño
            // 
            lblTamaño.AutoSize = true;
            lblTamaño.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTamaño.ForeColor = SystemColors.ControlDarkDark;
            lblTamaño.Location = new Point(53, 46);
            lblTamaño.Name = "lblTamaño";
            lblTamaño.Size = new Size(54, 20);
            lblTamaño.TabIndex = 1;
            lblTamaño.Text = "25 onz";
            // 
            // lblPrecio
            // 
            lblPrecio.AutoSize = true;
            lblPrecio.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrecio.ForeColor = Color.LimeGreen;
            lblPrecio.Location = new Point(27, 80);
            lblPrecio.Name = "lblPrecio";
            lblPrecio.Size = new Size(104, 23);
            lblPrecio.TabIndex = 2;
            lblPrecio.Text = "C$ 150.00";
            // 
            // CardPlatillo
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(lblPrecio);
            Controls.Add(lblTamaño);
            Controls.Add(lblTipo);
            Name = "CardPlatillo";
            Size = new Size(158, 118);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTipo;
        private Label lblTamaño;
        private Label lblPrecio;
    }
}
