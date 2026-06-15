using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.UI.Catalogs;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Clase de dominio que modela la estructura y el comportamiento lógico de un reporte financiero.
    /// para un rango de fechas determinado.
    /// </summary>
    public class FinancialReport
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public double TotalProfit => TotalIncome - TotalExpenses;
        public Dish MostSoldDish { get; set; }
        public string MostFrequentExpense { get; set; }
        public List<DetailedSaleDTO> SalesHistory { get; set; }

        public FinancialReport(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate.Date;
            EndDate = endDate.Date.AddDays(1).AddTicks(-1);
            SalesHistory = new List<DetailedSaleDTO>();
            MostFrequentExpense = "Sin registros";
        }


        public void LoadReportData()
        {
            // 1. Calcular Ingresos del Periodo
            string incomeQuery = "SELECT ISNULL(SUM(Total_Amount), 0) FROM Sale WHERE Record_Date BETWEEN @start AND @end AND Enable = 1";
            SqlParameter[] parameters = { new SqlParameter("@start", StartDate), new SqlParameter("@end", EndDate) };

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(incomeQuery, parameters);
                if (dt.Rows.Count > 0) TotalIncome = Convert.ToDouble(dt.Rows[0][0]);
            }

            // 2. Calcular Gastos Operativos del Periodo
            string expenseQuery = "SELECT ISNULL(SUM(Amount), 0) FROM Expense WHERE Date BETWEEN @start AND @end AND Enable = 1";
            SqlParameter[] parameters2 = { new SqlParameter("@start", StartDate), new SqlParameter("@end", EndDate) };

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(expenseQuery, parameters2);
                if (dt.Rows.Count > 0) TotalExpenses = Convert.ToDouble(dt.Rows[0][0]);
            }
        }

    }

    /// <summary>
    /// Estructura DTO diseñada exclusivamente para formatear automáticamente las columnas del DataGridView.
    /// </summary>
    public class DetailedSaleDTO
    {
        public int Sale_Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Dish_Type { get; set; }
        public string Size { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total_Amount { get; set; }
        public string Payment_Method { get; set; }
        public string Purchase_Type { get; set; }
        public string Auditor_User { get; set; }

    }

}