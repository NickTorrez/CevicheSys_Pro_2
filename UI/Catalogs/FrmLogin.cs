using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Windows.Forms;
using CevicheSys_Pro_2.Domain;                       // Para mapear entidades en las tablas/vistas
using CevicheSys_Pro_2.Services.BusinessLogic;       // Para llamar a los controladores de negocio     
using CevicheSys_Pro_2.Helpers;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmLogin : Form
    {
        // Instancia de la capa de negocio encargada de validar las credenciales
        private readonly UserBusiness _userBusiness;

        #region Constructores y Load
        public FrmLogin()
        {
            InitializeComponent();
            _userBusiness = new UserBusiness();
            // Vinculamos el evento Resize para que responda si estiran o maximizan la ventana
            this.Resize += new EventHandler(FrmLogin_Resize);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Centrar la tarjeta al cargar por primera vez
            CentrarTarjetaLogin();

            // Aseguramos que la contraseña inicie oculta de forma nativa
            txtPassword.PasswordChar = '●';
            btnTogglePassword.Text = "👁"; // O usa el icono que prefieras

            // Asignar eventos de estilo visual a los campos de texto
            AsignarEventosEstilo();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            // Volver a centrar si la pantalla cambia de tamaño
            CentrarTarjetaLogin();

        }

        private void CentrarTarjetaLogin()
        {
            if (pnlTarjetaLogin != null && pnlRegistro != null)
            {
                pnlTarjetaLogin.Left = (pnlRegistro.Width - pnlTarjetaLogin.Width) / 2;
                pnlTarjetaLogin.Top = (pnlRegistro.Height - pnlTarjetaLogin.Height) / 2;
            }
        }

        private void AsignarEventosEstilo()
        {
            txtUsername.Enter += InputControl_Enter;
            txtUsername.Leave += InputControl_Leave;

            txtPassword.Enter += InputControl_Enter;
            txtPassword.Leave += InputControl_Leave;
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

        #region Eventos de Botones

        // LÓGICA PARA MOSTRAR / OCULTAR CONTRASEÑA
        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            // Verificamos qué carácter está usando actualmente
            if (txtPassword.PasswordChar == '●')
            {
                // Si está oculta, la mostramos. \0 significa "Carácter nulo / Ninguno"
                txtPassword.PasswordChar = '\0';
                btnTogglePassword.Text = "🔒︎";
            }
            else
            {
                // Si está visible, la volvemos a ocultar
                txtPassword.PasswordChar = '●';
                btnTogglePassword.Text = "👁";
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor, ingrese sus credenciales completas.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Users loggedInUser = _userBusiness.AuthenticateUser(username, password);

                Session.ActiveUser = loggedInUser;

                Session.IsMasterKeyLogin = false;

                FrmMainMenu mainMenu = new FrmMainMenu();

                this.Hide();

                mainMenu.ShowDialog();

                this.Close();
            }
            catch (ArgumentException ex)
            {
                // Captura si el usuario o contraseña iban vacíos según las reglas de UserBusiness
                MessageBox.Show(ex.Message, "Campos Requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Error de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
            }
            catch (Exception ex)
            {
                // Captura fallos de infraestructura (Por ejemplo, si SQL Server está apagado o la cadena del JSON está mal puesta)
                MessageBox.Show($"Error crítico de conexión con la base de datos: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LimpiarCampos()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            lblErrorMessage.Visible = false; // Ocultamos errores previos si los hay
            txtUsername.Focus();             // Coloca el cursor listo para escribir en el usuario
        }

        #endregion

        private void AbrirMenuPrincipal()
        {
            lblErrorMessage.Visible = false;
            FrmMainMenu mainMenu = new FrmMainMenu();
            mainMenu.Show();
            this.Hide(); // Ocultamos el Login de forma segura
        }

        private void MostrarError(string mensaje)
        {
            lblErrorMessage.Text = mensaje;
            lblErrorMessage.Visible = true;
        }

        private void btnCerrarApp_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

