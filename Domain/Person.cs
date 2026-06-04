using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.UI.Catalogs;


namespace CevicheSys_Pro_2.Domain
{
    public abstract class Person
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades Compartidas                                               */
        /* --------------------------------------------------------------------- */
        public string Phone { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Person()
        {
            Phone = string.Empty;
            Enable = true;
        }

        public Person(string phone, bool enable)
        {
            Phone = phone;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos Abstractos (Polimorfismo)                                     */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Obliga a las clases derivadas a definir su propia regla de validación de identidad.
        /// </summary>
        public abstract bool ValidateIdentification();
    }
}
