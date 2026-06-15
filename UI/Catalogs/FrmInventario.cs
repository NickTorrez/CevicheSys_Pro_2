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

    public partial class FrmInventario : Form
    {
        private DataTable tablaProductos = new DataTable();
        private DataTable tablaPlatillos = new DataTable();
        private int productoSeleccionadoId = 0;
        private int platilloSeleccionadoId = 0;
        private readonly CultureInfo cultura = new CultureInfo("es-NI");

        public FrmInventario()
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

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            ConfigurarGrid(dgvInventario);
            ConfigurarGrid(dgvPlatillos);
            CrearTablasTemporales();
            CargarCombosTemporales();
            CargarDatosTemporales();
            LimpiarProducto();
            LimpiarPlatillo();
        }

        private void SoloNumerosYDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && sender is TextBox txt && txt.Text.Contains("."))
                e.Handled = true;
        }

        private void ConfigurarFormulario()
        {
            txtNombreProducto.MaxLength = 100;
            txtStockActual.MaxLength = 12;
            txtTipoPlatillo.MaxLength = 50;
            txtTamano.MaxLength = 30;
            txtPrecio.MaxLength = 12;
            txtStockActual.KeyPress += SoloNumerosYDecimales_KeyPress;
            txtPrecio.KeyPress += SoloNumerosYDecimales_KeyPress;
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

        private void CrearTablasTemporales()
        {
            tablaProductos.Columns.Add("Product_Id", typeof(int));
            tablaProductos.Columns.Add("Product_Name", typeof(string));
            tablaProductos.Columns.Add("Category_Name", typeof(string));
            tablaProductos.Columns.Add("Supplier_Name", typeof(string));
            tablaProductos.Columns.Add("Current_Stock", typeof(decimal));
            tablaProductos.Columns.Add("Expiration_Date", typeof(DateTime));
            tablaProductos.Columns.Add("Enable", typeof(bool));

            tablaPlatillos.Columns.Add("Dish_Id", typeof(int));
            tablaPlatillos.Columns.Add("Dish_Type", typeof(string));
            tablaPlatillos.Columns.Add("Size", typeof(string));
            tablaPlatillos.Columns.Add("Price", typeof(decimal));
            tablaPlatillos.Columns.Add("Is_Available", typeof(bool));
            tablaPlatillos.Columns.Add("Enable", typeof(bool));
        }

        private void CargarCombosTemporales()
        {
            cmbCategoria.Items.Clear();
            cmbCategoria.Items.AddRange(new object[] { "Insumo", "Bebida", "Empaque" });
            cmbCategoria.SelectedIndex = 0;

            cmbProveedor.Items.Clear();
            cmbProveedor.Items.AddRange(new object[] { "Carlos Mendoza", "Mariscos Del Pacifico" });
            cmbProveedor.SelectedIndex = 0;
        }

        private void CargarDatosTemporales()
        {
            tablaProductos.Rows.Add(1, "Camaron", "Insumo", "Carlos Mendoza", 25.5m, DateTime.Today.AddDays(10), true);
            tablaProductos.Rows.Add(2, "Pescado", "Insumo", "Mariscos Del Pacifico", 40m, DateTime.Today.AddDays(7), true);
            dgvInventario.DataSource = tablaProductos;

            tablaPlatillos.Rows.Add(1, "Ceviche de Camaron", "12 oz", 180m, true, true);
            tablaPlatillos.Rows.Add(2, "Ceviche Mixto", "Familiar", 420m, true, true);
            dgvPlatillos.DataSource = tablaPlatillos;

            OcultarColumnasTecnicas();
        }

        private void OcultarColumnasTecnicas()
        {
            if (dgvInventario.Columns["Product_Id"] != null) dgvInventario.Columns["Product_Id"].Visible = false;
            if (dgvInventario.Columns["Enable"] != null) dgvInventario.Columns["Enable"].Visible = false;
            if (dgvPlatillos.Columns["Dish_Id"] != null) dgvPlatillos.Columns["Dish_Id"].Visible = false;
            if (dgvPlatillos.Columns["Enable"] != null) dgvPlatillos.Columns["Enable"].Visible = false;
            if (dgvPlatillos.Columns["Price"] != null) dgvPlatillos.Columns["Price"].DefaultCellStyle.Format = "C2";
        }

        private void btnGuardarPlatillo_Click(object sender, EventArgs e)
        {
            if (!ValidarPlatillo()) return;
            int id = tablaPlatillos.Rows.Count == 0 ? 1 : tablaPlatillos.AsEnumerable().Max(r => r.Field<int>("Dish_Id")) + 1;
            tablaPlatillos.Rows.Add(id, txtTipoPlatillo.Text.Trim(), txtTamano.Text.Trim(), decimal.Parse(txtPrecio.Text, cultura), chkDisponible.Checked, true);
            LimpiarPlatillo();
        }

        private void btnGuardarProducto_Click(object sender, EventArgs e)
        {
            if (!ValidarProducto()) return;
            int id = tablaProductos.Rows.Count == 0 ? 1 : tablaProductos.AsEnumerable().Max(r => r.Field<int>("Product_Id")) + 1;
            tablaProductos.Rows.Add(id, txtNombreProducto.Text.Trim(), cmbCategoria.Text, cmbProveedor.Text, decimal.Parse(txtStockActual.Text, cultura), dtpFechaVencimiento.Value.Date, true);
            LimpiarProducto();
        }

        private void btnEditarProducto_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoId == 0) return;
            if (!ValidarProducto()) return;

            DataRow fila = tablaProductos.AsEnumerable().First(r => r.Field<int>("Product_Id") == productoSeleccionadoId);
            fila["Product_Name"] = txtNombreProducto.Text.Trim();
            fila["Category_Name"] = cmbCategoria.Text;
            fila["Supplier_Name"] = cmbProveedor.Text;
            fila["Current_Stock"] = decimal.Parse(txtStockActual.Text, cultura);
            fila["Expiration_Date"] = dtpFechaVencimiento.Value.Date;
            LimpiarProducto();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (productoSeleccionadoId == 0) return;
            tablaProductos.AsEnumerable().First(r => r.Field<int>("Product_Id") == productoSeleccionadoId)["Enable"] = false;
            LimpiarProducto();
        }

        private void dgvInventario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvInventario.Rows[e.RowIndex];
            productoSeleccionadoId = Convert.ToInt32(row.Cells["Product_Id"].Value);
            txtNombreProducto.Text = row.Cells["Product_Name"].Value.ToString();
            cmbCategoria.Text = row.Cells["Category_Name"].Value.ToString();
            cmbProveedor.Text = row.Cells["Supplier_Name"].Value.ToString();
            txtStockActual.Text = row.Cells["Current_Stock"].Value.ToString();
            dtpFechaVencimiento.Value = Convert.ToDateTime(row.Cells["Expiration_Date"].Value);
        }

        private void txtTipoPlatillo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarPlatillo_Click(object sender, EventArgs e)
        {
            if (platilloSeleccionadoId == 0) return;
            if (!ValidarPlatillo()) return;

            DataRow fila = tablaPlatillos.AsEnumerable().First(r => r.Field<int>("Dish_Id") == platilloSeleccionadoId);
            fila["Dish_Type"] = txtTipoPlatillo.Text.Trim();
            fila["Size"] = txtTamano.Text.Trim();
            fila["Price"] = decimal.Parse(txtPrecio.Text, cultura);
            fila["Is_Available"] = chkDisponible.Checked;
            LimpiarPlatillo();
        }

        private void btnEliminarPlatillo_Click(object sender, EventArgs e)
        {
            if (platilloSeleccionadoId == 0) return;
            tablaPlatillos.AsEnumerable().First(r => r.Field<int>("Dish_Id") == platilloSeleccionadoId)["Enable"] = false;
            LimpiarPlatillo();
        }

        private void dgvPlatillos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvPlatillos.Rows[e.RowIndex];
            platilloSeleccionadoId = Convert.ToInt32(row.Cells["Dish_Id"].Value);
            txtTipoPlatillo.Text = row.Cells["Dish_Type"].Value.ToString();
            txtTamano.Text = row.Cells["Size"].Value.ToString();
            txtPrecio.Text = row.Cells["Price"].Value.ToString();
            chkDisponible.Checked = Convert.ToBoolean(row.Cells["Is_Available"].Value);
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarProducto.Text.Trim().Replace("'", "''");
            tablaProductos.DefaultView.RowFilter = $"Enable = true AND Product_Name LIKE '%{filtro}%'";
        }

        private void txtBuscarPlatillo_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarPlatillo.Text.Trim().Replace("'", "''");
            tablaPlatillos.DefaultView.RowFilter = $"Enable = true AND Dish_Type LIKE '%{filtro}%'";
        }

        private bool ValidarProducto()
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtStockActual.Text))
            {
                MessageBox.Show("Completa nombre y stock del producto.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return decimal.TryParse(txtStockActual.Text, out _);
        }

        private bool ValidarPlatillo()
        {
            if (string.IsNullOrWhiteSpace(txtTipoPlatillo.Text) || string.IsNullOrWhiteSpace(txtTamano.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("Completa tipo, tamano y precio del platillo.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return decimal.TryParse(txtPrecio.Text, out _);
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarProducto();
        private void btnLimpiarPlatillo_Click(object sender, EventArgs e) => LimpiarPlatillo();

        private void LimpiarProducto()
        {
            productoSeleccionadoId = 0;
            txtNombreProducto.Clear();
            txtStockActual.Clear();
            cmbCategoria.SelectedIndex = cmbCategoria.Items.Count > 0 ? 0 : -1;
            cmbProveedor.SelectedIndex = cmbProveedor.Items.Count > 0 ? 0 : -1;
            dtpFechaVencimiento.Value = DateTime.Today;
            tablaProductos.DefaultView.RowFilter = "Enable = true";
        }

        private void LimpiarPlatillo()
        {
            platilloSeleccionadoId = 0;
            txtTipoPlatillo.Clear();
            txtTamano.Clear();
            txtPrecio.Clear();
            chkDisponible.Checked = true;
            tablaPlatillos.DefaultView.RowFilter = "Enable = true";
        }
    }

}
