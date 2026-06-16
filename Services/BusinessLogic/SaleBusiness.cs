using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador transaccional encargado de orquestar la cabecera de la venta y sus detalles.
    /// </summary>
    public class SaleBusiness
    {
        public int InsertCompleteSale(Sale newSale, List<SaleDetail> details)
        {
            if (newSale == null) return 1;
            if (details == null || details.Count == 0) return 2;

            if (newSale.Total_Amount <= 0) return 3;
            if (newSale.User_Id <= 0) return 4;
            if (string.IsNullOrWhiteSpace(newSale.Payment_Method) || string.IsNullOrWhiteSpace(newSale.Purchase_Type)) return 5;

            // Validar que ningún detalle tenga valores anómalos
            if (details.Any(d => d.Dish_Id <= 0 || d.Quantity <= 0)) return 6;

            bool success = newSale.ProcessSaleWithDetails(details);
            return success ? 0 : 7;
        }

    }
}
