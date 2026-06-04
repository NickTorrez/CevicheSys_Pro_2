using CevicheSys_Pro_2.UI.Catalogs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.Services.Repositories;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Reglas de negocio para Proveedores. Depende directamente de la clase concreta SupplierRepository.
    /// </summary>
    public class SupplierBusiness
    {
        private readonly SupplierRepository _supplierRepository;

        public SupplierBusiness(SupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        public List<Supplier> ObtainAllSuppliers()
        {
            return _supplierRepository.GetAll();
        }

        public Supplier ObtainSupplierById(int id)
        {
            if (id <= 0) throw new ArgumentException("El identificador del proveedor proporcionado no es válido.");
            return _supplierRepository.GetById(id);
        }

        public bool RegisterSupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));

            if (!supplier.ValidateIdentification())
            {
                throw new InvalidOperationException("La Cédula o RUC del proveedor no cumple con el formato mínimo legal de 14 caracteres.");
            }

            if (string.IsNullOrWhiteSpace(supplier.FirstName) || string.IsNullOrWhiteSpace(supplier.LastName))
            {
                throw new InvalidOperationException("El nombre y el apellido del proveedor constituyen campos de carácter obligatorio.");
            }

            return _supplierRepository.Insert(supplier);
        }

        public bool ModifySupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));
            if (supplier.SupplierId <= 0) throw new ArgumentException("El identificador del proveedor no es válido para su edición.");

            if (!supplier.ValidateIdentification())
            {
                throw new InvalidOperationException("Las modificaciones en la Cédula o RUC del proveedor no cumplen con los requerimientos.");
            }

            return _supplierRepository.Update(supplier);
        }

        public bool RemoveSupplier(int id)
        {
            if (id <= 0) throw new ArgumentException("El identificador del proveedor a eliminar no es válido.");
            return _supplierRepository.Delete(id);
        }
    }
}
