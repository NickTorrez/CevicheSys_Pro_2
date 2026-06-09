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
    public partial class FrmCierreCaja : Form
    {
        // Variables para los cálculos del sistema
        private double efectivoInicial = 1000.00; // Simulación: Fondo de caja (Suelto para dar vuelto en la mañana)
        private double totalVentasEfectivo = 0;
        private double totalCambiosDados = 0;
        private double ingresosCalculados = 0;    // Lo que el sistema ESPERA que haya

        // Variables para el arqueo manual
        private double efectivoReal = 0;          // Lo que el usuario CUENTA con las manos
        private double descuadre = 0;

        public FrmCierreCaja()
        {
            InitializeComponent();
        }

        private void FrmCierreCaja_Load(object sender, EventArgs e)
        {
            // --- 1. SIMULACIÓN DE DATOS DEL SISTEMA ---
            // (En el futuro, esto lo traerás de tu base de datos sumando las ventas del día)
            totalVentasEfectivo = 4500.00; // Simulación de lo vendido
            totalCambiosDados = 320.00;    // Simulación de los vueltos entregados

            // --- 2. CÁLCULO MATEMÁTICO DEL SISTEMA ---
            // Fórmula: (Efectivo con el que inicié + Lo que vendí) - Lo que di de vuelto
            ingresosCalculados = (efectivoInicial + totalVentasEfectivo) - totalCambiosDados;

            // --- 3. MOSTRAR EN PANTALLA (Solo Lectura) ---
            lblEfectivoInicial.Text = $"C$ {efectivoInicial:F2}";
            lblTotalVentasEfectivo.Text = $"C$ {totalVentasEfectivo:F2}";
            lblCambiosEntregados.Text = $"C$ {totalCambiosDados:F2}";
            lblIngresosCalculados.Text = $"C$ {ingresosCalculados:F2}";

            // --- 4. PREPARAR INTERFAZ MANUAL ---
            txtEfectivoReal.Text = string.Empty;
            txtObservaciones.Text = string.Empty;
            lblDescuadre.Text = "Descuadre: C$ 0.00";
            lblDescuadre.ForeColor = Color.Black;

            txtEfectivoReal.Focus(); // Cursor listo para escribir el dinero contado
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
                lblDescuadre.Text = "Descuadre: C$ 0.00";
                lblDescuadre.ForeColor = Color.Black;
                return;
            }

            // Convertimos lo tecleado a número
            if (double.TryParse(txtEfectivoReal.Text, out efectivoReal))
            {
                // REGLA DE NEGOCIO (Aplicando tu 3NF en memoria)
                // Fórmula del descuadre: Efectivo Físico - Ingresos Calculados
                descuadre = efectivoReal - ingresosCalculados;

                lblDescuadre.Text = $"Descuadre: C$ {descuadre:F2}";

                // Coloreamos dinámicamente según el estado de la caja
                if (descuadre < 0)
                {
                    lblDescuadre.ForeColor = Color.Red; // FALTANTE (Peligro)
                }
                else if (descuadre > 0)
                {
                    lblDescuadre.ForeColor = Color.Blue; // SOBRANTE (Anomalía)
                }
                else
                {
                    lblDescuadre.ForeColor = Color.DarkGreen; // EXACTO (Caja perfecta)
                }
            }
            else
            {
                lblDescuadre.Text = "Monto inválido";
                lblDescuadre.ForeColor = Color.Red;
            }
        }

        private void btnRegistrarCierre_Click(object sender, EventArgs e)
        {
            // 1. Validaciones previas
            if (string.IsNullOrWhiteSpace(txtEfectivoReal.Text) || !double.TryParse(txtEfectivoReal.Text, out efectivoReal))
            {
                MessageBox.Show("Por favor, ingrese un monto válido en el conteo físico.", "Dato Requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (efectivoReal < 0)
            {
                MessageBox.Show("El efectivo real no puede ser un número negativo.", "Error de Lógica", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Alerta de seguridad si la caja reporta faltante
            if (descuadre < 0)
            {
                var confirmacion = MessageBox.Show($"¡Atención! Hay un FALTANTE en caja de C$ {Math.Abs(descuadre):F2}.\n\n¿Está seguro de registrar el cierre con este descuadre?",
                                              "Confirmar Faltante", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirmacion == DialogResult.No) return;
            }

            // 3. Preparación de Entidad para la Base de Datos (Mapeo a tu Capa Domain)
            /*
            CashClosure nuevoCierre = new CashClosure
            {
                Date = DateTime.Now,
                Calculated_Income = ingresosCalculados,
                Real_Cash = efectivoReal,
                Observations = txtObservaciones.Text.Trim(),
                // Se asocia al usuario que tiene la sesión abierta
                User_Id = Session.ActiveUser != null ? Session.ActiveUser.User_Id : 1 
            };

            // 4. Llamada a la Capa Services
            CashClosureBusiness closureBusiness = new CashClosureBusiness();
            int resultado = closureBusiness.InsertClosure(nuevoCierre);

            if (resultado == 0)
            {
                MessageBox.Show("Cierre de caja registrado exitosamente.", "Arqueo Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Ocurrió un error al intentar guardar el cierre en la base de datos.", "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            // --- SIMULACIÓN DE GUARDADO (Quita esto cuando conectes la BD) ---
            MessageBox.Show("Cierre de caja calculado y registrado exitosamente (Modo Simulación).", "Arqueo Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
