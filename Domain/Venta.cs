using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Venta
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _id_Venta;
        private string _nombre_Cliente;
        private string _metodo_Pago; // Efectivo o Tarjeta
        private string _tipo_Compra; // Local o Delivery
        private double _total_Pagar;
        private DateTime _fecha_Registro;
        private int _id_Usuario; // Llave Foránea de quien procesa la venta

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Id_Venta { get => _id_Venta; set => _id_Venta = value; }
        public string Nombre_Cliente { get => _nombre_Cliente; set => _nombre_Cliente = value; }
        public string Metodo_Pago { get => _metodo_Pago; set => _metodo_Pago = value; }
        public string Tipo_Compra { get => _tipo_Compra; set => _tipo_Compra = value; }
        public double Total_Pagar { get => _total_Pagar; set => _total_Pagar = value; }
        public DateTime Fecha_Registro { get => _fecha_Registro; set => _fecha_Registro = value; }
        public int Id_Usuario { get => _id_Usuario; set => _id_Usuario = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Venta()
        {
            _nombre_Cliente = string.Empty;
            _metodo_Pago = string.Empty;
            _tipo_Compra = string.Empty;
            _fecha_Registro = DateTime.Now;
        }

        public Venta(int id, string nombreCliente, string metodoPago, string tipoCompra, double totalPagar, DateTime fechaRegistro, int idUsuario)
        {
            _id_Venta = id;
            _nombre_Cliente = nombreCliente;
            _metodo_Pago = metodoPago;
            _tipo_Compra = tipoCompra;
            _total_Pagar = totalPagar;
            _fecha_Registro = fechaRegistro;
            _id_Usuario = idUsuario;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "ventas.json");

        public static List<Venta> Listar() // Lee el archivo JSON y devuelve la lista de ventas, si el archivo no existe devuelve una lista vacía
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Venta>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Venta>>(json) ?? new List<Venta>();
        }

        /// <summary>
        /// Guarda una venta y procesa sus líneas de detalle correspondientes disminuyendo el inventario.
        /// </summary>
        public bool GuardarConDetalles(List<DetalleVenta> detalles) 
        {
            List<Venta> listaVentas = Listar();

            // 1. Asignar ID autoincremental a la cabecera de la Venta
            if (this.Id_Venta == 0)
            {
                this.Id_Venta = listaVentas.Count > 0 ? listaVentas.Max(v => v.Id_Venta) + 1 : 1; // Nuevo registro
                listaVentas.Add(this);// Agrega la nueva venta a la lista
            }
            else
            {
                int index = listaVentas.FindIndex(v => v.Id_Venta == this.Id_Venta); // Actualización de venta existente
                if (index != -1) listaVentas[index] = this;// Reemplaza la venta existente con los nuevos datos
            }

            // Guardar archivo maestro de Ventas
            string jsonVentas = JsonSerializer.Serialize(listaVentas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, jsonVentas);

            // 2. Guardar los detalles asignándoles el Id_Venta recién generado
            foreach (var detalle in detalles)
            {
                detalle.Id_Venta = this.Id_Venta;
                detalle.Guardar();

                // 3. DESCUENTO AUTOMÁTICO DE STOCK POR RECETA
                // Busca qué insumos y qué cantidades utiliza el platillo vendido
                List<Receta> insumosReceta = Receta.ObtenerInsumosPorPlatillo(detalle.Id_Platillo);
                List<Producto> inventarioGlobal = Producto.Listar();

                foreach (var insumo in insumosReceta)
                {
                    // Localiza el producto físico en inventory.json
                    var productoEnStock = inventarioGlobal.FirstOrDefault(p => p.Id_Producto == insumo.Id_Producto);
                    if (productoEnStock != null)
                    {
                        // Descuento = Cantidad de la receta * cantidad de platillos ordenados
                        double cantidadADescontar = insumo.Cantidad_Utilizada * detalle.Cantidad;
                        productoEnStock.Stock_Actual -= cantidadADescontar;

                        // Guardar la actualización del producto individual en la lista
                        productoEnStock.Guardar();
                    }
                }
            }

            return true;
        }

        public static bool Eliminar(int id)
        {
            List<Venta> lista = Listar();
            int index = lista.FindIndex(v => v.Id_Venta == id);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }
    }
}