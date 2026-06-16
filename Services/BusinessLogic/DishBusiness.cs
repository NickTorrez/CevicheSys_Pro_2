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
        private readonly Dish dish = new Dish();

        public int InsertDish(Dish newDish)
        {
            if (newDish == null) return 1;
            if (string.IsNullOrWhiteSpace(newDish.Dish_Type)) return 2;
            if (string.IsNullOrWhiteSpace(newDish.Size)) return 3;
            if (newDish.Price <= 0) return 4;

            newDish.Dish_Type = newDish.Dish_Type.Trim();
            newDish.Size = newDish.Size.Trim();
            newDish.Enable = true;

            return newDish.AddDish() > 0 ? 0 : 5;
        }

        public int UpdateDish(Dish modifiedDish)
        {
            if (modifiedDish == null || modifiedDish.Dish_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedDish.Dish_Type)) return 2;
            if (string.IsNullOrWhiteSpace(modifiedDish.Size)) return 3;
            if (modifiedDish.Price <= 0) return 4;

            modifiedDish.Dish_Type = modifiedDish.Dish_Type.Trim();
            modifiedDish.Size = modifiedDish.Size.Trim();

            return modifiedDish.UpdateDish() > 0 ? 0 : 5;
        }

        public int DisableDish(int id)
        {
            if (id <= 0) return 1;
            return dish.DisableDish(id) > 0 ? 0 : 5;
        }

        public List<Dish> ListDishes()
        {
            return dish.ListAllDishes();
        }

        public List<Dish> ListAvailableDishes()
        {
            return dish.ListAllDishes().FindAll(d => d.Is_Available);
        }
    }
}
