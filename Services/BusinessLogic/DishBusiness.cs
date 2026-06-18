using CevicheSys_Pro_2.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para los platillos del menú.
    /// </summary>
    public class DishBusiness
    {
        private readonly Dish _dishDomain = new Dish();

        public DataTable ListDishes() => new Dish().ListAllDishes();

        public int InsertDish(Dish newDish)
        {
            if (newDish == null)
                throw new ArgumentNullException(nameof(newDish), "Los datos del platillo están vacíos.");

            if (string.IsNullOrWhiteSpace(newDish.Dish_Type) || string.IsNullOrWhiteSpace(newDish.Size))
                throw new ArgumentException("El tipo de platillo y el tamaño son obligatorios.");

            if (newDish.Price <= 0)
                throw new ArgumentException("El precio del platillo debe ser mayor a cero.");

            if (_dishDomain.ExistsByTypeAndSize(newDish.Dish_Type, newDish.Size))
                throw new Exception($"El platillo '{newDish.Dish_Type}' tamaño '{newDish.Size}' ya se encuentra registrado en el menú.");

            return newDish.InsertDish();
        }

        public int UpdateDish(Dish existingDish)
        {
            if (existingDish == null || existingDish.Dish_Id <= 0)
                throw new ArgumentException("El platillo proporcionado es inválido para actualización.");

            if (string.IsNullOrWhiteSpace(existingDish.Dish_Type) || string.IsNullOrWhiteSpace(existingDish.Size))
                throw new ArgumentException("El tipo de platillo y el tamaño son obligatorios.");

            if (existingDish.Price <= 0)
                throw new ArgumentException("El precio del platillo debe ser mayor a cero.");

            if (_dishDomain.ExistsByTypeAndSize(existingDish.Dish_Type, existingDish.Size, existingDish.Dish_Id))
                throw new Exception($"El platillo '{existingDish.Dish_Type}' tamaño '{existingDish.Size}' ya está registrado.");

            return existingDish.UpdateDish();
        }

        public int DeleteDish(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Se requiere un ID válido para eliminar el platillo.");

            Dish dishToDelete = new Dish { Dish_Id = id };
            return dishToDelete.DeleteDish();
        }
    }
}
