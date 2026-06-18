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
    /// Controlador de lógica de negocio para la gestión de insumos y materia prima.
    /// </summary>
    public class ProductBusiness
    {
        private readonly Product _productDomain = new Product();

        public DataTable ListProducts()
        {
            return _productDomain.ListAllProducts();
        }

        public void InsertProduct(Product newProduct)
        {
            if (newProduct == null)
                throw new ArgumentNullException(nameof(newProduct), "La referencia del producto no puede apuntar a un valor nulo.");

            if (string.IsNullOrWhiteSpace(newProduct.Product_Name))
                throw new ArgumentException("El nombre descriptivo del producto es obligatorio.");

            if (newProduct.Category_Id <= 0)
                throw new ArgumentException("Debe seleccionar una categoría de inventario válida.");

            if (newProduct.Current_Stock < 0)
                throw new ArgumentException("El stock inicial de existencias no puede ser un valor negativo.");

            if (newProduct.Minimum_Stock < 0)
                throw new ArgumentException("El parámetro de stock crítico/mínimo no admite valores negativos.");

            if (_productDomain.ExistsByName(newProduct.Product_Name.Trim(), 0))
                throw new ArgumentException($"Ya se encuentra registrado un producto bajo la nomenclatura '{newProduct.Product_Name}'.");

            newProduct.Product_Name = newProduct.Product_Name.Trim();
            newProduct.Enable = true;

            int rowsAffected = newProduct.InsertProduct();
            if (rowsAffected <= 0)
                throw new Exception("Ocurrió un error físico en el servidor SQL al intentar registrar el nuevo insumo.");
        }

        public void UpdateProduct(Product existingProduct)
        {
            if (existingProduct == null)
                throw new ArgumentNullException(nameof(existingProduct), "El producto a modificar es nulo.");

            if (existingProduct.Product_Id <= 0)
                throw new ArgumentException("El ID del producto mapeado es incorrecto.");

            if (string.IsNullOrWhiteSpace(existingProduct.Product_Name))
                throw new ArgumentException("El nombre de insumo no puede actualizarse con caracteres vacíos.");

            if (existingProduct.Category_Id <= 0)
                throw new ArgumentException("Debe reasignar una categoría de catálogo válida.");

            if (existingProduct.Current_Stock < 0 || existingProduct.Minimum_Stock < 0)
                throw new ArgumentException("Las métricas de existencias y alarmas críticas no admiten signos negativos.");

            if (_productDomain.ExistsByName(existingProduct.Product_Name.Trim(), existingProduct.Product_Id))
                throw new ArgumentException($"Ya existe otro producto activo en el inventario con el nombre '{existingProduct.Product_Name}'.");

            existingProduct.Product_Name = existingProduct.Product_Name.Trim();

            int rowsAffected = existingProduct.UpdateProduct();
            if (rowsAffected <= 0)
                throw new Exception("No fue posible actualizar las propiedades físicas del insumo en el almacenamiento.");
        }

        public void DeleteProduct(int productId)
        {
            if (productId <= 0)
                throw new ArgumentException("El ID provisto para la remoción física/lógica del insumo es inválido.");

            Product productToDelete = new Product { Product_Id = productId };
            int rowsAffected = productToDelete.DeleteProduct();

            if (rowsAffected <= 0)
                throw new Exception("Error al purgar de forma lógica el insumo del listado activo.");
        }
    }
}
