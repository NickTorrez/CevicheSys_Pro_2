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
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Closure_Id { get; set; }
        public int User_Id { get; set; }             // ACTUALIZADO: FK obligatoria
        public DateTime Closure_Date { get; set; }
        public decimal Initial_Cash { get; set; }    // ACTUALIZADO: Fondo de caja ingresado en la mañana
        public decimal Calculated_Income { get; set; } 
        public decimal Real_Cash { get; set; }
        public string Notes_Remarks { get; set; }    // ACTUALIZADO: Para soportar las observaciones

        // Propiedad matemática excluida de SQL Server (Regla 3NF)
        public decimal Cash_Discrepancy { get; set; }
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa un informe de arqueo de caja con la fecha del sistema.
        /// </summary>
        public CashClosure()
        {
            Closure_Date = DateTime.Now;
            Notes_Remarks = string.Empty;
            Enable = true;
        }

        /// <summary>
        /// Crea una transacción de cierre precomputando de forma automática el descuadre sin romper la integridad 3NF.
        /// </summary>
        public CashClosure(int closureId, int userId, DateTime closureDate, decimal initialCash, decimal calculatedIncome, decimal realCash, string notes, bool enable = true)
        {
            Closure_Id = closureId;
            User_Id = userId;
            Closure_Date = closureDate;
            Initial_Cash = initialCash;
            Calculated_Income = calculatedIncome;
            Real_Cash = realCash;
            Notes_Remarks = notes;
            Cash_Discrepancy = realCash - calculatedIncome;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Extrae el historial forense de todos los balances diarios efectuados.
        /// </summary>
        public List<CashClosure> ListAllClosures()
        {
            List<CashClosure> list = new List<CashClosure>();
            string query = "SELECT Closure_Id, User_Id, Closure_Date, Initial_Cash, Calculated_Income, Real_Cash, Notes_Remarks, Enable FROM Cash_Closure WHERE Enable = 1 ORDER BY Closure_Date DESC";

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new CashClosure(
                        Convert.ToInt32(row["Closure_Id"]),
                        Convert.ToInt32(row["User_Id"]),
                        Convert.ToDateTime(row["Closure_Date"]),
                        Convert.ToDecimal(row["Initial_Cash"]),
                        Convert.ToDecimal(row["Calculated_Income"]),
                        Convert.ToDecimal(row["Real_Cash"]),
                        row["Notes_Remarks"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }

            return list;
        }

        /// <summary>
        /// Graba el arqueo físico del empleado en la tabla Cash_Closure, respetando la omisión del cálculo aritmético.
        /// </summary>
        public int AddCashClosure()
        {
            string query = @"INSERT INTO Cash_Closure (User_Id, Closure_Date, Initial_Cash, Calculated_Income, Real_Cash, Notes_Remarks, Enable)
                             VALUES (@userId, @date, @initial, @calculated, @real, @notes, @enable)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@userId", User_Id),
                new SqlParameter("@date", Closure_Date),
                new SqlParameter("@initial", Initial_Cash),
                new SqlParameter("@calculated", Calculated_Income),
                new SqlParameter("@real", Real_Cash),
                new SqlParameter("@notes", (object)Notes_Remarks ?? DBNull.Value),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
        }
    }
}