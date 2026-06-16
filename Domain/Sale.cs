using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Registra la cabecera general y datos transaccionales de cada venta efectuada.
    /// </summary>
    public class Sale
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Sale_Id { get; set; }
        public int? Customer_Id { get; set; }         // ACTUALIZADO: FK opcional a la tabla Customer
        public string Payment_Method { get; set; }
        public string Purchase_Type { get; set; }
        public decimal Total_Amount { get; set; }     // ACTUALIZADO: Manejo financiero preciso
        public DateTime Record_Date { get; set; }
        public int User_Id { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa un ticket de factura predeterminado.
        /// </summary>
        public Sale()
        {
            Payment_Method = string.Empty;
            Purchase_Type = string.Empty;
            Record_Date = DateTime.Now;
            Total_Amount = 0m;
            Enable = true;
        }

        /// <summary>
        /// Arma los encabezados de la transacción de venta completada en caja.
        /// </summary>
        public Sale(int saleId, int? customerId, string paymentMethod, string purchaseType,
                    decimal totalAmount, DateTime recordDate, int userId, bool enable = true)
        {
            Sale_Id = saleId;
            Customer_Id = customerId;
            Payment_Method = paymentMethod;
            Purchase_Type = purchaseType;
            Total_Amount = totalAmount;
            Record_Date = recordDate;
            User_Id = userId;
            Enable = enable;
        }

        /*----------------------------------------------------------------------------------*/
        /* Métodos de Persistencia (CRUD)                                                   */
        /*----------------------------------------------------------------------------------*/

        /// <summary>
        /// Orquesta la inserción atómica de la cabecera de la venta junto con sus múltiples líneas de detalle.
        /// </summary>
        public int ProcessSaleWithDetails(List<SaleDetail> details)
        {
            string masterQuery = @"INSERT INTO Sale (User_Id, Customer_Id, Payment_Method, Purchase_Type, Total_Amount, Record_Date, Enable)
                                   VALUES (@userId, @customerId, @paymentMethod, @purchaseType, @totalAmount, @recordDate, @enable);
                                   SELECT SCOPE_IDENTITY();";

            SqlParameter[] masterParams =
            {
                new SqlParameter("@userId", User_Id),
                new SqlParameter("@customerId", (object)Customer_Id ?? DBNull.Value),
                new SqlParameter("@paymentMethod", Payment_Method),
                new SqlParameter("@purchaseType", Purchase_Type),
                new SqlParameter("@totalAmount", Total_Amount),
                new SqlParameter("@recordDate", Record_Date),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insertMaster = new InsertCommand())
            {
                int generatedSaleId = insertMaster.ExecuteInsertReturnId(masterQuery, masterParams);
                if (generatedSaleId <= 0) return 0;

                string detailQuery = @"INSERT INTO Sale_Detail (Dish_Id, Sale_Id, Quantity, Enable)
                                       VALUES (@dishId, @saleId, @quantity, @enable)";

                foreach (SaleDetail item in details)
                {
                    SqlParameter[] detailParams =
                    {
                        new SqlParameter("@dishId", item.Dish_Id),
                        new SqlParameter("@saleId", generatedSaleId),
                        new SqlParameter("@quantity", item.Quantity),
                        new SqlParameter("@enable", true)
                    };

                    using (InsertCommand insertDetail = new InsertCommand())
                        insertDetail.ExecuteInsert(detailQuery, detailParams);
                }

                return generatedSaleId;
            }
        }
    }
}
