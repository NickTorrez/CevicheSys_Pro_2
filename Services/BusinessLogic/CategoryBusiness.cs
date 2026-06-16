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
        private readonly Category category = new Category();

        public int InsertCategory(Category newCategory)
        {
            if (newCategory == null) return 1;
            if (string.IsNullOrWhiteSpace(newCategory.Category_Name)) return 2;
            if (string.IsNullOrWhiteSpace(newCategory.Target_Module)) return 3;

            newCategory.Category_Name = newCategory.Category_Name.Trim();
            newCategory.Target_Module = newCategory.Target_Module.Trim();
            newCategory.Enable = true;

            return newCategory.AddCategory() > 0 ? 0 : 5;
        }

        public int UpdateCategory(Category modifiedCategory)
        {
            if (modifiedCategory == null || modifiedCategory.Category_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedCategory.Category_Name)) return 2;
            if (string.IsNullOrWhiteSpace(modifiedCategory.Target_Module)) return 3;

            modifiedCategory.Category_Name = modifiedCategory.Category_Name.Trim();
            modifiedCategory.Target_Module = modifiedCategory.Target_Module.Trim();

            return modifiedCategory.UpdateCategory() > 0 ? 0 : 5;
        }

        public int DisableCategory(int id)
        {
            if (id <= 0) return 1;
            return category.DisableCategory(id) > 0 ? 0 : 5;
        }

        public List<Category> ListCategories()
        {
            return category.ListAllCategories();
        }
    }
}
