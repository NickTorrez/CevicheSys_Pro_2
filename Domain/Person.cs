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
    /// <summary>
    /// Clase base abstracta que define las propiedades y comportamientos comunes para personas o entidades de contacto.
    /// Solo existe en la lógica de C#, no tiene tabla directa en SQL (Table-Per-Concrete-Class).
    /// </summary>
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

        /// <summary>
        /// Inicializa una nueva instancia de la clase base con valores por defecto.
        /// </summary>
        protected Person()
        {
            Phone = string.Empty;
            Enable = true;
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase base con los valores proporcionados.
        /// </summary>
        protected Person(string phone, bool enable)
        {
            Phone = phone;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos Abstractos (Polimorfismo)                                     */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Método polimórfico que obliga a las clases derivadas a definir su propia regla de validación de identidad.
        /// </summary>
        public abstract bool ValidateIdentification();
    }
}
