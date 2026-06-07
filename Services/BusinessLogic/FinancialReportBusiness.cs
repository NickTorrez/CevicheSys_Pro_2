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
    /// Consolida todas las sentencias SQL de analítica para construir el modelo FinancialReport completo.
    /// </summary>
    public class FinancialReportBusiness
    {
        private readonly string _connectionString;

        public FinancialReportBusiness(string connectionString) => _connectionString = connectionString;

        public FinancialReport GenerateReport(DateTime startDate, DateTime endDate)
        {
            var report = new FinancialReport(startDate, endDate);

            using (var conn = new SqlConnection(_connectionString))
            {
                conn.Open();

                // 1. Obtener Ingresos Totales
                using (var cmd = new SqlCommand("SELECT ISNULL(SUM(Total_Pagar), 0) FROM Venta WHERE Fecha_Registro BETWEEN @start AND @end AND Enable = 1", conn))
                {
                    cmd.Parameters.AddWithValue("@start", report.StartDate);
                    cmd.Parameters.AddWithValue("@end", report.EndDate);
                    report.TotalIncome = Convert.ToDouble(cmd.ExecuteScalar());
                }

                // 2. Obtener Gastos Totales
                using (var cmd = new SqlCommand("SELECT ISNULL(SUM(Monto), 0) FROM Gasto WHERE Fecha_Gasto BETWEEN @start AND @end AND Enable = 1", conn))
                {
                    cmd.Parameters.AddWithValue("@start", report.StartDate);
                    cmd.Parameters.AddWithValue("@end", report.EndDate);
                    report.TotalExpenses = Convert.ToDouble(cmd.ExecuteScalar());
                }

                // 3. Obtener Platillo Más Vendido
                string qDish = @"SELECT TOP 1 p.Id_Platillo, p.Tipo_Platillo, p.Tamaño, p.Precio, p.Is_Available
                                 FROM Detalle_Venta d
                                 INNER JOIN Venta v ON d.Id_Venta = v.Id_Venta
                                 INNER JOIN Platillo p ON d.Id_Platillo = p.Id_Platillo
                                 WHERE v.Fecha_Registro BETWEEN @start AND @end AND v.Enable = 1
                                 GROUP BY p.Id_Platillo, p.Tipo_Platillo, p.Tamaño, p.Precio, p.Is_Available
                                 ORDER BY SUM(d.Cantidad) DESC";
                using (var cmd = new SqlCommand(qDish, conn))
                {
                    cmd.Parameters.AddWithValue("@start", report.StartDate);
                    cmd.Parameters.AddWithValue("@end", report.EndDate);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            report.MostSoldDish = new Dish(
                                Convert.ToInt32(reader["Id_Platillo"]),
                                reader["Tipo_Platillo"].ToString(),
                                reader["Tamaño"].ToString(),
                                Convert.ToDouble(reader["Precio"]),
                                Convert.ToBoolean(reader["Is_Available"])
                            );
                        }
                    }
                }

                // 4. Obtener Gasto Frecuente
                using (var cmd = new SqlCommand("SELECT TOP 1 Descripcion FROM Gasto WHERE Fecha_Gasto BETWEEN @start AND @end AND Enable = 1 GROUP BY Descripcion ORDER BY COUNT(*) DESC", conn))
                {
                    cmd.Parameters.AddWithValue("@start", report.StartDate);
                    cmd.Parameters.AddWithValue("@end", report.EndDate);
                    object res = cmd.ExecuteScalar();
                    report.MostFrequentExpense = res != null && res != DBNull.Value ? res.ToString() : "Sin registros";
                }

                // 5. Historial Detallado 3NF
                string qHistory = @"SELECT v.Id_Venta, v.Fecha_Registro, c.Nombre_Completo, p.Tipo_Platillo, p.Tamaño, p.Precio, 
                                    d.Cantidad, (p.Precio * d.Cantidad) AS Total_Calculado, v.Metodo_Pago, v.Tipo_Compra, u.Nombre_Usuario
                                    FROM Detalle_Venta d
                                    INNER JOIN Venta v ON d.Id_Venta = v.Id_Venta
                                    INNER JOIN Platillo p ON d.Id_Platillo = p.Id_Platillo
                                    INNER JOIN Usuario u ON v.Id_Usuario = u.Id_Usuario
                                    INNER JOIN Cliente c ON v.Id_Cliente = c.Id_Cliente
                                    WHERE v.Fecha_Registro BETWEEN @start AND @end AND v.Enable = 1
                                    ORDER BY v.Fecha_Registro DESC";
                using (var cmd = new SqlCommand(qHistory, conn))
                {
                    cmd.Parameters.AddWithValue("@start", report.StartDate);
                    cmd.Parameters.AddWithValue("@end", report.EndDate);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            report.SalesHistory.Add(new DetailedSaleDTO
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
            }

            return report;
        }
    }
}
