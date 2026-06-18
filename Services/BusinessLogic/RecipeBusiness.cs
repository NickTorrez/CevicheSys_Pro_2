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
        private readonly Recipe _recipeDomain;
        #endregion

        #region Constructores
        public RecipeBusiness()
        {
            _recipeDomain = new Recipe();
        }
        #endregion

        #region Métodos
        public int InsertRecipe(Recipe newRecipe)
        {
            if (newRecipe == null)
                throw new ArgumentNullException(nameof(newRecipe), "La receta está vacía.");

            if (newRecipe.Dish_Id <= 0)
                throw new ArgumentException("Debe seleccionar un platillo válido.");

            if (newRecipe.Product_Id <= 0)
                throw new ArgumentException("Debe seleccionar un producto (insumo) válido.");

            if (newRecipe.Quantity_Used <= 0)
                throw new ArgumentException("La cantidad utilizada debe ser mayor a cero.");

            newRecipe.Enable = true;
            return newRecipe.AddRecipe();
        }

        public int DisableRecipe(int recipeId)
        {
            if (recipeId <= 0)
                throw new ArgumentException("Se requiere un ID de receta válido para inhabilitarla.");

            return _recipeDomain.DisableRecipe(recipeId);
        }
        #endregion
    }
}
