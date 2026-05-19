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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMostrarOcultar_Click(object sender, EventArgs e)
        {
            // UseSystemPasswordChar es la propiedad que oculta el texto con círculos
            // Al negarla (!), si está activada se desactiva, y viceversa
            txtPassword.UseSystemPasswordChar = !txtPassword.UseSystemPasswordChar;

            // Cambiamos el texto del botón para darle feedback visual al usuario
            if (txtPassword.UseSystemPasswordChar)
            {
                btnMostrarOcultar.Text = "👁"; // Modo oculto (muestra el ojo para permitir ver)
            }
            else
            {
                btnMostrarOcultar.Text = "🔒"; // Modo visible (muestra el candado para permitir ocultar)
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }
    }
    public static class Sesion
    {
        // Guardará el objeto completo del usuario que logueó con éxito
        public static Usuario UsuarioActivo { get; set; }
    }
}

