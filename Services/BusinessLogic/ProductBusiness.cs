using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para la gestión de insumos y materia prima.
    /// </summary>
    public class ProductBusiness
    {
        private Product product;

        public ProductBusiness()
        {
            product = new Product();
        }

        public int InsertProduct(Product newProduct)
        {
            if (newProduct == null) return 1;

            // Reglas lógicas de inventario
            if (string.IsNullOrWhiteSpace(newProduct.Product_Name)) return 2;
            if (newProduct.Current_Stock < 0) return 3; // El stock inicial no puede ser negativo
            if (newProduct.Minimum_Stock < 0) return 4;

            if (newProduct.AddProduct() > 0)
                return 0;
            else
                return 5;
        }

        public int UpdateProduct(Product modifiedProduct)
        {
            if (modifiedProduct == null || modifiedProduct.Product_Id <= 0) return 1;
            if (modifiedProduct.Current_Stock < 0) return 3;

            if (modifiedProduct.UpdateProduct() > 0)
                return 0;
            else
                return 5;
        }

        public int DisableProduct(int id)
        {
            if (id <= 0) return 1;

            if (product.DisableProduct(id) > 0)
                return 0;
            else
                return 5;
        }

        public List<Product> ListProducts()
        {
            return product.ListAllProducts();
        }

        /// <summary>
        /// Aplica la regla de negocio del dominio para filtrar productos que requieren reabastecimiento.
        /// </summary>
        public List<Product> ListLowStockProducts()
        {
            List<Product> allProducts = product.ListAllProducts();
            return allProducts.FindAll(p => p.RequiresRestock());
        }
    }
}
