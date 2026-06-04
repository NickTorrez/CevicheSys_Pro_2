using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CevicheSys_Pro_2.UI.Controls
{
    public partial class CardPlatillo : UserControl
    {
        // Guardamos el platillo que esta tarjeta representa
        public Dish PlatilloAsignado { get; private set; }

        // Creamos un evento personalizado para avisarle al Formulario Principal cuando nos hacen clic
        public event EventHandler TarjetaSeleccionada;

        public CardPlatillo(Dish platillo)
        {
            InitializeComponent();
            PlatilloAsignado = platillo;
            LlenarDatos();
            ConfigurarEventosClic();
        }

        private void LlenarDatos()
        {
            lblTipo.Text = PlatilloAsignado.Dish_Type;
            lblTamaño.Text = PlatilloAsignado.Size;
            lblPrecio.Text = $"C$ {PlatilloAsignado.Price:N2}";

            // Si no hay disponibilidad, cambiamos el color para que se vea inactivo
            if (!PlatilloAsignado.Availability)
            {
                this.BackColor = Color.LightGray;
                lblTipo.ForeColor = Color.DarkGray;
                this.Enabled = false; // No se puede clickear
            }
        }

        // Truco vital: Si el usuario hace clic en el texto (Label) en vez del fondo, 
        // también debe contar como un clic a toda la tarjeta.
        private void ConfigurarEventosClic()
        {
            this.Click += EmitirClic;
            lblTipo.Click += EmitirClic;
            lblTamaño.Click += EmitirClic;
            lblPrecio.Click += EmitirClic;
        }

        private async void EmitirClic(object sender, EventArgs e)
        {
            TarjetaSeleccionada?.Invoke(this, EventArgs.Empty);

            // Guardamos el fondo original si estaba activo
            Color fondoOriginal = Color.White;

            this.BackColor = Color.FromArgb(230, 240, 255); // Azul claro de pulsación
            await System.Threading.Tasks.Task.Delay(150);   // Espera 150 milisegundos
            this.BackColor = fondoOriginal;                 // Regresa a su estado original limpio
        }
    }
    
}
