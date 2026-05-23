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
            // Suscribimos el evento Resize
            this.Resize += new EventHandler(FrmLogin_Resize);
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Centrar al cargar por primera vez
            CentrarTarjetaLogin();
        }

        private void FrmLogin_Resize(object sender, EventArgs e)
        {
            // Volver a centrar si la pantalla cambia de tamaño
            CentrarTarjetaLogin();
        }

        private void CentrarTarjetaLogin()
        {
            // Calcula el centro exacto de la pantalla actual
            pnlTarjetaLogin.Left = (this.ClientSize.Width - pnlTarjetaLogin.Width) / 2;
            pnlTarjetaLogin.Top = (this.ClientSize.Height - pnlTarjetaLogin.Height) / 2;
        }

    }
    public static class Session
    {
        // Guardará el objeto completo del usuario que logueó con éxito
        public static User ActiveUser { get; set; }
    }
}

