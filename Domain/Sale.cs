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
        public int User_Id { get; set; }             // Id_Usuario (FK - Quién procesó la venta)
        public bool Enable { get; set; }              // Enable (1 = Venta Válida, 0 = Venta Anulada) 

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
    }
}
