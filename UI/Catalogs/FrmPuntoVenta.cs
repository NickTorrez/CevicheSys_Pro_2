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
        private BindingList<DetailedSaleDTO> _carritoCompras;
        private decimal _totalPagar = 0m;
        private readonly DishBusiness _dishBusiness;

        public FrmPuntoVenta()
        {
            InitializeComponent();
            _carritoCompras = new BindingList<DetailedSaleDTO>();
            _dishBusiness = new DishBusiness();
        }

        private void FrmPuntoVenta_Load(object sender, EventArgs e)
        {
            dgvCarrito.DataSource = _carritoCompras;
            ConfigurarColumnasCarrito();
            CargarPlatillosDesdeBD();
            ActualizarTotal();
        }

        /// <summary>
        /// Evento que se dispara cada vez que el usuario hace clic en el botón de un platillo
        /// </summary>
        /// 
        private void BtnPlatillo_Click(object sender, EventArgs e)
        {
            if (sender is not Button btnClickeado || btnClickeado.Tag is not Dish platillo) return;

            DetailedSaleDTO itemExistente = _carritoCompras.FirstOrDefault(x => x.Dish_Id == platillo.Dish_Id);

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
                _carritoCompras.Add(nuevoItem);
            }

            dgvCarrito.Refresh();
            ActualizarTotal();
        }


        /// <summary>
        /// Genera los botones del menú de forma dinámica. 
        /// En el futuro, esta lista vendrá de tu capa Services (ej: productoBusiness.ListarPlatillos()).
        /// </summary>
       
        
        private void CargarPlatillosDesdeBD()
        {
            try
            {
                flpPlatillos.Controls.Clear();
                List<Dish> menuActivo = _dishBusiness.ListAvailableDishes();

                foreach (Dish platillo in menuActivo)
                {
                    Button btnPlatillo = new Button
                    {
                        Width = 140,
                        Height = 100,
                        Text = $"{platillo.Dish_Type}\n{platillo.Size}\nC$ {platillo.Price:F2}",
                        Font = new Font("Segoe UI", 10, FontStyle.Bold),
                        BackColor = Color.FromArgb(227, 242, 253),
                        FlatStyle = FlatStyle.Flat,
                        Cursor = Cursors.Hand,
                        Tag = platillo
                    };
                    btnPlatillo.FlatAppearance.BorderColor = Color.FromArgb(33, 150, 243);
                    btnPlatillo.Click += BtnPlatillo_Click;
                    flpPlatillos.Controls.Add(btnPlatillo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al extraer el menú: {ex.Message}", "Error BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActualizarTotal()
        {
            _totalPagar = _carritoCompras.Sum(x => x.Total_Amount);
            lblTotal.Text = $"Total: C$ {_totalPagar:F2}";
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
            if (dgvCarrito.Columns["Size"] != null) dgvCarrito.Columns["Size"].HeaderText = "Tamaño";
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
            if (_carritoCompras.Count == 0)
            {
                MessageBox.Show("Agregue al menos un platillo al carrito antes de cobrar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<DetailedSaleDTO> listaParaCobrar = _carritoCompras.ToList();

            using (FrmFacturacion modalFacturacion = new FrmFacturacion(listaParaCobrar, _totalPagar))
            {
                if (modalFacturacion.ShowDialog() == DialogResult.OK)   
                {
                    _carritoCompras.Clear();
                    ActualizarTotal();
                    MessageBox.Show("Transacción completada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        
    }
}
