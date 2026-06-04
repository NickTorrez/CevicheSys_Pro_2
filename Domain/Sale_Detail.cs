using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Entidad intermedia que rompe la relación N a N entre Ventas y Platillos (Representa cada línea del boucher).
    /// </summary>
    public class Sale_Detail
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Detail_Id { get; set; } // Id_Detalle (PK) [cite: 668]
        public int Sale_Id { get; set; }   // Id_Venta (FK) [cite: 667]
        public int Dish_Id { get; set; }   // Id_Platillo (FK) [cite: 667]
        public int Quantity { get; set; }  // Cantidad [cite: 667]

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Sale_Detail()
        {
        }

        public Sale_Detail(int detailId, int saleId, int dishId, int quantity)
        {
            Detail_Id = detailId;
            Sale_Id = saleId;
            Dish_Id = dishId;
            Quantity = quantity;
        }
    }
}