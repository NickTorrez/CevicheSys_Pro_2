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
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Expense_Id { get; set; }
        public int Category_Id { get; set; }
        public string Concept { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public bool Enable { get; set; }
        public int User_Id { get; set; }


        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Instancia un gasto vacío.
        /// </summary>
        public Expense()
        {
            Concept = string.Empty;
            Date = DateTime.Today;
            Amount = 0m;
            Enable = true;
        }

        /// <summary>
        /// Configura el registro contable de salida de efectivo con sus detalles y el usuario auditor.
        /// </summary>
        public Expense(int expenseId, int categoryId, string concept, decimal amount, DateTime date, int userId, bool enable = true)
        {
            Expense_Id = expenseId;
            Category_Id = categoryId;
            Concept = concept;
            Amount = amount;
            Date = date;
            User_Id = userId;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Recupera el historial completo de egresos reportados.
        /// </summary>
        public List<Expense> ListAllExpenses()
        {
            List<Expense> list = new List<Expense>();
            string query = "SELECT Expense_Id, Category_Id, Concept, Amount, Date, User_Id, Enable FROM Expense WHERE Enable = 1";

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Expense(
                        Convert.ToInt32(row["Expense_Id"]),
                        Convert.ToInt32(row["Category_Id"]),
                        row["Concept"].ToString(),
                        Convert.ToDecimal(row["Amount"]),
                        Convert.ToDateTime(row["Date"]),
                        Convert.ToInt32(row["User_Id"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }

            return list;
        }

        /// <summary>
        /// Consolida en la base de datos una nueva salida de efectivo.
        /// </summary>
        public int AddExpense()
        {
            string query = @"INSERT INTO Expense (Category_Id, Concept, Amount, Date, Enable, User_Id)
                             VALUES (@categoryId, @concept, @amount, @date, @enable, @userId)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@categoryId", Category_Id),
                new SqlParameter("@concept", Concept),
                new SqlParameter("@amount", Amount),
                new SqlParameter("@date", Date.Date),
                new SqlParameter("@enable", Enable),
                new SqlParameter("@userId", User_Id)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
        }

        /// <summary>
        /// Realiza correcciones en la descripción o monto del gasto previamente salvado.
        /// </summary>
        public int UpdateExpense()
        {
            string query = @"UPDATE Expense
                             SET Category_Id = @categoryId, Concept = @concept, Amount = @amount, Date = @date
                             WHERE Expense_Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", Expense_Id),
                new SqlParameter("@categoryId", Category_Id),
                new SqlParameter("@concept", Concept),
                new SqlParameter("@amount", Amount),
                new SqlParameter("@date", Date.Date)
            };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }

        /// <summary>
        /// Anula el registro financiero para que deje de afectar los cálculos.
        /// </summary>
        public int DisableExpense(int id)
        {
            string query = "UPDATE Expense SET Enable = 0 WHERE Expense_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }
    }
    
}