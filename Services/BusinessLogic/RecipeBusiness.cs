using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class RecipeBusiness
    {
        private readonly Recipe recipe = new Recipe();

        public int InsertRecipe(Recipe newRecipe)
        {
            if (newRecipe == null) return 1;
            if (newRecipe.Dish_Id <= 0) return 2;
            if (newRecipe.Ingredient_Id <= 0) return 3;
            if (newRecipe.Quantity <= 0) return 4;
            if (string.IsNullOrWhiteSpace(newRecipe.Unit)) return 4;

            newRecipe.Unit = newRecipe.Unit.Trim();
            newRecipe.Enable = true;

            return newRecipe.AddRecipe() > 0 ? 0 : 5;
        }

        public int DisableRecipe(int recipeId)
        {
            if (recipeId <= 0) return 1;
            return recipe.RemoveRecipe(recipeId) > 0 ? 0 : 5;
        }
    }
}
