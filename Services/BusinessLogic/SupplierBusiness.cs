using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    //// <summary>
    /// Gestiona el flujo y las reglas de validación estricta para la entidad Proveedor.
    /// </summary>
    public class SupplierBusiness
    {
        private readonly Supplier _supplierDomain = new Supplier();

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
        /// 
        public int InsertSupplier(Supplier newSupplier)
        {
            if (newSupplier == null) return 1;
            if (!newSupplier.ValidateIdentification()) return 2;
            if (string.IsNullOrWhiteSpace(newSupplier.First_Name) || string.IsNullOrWhiteSpace(newSupplier.Last_Name)) return 3;

            if (_supplierDomain.ExistsByTaxId(newSupplier.Tax_Id)) return 4;

            bool success = newSupplier.InsertSupplier();
            return success ? 0 : 5;
        }

        public int UpdateSupplier(Supplier existingSupplier)
        {
            if (existingSupplier == null || existingSupplier.Supplier_Id <= 0) return 1;
            if (!existingSupplier.ValidateIdentification()) return 2;
            if (string.IsNullOrWhiteSpace(existingSupplier.First_Name) || string.IsNullOrWhiteSpace(existingSupplier.Last_Name)) return 3;

            if (_supplierDomain.ExistsByTaxId(existingSupplier.Tax_Id, existingSupplier.Supplier_Id)) return 4;

            bool success = existingSupplier.UpdateSupplier();
            return success ? 0 : 5;
        }

        public int DeleteSupplier(int id)
        {
            if (id <= 0) return 1;
            Supplier supplierToDelete = new Supplier { Supplier_Id = id };
            bool success = supplierToDelete.DeleteSupplier();
            return success ? 0 : 5;
        }
    }    
}
