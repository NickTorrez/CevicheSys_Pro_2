using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Modulo financiero para cuadrar la caja al finalizar el día, controlando ingresos reales contra calculados.
    /// </summary>
    public class CashClosure
    {
        #region Properties
        public int Closure_Id { get; set; }
        public int User_Id { get; set; }
        public DateTime Closure_Date { get; set; } = DateTime.Now;
        public decimal Initial_Cash { get; set; } = 0m;
        public decimal Calculated_Income { get; set; } = 0m;
        public decimal Real_Cash { get; set; } = 0m;
        public string Notes_Remarks { get; set; } = string.Empty;
        public decimal Cash_Discrepancy { get; set; } = 0m;
        public bool Enable { get; set; } = true;
        #endregion

        #region Constructors
        public CashClosure() { }
        #endregion

        #region Persistence Methods
        public int InsertClosure()
        {
            string sql = @"INSERT INTO Cash_Closure (User_Id, Closure_Date, Initial_Cash, Calculated_Income, Real_Cash, Notes_Remarks, Enable) 
                           VALUES (@UserId, @Date, @Initial, @Calculated, @Real, @Notes, 1)";

            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UserId", SqlDbType.Int) { Value = this.User_Id },
                new SqlParameter("@Date", SqlDbType.DateTime) { Value = this.Closure_Date },
                new SqlParameter("@Initial", SqlDbType.Decimal) { Value = this.Initial_Cash },
                new SqlParameter("@Calculated", SqlDbType.Decimal) { Value = this.Calculated_Income },
                new SqlParameter("@Real", SqlDbType.Decimal) { Value = this.Real_Cash },
                // Uso de -1 para representar VARCHAR(MAX) en SqlDbType
                new SqlParameter("@Notes", SqlDbType.VarChar, -1) { Value = (object)this.Notes_Remarks ?? DBNull.Value }
            };

            return insert.ExecuteInsert(sql, parameters);
        }
        #endregion
    }
}