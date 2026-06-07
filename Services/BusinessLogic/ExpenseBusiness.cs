using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Gestiona el ciclo CRUD de los gastos operativos, permitiendo correcciones en caso de errores de caja.
    /// </summary>
    public class ExpenseBusiness
    {
        private readonly string _connectionString;

        public ExpenseBusiness(string connectionString) => _connectionString = connectionString;

        public List<Expense> ObtainAllExpenses()
        {
            var list = new List<Expense>();
            string query = "SELECT Id_Gasto, Descripcion, Monto, Fecha_Gasto, Id_Categoria, Enable FROM Gasto WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new Expense(
                            Convert.ToInt32(r["Id_Gasto"]),
                            r["Descripcion"].ToString(),
                            Convert.ToDouble(r["Monto"]),
                            Convert.ToDateTime(r["Fecha_Gasto"]),
                            Convert.ToInt32(r["Id_Categoria"]),
                            Convert.ToBoolean(r["Enable"])
                        ));
                    }
                }
            }
            return list;
        }

        public bool RegisterExpense(Expense expense)
        {
            if (expense == null) throw new ArgumentNullException(nameof(expense));
            if (expense.Amount <= 0) throw new ArgumentException("El monto del gasto debe ser estrictamente mayor a cero.");

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

        public bool ModifyExpense(Expense expense)
        {
            if (expense == null || expense.Expense_Id <= 0) throw new ArgumentException("Gasto inválido.");
            if (expense.Amount <= 0) throw new ArgumentException("El monto no puede ser cero o negativo.");

            string query = "UPDATE Gasto SET Descripcion = @desc, Monto = @amount, Fecha_Gasto = @date, Id_Categoria = @catId WHERE Id_Gasto = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", expense.Expense_Id);
                cmd.Parameters.AddWithValue("@desc", expense.Description);
                cmd.Parameters.AddWithValue("@amount", expense.Amount);
                cmd.Parameters.AddWithValue("@date", expense.Expense_Date);
                cmd.Parameters.AddWithValue("@catId", expense.Category_Id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveExpense(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Gasto SET Enable = 0 WHERE Id_Gasto = @id";
            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
