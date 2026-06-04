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
    public class CashClosureRepository
    {
        private readonly string _connectionString;
        public CashClosureRepository(string connectionString) => _connectionString = connectionString;

        public bool SaveClosure(Cash_Closure closure)
        {
            string query = "INSERT INTO Cierre_Caja (Fecha_Cierre, Efectivo_Real, Ingresos_Calculados, Descuadre, Enable) VALUES (@date, @real, @calc, @disc, @enable)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@date", closure.Closure_Date);
                cmd.Parameters.AddWithValue("@real", closure.Real_Cash);
                cmd.Parameters.AddWithValue("@calc", closure.Calculated_Income);
                cmd.Parameters.AddWithValue("@disc", closure.Cash_Discrepancy);
                cmd.Parameters.AddWithValue("@enable", closure.Enable);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
