using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Controla el stock físico, procedencia y caducidad de las materias primas e insumos de la cevichería.
    /// </summary>
    public class Product
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Product_Id { get; set; }
        public string Product_Name { get; set; }
        public int? Supplier_Id { get; set; }          // Acepta nulos según la estructura SQL
        public int Category_Id { get; set; }
        public decimal Current_Stock { get; set; }     // Decimal para exactitud en pesos/libras
        public decimal Minimum_Stock { get; set; }
        public DateTime? Expiration_Date { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa un objeto de inventario vacío.
        /// </summary>
        public Product()
        {
            Product_Name = string.Empty;
            Current_Stock = 0m;
            Minimum_Stock = 0m;
            Enable = true;
        }

        /// <summary>
        /// Instancia un producto especificando todas sus relaciones foráneas y existencias.
        /// </summary>
        public Product(int productId, string productName, int? supplierId, int categoryId,
                       decimal currentStock, decimal minimumStock, DateTime? expirationDate, bool enable = true)
        {
            Product_Id = productId;
            Product_Name = productName;
            Supplier_Id = supplierId;
            Category_Id = categoryId;
            Current_Stock = currentStock;
            Minimum_Stock = minimumStock;
            Expiration_Date = expirationDate;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Reglas Operativas                                                     */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Evalúa si el producto físico ha alcanzado o caído por debajo del umbral mínimo de operación.
        /// </summary>
        public bool RequiresRestock()
        {
            return Current_Stock <= Minimum_Stock;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Retorna el catálogo completo de materia prima disponible.
        /// </summary>
        public List<Product> ListAllProducts()
        {
            List<Product> list = new List<Product>();
            string query = "SELECT Product_Id, Product_Name, Supplier_Id, Category_Id, Current_Stock, Minimum_Stock, Expiration_Date, Enable FROM Product WHERE Enable = 1";

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Product(
                        Convert.ToInt32(row["Product_Id"]),
                        row["Product_Name"].ToString(),
                        row["Supplier_Id"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["Supplier_Id"]),
                        Convert.ToInt32(row["Category_Id"]),
                        Convert.ToDecimal(row["Current_Stock"]),
                        row["Minimum_Stock"] == DBNull.Value ? 0m : Convert.ToDecimal(row["Minimum_Stock"]),
                        row["Expiration_Date"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Expiration_Date"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }

            return list;
        }

        /// <summary>
        /// Registra el ingreso de un nuevo artículo físico al almacén.
        /// </summary>
        public int AddProduct()
        {
            string query = @"INSERT INTO Product (Category_Id, Supplier_Id, Product_Name, Current_Stock, Minimum_Stock, Expiration_Date, Enable)
                             VALUES (@categoryId, @supplierId, @name, @stock, @expiration, @enable)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@categoryId", Category_Id),
                new SqlParameter("@supplierId", (object)Supplier_Id ?? DBNull.Value),
                new SqlParameter("@name", Product_Name),
                new SqlParameter("@stock", Current_Stock),
                new SqlParameter("@stock", Minimum_Stock),
                new SqlParameter("@expiration", (object)Expiration_Date ?? DBNull.Value),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
        }

        /// <summary>
        /// Modifica las propiedades del producto existente en inventario.
        /// </summary>
        public int UpdateProduct()
        {
            string query = @"UPDATE Product
                             SET Category_Id = @categoryId, Supplier_Id = @supplierId, Product_Name = @name,
                                 Current_Stock = @currentstock, Minimum_Stock = @minimumstock, Expiration_Date = @expiration
                             WHERE Product_Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", Product_Id),
                new SqlParameter("@categoryId", Category_Id),
                new SqlParameter("@supplierId", (object)Supplier_Id ?? DBNull.Value),
                new SqlParameter("@name", Product_Name),
                new SqlParameter("@currentstock", Current_Stock),
                new SqlParameter("@minimumstock", Minimum_Stock),
                new SqlParameter("@expiration", (object)Expiration_Date ?? DBNull.Value)
            };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }

        /// <summary>
        /// Elimina lógicamente el producto de las listas operativas.
        /// </summary>
        public int DisableProduct(int id)
        {
            string query = "UPDATE Product SET Enable = 0 WHERE Product_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }
    }

}
