using CevicheSys_Pro_2.Helpers;
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
    public partial class FrmFacturacion : Form
    {
        // Variables para recibir los datos desde el Punto de Venta
        private readonly List<DetailedSaleDTO> carrito;
        private readonly decimal totalAPagar;
        private decimal montoEntregado = 0m;
        private decimal cambio = 0m;
        private readonly CultureInfo cultura = new CultureInfo("es-NI");


        // Modificamos el constructor para que reciba el carrito y el total
        public FrmFacturacion(List<DetailedSaleDTO> carritoCompras, decimal totalAPagar)
        {
            InitializeComponent();
            carrito = carritoCompras;
            this.totalAPagar = totalAPagar;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            lblTotalPagar.Text = $"Total a Pagar: {totalAPagar.ToString("C2", cultura)}";

            if (cmbTipoCompra.Items.Count == 0)
                cmbTipoCompra.Items.AddRange(new string[] { "Local", "Delivery" });

            if (cmbMetodoPago.Items.Count == 0)
                cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta", "Transferencia" });

            cmbTipoCompra.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            txtNombreCliente.Text = "Cliente Mostrador";
            txtMontoEntregado.Text = string.Empty;
            txtMontoEntregado.MaxLength = 12;
            txtNombreCliente.MaxLength = 100;
            txtTelefono.MaxLength = 20;
            txtMontoEntregado.Focus();
        }

        // Evento: Cuando el cajero cambia entre Efectivo o Tarjeta
        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            string metodo = cmbMetodoPago.SelectedItem?.ToString() ?? string.Empty;

            if (metodo == "Tarjeta" || metodo == "Transferencia")
            {
                txtMontoEntregado.Enabled = false;
                txtMontoEntregado.Text = totalAPagar.ToString("F2");
                cambio = 0m;
                lblCambio.Text = "Cambio: C$ 0.00";
                lblCambio.ForeColor = Color.Black;
            }
            else
            {
                txtMontoEntregado.Enabled = true;
                txtMontoEntregado.Text = string.Empty;
                cambio = 0m;
                lblCambio.Text = "Cambio: C$ 0.00";
                lblCambio.ForeColor = Color.Black;
                txtMontoEntregado.Focus();
            }
        }

        private void txtMontoEntregado_TextChanged(object sender, EventArgs e)
        {
            CalcularCambio();
        }

        private void CalcularCambio()
        {
            if (string.IsNullOrWhiteSpace(txtMontoEntregado.Text))
            {
                lblCambio.Text = "Cambio: C$ 0.00";
                lblCambio.ForeColor = Color.Black;
                return;
            }

            if (decimal.TryParse(txtMontoEntregado.Text, out montoEntregado))
            {
                cambio = montoEntregado - totalAPagar;

                if (cambio < 0)
                {
                    lblCambio.Text = $"Faltan: {Math.Abs(cambio).ToString("C2", cultura)}";
                    lblCambio.ForeColor = Color.Red;
                }
                else
                {
                    lblCambio.Text = $"Cambio: {cambio.ToString("C2", cultura)}";
                    lblCambio.ForeColor = Color.DarkGreen;
                }
            }
            else
            {
                lblCambio.Text = "Monto invalido";
                lblCambio.ForeColor = Color.Red;
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string metodoPago = cmbMetodoPago.SelectedItem?.ToString() ?? string.Empty;

            if (metodoPago == "Efectivo" && cambio < 0)
            {
                MessageBox.Show("El monto entregado es menor al total a pagar.", "Falta Dinero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DetailedSaleDTO item in carrito)
            {
                item.Customer = txtNombreCliente.Text.Trim();
                item.Payment_Method = metodoPago;
                item.Purchase_Type = cmbTipoCompra.SelectedItem.ToString();
            }

            Sale nuevaVenta = new Sale
            {
                Customer_Id = null, // Luego se reemplaza por el cliente encontrado/creado.
                Payment_Method = metodoPago,
                Purchase_Type = cmbTipoCompra.SelectedItem.ToString(),
                Total_Amount = totalAPagar,
                Record_Date = DateTime.Now,
                User_Id = Session.ActiveUser != null ? Session.ActiveUser.User_Id : 1,
                Enable = true
            };

            List<SaleDetail> detalles = carrito.Select(item => new SaleDetail
            {
                Dish_Id = item.Dish_Id,
                Quantity = item.Quantity,
                Enable = true
            }).ToList();

            // Activar cuando la capa BusinessLogic ya este lista.
            /*
            SaleBusiness saleBusiness = new SaleBusiness();
            int resultado = saleBusiness.InsertCompleteSale(nuevaVenta, detalles);

            if (resultado != 0)
            {
                MessageBox.Show("No se pudo registrar la venta. Codigo: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

            // Simulacion temporal mientras conectamos BusinessLogic.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void TextBox_Enter(object sender, EventArgs e)
        {
            // Evaluamos si el elemento es un control válido
            if (sender is Control ctrl)
            {
                // Cambia a celeste claro marino al entrar
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                // Regresa a blanco al salir
                ctrl.BackColor = Color.White;
            }
        }

        private void SoloNumerosYDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && sender is TextBox txt && txt.Text.Contains("."))
                e.Handled = true;
        }
    }

}
