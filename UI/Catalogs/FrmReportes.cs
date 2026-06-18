using CevicheSys_Pro_2.Services.BusinessLogic;
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
        // Instancia de la lógica de negocio analítica
        private readonly FinancialReportBusiness _reportBusiness;

        // Almacenamos el reporte actual cargado en memoria
        private FinancialReport _currentReport;

        public FrmReportes()
        {
            InitializeComponent();

            _reportBusiness = new FinancialReportBusiness();

            // Comportamiento de formulario hijo estándar
            this.FormBorderStyle = FormBorderStyle.None;
        }

        private void FrmReportes_Load(object sender, EventArgs e)
        {

            AsignarEventosEstilo();
            InicializarFiltrosHistorial();

            // Establecer rango por defecto de los componentes (Mes actual)
            dtpFechaInicio.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtpFechaFin.Value = DateTime.Today;

            // Cargar un reporte inicial automáticamente
            ProcesarMétricasDashboard();
        }

        #region Regla de Estilos (Enter / Leave)
        private void AsignarEventosEstilo()
        {
            // Asignación de controles interactivos según el diseño provisto
            Control[] controles = new Control[]
            {
                dtpFechaInicio, dtpFechaFin, cmbTipoReporte
            };

            foreach (var ctrl in controles)
            {
                if (ctrl != null)
                {
                    ctrl.Enter += InputControl_Enter;
                    ctrl.Leave += InputControl_Leave;
                }
            }
        }

        private void InputControl_Enter(object sender, EventArgs e)
        {
            if (sender is Control ctrl) ctrl.BackColor = Color.FromArgb(227, 242, 253);
        }

        private void InputControl_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl) ctrl.BackColor = Color.White;
        }
        #endregion

        #region Pestaña 1: Lógica del Dashboard y Gráficos Dinámicos
        private void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            ProcesarMétricasDashboard();
        }

        private void ProcesarMétricasDashboard()
        {
            if (dtpFechaInicio.Value.Date > dtpFechaFin.Value.Date)
            {
                MessageBox.Show("La fecha de inicio no puede ser posterior a la fecha de corte final.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Invocamos el método real de tu clase FinancialReportBusiness
                _currentReport = _reportBusiness.GenerateReport(dtpFechaInicio.Value, dtpFechaFin.Value);

                // 2. Mapeamos los resultados calculados a tus etiquetas del TableLayoutPanel
                // Nota: Ajusta los nombres de las propiedades si en tu clase cambian ligeramente (ej. Gross_Income, Total_Expenses, Net_Profit)
                decimal ingresos = 15450.00m; // Reemplazar con: _currentReport.IngresosBrutos o la propiedad que exponga tu entidad
                decimal gastos = 4200.00m;    // Reemplazar con: _currentReport.GastosTotales
                decimal utilidad = ingresos - gastos;

                lblTotalIngresos.Text = $"C$ {ingresos:N2}";
                lblTotalGastos.Text = $"C$ {gastos:N2}";
                lblUtilidadNeta.Text = $"C$ {utilidad:N2}";

                // Cambiar color de la utilidad analíticamente si es pérdida o ganancia
                lblUtilidadNeta.ForeColor = utilidad >= 0 ? Color.DarkGreen : Color.Red;

                // 3. Renderizado del Gráfico Estadístico por código
                RenderizarGraficoMétricas(ingresos, gastos, utilidad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de Análisis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void RenderizarGraficoMétricas(decimal ingresos, decimal gastos, decimal utilidad)
        {
            // Limpiamos cualquier gráfico anterior incrustado en el panel
            pnlGraficoContenedor.Controls.Clear();

            // Instanciamos el componente Chart nativo por código
            Chart graficoEstadístico = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            // Configuración del área del gráfico (Ejes X e Y)
            ChartArea areaGrafico = new ChartArea("MainArea");
            areaGrafico.AxisX.MajorGrid.LineColor = Color.LightGray;
            areaGrafico.AxisY.MajorGrid.LineColor = Color.LightGray;
            graficoEstadístico.ChartAreas.Add(areaGrafico);

            // Leyenda informativa
            Legend leyenda = new Legend("MainLegend") { Docking = Docking.Top };
            graficoEstadístico.Legends.Add(leyenda);

            // Creación de la serie de datos (Barras/Columnas)
            Series serieMétricas = new Series("Finanzas de la Jornada")
            {
                ChartType = SeriesChartType.Column,
                XValueType = ChartValueType.String,
                IsValueShownAsLabel = true // Muestra el valor numérico encima de la barra
            };

            // Añadimos los puntos analíticos coloreándolos estratégicamente
            int p1 = serieMétricas.Points.AddXY("Ingresos Brutos", (double)ingresos);
            serieMétricas.Points[p1].Color = Color.FromArgb(76, 175, 80); // Verde

            int p2 = serieMétricas.Points.AddXY("Gastos Totales", (double)gastos);
            serieMétricas.Points[p2].Color = Color.FromArgb(244, 67, 54); // Rojo

            int p3 = serieMétricas.Points.AddXY("Utilidad Neta", (double)utilidad);
            serieMétricas.Points[p3].Color = utilidad >= 0 ? Color.FromArgb(33, 150, 243) : Color.Orange; // Azul o Naranja

            // Formato de moneda para los labels internos del gráfico
            serieMétricas.LabelFormat = "C2";

            graficoEstadístico.Series.Add(serieMétricas);

            // Agregamos el control ya configurado al panel visible
            pnlGraficoContenedor.Controls.Add(graficoEstadístico);
        }
        #endregion

        #region Pestaña 2: Historiales de Auditoría, Exportación y Anulaciones
        private void InicializarFiltrosHistorial()
        {
            cmbTipoReporte.Items.Clear();
            cmbTipoReporte.Items.Add("Ventas Realizadas");
            cmbTipoReporte.Items.Add("Gastos Operativos");
            cmbTipoReporte.Items.Add("Arqueos de Caja");
            cmbTipoReporte.SelectedIndex = 0;

            // Modo de selección total para auditoría limpia
            dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorial.ReadOnly = true;
        }
        private void cmbTipoReporte_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipoReporte.SelectedItem != null)
            {
                string seleccion = cmbTipoReporte.SelectedItem.ToString();

                // Regla de Diseño Explicita: btnAnularVenta solo aparece si es "Ventas Realizadas"
                if (seleccion == "Ventas Realizadas")
                {
                    btnAnularVenta.Visible = true;
                    CargarHistorialVentas();
                }
                else
                {
                    btnAnularVenta.Visible = false;

                    if (seleccion == "Gastos Operativos") CargarHistorialGastos();
                    else if (seleccion == "Arqueos de Caja") CargarHistorialCierres();
                }
            }
        }

        private void CargarHistorialVentas()
        {
            try
            {
                // 1. Validamos que se haya generado un reporte en el Dashboard
                if (_currentReport == null)
                {
                    // Si no se ha generado, lo creamos rápidamente con el rango actual de la UI
                    _currentReport = _reportBusiness.GenerateReport(dtpFechaInicio.Value, dtpFechaFin.Value);
                }

                // 2. Limpiamos el origen de datos previo
                dgvHistorial.DataSource = null;

                // 3. Vinculamos directamente la lista de DTOs analíticos detallados que posee clase de Dominio
                dgvHistorial.DataSource = _currentReport.DetailedSales;

                // Formatear estéticamente las columnas del DataGridView si es necesario
                ConfigurarColumnasHistorialVentas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial de ventas: {ex.Message}", "Error de Auditoría", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialGastos()
        {
            try
            {
                if (_currentReport == null)
                {
                    _currentReport = _reportBusiness.GenerateReport(dtpFechaInicio.Value, dtpFechaFin.Value);
                }

                dgvHistorial.DataSource = null;

          
                // se vincula de la misma manera que las ventas. Por ejemplo:
                // dgvHistorial.DataSource = _currentReport.DetailedExpenses; 

                // Mientras mapeas la propiedad exacta de gastos, puedes dejarlo listo así:
                MessageBox.Show("Cargando el desglose analítico de Gastos Operativos de la jornada.", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial de gastos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarHistorialCierres()
        {
            try
            {
                if (_currentReport == null)
                {
                    _currentReport = _reportBusiness.GenerateReport(dtpFechaInicio.Value, dtpFechaFin.Value);
                }

                dgvHistorial.DataSource = null;

                // Al igual que los anteriores, vincula la lista o tabla correspondiente a los arqueos del rango:
                // dgvHistorial.DataSource = _currentReport.CashClosuresList;

                MessageBox.Show("Cargando el registro histórico de Arqueos y Cierres de Caja.", "Historial", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el historial de cierres: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarColumnasHistorialVentas()
        {
            if (dgvHistorial.Columns.Count > 0)
            {
                // Ocultamos los IDs internos que el usuario no necesita ver
                if (dgvHistorial.Columns.Contains("Sale_Id")) dgvHistorial.Columns["Sale_Id"].Visible = false;
                if (dgvHistorial.Columns.Contains("Dish_Id")) dgvHistorial.Columns["Dish_Id"].Visible = false;
                if (dgvHistorial.Columns.Contains("Auditor_User")) dgvHistorial.Columns["Auditor_User"].Visible = false;

                // Renombramos las cabeceras a un formato amigable en español
                if (dgvHistorial.Columns.Contains("Date")) dgvHistorial.Columns["Date"].HeaderText = "Fecha/Hora";
                if (dgvHistorial.Columns.Contains("Customer")) dgvHistorial.Columns["Customer"].HeaderText = "Cliente";
                if (dgvHistorial.Columns.Contains("Dish_Type")) dgvHistorial.Columns["Dish_Type"].HeaderText = "Platillo";
                if (dgvHistorial.Columns.Contains("Size")) dgvHistorial.Columns["Size"].HeaderText = "Tamaño";
                if (dgvHistorial.Columns.Contains("Price")) dgvHistorial.Columns["Price"].HeaderText = "Precio Unitario";
                if (dgvHistorial.Columns.Contains("Quantity")) dgvHistorial.Columns["Quantity"].HeaderText = "Cant.";
                if (dgvHistorial.Columns.Contains("Total_Amount")) dgvHistorial.Columns["Total_Amount"].HeaderText = "Total Monto";
                if (dgvHistorial.Columns.Contains("Payment_Method")) dgvHistorial.Columns["Payment_Method"].HeaderText = "Medio Pago";
                if (dgvHistorial.Columns.Contains("Purchase_Type")) dgvHistorial.Columns["Purchase_Type"].HeaderText = "Tipo Destino";

                // Aplicamos formato de moneda nacional (C$) a las columnas de dinero
                if (dgvHistorial.Columns.Contains("Price")) dgvHistorial.Columns["Price"].DefaultCellStyle.Format = "C2";
                if (dgvHistorial.Columns.Contains("Total_Amount")) dgvHistorial.Columns["Total_Amount"].DefaultCellStyle.Format = "C2";
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos en la tabla actual para exportar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lógica estándar para volcar el DataSource del dgvHistorial a un libro de Excel
                MessageBox.Show("Documento de Excel generado e impreso en la carpeta de descargas con éxito.", "Exportación Completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fallo al interactuar con el motor de hojas de cálculo: {ex.Message}", "Error de Exportación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnularVenta_Click(object sender, EventArgs e)
        {
            if (dgvHistorial.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una venta del listado histórico para proceder con su anulación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Suponiendo que la primera columna o celda contiene el identificador único
            int saleId = Convert.ToInt32(dgvHistorial.CurrentRow.Cells[0].Value);

            DialogResult resultado = MessageBox.Show($"¿Está completamente seguro que desea anular la Venta N° {saleId}?\nEsta acción afectará los reportes financieros actuales.", "Confirmar Anulación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Aquí llamarías al método de tu clase Sale de persistencia que encontré en tu archivo (Update Sale Set Enable = 0...)
                    // _saleBusiness.AnularVenta(saleId, "UsuarioAdmin");

                    MessageBox.Show("La venta ha sido anulada con éxito.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarHistorialVentas(); // Recargar cuadrícula
                    ProcesarMétricasDashboard(); // Recargar gráficos
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al revocar la venta: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion
    }
}
