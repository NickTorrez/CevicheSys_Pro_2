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
        #region Properties
        public int Sale_Id { get; set; }
        public int? Customer_Id { get; set; }
        public string Payment_Method { get; set; } = string.Empty;
        public string Purchase_Type { get; set; } = string.Empty;
        public decimal Total_Amount { get; set; } = 0m;
        public DateTime Record_Date { get; set; } = DateTime.Now;
        public int User_Id { get; set; }
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public Sale() { }
        #endregion

        #region Persistence Methods
        /// <summary>
        /// Inserta la cabecera de la venta y sus detalles correspondientes.
        /// </summary>
        public bool ProcessSaleWithDetails(List<SaleDetail> details)
        {
            string masterQuery = @"INSERT INTO Sale (User_Id, Customer_Id, Payment_Method, Purchase_Type, Total_Amount, Record_Date, Enable)
                                   VALUES (@UserId, @CustomerId, @PaymentMethod, @PurchaseType, @TotalAmount, @RecordDate, 1)";

            int generatedSaleId = 0;

            using (InsertCommand insertMaster = new InsertCommand())
            {
                SqlParameter[] masterParams = new SqlParameter[]
                {
                    new SqlParameter("@UserId", SqlDbType.Int) { Value = this.User_Id },
                    new SqlParameter("@CustomerId", SqlDbType.Int) { Value = (object)this.Customer_Id ?? DBNull.Value },
                    new SqlParameter("@PaymentMethod", SqlDbType.VarChar) { Value = this.Payment_Method.Trim() },
                    new SqlParameter("@PurchaseType", SqlDbType.VarChar) { Value = this.Purchase_Type.Trim() },
                    new SqlParameter("@TotalAmount", SqlDbType.Decimal) { Value = this.Total_Amount },
                    new SqlParameter("@RecordDate", SqlDbType.DateTime) { Value = this.Record_Date }
                };

                generatedSaleId = insertMaster.ExecuteInsertReturnId(masterQuery, masterParams);
            }

            if (generatedSaleId <= 0) return false;

            string detailQuery = "INSERT INTO Sale_Detail (Dish_Id, Sale_Id, Quantity, Enable) VALUES (@DishId, @SaleId, @Quantity, 1)";

            foreach (var item in details)
            {
                using (InsertCommand insertDetail = new InsertCommand())
                {
                    SqlParameter[] detailParams = new SqlParameter[]
                    {
                        new SqlParameter("@DishId", SqlDbType.Int) { Value = item.Dish_Id },
                        new SqlParameter("@SaleId", SqlDbType.Int) { Value = generatedSaleId },
                        new SqlParameter("@Quantity", SqlDbType.Int) { Value = item.Quantity }
                    };
                    insertDetail.ExecuteInsert(detailQuery, detailParams);
                }
            }

            return true;
        }
        #endregion
    }
}
