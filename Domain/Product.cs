using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Product
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _product_Id;
        private string _product_Name;
        private int _supplier_Id;   // Llave Foránea hacia Supplier
        private int _category_Id;   // Llave Foránea hacia Category
        private double _current_Stock; // Usamos double por si manejas libras/fracciones (Ej: 2.5 kg de pescado)
        private double _minimum_Stock; // Umbral personalizado para disparar alertas de stock bajo
        private DateTime? _expiration_Date; // Nullable (?) para productos no perecederos

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Product_Id { get => _product_Id; set => _product_Id = value; }
        public string Product_Name { get => _product_Name; set => _product_Name = value; }
        public int Supplier_Id { get => _supplier_Id; set => _supplier_Id = value; }
        public int Category_Id { get => _category_Id; set => _category_Id = value; }
        public double Current_Stock { get => _current_Stock; set => _current_Stock = value; }
        public double Minimum_Stock { get => _minimum_Stock; set => _minimum_Stock = value; }
        public DateTime? Expiration_Date { get => _expiration_Date; set => _expiration_Date = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Product()
        {
            _product_Name = string.Empty;
        }

        public Product(int id, string productName, int supplierId, int categoryId, double currentStock, double minimumStock, DateTime? expirationDate)
        {
            _product_Id = id;
            _product_Name = productName;
            _supplier_Id = supplierId;
            _category_Id = categoryId;
            _current_Stock = currentStock;
            _minimum_Stock = minimumStock;
            _expiration_Date = expirationDate;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "inventory.json");

        public static List<Product> List()
        {
            // Garantiza la existencia segura de la carpeta Data antes de leer/escribir
            string directory = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            if (!File.Exists(PathArchivo)) return new List<Product>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public bool Save()
        {
            List<Product> list = List();

            if (this.Product_Id == 0)
            {
                this.Product_Id = list.Count > 0 ? list.Max(p => p.Product_Id) + 1 : 1;
                list.Add(this);
            }
            else
            {
                int index = list.FindIndex(p => p.Product_Id == this.Product_Id);
                if (index != -1) list[index] = this;
            }

            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Delete(int id)
        {
            List<Product> list = List();
            int index = list.FindIndex(p => p.Product_Id == id);
            if (index != -1)
            {
                list.RemoveAt(index);
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }

        /* ===================================================================== */
        /* MÉTODOS DE CONTROL OPERATIVO (ALERTAS)                                */
        /* ===================================================================== */

        // Alerta de Stock Bajo: Filtra productos cuya existencia está en o por debajo del mínimo establecido
        public static List<Product> GetLowStockAlerts()
        {
            return List().Where(p => p.Current_Stock <= p.Minimum_Stock).ToList();
        }

        // Alerta de Frescura: Filtra productos próximos a vencer según un margen de días (Por defecto 3 días)
        public static List<Product> GetUpcomingExpirations(int marginDays = 3)
        {
            return List()
                .Where(p => p.Expiration_Date.HasValue &&
                            p.Expiration_Date.Value.Date >= DateTime.Today &&
                            (p.Expiration_Date.Value.Date - DateTime.Today).TotalDays <= marginDays)
                .ToList();
        }
    }

}
