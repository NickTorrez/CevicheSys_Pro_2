using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmReportes : Form
    {
        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {
            // 1. Creamos el gráfico desde cero
            Chart chartFinanciero = new Chart();
            chartFinanciero.Dock = DockStyle.Fill; // Para que llene el Panel
            chartFinanciero.BackColor = Color.White;

            // 2. Le creamos su área de dibujo (Fondo del gráfico)
            ChartArea area = new ChartArea("AreaPrincipal");
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.LineColor = Color.LightGray; // Líneas de cuadrícula suaves
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartFinanciero.ChartAreas.Add(area);

            // 3. Creamos la serie de datos (Las barras)
            Series serieVentas = new Series("Ventas");
            serieVentas.ChartType = SeriesChartType.Column; // Tipo de gráfico: Columnas/Barras
            serieVentas.Color = Color.FromArgb(0, 91, 150); // Tu color Azul Cevichería
            serieVentas.IsValueShownAsLabel = true; // Mostrar el número arriba de la barra

            // DATOS DE PRUEBA (Simulación visual para que veas que funciona)
            serieVentas.Points.AddXY("Lunes", 4500);
            serieVentas.Points.AddXY("Martes", 3200);
            serieVentas.Points.AddXY("Miércoles", 5100);
            serieVentas.Points.AddXY("Jueves", 4800);
            serieVentas.Points.AddXY("Viernes", 7500);

            // 4. Agregamos la serie al gráfico
            chartFinanciero.Series.Add(serieVentas);

            // 5. ¡EL TOQUE FINAL! Metemos el gráfico adentro del Panel de tu diseño
            pnlGraficoContenedor.Controls.Add(chartFinanciero);
        }
    }
}
