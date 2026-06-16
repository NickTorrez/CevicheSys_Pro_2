using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para las categorías de inventario y gastos.
    /// </summary>
    public class CategoryBusiness
    {
        private readonly Category _categoryDomain = new Category();

        /// <summary>
        /// Valida y procesa el registro de un nuevo usuario en el sistema.
        /// </summary>
        /// <returns>
        /// 0 = Éxito.
        /// 1 = El objeto de usuario es nulo.
        /// 2 = Nombre de usuario o contraseña vacíos.
        /// 3 = Formato de nombre de usuario inválido.
        /// 4 = El nombre de usuario ya se encuentra registrado.
        /// 5 = Error al guardar en la base de datos.
        /// </returns>
        /// 
        public int InsertCategory(Category newCategory)
        {
            if (newCategory == null) return 1;
            if (string.IsNullOrWhiteSpace(newCategory.Category_Name) || string.IsNullOrWhiteSpace(newCategory.Target_Module)) return 2;

            if (_categoryDomain.ExistsByName(newCategory.Category_Name, newCategory.Target_Module)) return 4;

            bool success = newCategory.InsertCategory();
            return success ? 0 : 5;
        }

        public int UpdateCategory(Category existingCategory)
        {
            if (existingCategory == null || existingCategory.Category_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(existingCategory.Category_Name) || string.IsNullOrWhiteSpace(existingCategory.Target_Module)) return 2;

            if (_categoryDomain.ExistsByName(existingCategory.Category_Name, existingCategory.Target_Module, existingCategory.Category_Id)) return 4;

            bool success = existingCategory.UpdateCategory();
            return success ? 0 : 5;
        }

        public int DeleteCategory(int id)
        {
            if (id <= 0) return 1;
            Category categoryToDelete = new Category { Category_Id = id };
            bool success = categoryToDelete.DeleteCategory();
            return success ? 0 : 5;
        }
    }
}
