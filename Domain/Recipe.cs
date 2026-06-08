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
        public int Recipe_Id { get; set; }     // Identificador único de la receta
        public int Dish_Id { get; set; }       // Id_Platillo (FK)
        public int Product_Id { get; set; }    // Id_Producto (FK) 
        public double Quantity_Used { get; set; } // Cantidad exacta del insumo que consume el platillo 
        public bool Enable { get; set; }       // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Recipe()
        {
            Quantity_Used = 0.0;
            Enable = true;
        }

        public Recipe(int recipeId, int dishId, int productId, double quantityUsed, bool enable = true)
        {
            Recipe_Id = recipeId;
            Dish_Id = dishId;
            Product_Id = productId;
            Quantity_Used = quantityUsed;
            Enable = enable;
        }

        /*----------------------------------------------------------------------------------*/
        /* Métodos de Persistencia (CRUD)                                                   */
        /*----------------------------------------------------------------------------------*/

        public List<Recipe> GetRecipeByDish(int dishId)
        {
            var list = new List<Recipe>();
            string query = "SELECT Id_Receta, Id_Platillo, Id_Producto, Cantidad_Usada, Enable FROM Receta WHERE Id_Platillo = @dishId AND Enable = 1";
            SqlParameter[] parameters = { new SqlParameter("@dishId", dishId) };

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Recipe(
                        Convert.ToInt32(row["Id_Receta"]),
                        Convert.ToInt32(row["Id_Platillo"]),
                        Convert.ToInt32(row["Id_Producto"]),
                        Convert.ToDouble(row["Cantidad_Usada"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }
    }
}