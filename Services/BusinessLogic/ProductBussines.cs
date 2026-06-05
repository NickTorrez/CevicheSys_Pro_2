using CevicheSys_Pro_2.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class ProductBussines
    {
        private readonly ProductRepository _productRepository;
        public ProductBussines(ProductRepository repository) => _productRepository = repository;

        public List<Product> GetLowStockProducts() =>
            _productRepository.GetAll().FindAll(p => p.RequiresRestock());

        public List<Product> GetAllProducts() => _productRepository.GetAll();
    }
}
