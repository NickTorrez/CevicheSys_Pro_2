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
    public class DishRepository
    {
        private readonly string _connectionString;
        public DishRepository(string connectionString) => _connectionString = connectionString;

        public List<Dish> GetAvailableDishes()
        {
            var list = new List<Dish>();
            string query = "SELECT Id_Platillo, Tipo_Platillo, Tamaño, Precio, Is_Available, Enable FROM Platillo WHERE Enable = 1 AND Is_Available = 1";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Dish(
                            Convert.ToInt32(r["Id_Platillo"]),
                            r["Tipo_Platillo"].ToString(),
                            r["Tamaño"].ToString(),
                            Convert.ToDouble(r["Precio"]),
                            Convert.ToBoolean(r["Is_Available"]),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }
    }
}
