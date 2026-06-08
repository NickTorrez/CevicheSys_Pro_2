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
        private Sale sale;

        public SaleBusiness()
        {
            sale = new Sale();
        }

        public int InsertCompleteSale(Sale newSale, List<SaleDetail> details)
        {
            if (newSale == null) return 1;

            // Reglas estrictas de Punto de Venta
            if (details == null || details.Count == 0) return 2; // No se puede facturar una venta vacía
            if (newSale.Total_Amount <= 0) return 3; // El monto total debe ser válido
            if (newSale.User_Id <= 0) return 4; // Debe existir un usuario responsable

            // Se delega al dominio la transacción completa
            int generatedId = newSale.ProcessSaleWithDetails(details);

            if (generatedId > 0)
                return 0; // Transacción procesada con éxito
            else
                return 5; // Error al consolidar la venta en base de datos
        }

    }
}
