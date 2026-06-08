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
        private Dish dish;

        public DishBusiness()
        {
            dish = new Dish();
        }

        public int InsertDish(Dish newDish)
        {
            if (newDish == null) return 1;

            // Reglas de negocio restrictivas para el menú
            if (string.IsNullOrWhiteSpace(newDish.Dish_Type)) return 2; // El tipo es obligatorio
            if (newDish.Price <= 0) return 3; // Un platillo no puede ser gratis ni tener precio negativo

            if (newDish.AddDish() > 0)
                return 0;
            else
                return 4;
        }

        public int UpdateDish(Dish modifiedDish)
        {
            if (modifiedDish == null || modifiedDish.Dish_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedDish.Dish_Type)) return 2;
            if (modifiedDish.Price <= 0) return 3;

            if (modifiedDish.UpdateDish() > 0)
                return 0;
            else
                return 4;
        }

        public int DisableDish(int id)
        {
            if (id <= 0) return 1;

            if (dish.DisableDish(id) > 0)
                return 0;
            else
                return 4;
        }

        public List<Dish> ListDishes()
        {
            return dish.ListAllDishes();
        }
    }
}
