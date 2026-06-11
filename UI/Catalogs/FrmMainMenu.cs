using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CevicheSys_Pro_2.Domain;                       // Para mapear entidades en las tablas/vistas
using CevicheSys_Pro_2.Services.BusinessLogic;       // Para llamar a los controladores de negocio      
using CevicheSys_Pro_2.Helpers;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmMainMenu : Form
    {
        // Variable para mantener el rastro del formulario abierto actualmente
        private Form formularioActivo = null;

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
            // PASO 1: Ocultar TODOS los botones por defecto (Estrategia de seguridad limpia)
            btnPuntoVenta.Visible = false;
            btnInventario.Visible = false;
            btnProveedores.Visible = false;
            btnGastos.Visible = false;
            btnReportes.Visible = false;
            btnUsuarios.Visible = false;

            // PASO 2: Evaluar caso crítico de la Llave Maestra
            if (Session.IsMasterKeyLogin)
            {
                btnUsuarios.Visible = true; // Único botón visible
                MessageBox.Show("Modo de recuperación activo.\nPor seguridad, únicamente tiene acceso al módulo de 'Gestión de Perfiles' para restablecer credenciales.",
                                "Control de Acceso Contingente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Bloquea que se evalúen los roles estándar
            }

            // PASO 3: Distribución de módulos por Flujo Normal de Roles
            string rol = Session.ActiveUser.Role;

            if (rol == "Admin")
            {
                // El administrador visualiza la totalidad de los módulos
                btnPuntoVenta.Visible = true;
                btnInventario.Visible = true;
                btnProveedores.Visible = true;
                btnGastos.Visible = true;
                btnReportes.Visible = true;
                btnUsuarios.Visible = true;
            }
            else if (rol == "Vendedor")
            {
                // El vendedor solo visualiza sus operaciones nativas
                btnPuntoVenta.Visible = true;
                btnInventario.Visible = true;

                // NOTA: Recuerda que las restricciones CRUD del Inventario (ocultar botones Añadir/Editar)
                // se ejecutarán en el Load del 'FrmInventario' validando si Session.ActiveUser.Role == "Vendedor".
            }
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpiamos la sesión activa
            Session.ActiveUser = null;
            Session.IsMasterKeyLogin = false;
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
            // Si el usuario cierra desde la 'X' de Windows sin cerrar sesión de forma manual
            if (Session.ActiveUser != null || Session.IsMasterKeyLogin)
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

        /// <summary>
        /// Incrusta un formulario dentro del panel contenedor.
        /// </summary>
        private void AbrirModuloEnPanel(Form moduloHijo)
        {
            // Cerrar el formulario anterior si existe
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = moduloHijo;

            // Configuraciones para que el form actúe como un control dentro del panel
            moduloHijo.TopLevel = false;
            moduloHijo.FormBorderStyle = FormBorderStyle.None;
            moduloHijo.Dock = DockStyle.Fill;

            pnlContenedorPrincipal.Controls.Add(moduloHijo);
            pnlContenedorPrincipal.Tag = moduloHijo;

            moduloHijo.BringToFront();
            moduloHijo.Show();

            // Como acabamos de abrir un módulo, hacemos que el botón APAREZCA
            btnCerrarModulo.Visible = true;
        }

        private void btnPuntoVenta_Click(object sender, EventArgs e)
        {
            AbrirModuloEnPanel(new FrmPuntoVenta());
        }

        private void btnCerrarModulo_Click(object sender, EventArgs e)
        {
            // Verificamos si realmente hay algo abierto
            if (pnlContenedorPrincipal.Controls.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "¿Desea cerrar el módulo actual? Se perderán los datos no guardados.",
                    "Cerrar Módulo",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    // 1. Vaciamos el panel contenedor
                    pnlContenedorPrincipal.Controls.Clear();

                    // 2. Ocultamos el botón automáticamente ya que volvimos al "Home" vacío
                    btnCerrarModulo.Visible = false;
                }
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirModuloEnPanel(new FrmInventario());
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            AbrirModuloEnPanel(new FrmProveedores());
        }

        private void btnGastos_Click(object sender, EventArgs e)
        {
            AbrirModuloEnPanel(new FrmGastos());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirModuloEnPanel(new FrmReportes());
        }
    }
}
