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
        public FinancialReport GenerateReport(DateTime start, DateTime end)
        {
            if (start.Date > end.Date)
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha final.");

            FinancialReport report = new FinancialReport(start, end);
            report.LoadReportData();
            return report;
        }
    }
}
