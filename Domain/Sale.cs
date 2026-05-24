using CevicheSys_Pro_2.UI.Catalogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using static System.Collections.Specialized.BitVector32;
using CevicheSys_Pro_2.Helpers;

namespace CevicheSys_Pro_2
{
    public class Sale
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _sale_Id;
        private string _customer_Name;
        private string _payment_Method; // Efectivo o Tarjeta
        private string _purchase_Type;  // Local o Delivery
        private double _total_Amount;
        private DateTime _record_Date;
        private int _user_Id; // Llave Foránea de quien procesa la venta

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Sale_Id { get => _sale_Id; set => _sale_Id = value; }
        public string Customer_Name { get => _customer_Name; set => _customer_Name = value; }
        public string Payment_Method { get => _payment_Method; set => _payment_Method = value; }
        public string Purchase_Type { get => _purchase_Type; set => _purchase_Type = value; }
        public double Total_Amount { get => _total_Amount; set => _total_Amount = value; }
        public DateTime Record_Date { get => _record_Date; set => _record_Date = value; }
        public int User_Id { get => _user_Id; set => _user_Id = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Sale()
        {
            _customer_Name = string.Empty;
            _payment_Method = string.Empty;
            _purchase_Type = string.Empty;
            _record_Date = DateTime.Now;
        }

        public Sale(int id, string customerName, string paymentMethod, string purchaseType, double totalAmount, DateTime recordDate, int userId)
        {
            _sale_Id = id;
            _customer_Name = customerName;
            _payment_Method = paymentMethod;
            _purchase_Type = purchaseType;
            _total_Amount = totalAmount;
            _record_Date = recordDate;
            _user_Id = userId;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "sales.json");

        public static List<Sale> List() // Lee el archivo JSON y devuelve la lista de ventas, si el archivo no existe devuelve una lista vacía
        {
            string directorio = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directorio)) Directory.CreateDirectory(directorio);

            if (!File.Exists(PathArchivo)) return new List<Sale>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Sale>>(json) ?? new List<Sale>();
        }

        /// <summary>
        /// Guarda una venta y procesa sus líneas de detalle correspondientes disminuyendo el inventario.
        /// </summary>
        public bool SaveWithDetails(List<Sale_Detail> details) // Asegúrate de que tu clase DetalleVenta sea traducida como Sale_Detail
        {
            List<Sale> listaVentas = List();

            // 1. Asignar ID autoincremental a la cabecera de la Venta
            if (this.Sale_Id == 0)
            {
                this.Sale_Id = listaVentas.Count > 0 ? listaVentas.Max(v => v.Sale_Id) + 1 : 1; // Nuevo registro
                listaVentas.Add(this);// Agrega la nueva venta a la lista
            }
            else
            {
                int index = listaVentas.FindIndex(v => v.Sale_Id == this.Sale_Id); // Actualización de venta existente
                if (index != -1) listaVentas[index] = this;// Reemplaza la venta existente con los nuevos datos
            }

            // Guardar archivo maestro de Ventas
            string jsonVentas = JsonSerializer.Serialize(listaVentas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, jsonVentas);

            // 2. Guardar los detalles asignándoles el Sale_Id recién generado
            foreach (var detalle in details)
            {
                detalle.Sale_Id = this.Sale_Id;
                detalle.Save();

                // 3. DESCUENTO AUTOMÁTICO DE STOCK POR RECETA
                // Busca qué insumos y qué cantidades utiliza el platillo vendido
                List<Recipe> insumosReceta = Recipe.GetIngredientsByDish(detalle.Dish_Id);
                List<Product> inventarioGlobal = Product.List();

                foreach (var insumo in insumosReceta)
                {
                    // Localiza el producto físico en inventory.json
                    var productoEnStock = inventarioGlobal.FirstOrDefault(p => p.Product_Id == insumo.Product_Id);
                    if (productoEnStock != null)
                    {
                        // Descuento = Cantidad de la receta * cantidad de platillos ordenados
                        double cantidadADescontar = insumo.Quantity_Used * detalle.Quantity;
                        productoEnStock.Current_Stock -= cantidadADescontar;

                        // Guardar la actualización del producto individual en la lista
                        productoEnStock.Save();
                    }
                }
            }

            return true;
        }

        public static bool Delete(int id)
        {
            List<Sale> lista = List();
            int index = lista.FindIndex(v => v.Sale_Id == id);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Anula una venta del registro. SOLO PERMITIDO PARA ADMINISTRADORES.
        /// </summary>
        public static bool VoidSaleWithError(int saleIdToVoid)
        {
            // 1. BLINDAJE DE SEGURIDAD ABSOLUTA (Asegúrate de que 'Sesion' también esté traducida a 'Session')
            if (Session.ActiveUser == null || Session.ActiveUser.Role != "Admin")
            {
                // Lanza una excepción que puedes atrapar en tu Form para mostrar un MessageBox de error
                throw new UnauthorizedAccessException("Acceso denegado: Solo el Administrador puede anular ventas. El vendedor debe solicitar autorización.");
            }

            List<Sale> lista = List();
            int index = lista.FindIndex(v => v.Sale_Id == saleIdToVoid);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);

                // NOTA: Para mantener la integridad absoluta, aquí deberías idealmente 
                // revertir el stock de los productos descontados, llamando a la lógica inversa 
                // de SaveWithDetails(). Si no lo haces, la venta se borra pero el stock se pierde.

                return true;
            }
            return false;
        }
    }
}