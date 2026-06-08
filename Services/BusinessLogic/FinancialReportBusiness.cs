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
        /// <summary>
        /// Instancia y carga los datos del reporte utilizando las funciones autónomas del dominio.
        /// </summary>
        public FinancialReport GenerateReport(DateTime start, DateTime end)
        {
            // Validar coherencia de fechas
            if (start > end)
                throw new ArgumentException("La fecha de inicio no puede ser mayor que la fecha de fin.");

            // Instanciamos el objeto de dominio
            FinancialReport report = new FinancialReport(start, end);

            // El dominio recolecta su propia información
            report.LoadReportData();

            return report;
        }
    }
}
