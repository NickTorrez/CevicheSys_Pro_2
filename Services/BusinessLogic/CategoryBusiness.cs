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
    /// Provee el ciclo CRUD para administrar las clasificaciones operativas del negocio (Gastos/Inventario).
    /// </summary>
    public class CategoryBusiness
    {
        private readonly string _connectionString;

        public CategoryBusiness(string connectionString) => _connectionString = connectionString;

        public List<Category> ObtainAllCategories()
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

        public List<Category> GetInventoryCategories() => ObtainAllCategories().FindAll(c => c.Applied_Module == "Inventario");
        public List<Category> GetExpenseCategories() => ObtainAllCategories().FindAll(c => c.Applied_Module == "Gastos");

        public bool RegisterCategory(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            if (string.IsNullOrWhiteSpace(category.Category_Name)) throw new ArgumentException("El nombre de categoría es obligatorio.");

            string query = "INSERT INTO Categoria (Nombre_Categoria, Modulo_Aplica, Enable) VALUES (@name, @mod, @enable)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@name", category.Category_Name);
                cmd.Parameters.AddWithValue("@mod", category.Applied_Module);
                cmd.Parameters.AddWithValue("@enable", category.Enable);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModifyCategory(Category category)
        {
            if (category == null || category.Category_Id <= 0) throw new ArgumentException("Categoría inválida.");

            string query = "UPDATE Categoria SET Nombre_Categoria = @name, Modulo_Aplica = @mod WHERE Id_Categoria = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", category.Category_Id);
                cmd.Parameters.AddWithValue("@name", category.Category_Name);
                cmd.Parameters.AddWithValue("@mod", category.Applied_Module);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveCategory(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Categoria SET Enable = 0 WHERE Id_Categoria = @id";
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
