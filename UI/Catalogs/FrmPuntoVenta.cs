using CevicheSys_Pro_2;
using CevicheSys_Pro_2.Domain;                       // Para mapear entidades en las tablas/vistas
using CevicheSys_Pro_2.Helpers;                    // Para formateos, validaciones, etc.
using CevicheSys_Pro_2.Services.BusinessLogic;       // Para llamar a los controladores de negocio
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CevicheSys_Pro_2.UI.Catalogs
{
    public partial class FrmPuntoVenta : Form
    {
        // Usamos BindingList para que el DataGridView se actualice automáticamente al agregar o modificar items
        private BindingList<DetailedSaleDTO> carritoCompras = new BindingList<DetailedSaleDTO>();
        private decimal totalPagar = 0m;
        private readonly CultureInfo cultura = new CultureInfo("es-NI");
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
            flpPlatillos.Controls.Clear();

            // Temporal: luego esta lista vendra de DishBusiness.ListDishes()
            var listaPlatillos = new List<DishMenuItem>
            {
                new DishMenuItem { Dish_Id = 1, Dish_Type = "Camaron", Size = "12 onz", Price = 50.00m },
                new DishMenuItem { Dish_Id = 2, Dish_Type = "Camaron", Size = "25 onz", Price = 100.00m },
                new DishMenuItem { Dish_Id = 3, Dish_Type = "Pescado", Size = "12 onz", Price = 50.00m },
                new DishMenuItem { Dish_Id = 4, Dish_Type = "Pescado", Size = "25 onz", Price = 100.00m },
                new DishMenuItem { Dish_Id = 5, Dish_Type = "Mixto", Size = "12 onz", Price = 60.00m },
                new DishMenuItem { Dish_Id = 6, Dish_Type = "Mixto", Size = "25 onz", Price = 120.00m }
            };

            foreach (DishMenuItem platillo in listaPlatillos)
            {
                Button btnPlatillo = new Button();
                btnPlatillo.Width = 140;
                btnPlatillo.Height = 100;
                btnPlatillo.Text = $"{platillo.Dish_Type}\n{platillo.Size}\n{platillo.Price.ToString("C2", cultura)}";
                btnPlatillo.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                btnPlatillo.BackColor = Color.FromArgb(227, 242, 253);
                btnPlatillo.FlatStyle = FlatStyle.Flat;
                btnPlatillo.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);
                btnPlatillo.Cursor = Cursors.Hand;
                btnPlatillo.Tag = platillo;
                btnPlatillo.Click += BtnPlatillo_Click;

                flpPlatillos.Controls.Add(btnPlatillo);
            }
        }

        /// <summary>
        /// Evento que se dispara cada vez que el usuario hace clic en el botón de un platillo
        /// </summary>
        /// 
        private void BtnPlatillo_Click(object sender, EventArgs e)
        {
            if (sender is not Button btnClickeado || btnClickeado.Tag is not DishMenuItem platillo)
                return;

            DetailedSaleDTO itemExistente = carritoCompras
                .FirstOrDefault(x => x.Dish_Id == platillo.Dish_Id);

            if (itemExistente != null)
            {
                itemExistente.Quantity += 1;
                itemExistente.Total_Amount = itemExistente.Quantity * itemExistente.Price;
            }
            else
            {
                DetailedSaleDTO nuevoItem = new DetailedSaleDTO
                {
                    Dish_Id = platillo.Dish_Id,
                    Dish_Type = platillo.Dish_Type,
                    Size = platillo.Size,
                    Price = platillo.Price,
                    Quantity = 1,
                    Total_Amount = platillo.Price,
                    Customer = "Pendiente",
                    Payment_Method = "Pendiente",
                    Purchase_Type = "Pendiente"
                };

                carritoCompras.Add(nuevoItem);
            }

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
            if (dgvCarrito.Columns["Sale_Id"] != null) dgvCarrito.Columns["Sale_Id"].Visible = false;
            if (dgvCarrito.Columns["Dish_Id"] != null) dgvCarrito.Columns["Dish_Id"].Visible = false;
            if (dgvCarrito.Columns["Date"] != null) dgvCarrito.Columns["Date"].Visible = false;
            if (dgvCarrito.Columns["Customer"] != null) dgvCarrito.Columns["Customer"].Visible = false;
            if (dgvCarrito.Columns["Payment_Method"] != null) dgvCarrito.Columns["Payment_Method"].Visible = false;
            if (dgvCarrito.Columns["Purchase_Type"] != null) dgvCarrito.Columns["Purchase_Type"].Visible = false;
            if (dgvCarrito.Columns["Auditor_User"] != null) dgvCarrito.Columns["Auditor_User"].Visible = false;

            if (dgvCarrito.Columns["Dish_Type"] != null) dgvCarrito.Columns["Dish_Type"].HeaderText = "Platillo";
            if (dgvCarrito.Columns["Size"] != null) dgvCarrito.Columns["Size"].HeaderText = "Tamano";
            if (dgvCarrito.Columns["Price"] != null)
            {
                dgvCarrito.Columns["Price"].HeaderText = "Precio Unit.";
                dgvCarrito.Columns["Price"].DefaultCellStyle.Format = "C2";
            }

            if (dgvCarrito.Columns["Quantity"] != null) dgvCarrito.Columns["Quantity"].HeaderText = "Cant.";

            if (dgvCarrito.Columns["Total_Amount"] != null)
            {
                dgvCarrito.Columns["Total_Amount"].HeaderText = "Subtotal";
                dgvCarrito.Columns["Total_Amount"].DefaultCellStyle.Format = "C2";
            }
        }

        // --- BOTONES DE ACCIÓN ---
        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (carritoCompras.Count == 0)
            {
                MessageBox.Show("Agregue al menos un platillo al carrito antes de cobrar.", "Carrito Vacio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DetailedSaleDTO> listaParaCobrar = carritoCompras.ToList();

            using (FrmFacturacion modalFacturacion = new FrmFacturacion(listaParaCobrar, totalPagar))
            {
                if (modalFacturacion.ShowDialog() == DialogResult.OK)
                {
                    carritoCompras.Clear();
                    ActualizarTotal();
                    MessageBox.Show("Venta registrada exitosamente.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            using (FrmCierreCaja modalCierre = new FrmCierreCaja())
            {
                modalCierre.ShowDialog();
            }
        }

        private class DishMenuItem
        {
            public int Dish_Id { get; set; }
            public string Dish_Type { get; set; }
            public string Size { get; set; }
            public decimal Price { get; set; }
        }
    }
}
