using CevicheSys_Pro_2;
using CevicheSys_Pro_2.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class SaleBussines
    {
        private readonly SaleRepository _saleRepository;
        private readonly RecipeRepository _recipeRepository;
        private readonly ProductRepository _productRepository;

        public SaleBussines(SaleRepository saleRepo, RecipeRepository recipeRepo, ProductRepository productRepo)
        {
            _saleRepository = saleRepo;
            _recipeRepository = recipeRepo;
            _productRepository = productRepo;
        }

        /// <summary>
        /// Procesa una venta completa y ejecuta la regla operativa crítica de descargar automáticamente los insumos consumidos.
        /// </summary>
        public bool ProcessSale(Sale sale, List<Sale_Detail> details)
        {
            if (details == null || details.Count == 0) return false;

            int saleId = _saleRepository.InsertSaleHeader(sale);
            if (saleId <= 0) return false;

            foreach (var detail in details)
            {
                detail.Sale_Id = saleId;
                _saleRepository.InsertSaleDetail(detail);

                // --- REGLA OPERATIVA DE NEGOCIO: Descargo automático de Inventario ---
                var recipeItems = _recipeRepository.GetRecipeByDish(detail.Dish_Id);
                foreach (var item in recipeItems)
                {
                    // Buscamos el producto actual para restarle el inventario proporcional vendido
                    var allProducts = _productRepository.GetAll();
                    var product = allProducts.Find(p => p.Product_Id == item.Product_Id);
                    if (product != null)
                    {
                        double quantityToDeduct = item.Quantity_Used * detail.Quantity;
                        double finalStock = product.Current_Stock - quantityToDeduct;
                        _productRepository.UpdateStock(product.Product_Id, finalStock);
                    }
                }
            }
            return true;
        }
}
