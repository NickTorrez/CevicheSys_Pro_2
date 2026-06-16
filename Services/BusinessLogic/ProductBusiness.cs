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
        private readonly Product product = new Product();

        public int InsertProduct(Product newProduct)
        {
            if (newProduct == null) return 1;
            if (string.IsNullOrWhiteSpace(newProduct.Product_Name)) return 2;
            if (newProduct.Category_Id <= 0) return 3;
            if (newProduct.Current_Stock < 0) return 4;
            if (newProduct.Minimum_Stock < 0) return 4;

            newProduct.Product_Name = newProduct.Product_Name.Trim();
            newProduct.Enable = true;

            return newProduct.AddProduct() > 0 ? 0 : 5;
        }

        public int UpdateProduct(Product modifiedProduct)
        {
            if (modifiedProduct == null || modifiedProduct.Product_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedProduct.Product_Name)) return 2;
            if (modifiedProduct.Category_Id <= 0) return 3;
            if (modifiedProduct.Current_Stock < 0) return 4;
            if (modifiedProduct.Minimum_Stock < 0) return 4;

            modifiedProduct.Product_Name = modifiedProduct.Product_Name.Trim();

            return modifiedProduct.UpdateProduct() > 0 ? 0 : 5;
        }

        public int DisableProduct(int id)
        {
            if (id <= 0) return 1;
            return product.DisableProduct(id) > 0 ? 0 : 5;
        }

        public List<Product> ListProducts()
        {
            return product.ListAllProducts();
        }

        public List<Product> ListLowStockProducts()
        {
            return product.ListAllProducts().FindAll(p => p.RequiresRestock());
        }
    }
}
