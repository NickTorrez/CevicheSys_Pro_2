using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Almacena los productos finales disponibles en el menú configurados por tamaño y costo comercial.
    /// </summary>
    public class Dish
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Dish_Id { get; set; }          // Id_Platillo (PK) 
        public string Dish_Type { get; set; }     // Tipo_Platillo (Ej: Pescado, Camarón) 
        public string Size { get; set; }          // Tamaño (Ej: 12 onz, 25 onz) 
        public double Price { get; set; }         // Precio en Córdobas 
        public bool Is_Available { get; set; }    // Disponibilidad diaria (1 = Disponible, 0 = Agotado)
        public bool Enable { get; set; }          // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Dish()
        {
            Dish_Type = string.Empty;
            Size = string.Empty;
            Price = 0.0;
            Is_Available = true;
            Enable = true;
        }

        public Dish(int dishId, string dishType, string size, double price, bool isAvailable, bool enable = true)
        {
            Dish_Id = dishId;
            Dish_Type = dishType;
            Size = size;
            Price = price;
            Is_Available = isAvailable;
            Enable = enable;
        }

    }
}