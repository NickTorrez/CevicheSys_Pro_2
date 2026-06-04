using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.UI.Catalogs;
namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Entidad que representa a los proveedores y pescadores del negocio. Hereda de Person.
    /// </summary>
    public class Supplier : Person
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades Propias                                                   */
        /* --------------------------------------------------------------------- */
        public int SupplierId { get; set; }
        public string TaxId { get; set; } // Representa Cedula_Ruc
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Supplier() : base()
        {
            SupplierId = 0;
            TaxId = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
        }

        public Supplier(int supplierId, string taxId, string firstName, string lastName,
                        string address, string email, string phone, bool enable)
            : base(phone, enable)
        {
            SupplierId = supplierId;
            TaxId = taxId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos Polimórficos e Internos                                       */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Devuelve la concatenación nominal formal del proveedor.
        /// </summary>
        public string GetSupplierCompleteName()
        {
            return $"{FirstName} {LastName}".Trim();
        }

        /// <summary>
        /// Implementación de la validación: Verifica que la Cédula o el RUC comercial cumpla la extensión legal mínima.
        /// </summary>
        public override bool ValidateIdentification()
        {
            if (string.IsNullOrWhiteSpace(TaxId)) return false;
            return TaxId.Trim().Length >= 14;
        }
    }

}
