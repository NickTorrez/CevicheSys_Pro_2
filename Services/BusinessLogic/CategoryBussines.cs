using CevicheSys_Pro_2.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class CategoryBussines
    {
        private readonly CategoryRepository _categoryRepository;
        public CategoryBussines(CategoryRepository repository) => _categoryRepository = repository;

        public List<Category> GetInventoryCategories() =>
            _categoryRepository.GetAll().FindAll(c => c.Applied_Module == "Inventario");

        public List<Category> GetExpenseCategories() =>
            _categoryRepository.GetAll().FindAll(c => c.Applied_Module == "Gastos");
    }
}
