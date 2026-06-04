using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.UI.Catalogs;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Entidad que representa a los clientes de la cevichería. Hereda de Person.
    /// </summary>
    public class Customer : Person
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades Propias                                                   */
        /* --------------------------------------------------------------------- */
        public int CustomerId { get; set; }
        public string FullName { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Customer() : base()
        {
            CustomerId = 0;
            FullName = string.Empty;
        }

        public Customer(int customerId, string fullName, string phone, bool enable)
            : base(phone, enable)
        {
            CustomerId = customerId;
            FullName = fullName;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos Polimórficos e Internos                                       */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Implementación de la validación: Un cliente debe poseer un nombre de longitud válida.
        /// </summary>
        public override bool ValidateIdentification()
        {
            return !string.IsNullOrWhiteSpace(FullName) && FullName.Trim().Length >= 3;
        }
    }
}