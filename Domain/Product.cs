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
        public int Product_Id { get; set; }            // Id_Producto (PK)
        public string Product_Name { get; set; }       // Nombre
        public int Supplier_Id { get; set; }           // Id_Proveedor (FK)
        public int Category_Id { get; set; }           // Id_Categoria (FK)
        public double Current_Stock { get; set; }      // Stock_Actual (Manejado con double para libras/fracciones)
        public double Minimum_Stock { get; set; }      // Umbral para disparar alertas de stock bajo
        public DateTime? Expiration_Date { get; set; } // Fecha_Vencimiento (Nullable para productos no perecederos)
        public bool Enable { get; set; }               // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Product()
        {
            Product_Name = string.Empty;
            Current_Stock = 0.0;
            Minimum_Stock = 0.0;
            Enable = true;
        }

        public Product(int productId, string productName, int supplierId, int categoryId,
                       double currentStock, double minimumStock, DateTime? expirationDate, bool enable = true)
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
        public bool RequiresRestock()
        {
            return Current_Stock <= Minimum_Stock;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        public List<Product> ListAllProducts()
        {
            var list = new List<Product>();
            string query = "SELECT Id_Producto, Nombre_Producto, Id_Proveedor, Id_Categoria, Stock_Actual, Minimum_Stock, Fecha_Vencimiento, Enable FROM Producto WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Product(
                        Convert.ToInt32(row["Id_Producto"]),
                        row["Nombre_Producto"].ToString(),
                        Convert.ToInt32(row["Id_Proveedor"]),
                        Convert.ToInt32(row["Id_Categoria"]),
                        Convert.ToDouble(row["Stock_Actual"]),
                        Convert.ToDouble(row["Minimum_Stock"]),
                        row["Fecha_Vencimiento"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["Fecha_Vencimiento"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        public int AddProduct()
        {
            string query = @"INSERT INTO Producto (Nombre_Producto, Id_Proveedor, Id_Categoria, Stock_Actual, Minimum_Stock, Fecha_Vencimiento, Enable) 
                             VALUES (@name, @supId, @catId, @currStock, @minStock, @expDate, @enable)";

            SqlParameter[] parameters = {
                new SqlParameter("@name", this.Product_Name),
                new SqlParameter("@supId", this.Supplier_Id),
                new SqlParameter("@catId", this.Category_Id),
                new SqlParameter("@currStock", this.Current_Stock),
                new SqlParameter("@minStock", this.Minimum_Stock),
                new SqlParameter("@expDate", (object)this.Expiration_Date ?? DBNull.Value),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int UpdateProduct()
        {
            string query = @"UPDATE Producto SET Nombre_Producto = @name, Id_Proveedor = @supId, Id_Categoria = @catId, 
                             Stock_Actual = @currStock, Minimum_Stock = @minStock, Fecha_Vencimiento = @expDate WHERE Id_Producto = @id";

            SqlParameter[] parameters = {
                new SqlParameter("@id", this.Product_Id),
                new SqlParameter("@name", this.Product_Name),
                new SqlParameter("@supId", this.Supplier_Id),
                new SqlParameter("@catId", this.Category_Id),
                new SqlParameter("@currStock", this.Current_Stock),
                new SqlParameter("@minStock", this.Minimum_Stock),
                new SqlParameter("@expDate", (object)this.Expiration_Date ?? DBNull.Value)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableProduct(int id)
        {
            string query = "UPDATE Producto SET Enable = 0 WHERE Id_Producto = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }

}
