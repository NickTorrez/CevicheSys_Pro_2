using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Category
    {
        // Campos privados 
        private int _category_Id;
        private string _category_Name;
        private string _applied_Module;

        // Propiedades públicas
        public int Category_Id { get => _category_Id; set => _category_Id = value; }
        public string Category_Name { get => _category_Name; set => _category_Name = value; }
        public string Applied_Module { get => _applied_Module; set => _applied_Module = value; }

        // Constructor sin parámetros (Útil para serialización JSON)
        public Category()
        {
            _category_Name = string.Empty;
            _applied_Module = string.Empty;
        }

        public Category(int id, string categoryName, string appliedModule)
        {
            _category_Id = id;
            _category_Name = categoryName;
            _applied_Module = appliedModule;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (Basados en el modelo de RRHH)                */
        /* --------------------------------------------------------------------- */

        public static List<Category> List()
        {
            var list = new List<Category>();
            string query = "SELECT Id_Categoria, Nombre_Categoria, Modulo_Aplica FROM Categoria";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Category
                {
                    Category_Id = Convert.ToInt32(row["Id_Categoria"]),
                    Category_Name = row["Nombre_Categoria"].ToString(),
                    Applied_Module = row["Modulo_Aplica"].ToString()
                });
            }
            return list;
        }

    }
}