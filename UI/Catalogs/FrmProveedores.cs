using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmProveedores : Form
    {
        private DataTable tablaProveedores = new DataTable();
        private int proveedorSeleccionadoId = 0;

        public FrmProveedores()
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

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarFormulario();
            ConfigurarGrid(dgvProveedores);
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

        private void ConfigurarFormulario()
        {
            txtCedulaRuc.MaxLength = 20;
            txtNombreProveedor.MaxLength = 50;
            txtApellidoProveedor.MaxLength = 50;
            txtTelefono.MaxLength = 20;
            txtCorreo.MaxLength = 100;
            txtDireccion.MaxLength = 255;
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

        private void CrearTablaTemporal()
        {
            tablaProveedores.Columns.Add("Supplier_Id", typeof(int));
            tablaProveedores.Columns.Add("Tax_Id", typeof(string));
            tablaProveedores.Columns.Add("First_Name", typeof(string));
            tablaProveedores.Columns.Add("Last_Name", typeof(string));
            tablaProveedores.Columns.Add("Phone", typeof(string));
            tablaProveedores.Columns.Add("Email", typeof(string));
            tablaProveedores.Columns.Add("Address", typeof(string));
            tablaProveedores.Columns.Add("Enable", typeof(bool));
        }

        private void CargarDatosTemporales()
        {
            tablaProveedores.Rows.Add(1, "001-010101-0001A", "Carlos", "Mendoza", "8888-1111", "carlos@proveedor.com", "Mercado Oriental", true);
            tablaProveedores.Rows.Add(2, "J0310000000001", "Mariscos", "Del Pacifico", "8888-2222", "ventas@pacifico.com", "Corinto", true);
            dgvProveedores.DataSource = tablaProveedores;
            OcultarColumnasTecnicas();
        }

        private void OcultarColumnasTecnicas()
        {
            if (dgvProveedores.Columns["Supplier_Id"] != null) dgvProveedores.Columns["Supplier_Id"].Visible = false;
            if (dgvProveedores.Columns["Enable"] != null) dgvProveedores.Columns["Enable"].Visible = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarProveedor()) return;

            int nuevoId = tablaProveedores.Rows.Count == 0 ? 1 : tablaProveedores.AsEnumerable().Max(r => r.Field<int>("Supplier_Id")) + 1;
            tablaProveedores.Rows.Add(nuevoId, txtCedulaRuc.Text.Trim(), txtNombreProveedor.Text.Trim(), txtApellidoProveedor.Text.Trim(), txtTelefono.Text.Trim(), txtCorreo.Text.Trim(), txtDireccion.Text.Trim(), true);
            LimpiarFormulario();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionadoId == 0)
            {
                MessageBox.Show("Selecciona un proveedor para modificar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarProveedor()) return;

            DataRow fila = tablaProveedores.AsEnumerable().First(r => r.Field<int>("Supplier_Id") == proveedorSeleccionadoId);
            fila["Tax_Id"] = txtCedulaRuc.Text.Trim();
            fila["First_Name"] = txtNombreProveedor.Text.Trim();
            fila["Last_Name"] = txtApellidoProveedor.Text.Trim();
            fila["Phone"] = txtTelefono.Text.Trim();
            fila["Email"] = txtCorreo.Text.Trim();
            fila["Address"] = txtDireccion.Text.Trim();
            LimpiarFormulario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (proveedorSeleccionadoId == 0)
            {
                MessageBox.Show("Selecciona un proveedor para inactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRow fila = tablaProveedores.AsEnumerable().First(r => r.Field<int>("Supplier_Id") == proveedorSeleccionadoId);
            fila["Enable"] = false;
            LimpiarFormulario();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvProveedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvProveedores.Rows[e.RowIndex];
            proveedorSeleccionadoId = Convert.ToInt32(row.Cells["Supplier_Id"].Value);
            txtCedulaRuc.Text = row.Cells["Tax_Id"].Value.ToString();
            txtNombreProveedor.Text = row.Cells["First_Name"].Value.ToString();
            txtApellidoProveedor.Text = row.Cells["Last_Name"].Value.ToString();
            txtTelefono.Text = row.Cells["Phone"].Value.ToString();
            txtCorreo.Text = row.Cells["Email"].Value.ToString();
            txtDireccion.Text = row.Cells["Address"].Value.ToString();
        }

        private void txtBuscarProveedor_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscarProveedor.Text.Trim().Replace("'", "''");
            tablaProveedores.DefaultView.RowFilter =
                $"Enable = true AND (Tax_Id LIKE '%{filtro}%' OR First_Name LIKE '%{filtro}%' OR Last_Name LIKE '%{filtro}%')";
        }

        private bool ValidarProveedor()
        {
            if (string.IsNullOrWhiteSpace(txtCedulaRuc.Text) ||
                string.IsNullOrWhiteSpace(txtNombreProveedor.Text) ||
                string.IsNullOrWhiteSpace(txtApellidoProveedor.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) ||
                string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Completa los datos obligatorios del proveedor.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!txtCorreo.Text.Contains("@"))
            {
                MessageBox.Show("Ingresa un correo electronico valido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            proveedorSeleccionadoId = 0;
            txtCedulaRuc.Clear();
            txtNombreProveedor.Clear();
            txtApellidoProveedor.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtDireccion.Clear();
            txtBuscarProveedor.Clear();
            tablaProveedores.DefaultView.RowFilter = "Enable = true";
            txtCedulaRuc.Focus();
        }
    }
}
