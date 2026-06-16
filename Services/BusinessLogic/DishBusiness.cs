using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para los platillos del menú.
    /// </summary>
    public class DishBusiness
    {
        private readonly Dish _dishDomain = new Dish();

        public int InsertDish(Dish newDish)
        {
            if (newDish == null) return 1;
            if (string.IsNullOrWhiteSpace(newDish.Dish_Type) || string.IsNullOrWhiteSpace(newDish.Size)) return 2;
            if (newDish.Price <= 0) return 3;

            if (_dishDomain.ExistsByTypeAndSize(newDish.Dish_Type, newDish.Size)) return 4;

            bool success = newDish.InsertDish();
            return success ? 0 : 5;
        }

        public int UpdateDish(Dish existingDish)
        {
            if (existingDish == null || existingDish.Dish_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(existingDish.Dish_Type) || string.IsNullOrWhiteSpace(existingDish.Size)) return 2;
            if (existingDish.Price <= 0) return 3;

            if (_dishDomain.ExistsByTypeAndSize(existingDish.Dish_Type, existingDish.Size, existingDish.Dish_Id)) return 4;

            bool success = existingDish.UpdateDish();
            return success ? 0 : 5;
        }

        public int DeleteDish(int id)
        {
            if (id <= 0) return 1;
            Dish dishToDelete = new Dish { Dish_Id = id };
            bool success = dishToDelete.DeleteDish();
            return success ? 0 : 5;
        }
    }
}
