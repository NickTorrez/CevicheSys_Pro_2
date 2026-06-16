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

        public FrmLogin()
        {
            InitializeComponent();
            _userBusiness = new UserBusiness();
            // Vinculamos el evento Resize para que responda si estiran o maximizan la ventana
            this.Resize += new EventHandler(FrmLogin_Resize);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Centrar al cargar por primera vez
            CentrarTarjetaLogin();
            // Aseguramos que la contraseña inicie oculta de forma nativa
            txtPassword.PasswordChar = '●';
            btnTogglePassword.Text = "👁";
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

        // LÓGICA PRINCIPAL DE AUTENTICACIÓN
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUsername.Text.Trim();
            string passwordInput = txtPassword.Text;

            // 1. Validación de interfaz (Campos requeridos)
            if (string.IsNullOrWhiteSpace(usernameInput) || string.IsNullOrWhiteSpace(passwordInput))
            {
                MostrarError("Por favor, completa todos los campos requeridos.");
                return;
            }

            // 2. Transacción segura hacia la capa de base de datos
            try
            {
                User usuarioLogueado = _userBusiness.AuthenticateUser(usernameInput, passwordInput);

                // 3. Evaluación del resultado de la autenticación
                if (usuarioLogueado != null)
                {
                    if (usuarioLogueado.Enable)
                    {
                        // 4. Configurar la sesión global de la aplicación
                        Session.ActiveUser = usuarioLogueado;
                        Session.IsMasterKeyLogin = false; // Concepto obsoleto, se desactiva por seguridad

                        AbrirMenuPrincipal();
                    }
                    else
                    {
                        MessageBox.Show("Este usuario se encuentra inactivo. Contacte al administrador del sistema.",
                                        "Acceso Restringido", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                // 5. Manejo de excepciones provenientes de la clase DatabaseConnection
                MessageBox.Show($"Ocurrió un error al intentar comunicar con la base de datos:\n\n{ex.Message}",
                                "Fallo de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        public void LimpiarCampos()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            lblErrorMessage.Visible = false; // Ocultamos errores previos si los hay
            txtUsername.Focus();             // Coloca el cursor listo para escribir en el usuario
        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

