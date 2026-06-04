using CevicheSys_Pro_2.UI.Controls;
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
    public partial class FrmPuntoVenta : Form
    {
        public FrmPuntoVenta()
        {
            InitializeComponent();
        }

        private void FrmPuntoVenta_Load(object sender, EventArgs e)
        {
            CargarCatalogoDinamico();
        }

        private void CargarCatalogoDinamico()
        {
            // 1. Limpiamos tarjetas anteriores (por si estamos recargando)
            flpCatalogo.Controls.Clear();

            // 2. Obtenemos la lista de platillos desde la BD (o memoria si aún pruebas sin BD)
            var listaPlatillos = Dish.List();

            // 3. Iteramos y creamos las tarjetas
            foreach (var platillo in listaPlatillos)
            {
                // Instanciamos el UserControl pasándole el platillo
                CardPlatillo nuevaTarjeta = new CardPlatillo(platillo);

                // Nos suscribimos al evento click de la tarjeta
                nuevaTarjeta.TarjetaSeleccionada += NuevaTarjeta_TarjetaSeleccionada;

                // La agregamos al FlowLayoutPanel
                flpCatalogo.Controls.Add(nuevaTarjeta);
            }
        }

        // Este método se ejecuta automáticamente cuando alguien hace clic en CUALQUIER tarjeta
        private void NuevaTarjeta_TarjetaSeleccionada(object sender, EventArgs e)
        {
            // Descubrimos qué tarjeta disparó el evento
            CardPlatillo tarjetaClickeada = sender as CardPlatillo;

            if (tarjetaClickeada != null)
            {
                Dish platilloElegido = tarjetaClickeada.PlatilloAsignado;

                // Aquí ya tienes el objeto exacto. 
                // Muestra el nombre en un Label, o prepáralo para agregarlo al DataGridView del Ticket.
                MessageBox.Show($"Seleccionaste: {platilloElegido.Dish_Type} de {platilloElegido.Size}");

                // Ejemplo de lo que harías luego:
                // lblPlatilloSeleccionado.Text = platilloElegido.Dish_Type;
                // numCantidadPlatillo.Focus();
            }
        }
    }
}
