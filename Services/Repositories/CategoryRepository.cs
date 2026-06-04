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
    public class CategoryRepository
    {
        private readonly string _connectionString;
        public CategoryRepository(string connectionString) => _connectionString = connectionString;

        public List<Category> GetAll()
        {
            var list = new List<Category>();
            string query = "SELECT Id_Categoria, Nombre_Categoria, Modulo_Aplica, Enable FROM Categoria WHERE Enable = 1";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Category(
                            Convert.ToInt32(r["Id_Categoria"]),
                            r["Nombre_Categoria"].ToString(),
                            r["Modulo_Aplica"].ToString(),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }
    }
}
