using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Registra las salidas financieras y costos operativos del negocio.
    /// </summary>
    public class Expense
    {
        #region Properties
        public int Expense_Id { get; set; }
        public int Category_Id { get; set; }
        public string Concept { get; set; } = string.Empty;
        public decimal Amount { get; set; } = 0m;
        public DateTime Date { get; set; } = DateTime.Today;
        public bool Enable { get; set; } = true;
        public int User_Id { get; set; }
        #endregion

        #region Constructors
        public Expense() { }
        #endregion

        #region Persistence Methods

        public DataTable ListAllExpenses()
        {
            string sql = "SELECT e.Expense_Id, e.Date, c.Category_Name AS Category, " +
                         "e.Concept, e.Amount " +
                         "FROM Expense e INNER JOIN Category c ON e.Category_Id = c.Category_Id " +
                         "LEFT JOIN Supplier s ON e.Supplier_Id = s.Supplier_Id WHERE e.Enable = 1 ORDER BY e.Date DESC;";
            using (SelectQuery select = new SelectQuery())
                return select.ExecuteSelect(sql);
        }

        public int InsertExpense()
        {
            string sql = @"INSERT INTO Expense (Category_Id, Concept, Amount, Date, Enable, User_Id) 
                           VALUES (@CategoryId, @Concept, @Amount, @Date, 1, @UserId)";

            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@Concept", SqlDbType.VarChar, 255) { Value = this.Concept.Trim() },
                new SqlParameter("@Amount", SqlDbType.Decimal) { Value = this.Amount },
                new SqlParameter("@Date", SqlDbType.Date) { Value = this.Date.Date },
                new SqlParameter("@UserId", SqlDbType.Int) { Value = this.User_Id }
            };

            return insert.ExecuteInsert(sql, parameters);
        }

        public int UpdateExpense()
        {
            string sql = @"UPDATE Expense SET Category_Id = @CategoryId, Concept = @Concept, Amount = @Amount, Date = @Date 
                           WHERE Expense_Id = @Id AND Enable = 1";

            using UpdateCommand update = new UpdateCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Expense_Id },
                new SqlParameter("@CategoryId", SqlDbType.Int) { Value = this.Category_Id },
                new SqlParameter("@Concept", SqlDbType.VarChar, 255) { Value = this.Concept.Trim() },
                new SqlParameter("@Amount", SqlDbType.Decimal) { Value = this.Amount },
                new SqlParameter("@Date", SqlDbType.Date) { Value = this.Date.Date }
            };

            return update.ExecuteUpdate(sql, parameters);
        }

        public int DeleteExpense()
        {
            string sql = "UPDATE Expense SET Enable = 0 WHERE Expense_Id = @Id";

            using DeleteCommand delete = new DeleteCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Expense_Id }
            };

            return delete.ExecuteDelete(sql, parameters);
        }
        #endregion

    }

}