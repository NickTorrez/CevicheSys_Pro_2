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
        // Instancia de negocio para traer los platillos del menú
        private readonly DishBusiness _dishBusiness;

        // Tabla en memoria que maneja los artículos agregados al carrito de compras
        private DataTable _dtCarrito;

        // Variable global para acumular el costo total del pedido
        private decimal _totalVenta = 0m;

        public FrmPuntoVenta()
        {
            InitializeComponent();
            _dishBusiness = new DishBusiness();

            // Comportamiento del formulario transaccional
            this.FormBorderStyle = FormBorderStyle.None;

            InicializarCarrito();
        }

        private void FrmPuntoVenta_Load(object sender, EventArgs e)
        {
            AsignarEventosEstilo();
            GenerarBotonesPlatillos();
        }

        #region Regla de Estilos y Eventos de Interfaz
        private void AsignarEventosEstilo()
        {
            // Asignación dinámica de eventos de color a los botones principales
            Control[] controlesConFoco = new Control[] { btnFinalizarVenta, btnCierreCaja };

            foreach (var ctrl in controlesConFoco)
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
            if (sender is Control ctrl)
            {
                ctrl.BackColor = Color.FromArgb(227, 242, 253);
            }
        }

        private void InputControl_Leave(object sender, EventArgs e)
        {
            if (sender is Control ctrl)
            {
                ctrl.BackColor = Color.White;
            }
        }
        #endregion

        #region Configuración y Lógica del Carrito de Ventas
        private void InicializarCarrito()
        {
            // Creamos la estructura exacta solicitada para mostrar en el dgvCarrito
            _dtCarrito = new DataTable();
            _dtCarrito.Columns.Add("Platillo", typeof(string));
            _dtCarrito.Columns.Add("Tamaño", typeof(string));
            _dtCarrito.Columns.Add("Cantidad", typeof(int));
            _dtCarrito.Columns.Add("Precio", typeof(decimal));
            _dtCarrito.Columns.Add("Subtotal", typeof(decimal)); // Columna auxiliar para el cálculo analítico

            dgvCarrito.DataSource = _dtCarrito;

            // Ajustes visuales nativos según el estándar de interfaz de usuario
            dgvCarrito.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Ocultar columna subtotal si se desea mantener estrictamente limpio el dgv
            if (dgvCarrito.Columns.Contains("Subtotal"))
                dgvCarrito.Columns["Subtotal"].Visible = false;

            ActualizarTotalUI();
        }

        private void ActualizarTotalUI()
        {
            _totalVenta = 0m;
            foreach (DataRow fila in _dtCarrito.Rows)
            {
                _totalVenta += Convert.ToDecimal(fila["Subtotal"]);
            }

            // Muestra el total formateado de todos los platillos seleccionados
            lblTotal.Text = $"C$ {_totalVenta:N2}";
        }
        #endregion

        #region Generador Dinámico de Menú (FlowLayoutPanel)
        private void GenerarBotonesPlatillos()
        {
            try
            {
                // Limpiar cualquier residuo de diseño previo
                flpPlatillos.Controls.Clear();

                // Consumimos el método real de tu arquitectura que conecta a la base de datos SQL Server
                DataTable dtPlatillosDisponibles = _dishBusiness.ListDishes();

                if (dtPlatillosDisponibles == null || dtPlatillosDisponibles.Rows.Count == 0)
                {
                    Label lblMensaje = new Label
                    {
                        Text = "No hay platillos disponibles registrados en el inventario.",
                        AutoSize = true,
                        ForeColor = Color.Red,
                        Font = new Font("Segoe UI", 11, FontStyle.Italic)
                    };
                    flpPlatillos.Controls.Add(lblMensaje);
                    return;
                }

                foreach (DataRow fila in dtPlatillosDisponibles.Rows)
                {
                    // Solo mapear platillos marcados como activos (Enable = true)
                    if (Convert.ToBoolean(fila["Enable"]))
                    {
                        string tipoPlatillo = fila["Dish_Type"].ToString();
                        string tamano = fila["Size"].ToString();
                        decimal precio = Convert.ToDecimal(fila["Price"]);

                        // Creación y estilización del botón dinámico que representará al platillo
                        Button btnPlatillo = new Button
                        {
                            Text = $"{tipoPlatillo}\n({tamano})\n{precio:C2}",
                            Width = 145,
                            Height = 110,
                            BackColor = Color.White,
                            FlatStyle = FlatStyle.Flat,
                            Font = new Font("Segoe UI", 10, FontStyle.Bold),
                            Cursor = Cursors.Hand,
                            Margin = new Padding(6)
                        };

                        // Almacenamos la fila completa en la propiedad Tag para extraerla velozmente en el clic
                        btnPlatillo.Tag = fila;

                        // Vinculamos el disparador del carrito de compras
                        btnPlatillo.Click += BtnPlatillo_Click;

                        // Efectos visuales de foco para los botones dinámicos
                        btnPlatillo.MouseEnter += (s, ev) => btnPlatillo.BackColor = Color.FromArgb(227, 242, 253);
                        btnPlatillo.MouseLeave += (s, ev) => btnPlatillo.BackColor = Color.White;

                        flpPlatillos.Controls.Add(btnPlatillo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error crítico al renderizar el menú interactivo: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Evento que se dispara cada vez que el usuario hace clic en el botón de un platillo
        /// </summary>
        /// 
        private void BtnPlatillo_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is DataRow datosPlatillo)
            {
                string platilloStr = datosPlatillo["Dish_Type"].ToString()!;
                string tamanoStr = datosPlatillo["Size"].ToString()!;
                decimal precioNum = Convert.ToDecimal(datosPlatillo["Price"]);

                // Buscamos si el platillo con ese tamaño exacto ya fue seleccionado previamente
                DataRow[] filasExistentes = _dtCarrito.Select($"Platillo = '{platilloStr.Replace("'", "''")}' AND Tamaño = '{tamanoStr.Replace("'", "''")}'");

                if (filasExistentes.Length > 0)
                {
                    // Si ya existe, incrementamos de forma aritmética la cantidad y recalculamos subtotal
                    int nuevaCantidad = Convert.ToInt32(filasExistentes[0]["Cantidad"]) + 1;
                    filasExistentes[0]["Cantidad"] = nuevaCantidad;
                    filasExistentes[0]["Subtotal"] = nuevaCantidad * precioNum;
                }
                else
                {
                    // Si es nuevo, añadimos la nueva tupla al dgvCarrito
                    DataRow nuevaFila = _dtCarrito.NewRow();
                    nuevaFila["Platillo"] = platilloStr;
                    nuevaFila["Tamaño"] = tamanoStr;
                    nuevaFila["Cantidad"] = 1;
                    nuevaFila["Precio"] = precioNum;
                    nuevaFila["Subtotal"] = precioNum; // 1 * precio

                    _dtCarrito.Rows.Add(nuevaFila);
                }

                ActualizarTotalUI();
            }
        }
        #endregion

        // --- BOTONES DE ACCIÓN ---
        private void btnFinalizarVenta_Click(object sender, EventArgs e)
        {
            if (_dtCarrito.Rows.Count == 0)
            {
                MessageBox.Show("El carrito de compras está vacío. Seleccione platillos para procesar la orden.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // 1. Mapeamos y convertimos las filas del DataTable de la UI al listado de DTOs requerido por el negocio
                List<DetailedSaleDTO> listaDetalle = new List<DetailedSaleDTO>();

                foreach (DataRow fila in _dtCarrito.Rows)
                {
                    DetailedSaleDTO detalleItem = new DetailedSaleDTO
                    {
                        // Mapea las propiedades nativas según tu clase DetailedSaleDTO
                        Dish_Id = Convert.ToInt32(fila["Dish_Id"]),
                        Dish_Type = fila["Platillo"].ToString(),
                        Size = fila["Tamaño"].ToString(),
                        Quantity = Convert.ToInt32(fila["Cantidad"]),
                        Price = Convert.ToDecimal(fila["Precio"])

                    };

                    listaDetalle.Add(detalleItem);
                }

                // 2. Inyectamos los argumentos requeridos ("carritoCompras" y el monto total) al constructor
                using (Form frmFactura = new FrmFacturacion(listaDetalle, _totalVenta))
                {
                    frmFactura.StartPosition = FormStartPosition.CenterParent;
                    DialogResult dr = frmFactura.ShowDialog();

                    if (dr == DialogResult.OK)
                    {
                        // Si la venta se procesó e imprimió con éxito, limpiamos el punto de venta
                        InicializarCarrito();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al transferir los datos a facturación: {ex.Message}", "Error de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCierreCaja_Click(object sender, EventArgs e)
        {
            // Instanciamos el Formulario de Arqueo de Caja según su restricción de diseño (FixedDialog)
            using (Form frmCierre = new FrmCierreCaja())
            {
                frmCierre.StartPosition = FormStartPosition.CenterParent;
                frmCierre.ShowDialog();
            }
        }

        private void dgvCarrito_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. BLINDAJE ULTRA-CRÍTICO: Si hacen clic en los títulos de las columnas (fila -1)
            // o el control de la fila actual está vacío, cancelamos la ejecución de inmediato.
            if (e.RowIndex < 0 || dgvCarrito.CurrentRow == null)
            {
                return;
            }

            try
            {
                // Obtener la fila seleccionada en el carrito de compras de forma segura
                DataGridViewRow filaCarrito = dgvCarrito.Rows[e.RowIndex];

                // 2. DETECCIÓN DE FILAS VACÍAS (Fila de edición nueva al final del DataGridView)
                // Si el DataGridView tiene habilitada la opción 'AllowUserToAddRows', la última fila está vacía.
                if (filaCarrito.IsNewRow)
                {
                    return;
                }

                // 3. EJEMPLO DE ACCIÓN: Si tienes una columna especial para eliminar el platillo del carrito
                // Supongamos que tu columna botón se llama "btnEliminarCol" o está en el índice 4
                if (dgvCarrito.Columns[e.ColumnIndex].Name == "btnEliminarCol")
                {
                    // Validamos que el nombre del platillo no sea nulo antes de mostrar el aviso
                    string platilloNombre = filaCarrito.Cells["Platillo"].Value?.ToString() ?? "Este platillo";

                    DialogResult result = MessageBox.Show($"¿Desea remover '{platilloNombre}' de la orden actual?", "Quitar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        // Removemos la fila del DataTable subyacente (_dtCarrito) para que se actualice la UI
                        // Usamos el enlace de datos nativo si aplica, o directo a la fila
                        if (filaCarrito.DataBoundItem is DataRowView drv)
                        {
                            drv.Row.Delete();
                        }
                        else
                        {
                            dgvCarrito.Rows.Remove(filaCarrito);
                        }

                        // RECALCULO SEGURO: Volvemos a sumar el total de la venta tras la eliminación
                        ActualizarTotalUI();
                    }
                }
            }
            catch (Exception ex)
            {
                // Captura cualquier anomalía de conversión de tipos sin congelar la pantalla del cajero
                MessageBox.Show($"Aviso de interfaz: {ex.Message}", "Punto de Venta", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
