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
        #region Propiedades
        public int Recipe_Id { get; set; }
        public int Dish_Id { get; set; }
        public int Product_Id { get; set; }
        public decimal Quantity_Used { get; set; }
        public bool Enable { get; set; }
        #endregion

        #region Constructores
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
        #endregion

        #region Métodos
        public int AddRecipe()
        {
            string sql = @"INSERT INTO Recipe (Dish_Id, Product_Id, Quantity_Used, Enable) 
                           VALUES (@dishId, @productId, @quantity, @enable)";

            SqlParameter[] parameters = {
                new SqlParameter("@dishId", SqlDbType.Int) { Value = Dish_Id },
                new SqlParameter("@productId", SqlDbType.Int) { Value = Product_Id },
                new SqlParameter("@quantity", SqlDbType.Decimal) { Value = Quantity_Used },
                new SqlParameter("@enable", SqlDbType.Bit) { Value = Enable }
            };

            using InsertCommand insert = new InsertCommand();
            return insert.ExecuteInsert(sql, parameters);
        }

        public int DisableRecipe(int recipeId)
        {
            string sql = "UPDATE Recipe SET Enable = @enable WHERE Recipe_Id = @id";

            SqlParameter[] parameters = {
                new SqlParameter("@id", SqlDbType.Int) { Value = recipeId },
                new SqlParameter("@enable", SqlDbType.Bit) { Value = false }
            };

            using UpdateCommand update = new UpdateCommand();
            return update.ExecuteUpdate(sql, parameters);
        }
        #endregion
    }
}