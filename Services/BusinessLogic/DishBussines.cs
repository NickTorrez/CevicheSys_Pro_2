using CevicheSys_Pro_2.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class DishBussines
    {
        private readonly DishRepository _dishRepository;
        public DishBussines(DishRepository repository) => _dishRepository = repository;

        public List<Dish> GetMenu() => _dishRepository.GetAvailableDishes();
    }
}
