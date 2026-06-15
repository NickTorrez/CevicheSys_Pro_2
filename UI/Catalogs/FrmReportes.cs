using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmReportes : Form
    {
        private Chart chartFinanciero;
        private readonly CultureInfo culturaNicaragua = new CultureInfo("es-NI");

        public FrmReportes()
        {
            InitializeComponent();
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

            ConfigurarFechas();
            ConfigurarComboReportes();
            ConfigurarGridHistorial();
            CrearGraficoFinanciero();
            CargarDashboardSimulado();

        }

        private void ConfigurarFechas()
        {
            dtpFechaInicio.Value = DateTime.Today.AddDays(-7);
            dtpFechaFin.Value = DateTime.Today;
        }

        private void ConfigurarComboReportes()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Ventas Realizadas");
            cmbTipoReporte.Items.Add("Gastos Operativos");
            cmbTipoReporte.Items.Add("Cierres de Caja");
            cmbTipoReporte.SelectedIndex = 0;
        }

        private void ConfigurarGridHistorial()
        {
            dgvHistorial.ReadOnly = true;
            dgvHistorial.AllowUserToAddRows = false;
            dgvHistorial.AllowUserToDeleteRows = false;
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.MultiSelect = false;
            dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistorial.BackgroundColor = Color.White;
            dgvHistorial.BorderStyle = BorderStyle.None;
            dgvHistorial.RowHeadersVisible = false;
        }

        private void CrearGraficoFinanciero()
        {
            pnlGraficoContenedor.Controls.Clear();

            chartFinanciero = new Chart();
            chartFinanciero.Dock = DockStyle.Fill;
            chartFinanciero.BackColor = Color.White;

            ChartArea area = new ChartArea("AreaPrincipal");
            area.BackColor = Color.White;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.LineColor = Color.Gainsboro;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Font = new Font("Segoe UI", 9F);
            area.AxisY.LabelStyle.Format = "C0";
            area.AxisY.LabelStyle.Format = "C$ #,##0";

            chartFinanciero.ChartAreas.Add(area);

            Series serieVentas = new Series("Ventas");
            serieVentas.ChartType = SeriesChartType.Column;
            serieVentas.Color = Color.FromArgb(0, 91, 150);
            serieVentas.IsValueShownAsLabel = true;
            serieVentas.LabelFormat = "C$ #,##0";
            serieVentas.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            chartFinanciero.Series.Add(serieVentas);

            Legend leyenda = new Legend();
            leyenda.Docking = Docking.Top;
            leyenda.Font = new Font("Segoe UI", 9F);
            chartFinanciero.Legends.Add(leyenda);

            pnlGraficoContenedor.Controls.Add(chartFinanciero);
        }

        private void CargarDashboardSimulado()
        {
            decimal totalIngresos = 25100m;
            decimal totalGastos = 8700m;
            decimal utilidadNeta = totalIngresos - totalGastos;

            lblTotalIngresos.Text = totalIngresos.ToString("C2", culturaNicaragua);
            lblTotalGastos.Text = totalGastos.ToString("C2", culturaNicaragua);
            lblUtilidadNeta.Text = utilidadNeta.ToString("C2", culturaNicaragua);

            CargarGraficoSimulado();
            CargarHistorialSimulado();
        }

        private void CargarGraficoSimulado()
        {
            Series serie = chartFinanciero.Series["Ventas"];
            serie.Points.Clear();

            serie.Points.AddXY("Lunes", 4500);
            serie.Points.AddXY("Martes", 3200);
            serie.Points.AddXY("Miercoles", 5100);
            serie.Points.AddXY("Jueves", 4800);
            serie.Points.AddXY("Viernes", 7500);
        }

        private void CargarHistorialSimulado()
        {
            DataTable tabla = new DataTable();
            tabla.Columns.Add("Fecha", typeof(DateTime));
            tabla.Columns.Add("Tipo", typeof(string));
            tabla.Columns.Add("Concepto", typeof(string));
            tabla.Columns.Add("Monto", typeof(decimal));

            tabla.Rows.Add(DateTime.Today.AddDays(-4), "Venta", "Venta en efectivo", 4500m);
            tabla.Rows.Add(DateTime.Today.AddDays(-3), "Venta", "Venta por transferencia", 3200m);
            tabla.Rows.Add(DateTime.Today.AddDays(-2), "Gasto", "Compra de pescado", 2700m);
            tabla.Rows.Add(DateTime.Today.AddDays(-1), "Venta", "Venta general", 5100m);
            tabla.Rows.Add(DateTime.Today, "Gasto", "Pago de servicios", 1200m);

            dgvHistorial.DataSource = tabla;

            if (dgvHistorial.Columns["Monto"] != null)
            {
                dgvHistorial.Columns["Monto"].DefaultCellStyle.Format = "C2";
                dgvHistorial.Columns["Monto"].DefaultCellStyle.FormatProvider = culturaNicaragua;
                dgvHistorial.Columns["Monto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (dgvHistorial.Columns["Fecha"] != null)
            {
                dgvHistorial.Columns["Fecha"].DefaultCellStyle.Format = "dd/MM/yyyy";
            }
        }

        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                MessageBox.Show(
                    "La fecha inicial no puede ser mayor que la fecha final.",
                    "Rango de fechas invalido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            CargarDashboardSimulado();
        }

        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarHistorialSimulado();
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "La exportacion se conectara cuando terminemos la capa BusinessLogic.",
                "Modulo en preparacion",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}
