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
        public int Closure_Id { get; set; }          // Id_Cierre (PK)
        public DateTime Closure_Date { get; set; }   // Fecha_Cierre
        public double Real_Cash { get; set; }        // Efectivo_Real (Físico en caja)
        public double Calculated_Income { get; set; } // Ingresos_Calculados por el sistema
        public double Cash_Discrepancy { get; set; }  // Descuadre (Monto Real - Monto Calculado)
        public bool Enable { get; set; }             // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public CashClosure()
        {
            Closure_Date = DateTime.Now;
            Enable = true;
        }

        public CashClosure(int closureId, DateTime closureDate, double realCash, double calculatedIncome, bool enable = true)
        {
            Closure_Id = closureId;
            Closure_Date = closureDate;
            Real_Cash = realCash;
            Calculated_Income = calculatedIncome;
            // El descuadre se calcula automáticamente protegiendo la integridad matemática
            Cash_Discrepancy = realCash - calculatedIncome;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        public List<CashClosure> ListAllClosures()
        {
            var list = new List<CashClosure>();
            string query = "SELECT Id_Cierre, Fecha_Cierre, Efectivo_Real, Ingresos_Calculados, Descuadre, Enable FROM Cierre_Caja WHERE Enable = 1 ORDER BY Fecha_Cierre DESC";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new CashClosure(
                        Convert.ToInt32(row["Id_Cierre"]),
                        Convert.ToDateTime(row["Fecha_Cierre"]),
                        Convert.ToDouble(row["Efectivo_Real"]),
                        Convert.ToDouble(row["Ingresos_Calculados"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        public int AddCashClosure()
        {
            string query = @"INSERT INTO Cierre_Caja (Fecha_Cierre, Efectivo_Real, Ingresos_Calculados, Descuadre, Enable) 
                             VALUES (@date, @real, @calc, @disc, @enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@date", this.Closure_Date),
                new SqlParameter("@real", this.Real_Cash),
                new SqlParameter("@calc", this.Calculated_Income),
                new SqlParameter("@disc", this.Cash_Discrepancy),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }
    }
}