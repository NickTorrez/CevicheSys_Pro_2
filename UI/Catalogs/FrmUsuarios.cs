    using CevicheSys_Pro_2.Services.BusinessLogic;
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
            #region Propiedades y Referencias
            private readonly UserBusiness _userBusiness;
            private int _usuarioSeleccionadoId = 0;
            #endregion

            #region Cnstructor y Load
            public FrmUsuarios()
            {
                InitializeComponent();
                _userBusiness = new UserBusiness(); // Instancia de la capa de negocio
            }


            private void FrmUsuarios_Load(object sender, EventArgs e)
            {
                ConfigurarFormulario();
                ConfigurarGrid();
                CargarUsuarios();
                LimpiarCampos();
            }

            #endregion

            #region Configuraciones Visuales y Comportamientos
            private void ConfigurarFormulario()
            {
                txtUsername.MaxLength = 50;
                txtPassword.MaxLength = 255;
                txtPassword.UseSystemPasswordChar = true;

                cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
                cmbRol.Items.Clear();
                cmbRol.Items.AddRange(new object[] { "Admin", "Vendedor" });
                cmbRol.SelectedIndex = 1;

                // Suscripción manual a eventos de diseño
                txtUsername.Enter += InputControl_Enter;
                txtUsername.Leave += InputControl_Leave;
                txtPassword.Enter += InputControl_Enter;
                txtPassword.Leave += InputControl_Leave;
                txtBuscarUsuario.Enter += InputControl_Enter;
                txtBuscarUsuario.Leave += InputControl_Leave;
            }

            private void ConfigurarGrid()
            {
                dgvUsuarios.ReadOnly = true;
                dgvUsuarios.AllowUserToAddRows = false;
                dgvUsuarios.AllowUserToDeleteRows = false;
                dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsuarios.MultiSelect = false;
                dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvUsuarios.BackgroundColor = Color.White;
                dgvUsuarios.BorderStyle = BorderStyle.None;
                dgvUsuarios.RowHeadersVisible = false;
                dgvUsuarios.EnableHeadersVisualStyles = false;
                dgvUsuarios.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 91, 150);
                dgvUsuarios.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvUsuarios.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 247, 250);

                // Asignación de propiedades para DataBinding
                dgvUsuarios.AutoGenerateColumns = false;
                dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "User_Id", DataPropertyName = "User_Id", Visible = false });
                dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", DataPropertyName = "Username", HeaderText = "Nombre de Usuario" });
                dgvUsuarios.Columns.Add(new DataGridViewTextBoxColumn { Name = "Role", DataPropertyName = "Role", HeaderText = "Rol de Sistema" });
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

            #endregion

            #region Métodos de Procesamiento
            private void CargarUsuarios()
            {
                try
                {
                    // Ahora se recibe directamente un DataTable desde SQL
                    dgvUsuarios.DataSource = _userBusiness.ListUsers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al cargar usuarios:\n{ex.Message}", "Fallo de Lectura", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            private void LimpiarCampos()
            {
                _usuarioSeleccionadoId = 0;
                txtUsername.Clear();
                txtPassword.Clear();
                cmbRol.SelectedIndex = 1;
                txtBuscarUsuario.Clear();
                txtUsername.Focus();
            }

            
            #endregion

            #region Eventos de Botones
            private void btnGuardarUsuario_Click(object sender, EventArgs e)
            {
                try
                {
                    Users newUser = new Users
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Text,
                        Role = cmbRol.SelectedItem?.ToString() ?? ""
                    };

                    _userBusiness.InsertUser(newUser); // Si falla, salta directo al catch

                    MessageBox.Show("Usuario registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void btnBajaUsuario_Click(object sender, EventArgs e)
            {
                try
                {
                    if (MessageBox.Show($"¿Desea dar de baja permanentemente al usuario '{txtUsername.Text}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        _userBusiness.DeleteUser(_usuarioSeleccionadoId);

                        MessageBox.Show("Usuario dado de baja exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarUsuarios();
                        LimpiarCampos();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                _usuarioSeleccionadoId = Convert.ToInt32(dgvUsuarios.Rows[e.RowIndex].Cells["User_Id"].Value);
                txtUsername.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                cmbRol.SelectedItem = dgvUsuarios.Rows[e.RowIndex].Cells["Role"].Value.ToString();
            }

            private void btnVerPassword_Click(object sender, EventArgs e)
            {
                txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;
            }

            private void btnLimpiarUsuario_Click(object sender, EventArgs e)
            {
                LimpiarCampos();
            }

            private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
            {

            }

            private void txtBuscarUsuario_TextChanged(object sender, EventArgs e)
            {
                // Filtro nativo usando DataTable
                if (dgvUsuarios.DataSource is DataTable dt)
                {
                    string filtro = txtBuscarUsuario.Text.Trim().Replace("'", "''");
                    dt.DefaultView.RowFilter = string.IsNullOrWhiteSpace(filtro) ? "" : $"Username LIKE '%{filtro}%'";
                }
            }
            


            private void btnEditarUsuario_Click(object sender, EventArgs e)
            {
                try
                {
                    Users editUser = new Users
                    {
                        User_Id = _usuarioSeleccionadoId,
                        Username = txtUsername.Text,
                        // La contraseña no se actualiza desde aquí por seguridad en este ejemplo
                        Role = cmbRol.SelectedItem?.ToString() ?? ""
                    };

                    _userBusiness.UpdateUser(editUser);

                    MessageBox.Show("Usuario modificado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarUsuarios();
                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Validación del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            #endregion
        }
    }
