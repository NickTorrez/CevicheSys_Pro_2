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
        #region Propiedades
        public int Detail_Id { get; set; }
        public int Sale_Id { get; set; }
        public int Dish_Id { get; set; }
        public int Quantity { get; set; }
        public bool Enable { get; set; }
        #endregion

        #region Constructores
        public SaleDetail()
        {
            Enable = true;
        }

        public SaleDetail(int detailId, int saleId, int dishId, int quantity, bool enable = true)
        {
            Detail_Id = detailId;
            Sale_Id = saleId;
            Dish_Id = dishId;
            Quantity = quantity;
            Enable = enable;
        }
        #endregion

        // Nota: Los métodos de persistencia para SaleDetail se ejecutan en transacción desde Sale.ProcessSaleWithDetails()
    }
}