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
        public int Sale_Id { get; set; }             // Id_Venta (PK)
        public string Customer_Name { get; set; }     // Nombre o descripción rápida del cliente
        public string Payment_Method { get; set; }    // Metodo_Pago ("Efectivo" o "Tarjeta")
        public string Purchase_Type { get; set; }     // Tipo_Compra ("Local" o "Delivery")
        public double Total_Amount { get; set; }      // Total_Pagar
        public DateTime Record_Date { get; set; }     // Fecha_Registro
        public int User_Id { get; set; }             // Id_Usuario (FK)
        public bool Enable { get; set; }              // Enable (1 = Válida, 0 = Anulada)

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Sale()
        {
            Customer_Name = string.Empty;
            Payment_Method = string.Empty;
            Purchase_Type = string.Empty;
            Record_Date = DateTime.Now;
            Enable = true;
        }

        public Sale(int saleId, string customerName, string paymentMethod, string purchaseType,
                    double totalAmount, DateTime recordDate, int userId, bool enable = true)
        {
            Sale_Id = saleId;
            Customer_Name = customerName;
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

        public int ProcessSaleWithDetails(List<SaleDetail> details)
        {
            // Primero insertamos la cabecera y obtenemos el ID generado (SCOPE_IDENTITY)
            string masterQuery = @"INSERT INTO Venta (Nombre_Cliente, Metodo_Pago, Tipo_Compra, Total_Pagar, Fecha_Registro, Id_Usuario, Enable) 
                                   VALUES (@cust, @pay, @type, @total, @date, @userId, @enable);
                                   SELECT SCOPE_IDENTITY();";

            SqlParameter[] masterParams = {
                new SqlParameter("@cust", this.Customer_Name),
                new SqlParameter("@pay", this.Payment_Method),
                new SqlParameter("@type", this.Purchase_Type),
                new SqlParameter("@total", this.Total_Amount),
                new SqlParameter("@date", this.Record_Date),
                new SqlParameter("@userId", this.User_Id),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insertMaster = new InsertCommand())
            {
                int generatedSaleId = insertMaster.ExecuteInsert(masterQuery, masterParams);
                if (generatedSaleId <= 0) return 0;

                // Insertamos cada elemento del detalle usando el ID de venta obtenido
                string detailQuery = "INSERT INTO Detalle_Venta (Id_Venta, Id_Platillo, Cantidad) VALUES (@saleId, @dishId, @qty)";

                foreach (var item in details)
                {
                    SqlParameter[] detailParams = {
                        new SqlParameter("@saleId", generatedSaleId),
                        new SqlParameter("@dishId", item.Dish_Id),
                        new SqlParameter("@qty", item.Quantity)
                    };

                    using (var insertDetail = new InsertCommand())
                    {
                        insertDetail.ExecuteInsert(detailQuery, detailParams);
                    }
                }
                return generatedSaleId; // Retorna éxito con ID transaccional
            }
        }
    }
}
