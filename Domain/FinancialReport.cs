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
        public decimal TotalIncome { get; private set; }
        public decimal TotalExpenses { get; private set; }
        public decimal TotalProfit => TotalIncome - TotalExpenses;
        public Dish MostSoldDish { get; private set; }
        public string MostFrequentExpense { get; private set; }
        public List<DetailedSaleDTO> SalesHistory { get; private set; }

        public FinancialReport(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate.Date;
            EndDate = endDate.Date.AddDays(1).AddTicks(-1);
            TotalIncome = 0m;
            TotalExpenses = 0m;
            MostFrequentExpense = "Sin registros";
            SalesHistory = new List<DetailedSaleDTO>();
        }


        public void LoadReportData()
        {
            LoadTotals();
            LoadMostSoldDish();
            LoadMostFrequentExpense();
            LoadSalesHistory();
        }

        private void LoadTotals()
        {
            SqlParameter[] parameters =
            {
                new SqlParameter("@start", StartDate),
                new SqlParameter("@end", EndDate)
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable incomeTable = select.ExecuteSelect(
                    "SELECT ISNULL(SUM(Total_Amount), 0) AS TotalIncome FROM Sale WHERE Record_Date BETWEEN @start AND @end AND Enable = 1",
                    parameters);

                if (incomeTable.Rows.Count > 0)
                    TotalIncome = Convert.ToDecimal(incomeTable.Rows[0]["TotalIncome"]);
            }

            SqlParameter[] expenseParams =
            {
                new SqlParameter("@start", StartDate.Date),
                new SqlParameter("@end", EndDate.Date)
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable expenseTable = select.ExecuteSelect(
                    "SELECT ISNULL(SUM(Amount), 0) AS TotalExpenses FROM Expense WHERE Date BETWEEN @start AND @end AND Enable = 1",
                    expenseParams);

                if (expenseTable.Rows.Count > 0)
                    TotalExpenses = Convert.ToDecimal(expenseTable.Rows[0]["TotalExpenses"]);
            }
        }

        private void LoadMostSoldDish()
        {
            string query = @"
                SELECT TOP 1 d.Dish_Id, d.Dish_Type, d.Size, d.Price, d.Is_Available, d.Enable
                FROM Sale_Detail sd
                INNER JOIN Sale s ON s.Sale_Id = sd.Sale_Id
                INNER JOIN Dish d ON d.Dish_Id = sd.Dish_Id
                WHERE s.Record_Date BETWEEN @start AND @end
                  AND s.Enable = 1
                  AND sd.Enable = 1
                GROUP BY d.Dish_Id, d.Dish_Type, d.Size, d.Price, d.Is_Available, d.Enable
                ORDER BY SUM(sd.Quantity) DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@start", StartDate),
                new SqlParameter("@end", EndDate)
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query, parameters);
                if (dt.Rows.Count == 0) return;

                DataRow row = dt.Rows[0];
                MostSoldDish = new Dish(
                    Convert.ToInt32(row["Dish_Id"]),
                    row["Dish_Type"].ToString(),
                    row["Size"].ToString(),
                    Convert.ToDecimal(row["Price"]),
                    Convert.ToBoolean(row["Is_Available"]),
                    Convert.ToBoolean(row["Enable"])
                );
            }
        }

        private void LoadMostFrequentExpense()
        {
            string query = @"
                SELECT TOP 1 c.Category_Name
                FROM Expense e
                INNER JOIN Category c ON c.Category_Id = e.Category_Id
                WHERE e.Date BETWEEN @start AND @end
                  AND e.Enable = 1
                GROUP BY c.Category_Name
                ORDER BY COUNT(*) DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@start", StartDate.Date),
                new SqlParameter("@end", EndDate.Date)
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query, parameters);
                if (dt.Rows.Count > 0)
                    MostFrequentExpense = dt.Rows[0]["Category_Name"].ToString();
            }
        }

        private void LoadSalesHistory()
        {
            string query = @"
                SELECT
                    s.Sale_Id,
                    s.Record_Date,
                    ISNULL(c.Full_Name, 'Cliente Mostrador') AS Customer,
                    d.Dish_Id,
                    d.Dish_Type,
                    d.Size,
                    d.Price,
                    sd.Quantity,
                    (d.Price * sd.Quantity) AS Total_Amount,
                    s.Payment_Method,
                    s.Purchase_Type,
                    u.Username AS Auditor_User
                FROM Sale s
                INNER JOIN Sale_Detail sd ON sd.Sale_Id = s.Sale_Id
                INNER JOIN Dish d ON d.Dish_Id = sd.Dish_Id
                INNER JOIN Users u ON u.User_Id = s.User_Id
                LEFT JOIN Customer c ON c.Customer_Id = s.Customer_Id
                WHERE s.Record_Date BETWEEN @start AND @end
                  AND s.Enable = 1
                  AND sd.Enable = 1
                ORDER BY s.Record_Date DESC";

            SqlParameter[] parameters =
            {
                new SqlParameter("@start", StartDate),
                new SqlParameter("@end", EndDate)
            };

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query, parameters);
                foreach (DataRow row in dt.Rows)
                {
                    SalesHistory.Add(new DetailedSaleDTO
                    {
                        Sale_Id = Convert.ToInt32(row["Sale_Id"]),
                        Dish_Id = Convert.ToInt32(row["Dish_Id"]),
                        Date = Convert.ToDateTime(row["Record_Date"]),
                        Customer = row["Customer"].ToString(),
                        Dish_Type = row["Dish_Type"].ToString(),
                        Size = row["Size"].ToString(),
                        Price = Convert.ToDecimal(row["Price"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Total_Amount = Convert.ToDecimal(row["Total_Amount"]),
                        Payment_Method = row["Payment_Method"].ToString(),
                        Purchase_Type = row["Purchase_Type"].ToString(),
                        Auditor_User = row["Auditor_User"].ToString()
                    });
                }
            }
        }

    }

    /// <summary>
    /// Estructura DTO diseñada exclusivamente para formatear automáticamente las columnas del DataGridView.
    /// </summary>
    public class DetailedSaleDTO
    {
        public int Sale_Id { get; set; }
        public int Dish_Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Dish_Type { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total_Amount { get; set; }
        public string Payment_Method { get; set; }
        public string Purchase_Type { get; set; }
        public string Auditor_User { get; set; }

        public DetailedSaleDTO()
        {
            Customer = string.Empty;
            Dish_Type = string.Empty;
            Size = string.Empty;
            Payment_Method = string.Empty;
            Purchase_Type = string.Empty;
            Auditor_User = string.Empty;
        }
    }

}