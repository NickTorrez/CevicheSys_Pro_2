using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(string connectionString) => _connectionString = connectionString;

        public List<Product> GetAll()
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

        public bool UpdateStock(int productId, double newStock)
        {
            string query = "UPDATE Producto SET Stock_Actual = @stock WHERE Id_Producto = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@stock", newStock);
                cmd.Parameters.AddWithValue("@id", productId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
