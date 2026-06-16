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
        private readonly Supplier supplier = new Supplier();

        public List<Supplier> ListSuppliers()
        {
            return supplier.ListAllSuppliers();
        }

        // Alias para no romper codigo anterior.
        public List<Supplier> ObtainAllSuppliers()
        {
            return ListSuppliers();
        }

        public int InsertSupplier(Supplier newSupplier)
        {
            if (newSupplier == null) return 1;
            if (!newSupplier.ValidateIdentification()) return 2;
            if (string.IsNullOrWhiteSpace(newSupplier.First_Name)) return 3;
            if (string.IsNullOrWhiteSpace(newSupplier.Last_Name)) return 4;

            NormalizeSupplier(newSupplier);
            newSupplier.Enable = true;

            return newSupplier.AddSupplier() > 0 ? 0 : 5;
        }

        // Alias para no romper codigo anterior.
        public int RegisterSupplier(Supplier newSupplier)
        {
            return InsertSupplier(newSupplier);
        }

        public int UpdateSupplier(Supplier modifiedSupplier)
        {
            if (modifiedSupplier == null || modifiedSupplier.Supplier_Id <= 0) return 1;
            if (!modifiedSupplier.ValidateIdentification()) return 2;
            if (string.IsNullOrWhiteSpace(modifiedSupplier.First_Name)) return 3;
            if (string.IsNullOrWhiteSpace(modifiedSupplier.Last_Name)) return 4;

            NormalizeSupplier(modifiedSupplier);

            return modifiedSupplier.UpdateSupplier() > 0 ? 0 : 5;
        }

        // Alias para no romper codigo anterior.
        public int ModifySupplier(Supplier modifiedSupplier)
        {
            return UpdateSupplier(modifiedSupplier);
        }

        public int DisableSupplier(int id)
        {
            if (id <= 0) return 1;
            return supplier.DisableSupplier(id) > 0 ? 0 : 5;
        }

        // Alias para no romper codigo anterior.
        public int RemoveSupplier(int id)
        {
            return DisableSupplier(id);
        }

        private static void NormalizeSupplier(Supplier supplierToNormalize)
        {
            supplierToNormalize.Tax_Id = supplierToNormalize.Tax_Id?.Trim() ?? string.Empty;
            supplierToNormalize.First_Name = supplierToNormalize.First_Name?.Trim() ?? string.Empty;
            supplierToNormalize.Last_Name = supplierToNormalize.Last_Name?.Trim() ?? string.Empty;
            supplierToNormalize.Phone = supplierToNormalize.Phone?.Trim() ?? string.Empty;
            supplierToNormalize.Email = supplierToNormalize.Email?.Trim() ?? string.Empty;
            supplierToNormalize.Address = supplierToNormalize.Address?.Trim() ?? string.Empty;
        }
    }    
}
