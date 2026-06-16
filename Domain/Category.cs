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
        public int Category_Id { get; set; }
        public string Category_Name { get; set; }
        public string Target_Module { get; set; } // Ejemplo: "Inventario", "Gastos"
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa una categoría vacía.
        /// </summary>
        public Category()
        {
            Category_Name = string.Empty;
            Target_Module = string.Empty;
            Enable = true;
        }

        /// <summary>
        /// Inicializa una categoría completa.
        /// </summary>
        public Category(int categoryId, string categoryName, string targetModule, bool enable = true)
        {
            Category_Id = categoryId;
            Category_Name = categoryName;
            Target_Module = targetModule;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Retorna todas las categorías activas en el sistema.
        /// </summary>
        public List<Category> ListAllCategories()
        {
            List<Category> list = new List<Category>();
            string query = "SELECT Category_Id, Category_Name, Target_Module, Enable FROM Category WHERE Enable = 1";

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Category(
                        Convert.ToInt32(row["Category_Id"]),
                        row["Category_Name"].ToString(),
                        row["Target_Module"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }

            return list;
        }

        /// <summary>
        /// Registra una nueva categoría en la base de datos.
        /// </summary>
        public int AddCategory()
        {
            string query = "INSERT INTO Category (Category_Name, Target_Module, Enable) VALUES (@name, @module, @enable)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@name", Category_Name),
                new SqlParameter("@module", Target_Module),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
        }

        /// <summary>
        /// Actualiza el nombre o módulo de una categoría existente.
        /// </summary>
        public int UpdateCategory()
        {
            string query = "UPDATE Category SET Category_Name = @name, Target_Module = @module WHERE Category_Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", Category_Id),
                new SqlParameter("@name", Category_Name),
                new SqlParameter("@module", Target_Module)
            };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }

        /// <summary>
        /// Desactiva una categoría (borrado lógico).
        /// </summary>
        public int DisableCategory(int id)
        {
            string query = "UPDATE Category SET Enable = 0 WHERE Category_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }
    }
}