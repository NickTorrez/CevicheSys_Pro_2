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
    public partial class FrmCierreCaja : Form
    {
        // Variables para los cálculos del sistema
        private decimal efectivoInicial = 1000.00m;
        private decimal totalVentasEfectivo = 0m;
        private decimal totalCambiosDados = 0m;
        private decimal ingresosCalculados = 0m;
        private decimal efectivoReal = 0m;
        private decimal descuadre = 0m;
        private readonly CultureInfo cultura = new CultureInfo("es-NI");

        public FrmCierreCaja()
        {
            InitializeComponent();
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            // Temporal: luego estos datos vendran desde ventas del dia.
            totalVentasEfectivo = 4500.00m;
            totalCambiosDados = 320.00m;

            // Ojo: usa esta formula solo si totalVentasEfectivo representa efectivo recibido bruto.
            ingresosCalculados = (efectivoInicial + totalVentasEfectivo) - totalCambiosDados;

            lblEfectivoInicial.Text = efectivoInicial.ToString("C2", cultura);
            lblTotalVentasEfectivo.Text = totalVentasEfectivo.ToString("C2", cultura);
            lblCambiosEntregados.Text = totalCambiosDados.ToString("C2", cultura);
            lblIngresosCalculados.Text = ingresosCalculados.ToString("C2", cultura);

            txtEfectivoReal.MaxLength = 12;
            txtObservaciones.MaxLength = 0;
            txtEfectivoReal.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            lblDescuadre.Text = "Descuadre: C$ 0.00";
            lblDescuadre.ForeColor = Color.Black;
            txtEfectivoReal.Focus();
        }

        // Evento: Se dispara mientras el usuario va tecleando el dinero que contó
        private void txtEfectivoReal_TextChanged(object sender, EventArgs e)
        {
            CalcularDescuadreFisico();
        }

        private void CalcularDescuadreFisico()
        {
            if (string.IsNullOrWhiteSpace(txtEfectivoReal.Text))
            {
                descuadre = 0m;
                lblDescuadre.Text = "Descuadre: C$ 0.00";
                lblDescuadre.ForeColor = Color.Black;
                return;
            }

            if (decimal.TryParse(txtEfectivoReal.Text, out efectivoReal))
            {
                descuadre = efectivoReal - ingresosCalculados;
                lblDescuadre.Text = $"Descuadre: {descuadre.ToString("C2", cultura)}";

                if (descuadre < 0)
                    lblDescuadre.ForeColor = Color.Red;
                else if (descuadre > 0)
                    lblDescuadre.ForeColor = Color.Blue;
                else
                    lblDescuadre.ForeColor = Color.DarkGreen;
            }
            else
            {
                lblDescuadre.Text = "Monto invalido";
                lblDescuadre.ForeColor = Color.Red;
            }
        }

        private void btnRegistrarCierre_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEfectivoReal.Text) || !decimal.TryParse(txtEfectivoReal.Text, out efectivoReal))
            {
                MessageBox.Show("Por favor, ingrese un monto valido en el conteo fisico.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (efectivoReal < 0)
            {
                MessageBox.Show("El efectivo real no puede ser negativo.", "Error de Logica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (descuadre < 0)
            {
                DialogResult confirmacion = MessageBox.Show(
                    $"Hay un faltante en caja de {Math.Abs(descuadre).ToString("C2", cultura)}.\n\nDesea registrar el cierre?",
                    "Confirmar Faltante",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No)
                    return;
            }

            CashClosure nuevoCierre = new CashClosure
            {
                User_Id = Session.ActiveUser != null ? Session.ActiveUser.User_Id : 1,
                Closure_Date = DateTime.Now,
                Initial_Cash = efectivoInicial,
                Calculated_Income = ingresosCalculados,
                Real_Cash = efectivoReal,
                Notes_Remarks = txtObservaciones.Text.Trim(),
                Cash_Discrepancy = efectivoReal - ingresosCalculados,
                Enable = true
            };

            // Activar cuando BusinessLogic este conectado.
            /*
            CashClosureBusiness closureBusiness = new CashClosureBusiness();
            int resultado = closureBusiness.InsertClosure(nuevoCierre);

            if (resultado != 0)
            {
                MessageBox.Show("No se pudo registrar el cierre. Codigo: " + resultado, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */

            MessageBox.Show("Cierre de caja calculado y registrado exitosamente.", "Arqueo Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void SoloNumerosYDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
                e.Handled = true;

            if (e.KeyChar == '.' && sender is TextBox txt && txt.Text.Contains("."))
                e.Handled = true;
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
    }
}
