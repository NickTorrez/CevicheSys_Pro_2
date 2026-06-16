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
        private readonly Sale expense = new Sale();

        public int InsertCompleteSale(Sale newSale, List<SaleDetail> details)
        {
            if (newSale == null) return 1;
            if (details == null || details.Count == 0) return 2;
            if (newSale.Total_Amount <= 0) return 3;
            if (newSale.User_Id <= 0) return 4;
            if (string.IsNullOrWhiteSpace(newSale.Payment_Method)) return 4;
            if (string.IsNullOrWhiteSpace(newSale.Purchase_Type)) return 4;
            if (details.Any(d => d.Dish_Id <= 0 || d.Quantity <= 0)) return 4;

            newSale.Payment_Method = newSale.Payment_Method.Trim();
            newSale.Purchase_Type = newSale.Purchase_Type.Trim();
            newSale.Enable = true;

            int generatedId = newSale.ProcessSaleWithDetails(details);

            return generatedId > 0 ? 0 : 5;
        }

    }
}
