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
        public int Ingredient_Id { get; set; }
        public decimal Quantity { get; set; }
        public string Unit { get; set; } // Ejemplo: "g", "ml", "unidad"
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Recipe()
        {
            Unit = string.Empty;
            Enable = true;
        }

        public Recipe(int recipeId, int dishId, int ingredientId, decimal quantity, string unit, bool enable = true)
        {
            Recipe_Id = recipeId;
            Dish_Id = dishId;
            Ingredient_Id = ingredientId;
            Quantity = quantity;
            Unit = unit;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD                                                          */
        /* --------------------------------------------------------------------- */
        public int AddRecipe()
        {
            string query = "INSERT INTO Recipe (Dish_Id, Ingredient_Id, Quantity, Unit, Enable) VALUES (@dishId, @ingId, @qty, @unit, 1)";
            SqlParameter[] parameters = {
                new SqlParameter("@dishId", this.Dish_Id),
                new SqlParameter("@ingId", this.Ingredient_Id),
                new SqlParameter("@qty", this.Quantity),
                new SqlParameter("@unit", this.Unit)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int RemoveRecipe(int recipeId)
        {
            string query = "UPDATE Recipe SET Enable = 0 WHERE Recipe_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", recipeId) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }
}