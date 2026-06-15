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
        private Supplier supplier; // Instancia interna del modelo de dominio

        public SupplierBusiness()
        {
            supplier = new Supplier();
        }

        public List<Supplier> ObtainAllSuppliers()
        {
            return supplier.ListAllSuppliers();
        }

        public int RegisterSupplier(Supplier newSupplier)
        {
            if (newSupplier == null) return 1;

            // Filtro de negocio polimórfico heredado de Person (Cédula/RUC)
            if (!newSupplier.ValidateIdentification())
                return 2; // Código 2: Cédula o RUC inválido (Menor a 14 dígitos)

            if (string.IsNullOrWhiteSpace(newSupplier.First_Name) || string.IsNullOrWhiteSpace(newSupplier.Last_Name))
                return 3; // Código 3: Nombre o Apellido vacío

            // Ordena al dominio ejecutar la inserción
            if (newSupplier.AddSupplier() > 0)
                return 0; // Código 0: Éxito
            else
                return 1; // Código 1: Fallo operacional en la BD
        }

        public int ModifySupplier(Supplier modifiedSupplier)
        {
            if (modifiedSupplier == null || modifiedSupplier.Supplier_Id <= 0) return 1;

            if (!modifiedSupplier.ValidateIdentification())
                return 2;

            if (modifiedSupplier.UpdateSupplier() > 0)
                return 0;
            else
                return 1;
        }

        public int RemoveSupplier(int id)
        {
            if (id <= 0) return 1;

            if (supplier.DisableSupplier(id) > 0)
                return 0;
            else
                return 1;
        }
    }    
}
