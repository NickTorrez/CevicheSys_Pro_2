using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Catálogo maestro utilizado para clasificar de manera estandarizada tanto los insumos como los gastos.
    /// </summary>
    public class Category
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Category_Id { get; set; }       // Id_Categoria (PK)
        public string Category_Name { get; set; }  // Nombre_Categoria
        public string Applied_Module { get; set; } // Modulo_Aplica ("Inventario" o "Gastos")
        public bool Enable { get; set; }           // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Category()
        {
            Category_Name = string.Empty;
            Applied_Module = string.Empty;
            Enable = true;
        }

        public Category(int categoryId, string categoryName, string appliedModule, bool enable = true)
        {
            Category_Id = categoryId;
            Category_Name = categoryName;
            Applied_Module = appliedModule;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        public List<Category> ListAllCategories()
        {
            var list = new List<Category>();
            string query = "SELECT Id_Categoria, Nombre_Categoria, Modulo_Aplica, Enable FROM Categoria WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Category(
                        Convert.ToInt32(row["Id_Categoria"]),
                        row["Nombre_Categoria"].ToString(),
                        row["Modulo_Aplica"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        public int AddCategory()
        {
            string query = "INSERT INTO Categoria (Nombre_Categoria, Modulo_Aplica, Enable) VALUES (@name, @module, @enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@name", this.Category_Name),
                new SqlParameter("@module", this.Applied_Module),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int UpdateCategory()
        {
            string query = "UPDATE Categoria SET Nombre_Categoria = @name, Modulo_Aplica = @module WHERE Id_Categoria = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", this.Category_Id),
                new SqlParameter("@name", this.Category_Name),
                new SqlParameter("@module", this.Applied_Module)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableCategory(int id)
        {
            string query = "UPDATE Categoria SET Enable = 0 WHERE Id_Categoria = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }
}