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
    /// Procesador de arqueo de caja. Permite crear cierres y visualizar el historial.
    /// </summary>
    public class CashClosureBusiness
    {
        private readonly string _connectionString;

        public CashClosureBusiness(string connectionString) => _connectionString = connectionString;

        public List<Cash_Closure> ObtainAllClosures()
        {
            var list = new List<Cash_Closure>();
            string query = "SELECT Id_Cierre, Fecha_Cierre, Efectivo_Real, Ingresos_Calculados, Descuadre, Enable FROM Cierre_Caja WHERE Enable = 1 ORDER BY Fecha_Cierre DESC";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Cash_Closure(
                            Convert.ToInt32(r["Id_Cierre"]),
                            Convert.ToDateTime(r["Fecha_Cierre"]),
                            Convert.ToDouble(r["Efectivo_Real"]),
                            Convert.ToDouble(r["Ingresos_Calculados"]),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }

        public bool PerformDailyClosure(double realCashCounted)
        {
            DateTime today = DateTime.Today;
            DateTime endOfDay = today.AddDays(1).AddTicks(-1);
            double systemIncome = 0;

            string queryIncome = "SELECT ISNULL(SUM(Total_Pagar), 0) FROM Venta WHERE Fecha_Registro BETWEEN @start AND @end AND Enable = 1";
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmdIncome = new SqlCommand(queryIncome, conn))
                {
                    cmdIncome.Parameters.AddWithValue("@start", today);
                    cmdIncome.Parameters.AddWithValue("@end", endOfDay);
                    conn.Open();
                    systemIncome = Convert.ToDouble(cmdIncome.ExecuteScalar());
                }

                var closure = new Cash_Closure(0, DateTime.Now, realCashCounted, systemIncome);

                string queryInsert = "INSERT INTO Cierre_Caja (Fecha_Cierre, Efectivo_Real, Ingresos_Calculados, Descuadre, Enable) VALUES (@date, @real, @calc, @disc, @enable)";
                using (var cmdInsert = new SqlCommand(queryInsert, conn))
                {
                    cmdInsert.Parameters.AddWithValue("@date", closure.Closure_Date);
                    cmdInsert.Parameters.AddWithValue("@real", closure.Real_Cash);
                    cmdInsert.Parameters.AddWithValue("@calc", closure.Calculated_Income);
                    cmdInsert.Parameters.AddWithValue("@disc", closure.Cash_Discrepancy);
                    cmdInsert.Parameters.AddWithValue("@enable", closure.Enable);
                    return cmdInsert.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
