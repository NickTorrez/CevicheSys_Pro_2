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
            if (newSale == null)
                throw new ArgumentNullException(nameof(newSale), "Los datos de la venta principal están vacíos.");

            if (details == null || details.Count == 0)
                throw new ArgumentException("La venta debe contener al menos un platillo en el detalle.");

            if (newSale.Total_Amount <= 0)
                throw new ArgumentException("El monto total de la venta debe ser mayor a cero.");

            if (newSale.User_Id <= 0)
                throw new ArgumentException("No se ha identificado al usuario (cajero) que realiza la venta.");

            if (string.IsNullOrWhiteSpace(newSale.Payment_Method) || string.IsNullOrWhiteSpace(newSale.Purchase_Type))
                throw new ArgumentException("El método de pago y el tipo de compra son obligatorios.");

            if (details.Any(d => d.Dish_Id <= 0 || d.Quantity <= 0))
                throw new ArgumentException("Uno o más detalles de la venta contienen cantidades o platillos inválidos.");

            return newSale.ProcessSaleWithDetails(details);
        }

        /// <summary>
        /// Procesa y valida la solicitud de anulación de una venta del sistema.
        /// </summary>
        /// <param name="saleId">Identificador de la venta.</param>
        /// <param name="auditorUser">Usuario que autoriza la transacción.</param>
        /// <returns>0 = Éxito, 1 = Datos de entrada inválidos, 2 = Error en la base de datos o registro no encontrado</returns>
        public int AnnulSale(int saleId, string auditorUser)
        {
            // Validación de reglas de negocio previas al acceso a datos
            if (saleId <= 0 || string.IsNullOrWhiteSpace(auditorUser))
            {
                return 1;
            }

            Sale saleDomain = new Sale();
            int rowsAffected = saleDomain.AnnulSale(saleId, auditorUser);

            // Si las filas afectadas son mayores a 0 el proceso fue exitoso
            return rowsAffected > 0 ? 0 : 2;
        }
    }
}
