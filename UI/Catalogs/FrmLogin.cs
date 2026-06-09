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
        public FrmLogin()
        {
            InitializeComponent();
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
            string llaveMaestra = "ADMIN_MASTER_KEY_2026"; // Llave de recuperación predefinida

            // 1. Validación de campos vacíos
            if (string.IsNullOrEmpty(usernameInput) || string.IsNullOrEmpty(passwordInput))
            {
                MostrarError("Por favor, completa todos los campos.");
                return;
            }

            // 2. Verificar si es la Llave Maestra (Prioridad absoluta ante pérdida de acceso)
            if (passwordInput == llaveMaestra)
            {
                Session.ActiveUser = new User { Username = "Recuperación", Role = "Admin" };
                Session.IsMasterKeyLogin = true;

                AbrirMenuPrincipal();
                return;
            }

            // 3. Flujo por medio de Memoria / JSON (Prioridad para desarrollo y pruebas locales)
            try
            {
                var usuarioMock = User.MockAuthenticate(usernameInput, passwordInput);
                if (usuarioMock != null)
                {
                    if (usuarioMock.Enable)
                    {
                        Session.ActiveUser = usuarioMock;
                        Session.IsMasterKeyLogin = false;
                        AbrirMenuPrincipal();
                        return; // Detiene la ejecución aquí
                    }
                    else
                    {
                        MessageBox.Show("Este usuario de prueba está inactivo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                // Si hay un error con el archivo JSON del Mock, lo notificamos pero dejamos que intente con la BD
                System.Diagnostics.Debug.WriteLine("Error en Mock: " + ex.Message);
            }

            // 4. Flujo normal: Validar en la Base de Datos si no se encontró en memoria
            try
            {
                UserBusiness userBusiness = new UserBusiness();
                User usuarioLogueado = userBusiness.AuthenticateUser(usernameInput, passwordInput);

                if (usuarioLogueado != null)
                {
                    if (usuarioLogueado.Enable)
                    {
                        Session.ActiveUser = usuarioLogueado;
                        Session.IsMasterKeyLogin = false;
                        AbrirMenuPrincipal();
                        return; // Detiene la ejecución aquí
                    }
                    else
                    {
                        MessageBox.Show("Este usuario está inactivo. Contacte al administrador.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error de conexión a la Base de Datos: " + ex.Message);
                return;
            }

            // 5. Si llegó a este punto, ninguna credencial coincidió
            MostrarError("Usuario o contraseña incorrectos.");
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

