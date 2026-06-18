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
    /// Controlador de lógica de negocio para las categorías de inventario y gastos.
    /// </summary>
    public class CategoryBusiness
    {
        private readonly Category _categoryDomain = new Category();

        public DataTable ListCategories() => new Category().ListAllCategories();

        public int InsertCategory(Category newCategory)
        {
            if (newCategory == null)
                throw new ArgumentNullException(nameof(newCategory), "Los datos de la categoría están vacíos.");

            if (string.IsNullOrWhiteSpace(newCategory.Category_Name) || string.IsNullOrWhiteSpace(newCategory.Target_Module))
                throw new ArgumentException("El nombre y el módulo destino de la categoría son obligatorios.");

            if (_categoryDomain.ExistsByName(newCategory.Category_Name, newCategory.Target_Module))
                throw new Exception($"La categoría '{newCategory.Category_Name}' ya existe para el módulo '{newCategory.Target_Module}'.");

            return newCategory.InsertCategory();
        }

        public int UpdateCategory(Category existingCategory)
        {
            if (existingCategory == null || existingCategory.Category_Id <= 0)
                throw new ArgumentException("La categoría proporcionada es inválida para actualización.");

            if (string.IsNullOrWhiteSpace(existingCategory.Category_Name) || string.IsNullOrWhiteSpace(existingCategory.Target_Module))
                throw new ArgumentException("El nombre y el módulo destino de la categoría son obligatorios.");

            if (_categoryDomain.ExistsByName(existingCategory.Category_Name, existingCategory.Target_Module, existingCategory.Category_Id))
                throw new Exception($"La categoría '{existingCategory.Category_Name}' ya está registrada en el módulo '{existingCategory.Target_Module}'.");

            return existingCategory.UpdateCategory();
        }

        public int DeleteCategory(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Se requiere un ID válido para dar de baja la categoría.");

            Category categoryToDelete = new Category { Category_Id = id };
            return categoryToDelete.DeleteCategory();
        }
    }
}
