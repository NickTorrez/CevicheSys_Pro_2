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
        #region Properties
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public decimal TotalSales { get; private set; }
        public decimal TotalExpenses { get; private set; }
        public decimal NetProfit { get; private set; }
        public List<DetailedSaleDTO> DetailedSales { get; private set; }
        #endregion

        #region Constructors
        public FinancialReport(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate.Date;
            this.EndDate = endDate.Date.AddDays(1).AddTicks(-1); // Extender al final del día (23:59:59)
            this.DetailedSales = new List<DetailedSaleDTO>();
        }
        #endregion

        #region Analytics Methods
        public void LoadReportData()
        {
            SqlParameter[] reportParameters = new SqlParameter[]
            {
                new SqlParameter("@Start", SqlDbType.DateTime) { Value = this.StartDate },
                new SqlParameter("@End", SqlDbType.DateTime) { Value = this.EndDate }
            };

            // 1. Calcular sumatoria totalizada de transacciones por venta de platillos activos
            string salesSql = "SELECT ISNULL(SUM(Total_Amount), 0) FROM Sale WHERE Record_Date BETWEEN @Start AND @End AND Enable = 1;";
            using (SelectQuery select = new SelectQuery())
            {
                object? result = select.ExecuteScalar(salesSql, reportParameters);
                this.TotalSales = result != null ? Convert.ToDecimal(result) : 0;
            }

            // 2. Calcular sumatoria agregada de egresos y gastos de operación
            string expensesSql = "SELECT ISNULL(SUM(Amount), 0) FROM Expense WHERE Date BETWEEN @Start AND @End AND Enable = 1;";
            // Clonar parámetros debido a que el comando SQL toma propiedad del array anterior
            SqlParameter[] reportParameters2 = new SqlParameter[]
            {
                new SqlParameter("@Start", SqlDbType.DateTime) { Value = this.StartDate },
                new SqlParameter("@End", SqlDbType.DateTime) { Value = this.EndDate }
            };
            using (SelectQuery select = new SelectQuery())
            {
                object? result = select.ExecuteScalar(expensesSql, reportParameters2);
                this.TotalExpenses = result != null ? Convert.ToDecimal(result) : 0;
            }

            // 3. Balance del ejercicio contable
            this.NetProfit = this.TotalSales - this.TotalExpenses;

            // 4. Carga desglosada y relacional de ventas detalladas para auditoría de cuadrícula
            string listSql = "SELECT s.Sale_Id, sd.Dish_Id, s.Record_Date, " +
                             "ISNULL(c.Full_Name, 'Cliente General') AS Customer, " +
                             "d.Dish_Type, d.Size, d.Price, sd.Quantity, " +
                             "(sd.Quantity * d.Price) AS Calculated_Total, " +
                             "s.Payment_Method, s.Purchase_Type, u.Username AS Auditor_User " +
                             "FROM Sale s " +
                             "INNER JOIN Sale_Detail sd ON s.Sale_Id = sd.Sale_Id " +
                             "INNER JOIN Dish d ON sd.Dish_Id = d.Dish_Id " +
                             "INNER JOIN Users u ON s.User_Id = u.User_Id " +
                             "LEFT JOIN Customer c ON s.Customer_Id = c.Customer_Id " +
                             "WHERE s.Record_Date BETWEEN @Start AND @End AND s.Enable = 1 AND sd.Enable = 1 " +
                             "ORDER BY s.Record_Date DESC;";

            SqlParameter[] reportParameters3 = new SqlParameter[]
            {
                new SqlParameter("@Start", SqlDbType.DateTime) { Value = this.StartDate },
                new SqlParameter("@End", SqlDbType.DateTime) { Value = this.EndDate }
            };

            this.DetailedSales.Clear();
            using (SelectQuery select = new SelectQuery())
            {
                DataTable table = select.ExecuteSelect(listSql, reportParameters3);
                foreach (DataRow row in table.Rows)
                {
                    this.DetailedSales.Add(new DetailedSaleDTO
                    {
                        Sale_Id = Convert.ToInt32(row["Sale_Id"]),
                        Dish_Id = Convert.ToInt32(row["Dish_Id"]),
                        Date = Convert.ToDateTime(row["Record_Date"]),
                        Customer = row["Customer"].ToString() ?? "Desconocido",
                        Dish_Type = row["Dish_Type"].ToString() ?? "Indefinido",
                        Size = row["Size"].ToString() ?? "Estándar",
                        Price = Convert.ToDecimal(row["Price"]),
                        Quantity = Convert.ToInt32(row["Quantity"]),
                        Total_Amount = Convert.ToDecimal(row["Calculated_Total"]),
                        Payment_Method = row["Payment_Method"].ToString() ?? "Efectivo",
                        Purchase_Type = row["Purchase_Type"].ToString() ?? "Local",
                        Auditor_User = row["Auditor_User"].ToString() ?? "Sistema"
                    });
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// Estructura DTO diseñada exclusivamente para formatear automáticamente las columnas del DataGridView.
    /// </summary>
    public class DetailedSaleDTO
    {
        public int Sale_Id { get; set; }
        public int Dish_Id { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; } = string.Empty;
        public string Dish_Type { get; set; } = string.Empty;
        public string Size { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total_Amount { get; set; }
        public string Payment_Method { get; set; } = string.Empty;
        public string Purchase_Type { get; set; } = string.Empty;
        public string Auditor_User { get; set; } = string.Empty;
    }

}