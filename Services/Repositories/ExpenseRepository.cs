using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.Repositories
{
    public class ExpenseRepository
    {
        private readonly string _connectionString;
        public ExpenseRepository(string connectionString) => _connectionString = connectionString;

        public bool Insert(Expense expense)
        {
            string query = "INSERT INTO Gasto (Descripcion, Monto, Fecha_Gasto, Id_Categoria, Enable) VALUES (@desc, @amount, @date, @catId, @enable)";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@desc", expense.Description);
                cmd.Parameters.AddWithValue("@amount", expense.Amount);
                cmd.Parameters.AddWithValue("@date", expense.Expense_Date);
                cmd.Parameters.AddWithValue("@catId", expense.Category_Id);
                cmd.Parameters.AddWithValue("@enable", expense.Enable);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
