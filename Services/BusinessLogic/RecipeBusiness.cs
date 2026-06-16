using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class RecipeBusiness
    {
        #region Propiedades
        private readonly Recipe _recipe;
        #endregion

        #region Constructores
        public RecipeBusiness()
        {
            _recipe = new Recipe();
        }
        #endregion

        #region Métodos
        public int InsertRecipe(Recipe newRecipe)
        {
            try
            {
                if (newRecipe == null) return 1;
                if (newRecipe.Dish_Id <= 0) return 2;
                if (newRecipe.Product_Id <= 0) return 3;
                if (newRecipe.Quantity_Used <= 0) return 4;

                newRecipe.Enable = true;
                return newRecipe.AddRecipe() > 0 ? 0 : 5;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la lógica de inserción de la receta.", ex);
            }
        }

        public int DisableRecipe(int recipeId)
        {
            try
            {
                if (recipeId <= 0) return 1;
                return _recipe.DisableRecipe(recipeId) > 0 ? 0 : 5;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al inhabilitar la receta seleccionada.", ex);
            }
        }
        #endregion
    }
}
