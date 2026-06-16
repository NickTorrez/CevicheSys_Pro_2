using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Relación intermedia que asocia un Platillo con los insumos (Products) necesarios para su preparación.
    /// Es vital para realizar los descargos automatizados del inventario al vender.
    /// </summary>
    /// </summary>
    public class Recipe
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Recipe_Id { get; set; }
        public int Dish_Id { get; set; }
        public int Product_Id { get; set; }
        public decimal Quantity_Used { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Recipe()
        {
            Enable = true;
        }

        public Recipe(int recipeId, int dishId, int productId, decimal quantityUsed, bool enable = true)
        {
            Recipe_Id = recipeId;
            Dish_Id = dishId;
            Product_Id = productId;
            Quantity_Used = quantityUsed;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD                                                          */
        /* --------------------------------------------------------------------- */
        public int AddRecipe()
        {
            string query = @"INSERT INTO Recipe (Dish_Id, Product_Id, Quantity_Used, Enable)
                             VALUES (@dishId, @productId, @quantity, @enable)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@dishId", Dish_Id),
                new SqlParameter("@productId", Product_Id),
                new SqlParameter("@quantity", Quantity_Used),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
        }

        public int DisableRecipe(int recipeId)
        {
            string query = "UPDATE Recipe SET Enable = 0 WHERE Recipe_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", recipeId) };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }
    }
}