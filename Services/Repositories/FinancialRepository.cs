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
    /// <summary>
    /// Repositorio encargado de ejecutar las consultas SQL pesadas y agrupaciones analíticas para los reportes.
    /// </summary>
    public class FinancialRepository
    {
        private readonly string _connectionString;

        public FinancialRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public double GetTotalIncome(DateTime start, DateTime end)
        {
            string query = "SELECT ISNULL(SUM(Total_Pagar), 0) FROM Venta WHERE Fecha_Registro BETWEEN @start AND @end AND Enable = 1";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                conn.Open();
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        public double GetTotalExpenses(DateTime start, DateTime end)
        {
            string query = "SELECT ISNULL(SUM(Monto), 0) FROM Gasto WHERE Fecha_Gasto BETWEEN @start AND @end AND Enable = 1";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                conn.Open();
                return Convert.ToDouble(cmd.ExecuteScalar());
            }
        }

        public Dish GetMostSoldDish(DateTime start, DateTime end)
        {
            string query = @"
                SELECT TOP 1 p.Id_Platillo, p.Tipo_Platillo, p.Tamaño, p.Precio, p.Is_Available
                FROM Detalle_Venta d
                INNER JOIN Venta v ON d.Id_Venta = v.Id_Venta
                INNER JOIN Platillo p ON d.Id_Platillo = p.Id_Platillo
                WHERE v.Fecha_Registro BETWEEN @start AND @end AND v.Enable = 1
                GROUP BY p.Id_Platillo, p.Tipo_Platillo, p.Tamaño, p.Precio, p.Is_Available
                ORDER BY SUM(d.Cantidad) DESC";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Dish(
                            Convert.ToInt32(reader["Id_Platillo"]),
                            reader["Tipo_Platillo"].ToString(),
                            reader["Tamaño"].ToString(),
                            Convert.ToDouble(reader["Precio"]),
                            Convert.ToBoolean(reader["Is_Available"])
                        );
                    }
                }
            }
            return null;
        }

        public string GetMostFrequentExpenseDescription(DateTime start, DateTime end)
        {
            string query = @"
                SELECT TOP 1 Descripcion
                FROM Gasto
                WHERE Fecha_Gasto BETWEEN @start AND @end AND Enable = 1
                GROUP BY Descripcion
                ORDER BY COUNT(*) DESC";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                conn.Open();
                object result = cmd.ExecuteScalar();
                return result != null && result != DBNull.Value ? result.ToString() : "Sin registros";
            }
        }

        public List<DetailedSaleDTO> GetSalesHistory(DateTime start, DateTime end)
        {
            var historyList = new List<DetailedSaleDTO>();
            string query = @"
                SELECT 
                    v.Id_Venta, 
                    v.Fecha_Registro, 
                    c.Nombre_Completo, 
                    p.Tipo_Platillo, 
                    p.Tamaño, 
                    p.Precio, 
                    d.Cantidad, 
                    (p.Precio * d.Cantidad) AS Total_Calculado, 
                    v.Metodo_Pago, 
                    v.Tipo_Compra, 
                    u.Nombre_Usuario
                FROM Detalle_Venta d
                INNER JOIN Venta v ON d.Id_Venta = v.Id_Venta
                INNER JOIN Platillo p ON d.Id_Platillo = p.Id_Platillo
                INNER JOIN Usuario u ON v.Id_Usuario = u.Id_Usuario
                INNER JOIN Cliente c ON v.Id_Cliente = c.Id_Cliente
                WHERE v.Fecha_Registro BETWEEN @start AND @end AND v.Enable = 1
                ORDER BY v.Fecha_Registro DESC";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        historyList.Add(new DetailedSaleDTO
                        {
                            Sale_Id = Convert.ToInt32(reader["Id_Venta"]),
                            Date = Convert.ToDateTime(reader["Fecha_Registro"]),
                            Customer = reader["Nombre_Completo"].ToString(),
                            Dish_Type = reader["Tipo_Platillo"].ToString(),
                            Size = reader["Tamaño"].ToString(),
                            Price = Convert.ToDouble(reader["Precio"]),
                            Quantity = Convert.ToInt32(reader["Cantidad"]),
                            Total_Amount = Convert.ToDouble(reader["Total_Calculado"]),
                            Payment_Method = reader["Metodo_Pago"].ToString(),
                            Purchase_Type = reader["Tipo_Compra"].ToString(),
                            Auditor_User = reader["Nombre_Usuario"].ToString()
                        });
                    }
                }
            }
            return historyList;

        }
    }
}
