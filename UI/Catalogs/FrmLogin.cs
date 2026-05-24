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

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUsername.Text.Trim();
            string passwordInput = txtPassword.Text;

            if (string.IsNullOrEmpty(usernameInput) || string.IsNullOrEmpty(passwordInput))
            {
                MostrarError("Por favor, completa todos los campos.");
                return;
            }

            try
            {
                // Validación directa contra las credenciales seguras
                var usuarioEncontrado = User.Authenticate(usernameInput, passwordInput);

                if (usuarioEncontrado != null)
                {
                    lblErrorMessage.Visible = false;

                    // Almacenamiento del usuario activo para el control de accesos posterior
                    Session.ActiveUser = usuarioEncontrado;

                    // Instanciamos el menú principal unificado
                    FrmMainMenu mainMenu = new FrmMainMenu();
                    mainMenu.Show();

                    // Ocultamos el Login para liberar espacio visual
                    this.Hide();
                }
                else
                {
                    MostrarError("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MostrarError("Error del sistema: " + ex.Message);
            }
        }

        private void MostrarError(string mensaje)
        {
            lblErrorMessage.Text = mensaje;
            lblErrorMessage.Visible = true;
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

        private void lblBienvenida_Click(object sender, EventArgs e)
        {

        }

        private void pnlRegistro_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    public static class Session
    {
        // Guardará el objeto completo del usuario que logueó con éxito
        public static User ActiveUser { get; set; }
    }
}

