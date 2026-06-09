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
    public partial class FrmFacturacion : Form
    {
        // Variables para recibir los datos desde el Punto de Venta
        private List<DetailedSaleDTO> carrito;
        private double totalAPagar;
        private double montoEntregado = 0;
        private double cambio = 0;

        // Modificamos el constructor para que reciba el carrito y el total
        public FrmFacturacion(List<DetailedSaleDTO> carritoCompras, double totalAPagar)
        {
            InitializeComponent();
            this.carrito = carritoCompras;
            this.totalAPagar = totalAPagar;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            // 1. Mostrar el total con formato de moneda
            lblTotalPagar.Text = $"Total a Pagar: C$ {totalAPagar:F2}";

            // 2. Llenar los ComboBox si no lo hiciste en diseño
            if (cmbTipoCompra.Items.Count == 0)
            {
                cmbTipoCompra.Items.AddRange(new string[] { "Local", "Delivery" });
            }
            if (cmbMetodoPago.Items.Count == 0)
            {
                cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Tarjeta" });
            }

            // 3. Valores por defecto para agilizar la venta
            cmbTipoCompra.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            txtNombreCliente.Text = "Cliente Mostrador";
            txtMontoEntregado.Text = "";
            txtMontoEntregado.Focus(); // Pone el cursor directo para escribir el billete
        }

        // Evento: Cuando el cajero cambia entre Efectivo o Tarjeta
        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMetodoPago.SelectedItem.ToString() == "Transferencia")
            {
                // Si es tarjeta, pagan exacto y no hay vuelto
                txtMontoEntregado.Enabled = false;
                txtMontoEntregado.Text = totalAPagar.ToString("F2");
                lblCambio.Text = "Cambio: C$ 0.00";
                lblCambio.ForeColor = Color.Black;
                cambio = 0;
            }
            else
            {
                // Si es efectivo, habilitamos el campo para que digite
                txtMontoEntregado.Enabled = true;
                txtMontoEntregado.Text = "";
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
                return;
            }

            // Intentamos convertir el texto a número (Double)
            if (double.TryParse(txtMontoEntregado.Text, out montoEntregado))
            {
                cambio = montoEntregado - totalAPagar;

                if (cambio < 0)
                {
                    // Si falta dinero, lo ponemos en rojo
                    lblCambio.Text = $"Faltan: C$ {Math.Abs(cambio):F2}";
                    lblCambio.ForeColor = Color.Red;
                }
                else
                {
                    // Si sobra dinero (vuelto), lo ponemos en verde
                    lblCambio.Text = $"Cambio: C$ {cambio:F2}";
                    lblCambio.ForeColor = Color.DarkGreen;
                }
            }
            else
            {
                lblCambio.Text = "Monto inválido";
                lblCambio.ForeColor = Color.Red;
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // --- 1. VALIDACIONES ---
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbMetodoPago.SelectedItem.ToString() == "Efectivo" && cambio < 0)
            {
                MessageBox.Show("El monto entregado es menor al total a pagar. Revise el efectivo.", "Falta Dinero", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. PREPARAR DATOS (Simulación de Guardado) ---
            // Actualizamos la lista del carrito con los datos del cliente para pasárselo a la Capa Services
            foreach (var item in carrito)
            {
                item.Customer = txtNombreCliente.Text;
                item.Payment_Method = cmbMetodoPago.SelectedItem.ToString();
                item.Purchase_Type = cmbTipoCompra.SelectedItem.ToString();
            }

            // NOTA PARA EL FUTURO:
            // Aquí llamarás a "VentaBusiness.InsertarVenta(carrito)"
            // Aquí generarás el PDF con iTextSharp.

            // --- 3. FINALIZAR CON ÉXITO ---
            // Le decimos al FrmPuntoVenta que la ventana modal terminó con éxito (DialogResult.OK)
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Cancelar aborta la operación y regresa al Punto de Venta sin borrar el carrito
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
    
}
