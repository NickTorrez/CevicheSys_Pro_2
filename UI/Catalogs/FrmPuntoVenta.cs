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
using CevicheSys_Pro_2.Domain;                       // Para mapear entidades en las tablas/vistas
using CevicheSys_Pro_2.Services.BusinessLogic;       // Para llamar a los controladores de negocio
using CevicheSys_Pro_2.Services.Repositories;        // Solo si inicializas la persistencia desde el arranque
using CevicheSys_Pro_2.Helpers;                    // Para formateos, validaciones, etc.
using CevicheSys_Pro_2;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form
    {
        public FrmPuntoVenta()
        {
            InitializeComponent();
        }

        // Evento que se dispara al abrir la pantalla
        private void FrmPuntoVenta_Load(object sender, EventArgs e)
        {
            CargarCatalogoDinamico();
        }

        /* --------------------------------------------------------------------- */
        /* 1. CREACIÓN DE LAS TARJETAS DINÁMICAS                                 */
        /* --------------------------------------------------------------------- */
        private void CargarCatalogoDinamico()
        {
            // Limpiamos el panel por si se recarga la pantalla
            flpCatalogo.Controls.Clear();

            try
            {
                // SOLUCIÓN AL ERROR: Forzamos la ruta absoluta de la clase Dish
                var listaPlatillos = CevicheSys_Pro_2.Dish.List();

                foreach (var platillo in listaPlatillos)
                {
                    // Creamos una nueva tarjeta por cada platillo en la BD
                    CardPlatillo nuevaTarjeta = new CardPlatillo(platillo);

                    // Nos suscribimos para escuchar cuando el vendedor le haga clic
                    nuevaTarjeta.TarjetaSeleccionada += NuevaTarjeta_TarjetaSeleccionada;

                    // Agregamos la tarjeta visualmente al FlowLayoutPanel
                    flpCatalogo.Controls.Add(nuevaTarjeta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el catálogo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /* --------------------------------------------------------------------- */
        /* 2. LÓGICA AL HACER CLIC EN UNA TARJETA                                */
        /* --------------------------------------------------------------------- */

        // Este método se ejecuta automáticamente cuando alguien hace clic en CUALQUIER tarjeta
        private void NuevaTarjeta_TarjetaSeleccionada(object sender, EventArgs e)
        {
            CardPlatillo tarjetaClickeada = sender as CardPlatillo;

            if (tarjetaClickeada != null)
            {
                Dish platilloElegido = tarjetaClickeada.PlatilloAsignado;
                int cantidad = (int)numCantidadPlatillo.Value;
                string descripcionFactura = $"{platilloElegido.Dish_Type} ({platilloElegido.Size})";

                bool productoExiste = false;

                // Buscamos si el platillo ya fue agregado previamente al ticket
                foreach (DataGridViewRow row in dgvTicket.Rows)
                {
                    if (row.Cells[0].Value != null && row.Cells[0].Value.ToString() == descripcionFactura)
                    {
                        // El producto ya existe, actualizamos su cantidad y su nuevo subtotal
                        int cantidadAnterior = Convert.ToInt32(row.Cells[1].Value);
                        int nuevaCantidad = cantidadAnterior + cantidad;

                        row.Cells[1].Value = nuevaCantidad;
                        row.Cells[2].Value = platilloElegido.Price * nuevaCantidad;

                        productoExiste = true;
                        break;
                    }
                }

                // Si es un platillo nuevo en la orden actual, se agrega una nueva fila de forma limpia
                if (!productoExiste)
                {
                    double subtotal = platilloElegido.Price * cantidad;
                    dgvTicket.Rows.Add(descripcionFactura, cantidad, subtotal);
                }

                ActualizarTotalPagar();
                numCantidadPlatillo.Value = 1; // Reseteamos el contador siempre a 1

            }
        }

        /* --------------------------------------------------------------------- */
        /* 3. MATEMÁTICA DE LA FACTURA                                           */
        /* --------------------------------------------------------------------- */
        private void ActualizarTotalPagar()
        {
            double totalGeneral = 0;

            // Recorremos todas las filas del ticket
            foreach (DataGridViewRow row in dgvTicket.Rows)
            {
                // Verificamos que la celda del subtotal (índice 2) no esté vacía
                if (row.Cells[2].Value != null)
                {
                    totalGeneral += Convert.ToDouble(row.Cells[2].Value);
                }
            }

            // Actualizamos el Label gigante con el formato de moneda de Nicaragua
            lblTotalPagar.Text = $"TOTAL: C$ {totalGeneral:N2}";
        }
    }
}
