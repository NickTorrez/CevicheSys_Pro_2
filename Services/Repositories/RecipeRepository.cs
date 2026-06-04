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
    public class RecipeRepository
    {
        private readonly string _connectionString;
        public RecipeRepository(string connectionString) => _connectionString = connectionString;

        public List<Recipe> GetRecipeByDish(int dishId)
        {
            var list = new List<Recipe>();
            string query = "SELECT Recipe_Id, Id_Platillo, Id_Producto, Quantity_Used, Enable FROM Receta WHERE Id_Platillo = @dishId AND Enable = 1";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@dishId", dishId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Recipe(
                            Convert.ToInt32(r["Recipe_Id"]),
                            Convert.ToInt32(r["Id_Platillo"]),
                            Convert.ToInt32(r["Id_Producto"]),
                            Convert.ToDouble(r["Quantity_Used"]),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }
    }
}
