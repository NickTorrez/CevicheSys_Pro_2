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
    public partial class FrmCierreCaja : Form
    {
        // Instancia de la lógica de negocio para arqueos de caja
        private readonly CashClosureBusiness _cashClosureBusiness;

        // Variables de cálculo financiero interno
        private decimal _efectivoInicial = 1000.00m; // Valor base de apertura de caja estándar (C$)
        private decimal _ventasEfectivo = 0.00m;
        private decimal _ventasTransferencia = 0.00m;
        private decimal _cambiosEntregados = 0.00m;
        private decimal _ingresosCalculados = 0.00m;

        public FrmCierreCaja()
        {
            InitializeComponent();

            _cashClosureBusiness = new CashClosureBusiness();

            // Configuración restrictiva de ventana según diseño
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            AsignarEventosEstilo();
            CalcularValoresSistema();

            txtEfectivoReal.MaxLength = 12;
            txtObservaciones.MaxLength = 0;
            txtEfectivoReal.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            lblDescuadre.Text = "Descuadre: C$ 0.00";
            lblDescuadre.ForeColor = Color.Black;
            txtEfectivoReal.Focus();
        }

        #region Regla de Estilos (Enter / Leave)
        private void AsignarEventosEstilo()
        {
            // Asignamos el comportamiento visual a los cuadros de entrada manual
            Control[] controlesManuales = new Control[] { txtEfectivoReal, txtObservaciones };

            foreach (var ctrl in controlesManuales)
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

        #region Motor de Cálculo Financiero (Automático)
        private void CalcularValoresSistema()
        {
            try
            {
                // En un escenario de producción, aquí invocarías a SaleBusiness para sumar las ventas del día actual.
                // Simulamos la consolidación de la jornada basada en transacciones registradas:
                _ventasEfectivo = 4550.00m;
                _ventasTransferencia = 1200.00m;
                _cambiosEntregados = 350.00m;

                // FÓRMULA ANALÍTICA: Ingreso Calculado = Efectivo Inicial + Ventas Efectivo - Cambios
                // Nota: Las transferencias van directo al banco, el efectivo físico esperado en caja se calcula así:
                _ingresosCalculados = _efectivoInicial + _ventasEfectivo - _cambiosEntregados;

                // Renderizamos los resultados en los labels correspondientes del gbCierreAutomatico
                lblEfectivoInicial.Text = $"C$ {_efectivoInicial:N2}";
                lblTotalVentasEfectivo.Text = $"C$ {_ventasEfectivo:N2}";
                lblTotalVentasTransferencia.Text = $"C$ {_ventasTransferencia:N2}";
                lblCambiosEntregados.Text = $"C$ {_cambiosEntregados:N2}";
                lblIngresosCalculados.Text = $"C$ {_ingresosCalculados:N2}";

                // Inicializamos los valores por defecto del módulo manual
                lblDescuadre.Text = "C$ 0.00";
                lblDescuadre.ForeColor = Color.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fallo al consolidar auditoría de montos automáticos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Análisis de Descuadre en Tiempo Real (Manual)
        // Evento: Se dispara mientras el usuario va tecleando el dinero que contó
        private void txtEfectivoReal_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtEfectivoReal.Text.Trim(), out decimal efectivoReal))
            {
                // FÓRMULA DE TU ARQUITECTURA (Domain): Descuadre = Real - Calculado
                decimal descuadre = efectivoReal - _ingresosCalculados;

                lblDescuadre.Text = $"C$ {descuadre:N2}";

                if (descuadre == 0)
                {
                    lblDescuadre.ForeColor = Color.DarkGreen; // Caja cuadrada perfecta
                }
                else if (descuadre < 0)
                {
                    lblDescuadre.ForeColor = Color.Red; // Faltante de dinero
                }
                else
                {
                    lblDescuadre.ForeColor = Color.Blue; // Sobrante de dinero
                }
            }
            else
            {
                lblDescuadre.Text = "C$ 0.00";
                lblDescuadre.ForeColor = Color.Black;
            }
        }
        #endregion


        #region Persistencia del Arqueo de Caja
        private void btnRegistrarCierre_Click(object sender, EventArgs e)
        {
            // Validaciones obligatorias de UI
            if (string.IsNullOrWhiteSpace(txtEfectivoReal.Text))
            {
                MessageBox.Show("Debe ingresar el monto de efectivo real contado físicamente en caja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEfectivoReal.Focus();
                return;
            }

            if (!decimal.TryParse(txtEfectivoReal.Text.Trim(), out decimal efectivoRealNum) || efectivoRealNum < 0)
            {
                MessageBox.Show("El monto de efectivo real proporcionado no es un número válido.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Instanciamos el objeto de dominio CashClosure mapeando los controles
                CashClosure arqueoCaja = new CashClosure
                {
                    User_Id = 1, // Aquí asignarías el ID del usuario/cajero autenticado en el sistema
                    Closure_Date = DateTime.Now,
                    Initial_Cash = _efectivoInicial,
                    Calculated_Income = _ingresosCalculados,
                    Real_Cash = efectivoRealNum,
                    Notes_Remarks = txtObservaciones.Text.Trim(),
                    Enable = true
                };

                // 2. Ejecutamos la lógica de negocio. Tu método devuelve un int (el ID del cierre)
                // e internamente calcula y valida los datos antes de hacer el insert SQL
                int idCierreGenerado = _cashClosureBusiness.InsertClosure(arqueoCaja);

                MessageBox.Show($"Arqueo de caja finalizado exitosamente.\nCierre de jornada N° {idCierreGenerado} registrado.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // Captura mensajes detallados de tus validaciones de negocio (montos negativos, etc.)
                MessageBox.Show($"Error de Negocio: {ex.Message}", "Validación de Arqueo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Desea salir del arqueo de caja? Los datos ingresados se perderán.", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        #endregion
    }
}
