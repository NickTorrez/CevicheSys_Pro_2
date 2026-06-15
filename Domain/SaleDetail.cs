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
    public class SaleDetail
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Detail_Id { get; set; }
        public int Sale_Id { get; set; }
        public int Dish_Id { get; set; }
        public int Quantity { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa un detalle de venta vacío.
        /// </summary>
        public SaleDetail()
        {
            Enable = true;
        }

        /// <summary>
        /// Inicializa una línea de detalle con sus referencias a venta y platillo.
        /// </summary>
        public SaleDetail(int detailId, int saleId, int dishId, int quantity, bool enable = true)
        {
            Detail_Id = detailId;
            Sale_Id = saleId;
            Dish_Id = dishId;
            Quantity = quantity;
            Enable = enable;
        }
    }
}