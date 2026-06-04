using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Catálogo maestro utilizado para clasificar de manera estandarizada tanto los insumos como los gastos.
    /// </summary>
    public class Category
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Category_Id { get; set; }       // Id_Categoria (PK) 
        public string Category_Name { get; set; }  // Nombre_Categoria 
        public string Applied_Module { get; set; } // Modulo_Aplica ("Inventario" o "Gastos") 
        public bool Enable { get; set; }           // Enable 

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Category()
        {
            Category_Name = string.Empty;
            Applied_Module = string.Empty;
            Enable = true;
        }

        public Category(int categoryId, string categoryName, string appliedModule, bool enable = true)
        {
            Category_Id = categoryId;
            Category_Name = categoryName;
            Applied_Module = appliedModule;
            Enable = enable;
        }

    }
}