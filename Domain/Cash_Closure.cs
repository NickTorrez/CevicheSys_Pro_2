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
    public class Cash_Closure
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
        public Cash_Closure()
        {
            Closure_Date = DateTime.Now;
            Enable = true;
        }

        public Cash_Closure(int closureId, DateTime closureDate, double realCash, double calculatedIncome, bool enable = true)
        {
            Closure_Id = closureId;
            Closure_Date = closureDate;
            Real_Cash = realCash;
            Calculated_Income = calculatedIncome;
            // El descuadre se calcula automáticamente protegiendo la integridad matemática
            Cash_Discrepancy = realCash - calculatedIncome;
            Enable = enable;
        }
    }
}