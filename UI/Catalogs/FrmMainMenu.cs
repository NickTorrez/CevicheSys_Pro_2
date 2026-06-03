using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CevicheSys_Pro_2.Helpers;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {
            // 1. Verificación de seguridad
            if (Session.ActiveUser == null)
            {
                MessageBox.Show("Sesión no válida. Regresando al Login.", "Seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // 2. Bienvenida personalizada
            lblUsuarioActivo.Text = $"Hola, {Session.ActiveUser.Username} | Perfil: {Session.ActiveUser.Role}";

            // 3. Aplicación estricta de Roles
            ConfigurarAccesos();

            tmrReloj.Start(); // Iniciamos el temporizador para mostrar la hora en tiempo real
        }

        private void ConfigurarAccesos()
        {
            string rol = Session.ActiveUser.Role;

            if (rol == "Admin")
            {
                // El administrador tiene control total del negocio
                btnPuntoVenta.Visible = true;
                btnInventario.Visible = true;
                btnProveedores.Visible = true;
                btnGastos.Visible = true;
                btnReportes.Visible = true;
                btnUsuarios.Visible = true;
            }
            else if (rol == "Vendedor")
            {
                // Restricciones visuales para el perfil Vendedor
                btnPuntoVenta.Visible = true;
                btnInventario.Visible = true;

                // Ocultamos módulos sensibles
                btnProveedores.Visible = false;
                btnGastos.Visible = false;
                btnReportes.Visible = false;
                btnUsuarios.Visible = false;

                // NOTA: La validación de "Solo Lectura" para el Inventario
                // se programará directamente dentro del formulario de Inventario al abrirlo.
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpiamos la sesión activa
            Session.ActiveUser = null;
            tmrReloj.Stop();

            // Buscamos el formulario de Login abierto y lo volvemos a mostrar
            var loginForm = Application.OpenForms["FrmLogin"] as FrmLogin;
            if (loginForm != null)
            {
                loginForm.LimpiarCampos(); // <--- Llamamos al método que borra todo
                loginForm.Show();
            }

            this.Close(); // Cerramos el menú
        }

        // Para evitar que la aplicación se quede corriendo en segundo plano si cierran con la "X"
        private void FrmMainMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Session.ActiveUser != null) // Si no fue un cierre de sesión manual
            {
                Application.Exit();
            }
        }

        private void tmrReloj_Tick(object sender, EventArgs e)
        {
            // Actualiza la hora y la fecha cada segundo
            lblHora.Text = DateTime.Now.ToString("hh:mm:ss tt"); // Formato 12 horas con AM/PM
            lblFecha.Text = DateTime.Now.ToLongDateString(); // Ejemplo: "lunes, 24 de mayo de 2026"
        }

        private void lblUsuarioActivo_Click(object sender, EventArgs e)
        {

        }
    }
}
