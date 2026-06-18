using CevicheSys_Pro_2.Helpers;
using CevicheSys_Pro_2.Services.BusinessLogic;
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
        // Propiedades e instancias del estado de la transacción
        private readonly List<DetailedSaleDTO> _carritoCompras;
        private readonly decimal _totalPagar;
        private readonly SaleBusiness _saleBusiness; // Suponiendo que tienes tu controlador de ventas


        // Modificamos el constructor para que reciba el carrito y el total
        public FrmFacturacion(List<DetailedSaleDTO> carritoCompras, decimal totalPagar)
        {
            InitializeComponent();
            // Inyección de dependencias de datos desde el punto de venta
            _carritoCompras = carritoCompras ?? new List<DetailedSaleDTO>();
            _totalPagar = totalPagar;
            _saleBusiness = new SaleBusiness();

            // Configuración nativa del diálogo
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void FrmFacturacion_Load(object sender, EventArgs e)
        {
            AsignarEventosEstilo();
            CargarMetodosYTipos();

            // Inicializar la UI con el total transferido
            lblTotalPagar.Text = $"C$ {_totalPagar:N2}";
            lblCambio.Text = "C$ 0.00";

            // Por defecto, ocultar o deshabilitar el cálculo si no se ha elegido efectivo
            pnlEfectivo.Enabled = false;

            if (cmbTipoCompra.Items.Count == 0)
                cmbTipoCompra.Items.AddRange(new string[] { "Local", "Delivery" });

            if (cmbMetodoPago.Items.Count == 0)
                cmbMetodoPago.Items.AddRange(new string[] { "Efectivo", "Transferencia" });

            cmbTipoCompra.SelectedIndex = 0;
            cmbMetodoPago.SelectedIndex = 0;
            txtNombreCliente.Text = "Cliente Mostrador";
            txtMontoEntregado.Text = string.Empty;
            txtMontoEntregado.MaxLength = 12;
            txtNombreCliente.MaxLength = 100;
            txtTelefono.MaxLength = 20;
            txtMontoEntregado.Focus();
        }

        #region Regla de Estilos (Enter / Leave)
        private void AsignarEventosEstilo()
        {
            // Vinculamos todos los controles dentro del GroupBox y paneles
            Control[] controles = new Control[]
            {
                txtNombreCliente, txtTelefono, cmbTipoCompra,
                cmbMetodoPago, txtMontoEntregado
            };

            foreach (var ctrl in controles)
            {
                if (ctrl != null)
                {
                    ctrl.Enter += InputControl_Enter;
                    ctrl.Leave += InputControl_Leave;
                }
            }
        }

        private void InputControl_Enter(object sender, EventArgs e)
        {
            if (sender is Control ctrl) ctrl.BackColor = Color.FromArgb(227, 242, 253);
        }

        private void InputControl_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl) ctrl.BackColor = Color.White;
        }
        #endregion

        #region Inicialización de Catálogos de Venta
        private void CargarMetodosYTipos()
        {
            // Carga manual o estática según las políticas de tu negocio
            cmbTipoCompra.Items.Clear();
            cmbTipoCompra.Items.Add("Consumo Local");
            cmbTipoCompra.Items.Add("Para Llevar");
            cmbTipoCompra.SelectedIndex = 0;

            cmbMetodoPago.Items.Clear();
            cmbMetodoPago.Items.Add("Efectivo");
            cmbMetodoPago.Items.Add("Tarjeta de Crédito/Débito");
            cmbMetodoPago.Items.Add("Transferencia Bancaria");
            cmbMetodoPago.SelectedIndex = 0;
        }

        private void cmbMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            // El panel de efectivo solo se activa si el método seleccionado es "Efectivo"
            if (cmbMetodoPago.SelectedItem != null && cmbMetodoPago.SelectedItem.ToString() == "Efectivo")
            {
                pnlEfectivo.Enabled = true;
                txtMontoEntregado.Focus();
            }
            else
            {
                pnlEfectivo.Enabled = false;
                txtMontoEntregado.Clear();
                lblCambio.Text = "C$ 0.00";
            }
        }
        #endregion

        #region Lógica Transaccional y Cálculo Analítico
        private void txtMontoEntregado_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtMontoEntregado.Text.Trim(), out decimal montoEntregado))
            {
                if (montoEntregado >= _totalPagar)
                {
                    decimal cambio = montoEntregado - _totalPagar;
                    lblCambio.Text = $"C$ {cambio:N2}";
                    lblCambio.ForeColor = Color.DarkGreen;
                }
                else
                {
                    lblCambio.Text = "Monto insuficiente";
                    lblCambio.ForeColor = Color.Red;
                }
            }
            else
            {
                lblCambio.Text = "C$ 0.00";
                lblCambio.ForeColor = Color.Black;
            }
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            // Validaciones básicas de front-end
            if (cmbTipoCompra.SelectedIndex == -1 || cmbMetodoPago.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar el tipo de compra y método de pago.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si es efectivo, validar que pagó completo
            if (cmbMetodoPago.SelectedItem.ToString() == "Efectivo")
            {
                if (!decimal.TryParse(txtMontoEntregado.Text.Trim(), out decimal entregado) || entregado < _totalPagar)
                {
                    MessageBox.Show("El monto entregado es inválido o insuficiente para cubrir el total.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            try
            {
                // 1. Instanciamos la cabecera de la venta para persistencia en SQL Server
                Sale nuevaVenta = new Sale
                {
                    Customer_Id = null, // Puede mapearse si tienes catálogo de clientes
                    Payment_Method = cmbMetodoPago.SelectedItem.ToString(),
                    Purchase_Type = cmbTipoCompra.SelectedItem.ToString(),
                    Total_Amount = _totalPagar,
                    Record_Date = DateTime.Now,
                    User_Id = 1, // Aquí jalarías el ID del usuario logueado en el sistema
                    Enable = true
                };

                // 2. CONVERSIÓN CRÍTICA: Transformar List<DetailedSaleDTO> a List<SaleDetail>
                //capa SaleBusiness exige estrictamente SaleDetail para validar cantidades e IDs de platillos
                List<SaleDetail> detallesEntidad = new List<SaleDetail>();

                foreach (var itemDto in _carritoCompras)
                {
                    SaleDetail detalle = new SaleDetail
                    {
                        // Buscamos mapear el ID del platillo. 
                        
                        Dish_Id = itemDto.Dish_Id,
                        Quantity = itemDto.Quantity,
                        Enable = true
                    };
                    detallesEntidad.Add(detalle);
                }

                // 3. LLAMADA CORREGIDA: Usamos el método real 'InsertCompleteSale' de tu arquitectura
                int idVentaGenerada = _saleBusiness.InsertCompleteSale(nuevaVenta, detallesEntidad);

                // 4. Generación del comprobante físico/digital (Boucher PDF)
                GenerarBoucherPDF();

                MessageBox.Show($"Facturación completada con éxito. Venta N° {idVentaGenerada} registrada.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Retornamos OK para que FrmPuntoVenta sepa que debe limpiar el dgvCarrito
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Tu arquitectura lanza "throw new ArgumentException" o "Exception" si las validaciones fallan
                MessageBox.Show($"Error al procesar la transacción: {ex.Message}", "Error de Negocio", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea cancelar la facturación actual?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion

        #region Generador de Documentos Extensos (PDF Export)
        private void GenerarBoucherPDF()
        {
            try
            {
                // Aquí va la lógica de exportación utilizando librerías como iTextSharp o PDFsharp.
                // Como ejemplo nativo, puedes estructurar tu cadena del boucher:
                string nombreCliente = string.IsNullOrWhiteSpace(txtNombreCliente.Text) ? "Consumidor Final" : txtNombreCliente.Text.Trim();
                string telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? "N/A" : txtTelefono.Text.Trim();

                // Este método simula la creación física del PDF en tu carpeta de documentos
                // ... Código de renderizado de tablas para el PDF ...
            }
            catch (Exception ex)
            {
                throw new Exception($"Fallo al escribir el archivo digital PDF: {ex.Message}");
            }
        }
        #endregion

    }

}
