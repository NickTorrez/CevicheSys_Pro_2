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

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmGastos : Form
    {
        private DataTable tablaGastos = new DataTable();
        private int gastoSeleccionadoId = 0;
        private readonly CultureInfo cultura = new CultureInfo("es-NI");

        public FrmGastos()
        {
            InitializeComponent();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            // Evaluamos si el elemento es un control válido
            if (sender is Control ctrl)
            {
                // Cambia a celeste claro marino al entrar
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                // Regresa a blanco al salir
                ctrl.BackColor = Color.White;
            }
        }

        private void FrmGastos_Load(object sender, EventArgs e)
        {
            txtConcepto.MaxLength = 255;
            txtMonto.MaxLength = 12;
            txtMonto.KeyPress += SoloNumerosYDecimales_KeyPress;
            ConfigurarGrid(dgvGastos);
            CargarCombos();
            CrearTablaTemporal();
            CargarDatosTemporales();
            LimpiarFormulario();
        }

        private void SoloNumerosYDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && sender is TextBox txt && txt.Text.Contains("."))
                e.Handled = true;
        }

        private void ConfigurarGrid(DataGridView grid)
        {
            grid.ReadOnly = true;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 91, 150);
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);
        }


        private void CargarCombos()
        {
            cmbTipoGasto.Items.Clear();
            cmbTipoGasto.Items.AddRange(new object[] { "Compras", "Servicios Basicos", "Salarios", "Mantenimiento", "Otros" });
            cmbTipoGasto.SelectedIndex = 0;

            cmbProveedor.Items.Clear();
            cmbProveedor.Items.Add("");
            cmbProveedor.Items.Add("Carlos Mendoza");
            cmbProveedor.Items.Add("Mariscos Del Pacifico");
            cmbProveedor.SelectedIndex = 0;
        }

        private void CrearTablaTemporal()
        {
            tablaGastos.Columns.Add("Expense_Id", typeof(int));
            tablaGastos.Columns.Add("Date", typeof(DateTime));
            tablaGastos.Columns.Add("Category", typeof(string));
            tablaGastos.Columns.Add("Supplier", typeof(string));
            tablaGastos.Columns.Add("Concept", typeof(string));
            tablaGastos.Columns.Add("Amount", typeof(decimal));
            tablaGastos.Columns.Add("Enable", typeof(bool));
        }

        private void CargarDatosTemporales()
        {
            tablaGastos.Rows.Add(1, DateTime.Today, "Compras", "Carlos Mendoza", "Compra de pescado", 2700m, true);
            tablaGastos.Rows.Add(2, DateTime.Today, "Servicios Basicos", "", "Pago de energia", 1200m, true);
            dgvGastos.DataSource = tablaGastos;
            if (dgvGastos.Columns["Expense_Id"] != null) dgvGastos.Columns["Expense_Id"].Visible = false;
            if (dgvGastos.Columns["Enable"] != null) dgvGastos.Columns["Enable"].Visible = false;
            if (dgvGastos.Columns["Amount"] != null) dgvGastos.Columns["Amount"].DefaultCellStyle.Format = "C2";
        }

        private void btnGuardarEgreso_Click(object sender, EventArgs e)
        {
            if (!ValidarGasto()) return;
            int id = tablaGastos.Rows.Count == 0 ? 1 : tablaGastos.AsEnumerable().Max(r => r.Field<int>("Expense_Id")) + 1;
            tablaGastos.Rows.Add(id, dtpFechaGasto.Value.Date, cmbTipoGasto.Text, cmbProveedor.Text, txtConcepto.Text.Trim(), decimal.Parse(txtMonto.Text, cultura), true);
            LimpiarFormulario();
        }

        private void btnEliminarEgreso_Click(object sender, EventArgs e)
        {
            if (gastoSeleccionadoId == 0)
            {
                MessageBox.Show("Selecciona un gasto para anular.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tablaGastos.AsEnumerable().First(r => r.Field<int>("Expense_Id") == gastoSeleccionadoId)["Enable"] = false;
            LimpiarFormulario();
        }

        private void dgvGastos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvGastos.Rows[e.RowIndex];
            gastoSeleccionadoId = Convert.ToInt32(row.Cells["Expense_Id"].Value);
            dtpFechaGasto.Value = Convert.ToDateTime(row.Cells["Date"].Value);
            cmbTipoGasto.Text = row.Cells["Category"].Value.ToString();
            cmbProveedor.Text = row.Cells["Supplier"].Value.ToString();
            txtConcepto.Text = row.Cells["Concept"].Value.ToString();
            txtMonto.Text = row.Cells["Amount"].Value.ToString();
        }

        private void btnFiltrarEgreso_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            AplicarFiltro();
        }

        private void AplicarFiltro()
        {
            string inicio = dtpInicio.Value.Date.ToString("MM/dd/yyyy");
            string fin = dtpFin.Value.Date.ToString("MM/dd/yyyy");
            tablaGastos.DefaultView.RowFilter = $"Enable = true AND Date >= #{inicio}# AND Date <= #{fin}#";
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            decimal total = tablaGastos.DefaultView.Cast<DataRowView>().Sum(r => Convert.ToDecimal(r["Amount"]));
            lblTotalGastos.Text = total.ToString("C2", cultura);
        }

        private bool ValidarGasto()
        {
            if (string.IsNullOrWhiteSpace(txtConcepto.Text) || string.IsNullOrWhiteSpace(txtMonto.Text))
            {
                MessageBox.Show("Completa concepto y monto del gasto.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("El monto debe ser mayor que cero.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbTipoGasto.Text == "Compras" && cmbProveedor.SelectedIndex <= 0)
            {
                MessageBox.Show("Para compras debes seleccionar un proveedor.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarFormulario();

        private void LimpiarFormulario()
        {
            gastoSeleccionadoId = 0;
            dtpFechaGasto.Value = DateTime.Today;
            dtpInicio.Value = DateTime.Today.AddDays(-7);
            dtpFin.Value = DateTime.Today;
            cmbTipoGasto.SelectedIndex = cmbTipoGasto.Items.Count > 0 ? 0 : -1;
            cmbProveedor.SelectedIndex = cmbProveedor.Items.Count > 0 ? 0 : -1;
            txtConcepto.Clear();
            txtMonto.Clear();
            AplicarFiltro();
        }

        private void btnLimpiarEgreso_Click(object sender, EventArgs e)
        {

        }
    }
}
