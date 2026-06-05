using CevicheSys_Pro_2.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Gestiona la generación y el procesamiento de los datos del reporte financiero.
    /// </summary>
    public class FinancialReportBussines
    {
        private readonly FinancialRepository _financialRepository;

        public FinancialReportBussines(FinancialRepository financialRepository)
        {
            _financialRepository = financialRepository;
        }

        /// <summary>
        /// Genera un reporte financiero completamente poblado desde la base de datos para la UI.
        /// </summary>
        public FinancialReport GenerateReport(DateTime startDate, DateTime endDate)
        {
            // Instanciamos el objeto de dominio que normaliza las fechas automáticamente
            var report = new FinancialReport(startDate, endDate);

            // Poblar las propiedades del reporte invocando al repositorio
            report.TotalIncome = _financialRepository.GetTotalIncome(report.StartDate, report.EndDate);
            report.TotalExpenses = _financialRepository.GetTotalExpenses(report.StartDate, report.EndDate);
            report.MostSoldDish = _financialRepository.GetMostSoldDish(report.StartDate, report.EndDate);
            report.MostFrequentExpense = _financialRepository.GetMostFrequentExpenseDescription(report.StartDate, report.EndDate);
            report.SalesHistory = _financialRepository.GetSalesHistory(report.StartDate, report.EndDate);

            // Retornamos el objeto listo para ser bindeado a los controles de la pantalla
            return report;
        }
    }
}
