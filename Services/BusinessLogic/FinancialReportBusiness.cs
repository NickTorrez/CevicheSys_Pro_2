using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador analítico para la recolección de métricas.
    /// </summary>
    public class FinancialReportBusiness
    {
        #region Constructores
        public FinancialReportBusiness()
        {
            // Sin dependencias iniciales requeridas
        }
        #endregion

        #region Métodos
        public FinancialReport GenerateReport(DateTime start, DateTime end)
        {
            try
            {
                if (start.Date > end.Date)
                    throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha final.");

                FinancialReport report = new FinancialReport(start, end);
                report.LoadReportData();

                return report;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la generación y cálculo del reporte financiero.", ex);
            }
        }
        #endregion
    }
}
