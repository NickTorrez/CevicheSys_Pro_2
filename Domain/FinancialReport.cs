using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class FinancialReport
    {
        private DateTime _startDate;
        private DateTime _endDate;

        /// <summary>
        /// Constructor que inicializa el filtro de tiempo del reporte.
        /// </summary>
        /// <param name="startDate">Fecha desde donde inicia el filtro.</param>
        /// <param name="endDate">Fecha límite del filtro.</param>
        public FinancialReport(DateTime startDate, DateTime endDate)
        {
            _startDate = startDate.Date;
            _endDate = endDate.Date.AddDays(1).AddTicks(-1);
        }

        /* ===================================================================== */
        /* 1. PANELES NUMÉRICOS PRINCIPALES                                      */
        /* ===================================================================== */

        public double CalculateTotalIncome()
        {
            string query = "SELECT ISNULL(SUM(Total_Pagar), 0) FROM Venta WHERE Fecha_Registro BETWEEN @start AND @end";
            using var select = new SelectQuery();
            object result = select.ExecuteScalar(query, new[] {
                new SqlParameter("@start", _startDate),
                new SqlParameter("@end", _endDate)
            });
            return Convert.ToDouble(result);
        }

        public double CalculateTotalExpenses()
        {
            string query = "SELECT ISNULL(SUM(Monto), 0) FROM Gasto WHERE Fecha BETWEEN @start AND @end";
            using var select = new SelectQuery();
            object result = select.ExecuteScalar(query, new[] {
                new SqlParameter("@start", _startDate),
                new SqlParameter("@end", _endDate)
            });
            return Convert.ToDouble(result);
        }

        public double CalculateTotalProfit()
        {
            return CalculateTotalIncome() - CalculateTotalExpenses();
        }

        /* ===================================================================== */
        /* 2. PANELES ANALÍTICOS SECUNDARIOS                                     */
        /* ===================================================================== */

        /// <summary>
        /// Delega el análisis a SQL Server usando TOP 1, JOIN y GROUP BY para encontrar el platillo más vendido.
        /// </summary>
        public Dish GetMostSoldDish()
        {
            string query = @"
                SELECT TOP 1 p.Id_Platillo, p.Tipo_Platillo, p.Tamaño, p.Precio, p.Disponibilidad
                FROM Detalle_Venta d
                INNER JOIN Venta v ON d.Id_Venta = v.Id_Venta
                INNER JOIN Platillo p ON d.Id_Platillo = p.Id_Platillo
                WHERE v.Fecha_Registro BETWEEN @start AND @end
                GROUP BY p.Id_Platillo, p.Tipo_Platillo, p.Tamaño, p.Precio, p.Disponibilidad
                ORDER BY SUM(d.Cantidad) DESC";

            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query, new[] {
                new SqlParameter("@start", _startDate),
                new SqlParameter("@end", _endDate)
            });

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new Dish
                {
                    Dish_Id = Convert.ToInt32(row["Id_Platillo"]),
                    Dish_Type = row["Tipo_Platillo"].ToString(),
                    Size = row["Tamaño"].ToString(),
                    Price = Convert.ToDouble(row["Precio"]),
                    Availability = Convert.ToBoolean(row["Disponibilidad"])
                };
            }

            return null; // En caso de que no existan ventas en ese periodo
        }

        /// <summary>
        /// Encuentra el concepto de gasto más recurrente directamente mediante agrupación SQL.
        /// </summary>
        public string GetMostFrequentExpense()
        {
            string query = @"
                SELECT TOP 1 Concepto
                FROM Gasto
                WHERE Fecha BETWEEN @start AND @end
                GROUP BY Concepto
                ORDER BY COUNT(*) DESC";

            using var select = new SelectQuery();
            object result = select.ExecuteScalar(query, new[] {
                new SqlParameter("@start", _startDate),
                new SqlParameter("@end", _endDate)
            });

            return result != null && result != DBNull.Value ? result.ToString() : "Sin registros";
        }

        /* ===================================================================== */
        /* 3. HISTORIAL DE VENTAS DETALLADO (Combinación Multi-Tabla 3NF)        */
        /* ===================================================================== */

        /// <summary>
        /// Extrae la auditoría completa cruzando 5 tablas relacionales en una sola petición a la base de datos.
        /// </summary>
        public List<DetailedSaleDTO> GetSalesHistory()
        {
            var historyList = new List<DetailedSaleDTO>();

            // El JOIN incorpora la tabla Cliente de acuerdo a la Tercera Forma Normal (3NF)
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
                WHERE v.Fecha_Registro BETWEEN @start AND @end
                ORDER BY v.Fecha_Registro DESC";

            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query, new[] {
                new SqlParameter("@start", _startDate),
                new SqlParameter("@end", _endDate)
            });

            foreach (DataRow row in dt.Rows)
            {
                historyList.Add(new DetailedSaleDTO
                {
                    Sale_Id = Convert.ToInt32(row["Id_Venta"]),
                    Date = Convert.ToDateTime(row["Fecha_Registro"]),
                    Customer = row["Nombre_Completo"].ToString(),
                    Dish_Type = row["Tipo_Platillo"].ToString(),
                    Size = row["Tamaño"].ToString(),
                    Price = Convert.ToDouble(row["Precio"]),
                    Quantity = Convert.ToInt32(row["Cantidad"]),
                    Total_Amount = Convert.ToDouble(row["Total_Calculado"]),
                    Payment_Method = row["Metodo_Pago"].ToString(),
                    Purchase_Type = row["Tipo_Compra"].ToString(),
                    Auditor_User = row["Nombre_Usuario"].ToString()
                });
            }

            return historyList;
        }
    }

    /// <summary>
    /// Estructura DTO diseñada exclusivamente para formatear automáticamente las columnas del DataGridView.
    /// </summary>
    public class DetailedSaleDTO
    {
        public int Sale_Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Dish_Type { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total_Amount { get; set; }
        public string Payment_Method { get; set; }
        public string Purchase_Type { get; set; }
        public string Auditor_User { get; set; }
    }
}