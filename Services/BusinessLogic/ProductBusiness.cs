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
        private readonly Product _productDomain = new Product();

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

        public int InsertProduct(Product newProduct)
        {
            if (newProduct == null) return 1;
            if (string.IsNullOrWhiteSpace(newProduct.Product_Name)) return 2;
            if (newProduct.Category_Id <= 0) return 3;

            // Validaciones numéricas de inventario
            if (newProduct.Current_Stock < 0 || newProduct.Minimum_Stock < 0) return 4;

            // Validación de duplicidad en la Base de Datos
            if (_productDomain.ExistsByName(newProduct.Product_Name)) return 5;

            bool success = newProduct.InsertProduct();
            return success ? 0 : 6;
        }

        public int UpdateProduct(Product existingProduct)
        {
            if (existingProduct == null || existingProduct.Product_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(existingProduct.Product_Name)) return 2;
            if (existingProduct.Category_Id <= 0) return 3;
            if (existingProduct.Current_Stock < 0 || existingProduct.Minimum_Stock < 0) return 4;

            if (_productDomain.ExistsByName(existingProduct.Product_Name, existingProduct.Product_Id)) return 5;

            bool success = existingProduct.UpdateProduct();
            return success ? 0 : 6;
        }

        public int DeleteProduct(int id)
        {
            if (id <= 0) return 1;
            Product productToDelete = new Product { Product_Id = id };
            bool success = productToDelete.DeleteProduct();
            return success ? 0 : 6;
        }
    }
}
