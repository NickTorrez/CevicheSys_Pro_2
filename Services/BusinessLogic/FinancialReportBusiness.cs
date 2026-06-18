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
        /// Genera y retorna un informe consolidado de auditoría dentro de un rango temporal explícito.
        /// </summary>
        public FinancialReport GenerateReport(DateTime start, DateTime end)
        {
            if (start.Date > end.Date)
                throw new ArgumentException("Restricción Inválida: La fecha inicial provista no puede ser posterior a la fecha final de corte.");

            // Instancia de negocio mapea y ejecuta los cálculos usando la capa contable del dominio
            FinancialReport report = new FinancialReport(start, end);
            report.LoadReportData();

            return report;
        }
    }
}
