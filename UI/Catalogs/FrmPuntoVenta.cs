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
using CevicheSys_Pro_2.Helpers;                    // Para formateos, validaciones, etc.
using CevicheSys_Pro_2;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form
    {
        // Usamos BindingList para que el DataGridView se actualice automáticamente al agregar o modificar items
        private BindingList<DetailedSaleDTO> carritoCompras = new BindingList<DetailedSaleDTO>();
        private double totalPagar = 0;
        public FrmPuntoVenta()
        {
            InitializeComponent();
        }

        private void FrmPuntoVenta_Load(object sender, EventArgs e)
        {
            // Vinculamos el carrito al DataGridView
            dgvCarrito.DataSource = carritoCompras;
            ConfigurarColumnasCarrito();

            // Cargamos los botones
            CargarPlatillosDinamicos();
            ActualizarTotal();
        }

        /// <summary>
        /// Genera los botones del menú de forma dinámica. 
        /// En el futuro, esta lista vendrá de tu capa Services (ej: productoBusiness.ListarPlatillos()).
        /// </summary>
        private void CargarPlatillosDinamicos()
        {
            // Limpiamos el panel por si acaso
            flpPlatillos.Controls.Clear();

            // --- SIMULACIÓN DE DATOS DE LA BASE DE DATOS ---
            // Aquí simulo lo que tu Service traería de la tabla Producto/Platillo
            var listaPlatillos = new List<dynamic>
            {
                new { Id = 1, Tipo = "Camarón", Tamaño = "12 onz", Precio = 50.00 },
                new { Id = 2, Tipo = "Camarón", Tamaño = "25 onz", Precio = 100.00 },
                new { Id = 3, Tipo = "Pescado", Tamaño = "12 onz", Precio = 50.00 },
                new { Id = 4, Tipo = "Pescado", Tamaño = "25 onz", Precio = 100.00 },
                new { Id = 5, Tipo = "Mixto (Camarón y Pescado)", Tamaño = "12 onz", Precio = 60.00 },
                new { Id = 6, Tipo = "Mixto (Camarón y Pescado)", Tamaño = "25 onz", Precio = 120.00 }
            };

            // Recorremos la lista y creamos un botón por cada platillo
            foreach (var platillo in listaPlatillos)
            {
                Button btnPlatillo = new Button();
                btnPlatillo.Width = 140;
                btnPlatillo.Height = 100;
                btnPlatillo.Text = $"{platillo.Tipo}\n{platillo.Tamaño}\nC$ {platillo.Precio:F2}";
                btnPlatillo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnPlatillo.BackColor = Color.FromArgb(227, 242, 253); // Celeste claro
                btnPlatillo.FlatStyle = FlatStyle.Flat;
                btnPlatillo.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243); // Borde azul
                btnPlatillo.Cursor = Cursors.Hand;

                // Guardamos el objeto completo en la propiedad Tag para usarlo al hacer clic
                btnPlatillo.Tag = platillo;

                // Suscribimos el botón al evento Clic
                btnPlatillo.Click += BtnPlatillo_Click;

                // Lo agregamos al panel
                flpPlatillos.Controls.Add(btnPlatillo);
            }
        }

        /// <summary>
        /// Evento que se dispara cada vez que el usuario hace clic en el botón de un platillo
        /// </summary>
        /// 
        private void BtnPlatillo_Click(object sender, EventArgs e)
        {
            // Recuperamos el botón que fue clickeado y su información (Tag)
            Button btnClickeado = (Button)sender;
            dynamic platillo = btnClickeado.Tag;

            // Buscamos si el platillo ya está en el carrito
            var itemExistente = carritoCompras.FirstOrDefault(x => x.Dish_Type == platillo.Tipo && x.Size == platillo.Tamaño);

            if (itemExistente != null)
            {
                // Si ya existe, solo sumamos 1 a la cantidad y recalculamos su subtotal
                itemExistente.Quantity += 1;
                itemExistente.Total_Amount = itemExistente.Quantity * itemExistente.Price;
            }
            else
            {
                // Si no existe, creamos una nueva línea en el carrito
                DetailedSaleDTO nuevoItem = new DetailedSaleDTO
                {
                    Dish_Type = platillo.Tipo,
                    Size = platillo.Tamaño,
                    Price = platillo.Precio,
                    Quantity = 1,
                    Total_Amount = platillo.Precio,
                    // Estos campos se llenarán en el modal de facturación:
                    Customer = "Pendiente",
                    Payment_Method = "Pendiente",
                    Purchase_Type = "Pendiente"
                };
                carritoCompras.Add(nuevoItem);
            }
            // Refrescamos el DataGridView y el Total
            dgvCarrito.Refresh();
            ActualizarTotal();
        }

        private void ActualizarTotal()
        {
            totalPagar = carritoCompras.Sum(x => x.Total_Amount);
            lblTotal.Text = $"Total: C$ {totalPagar:F2}";
        }

        private void ConfigurarColumnasCarrito()
        {
            // Ocultamos columnas del DTO que no necesitamos ver en este momento
            if (dgvCarrito.Columns["Sale_Id"] != null) dgvCarrito.Columns["Sale_Id"].Visible = false;
            if (dgvCarrito.Columns["Date"] != null) dgvCarrito.Columns["Date"].Visible = false;
            if (dgvCarrito.Columns["Customer"] != null) dgvCarrito.Columns["Customer"].Visible = false;
            if (dgvCarrito.Columns["Payment_Method"] != null) dgvCarrito.Columns["Payment_Method"].Visible = false;
            if (dgvCarrito.Columns["Purchase_Type"] != null) dgvCarrito.Columns["Purchase_Type"].Visible = false;
            if (dgvCarrito.Columns["Auditor_User"] != null) dgvCarrito.Columns["Auditor_User"].Visible = false;

            // Cambiamos los títulos a español
            if (dgvCarrito.Columns["Dish_Type"] != null) dgvCarrito.Columns["Dish_Type"].HeaderText = "Platillo";
            if (dgvCarrito.Columns["Size"] != null) dgvCarrito.Columns["Size"].HeaderText = "Tamaño";
            if (dgvCarrito.Columns["Price"] != null) dgvCarrito.Columns["Price"].HeaderText = "Precio Unit.";
            if (dgvCarrito.Columns["Quantity"] != null) dgvCarrito.Columns["Quantity"].HeaderText = "Cant.";
            if (dgvCarrito.Columns["Total_Amount"] != null) dgvCarrito.Columns["Total_Amount"].HeaderText = "Subtotal";
        }

        // --- BOTONES DE ACCIÓN ---
        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (carritoCompras.Count == 0)
            {
                MessageBox.Show("Agregue al menos un platillo al carrito antes de cobrar.", "Carrito Vacío", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Convertimos la BindingList a un List normal para pasarlo al formulario
            List<DetailedSaleDTO> listaParaCobrar = carritoCompras.ToList();

            // Abrimos el Modal de Facturación pasándole el Carrito y el Total a Pagar
            using (FrmFacturacion modalFacturacion = new FrmFacturacion(listaParaCobrar, totalPagar))
            {
                // Si el usuario presionó "Generar Factura" en el modal y todo salió bien (DialogResult.OK)
                if (modalFacturacion.ShowDialog() == DialogResult.OK)
                {
                    // Venta exitosa. Limpiamos el carrito para el siguiente cliente
                    carritoCompras.Clear();
                    ActualizarTotal();

                    // Opcional: Mostrar un mensaje confirmando
                    MessageBox.Show("¡Venta registrada exitosamente! Se ha procesado el pago.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            // Abrimos el Modal de Cierre de Caja
            using (FrmCierreCaja modalCierre = new FrmCierreCaja())
            {
                if (modalCierre.ShowDialog() == DialogResult.OK)
                {
                    // Opcional: Podrías forzar el cierre de sesión tras un cierre de caja exitoso
                    // O simplemente limpiar el punto de venta.
                }
            }
        }
    }
}
