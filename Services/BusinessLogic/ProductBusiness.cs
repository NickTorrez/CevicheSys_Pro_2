using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Gestiona el catálogo de insumos, stock y su ciclo de vida (CRUD) en el inventario.
    /// </summary>
    public class ProductBusiness
    {
        private readonly string _connectionString;

        public ProductBusiness(string connectionString) => _connectionString = connectionString;

        public List<Product> ObtainAllProducts()
        {
            var list = new List<Product>();
            string query = "SELECT Id_Producto, Nombre, Id_Proveedor, Id_Categoria, Stock_Actual, Minimum_Stock, Fecha_Vencimiento, Enable FROM Producto WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Product(
                            Convert.ToInt32(r["Id_Producto"]),
                            r["Nombre"].ToString(),
                            Convert.ToInt32(r["Id_Proveedor"]),
                            Convert.ToInt32(r["Id_Categoria"]),
                            Convert.ToDouble(r["Stock_Actual"]),
                            Convert.ToDouble(r["Minimum_Stock"]),
                            r["Fecha_Vencimiento"] != DBNull.Value ? Convert.ToDateTime(r["Fecha_Vencimiento"]) : (DateTime?)null,
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }

        public List<Product> GetLowStockProducts() => ObtainAllProducts().FindAll(p => p.RequiresRestock());

        public bool RegisterProduct(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));

            string query = @"INSERT INTO Producto (Nombre, Id_Proveedor, Id_Categoria, Stock_Actual, Minimum_Stock, Fecha_Vencimiento, Enable) 
                             VALUES (@name, @provId, @catId, @stock, @min, @exp, @enable)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", product.Product_Name);
                cmd.Parameters.AddWithValue("@provId", product.Supplier_Id); 
                cmd.Parameters.AddWithValue("@catId", product.Category_Id);
                cmd.Parameters.AddWithValue("@stock", product.Current_Stock);
                cmd.Parameters.AddWithValue("@min", product.Minimum_Stock);
                cmd.Parameters.AddWithValue("@exp", product.Expiration_Date.HasValue ? (object)product.Expiration_Date.Value : DBNull.Value);
                cmd.Parameters.AddWithValue("@enable", product.Enable);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModifyProduct(Product product)
        {
            if (product == null || product.Product_Id <= 0) throw new ArgumentException("Producto inválido.");

            string query = @"UPDATE Producto SET Nombre = @name, Id_Proveedor = @provId, Id_Categoria = @catId, 
                             Stock_Actual = @stock, Minimum_Stock = @min, Fecha_Vencimiento = @exp WHERE Id_Producto = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", product.Product_Id);
                cmd.Parameters.AddWithValue("@name", product.Product_Name);
                cmd.Parameters.AddWithValue("@provId", product.Supplier_Id);
                cmd.Parameters.AddWithValue("@catId", product.Category_Id);
                cmd.Parameters.AddWithValue("@stock", product.Current_Stock);
                cmd.Parameters.AddWithValue("@min", product.Minimum_Stock);
                cmd.Parameters.AddWithValue("@exp", product.Expiration_Date.HasValue ? (object)product.Expiration_Date.Value : DBNull.Value);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveProduct(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Producto SET Enable = 0 WHERE Id_Producto = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
