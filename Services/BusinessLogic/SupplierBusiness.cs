using CevicheSys_Pro_2.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    //// <summary>
    /// Gestiona el flujo y las reglas de validación estricta para la entidad Proveedor.
    /// </summary>
    public class SupplierBusiness
    {
        private readonly Supplier _supplierDomain = new Supplier();

        public DataTable ListSuppliers()
        {
            return _supplierDomain.ListAllSuppliers();
        }

        public void InsertSupplier(Supplier newSupplier)
        {
            if (newSupplier == null)
                throw new ArgumentNullException(nameof(newSupplier), "Los datos del proveedor no pueden estar vacíos.");

            if (string.IsNullOrWhiteSpace(newSupplier.Tax_Id))
                throw new ArgumentException("El documento de identificación fiscal (RUC/Cédula) es obligatorio.");

            if (string.IsNullOrWhiteSpace(newSupplier.First_Name))
                throw new ArgumentException("El primer nombre o razón social es un dato obligatorio.");

            if (string.IsNullOrWhiteSpace(newSupplier.Last_Name))
                throw new ArgumentException("El apellido o complemento comercial es obligatorio.");

            if (_supplierDomain.ExistsByTaxId(newSupplier.Tax_Id.Trim(), 0))
                throw new ArgumentException($"La identificación fiscal '{newSupplier.Tax_Id}' ya se encuentra registrada en el sistema.");

            newSupplier.Tax_Id = newSupplier.Tax_Id.Trim();
            newSupplier.First_Name = newSupplier.First_Name.Trim();
            newSupplier.Last_Name = newSupplier.Last_Name.Trim();
            newSupplier.Address = newSupplier.Address?.Trim();
            newSupplier.Phone = newSupplier.Phone?.Trim();
            newSupplier.Email = newSupplier.Email?.Trim();
            newSupplier.Enable = true;

            int rowsAffected = newSupplier.InsertSupplier();
            if (rowsAffected <= 0)
                throw new Exception("Error interno: No se pudo registrar la información del proveedor.");
        }

        public void UpdateSupplier(Supplier existingSupplier)
        {
            if (existingSupplier == null)
                throw new ArgumentNullException(nameof(existingSupplier), "El proveedor a actualizar contiene una referencia nula.");

            if (existingSupplier.Supplier_Id <= 0)
                throw new ArgumentException("El ID de proveedor especificado es inválido.");

            if (string.IsNullOrWhiteSpace(existingSupplier.Tax_Id))
                throw new ArgumentException("La identificación fiscal no puede estar vacía.");

            if (string.IsNullOrWhiteSpace(existingSupplier.First_Name) || string.IsNullOrWhiteSpace(existingSupplier.Last_Name))
                throw new ArgumentException("El nombre y el apellido del proveedor son requeridos.");

            if (_supplierDomain.ExistsByTaxId(existingSupplier.Tax_Id.Trim(), existingSupplier.Supplier_Id))
                throw new ArgumentException($"La identificación fiscal '{existingSupplier.Tax_Id}' ya está registrada para otro proveedor.");

            existingSupplier.Tax_Id = existingSupplier.Tax_Id.Trim();
            existingSupplier.First_Name = existingSupplier.First_Name.Trim();
            existingSupplier.Last_Name = existingSupplier.Last_Name.Trim();
            existingSupplier.Address = existingSupplier.Address?.Trim();
            existingSupplier.Phone = existingSupplier.Phone?.Trim();
            existingSupplier.Email = existingSupplier.Email?.Trim();

            int rowsAffected = existingSupplier.UpdateSupplier();
            if (rowsAffected <= 0)
                throw new Exception("Ocurrió un error y no fue posible actualizar los datos del proveedor.");
        }

        public void DeleteSupplier(int supplierId)
        {
            if (supplierId <= 0)
                throw new ArgumentException("El ID del proveedor para remoción lógica es inválido.");

            Supplier supplierToDelete = new Supplier { Supplier_Id = supplierId };
            int rowsAffected = supplierToDelete.DeleteSupplier();

            if (rowsAffected <= 0)
                throw new Exception("No se pudo deshabilitar el proveedor seleccionado de la base de datos.");
        }
    }    
}
