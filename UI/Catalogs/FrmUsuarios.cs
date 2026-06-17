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
    public partial class FrmUsuarios : Form
    {
        private DataTable tablaUsuarios = new DataTable();
        private int usuarioSeleccionadoId = 0;

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void InputControl_Enter(object sender, EventArgs e)
        {
            // Evaluamos si el elemento es un control válido
            if (sender is Control ctrl)
            {
                // Cambia a celeste claro marino al entrar
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void InputControl_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                // Regresa a blanco al salir
                ctrl.BackColor = Color.White;
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            txtUsername.MaxLength = 50;
            txtPassword.MaxLength = 255;
            txtPassword.UseSystemPasswordChar = true;

            cmbRol.Items.Clear();
            cmbRol.Items.AddRange(new object[] { "Admin", "Vendedor" });
            cmbRol.SelectedIndex = 1;

            ConfigurarGrid(dgvUsuarios);
            CrearTablaTemporal();
            CargarDatosTemporales();
            LimpiarFormulario();
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
            tablaUsuarios.Columns.Add("User_Id", typeof(int));
            tablaUsuarios.Columns.Add("Username", typeof(string));
            tablaUsuarios.Columns.Add("Role", typeof(string));
            tablaUsuarios.Columns.Add("Enable", typeof(bool));
        }

        private void CargarDatosTemporales()
        {
            tablaUsuarios.Rows.Add(1, "admin", "Admin", true);
            tablaUsuarios.Rows.Add(2, "cajero", "Vendedor", true);
            dgvUsuarios.DataSource = tablaUsuarios;
            if (dgvUsuarios.Columns["User_Id"] != null) dgvUsuarios.Columns["User_Id"].Visible = false;
            if (dgvUsuarios.Columns["Enable"] != null) dgvUsuarios.Columns["Enable"].Visible = false;
        }

        private void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            if (!ValidarUsuario()) return;

            if (usuarioSeleccionadoId == 0)
            {
                int id = tablaUsuarios.Rows.Count == 0 ? 1 : tablaUsuarios.AsEnumerable().Max(r => r.Field<int>("User_Id")) + 1;
                tablaUsuarios.Rows.Add(id, txtUsername.Text.Trim(), cmbRol.Text, true);
            }
            else
            {
                DataRow fila = tablaUsuarios.AsEnumerable().First(r => r.Field<int>("User_Id") == usuarioSeleccionadoId);
                fila["Username"] = txtUsername.Text.Trim();
                fila["Role"] = cmbRol.Text;
            }

            LimpiarFormulario();
        }

        private void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            if (usuarioSeleccionadoId == 0)
            {
                MessageBox.Show("Selecciona un usuario para inactivar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            tablaUsuarios.AsEnumerable().First(r => r.Field<int>("User_Id") == usuarioSeleccionadoId)["Enable"] = false;
            LimpiarFormulario();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
            usuarioSeleccionadoId = Convert.ToInt32(row.Cells["User_Id"].Value);
            txtUsername.Text = row.Cells["Username"].Value.ToString();
            cmbRol.Text = row.Cells["Role"].Value.ToString();
            txtPassword.Clear();
        }

        private void btnVerPassword_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
        }

        private bool ValidarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Ingresa el nombre de usuario.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (usuarioSeleccionadoId == 0 && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingresa una contrasena para el nuevo usuario.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool duplicado = tablaUsuarios.AsEnumerable().Any(r =>
                r.Field<bool>("Enable") &&
                r.Field<int>("User_Id") != usuarioSeleccionadoId &&
                r.Field<string>("Username").Equals(txtUsername.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (duplicado)
            {
                MessageBox.Show("Ya existe un usuario con ese nombre.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void LimpiarFormulario()
        {
            usuarioSeleccionadoId = 0;
            txtUsername.Clear();
            txtPassword.Clear();
            cmbRol.SelectedIndex = cmbRol.Items.Count > 0 ? 1 : -1;
            tablaUsuarios.DefaultView.RowFilter = "Enable = true";
            txtUsername.Focus();
        }

        private void btnLimpiarUsuario_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
