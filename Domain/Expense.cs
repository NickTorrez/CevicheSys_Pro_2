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
        public string Concept { get; set; }     // ACTUALIZADO según DB
        public decimal Amount { get; set; }     // ACTUALIZADO a Decimal
        public DateTime Date { get; set; }
        public int Category_Id { get; set; }
        public int User_Id { get; set; }        // ACTUALIZADO: FK obligatoria en BD
        public bool Enable { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Instancia un gasto vacío.
        /// </summary>
        public Expense()
        {
            Concept = string.Empty;
            Date = DateTime.Now;
            Amount = 0.0m;
            Enable = true;
        }

        /// <summary>
        /// Configura el registro contable de salida de efectivo con sus detalles y el usuario auditor.
        /// </summary>
        public Expense(int expenseId, string concept, decimal amount, DateTime date, int categoryId, int userId, bool enable = true)
        {
            Expense_Id = expenseId;
            Concept = concept;
            Amount = amount;
            Date = date;
            Category_Id = categoryId;
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
            var list = new List<Expense>();
            string query = "SELECT Expense_Id, Concept, Amount, Date, Category_Id, User_Id, Enable FROM Expense WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Expense(
                        Convert.ToInt32(row["Expense_Id"]),
                        row["Concept"].ToString(),
                        Convert.ToDecimal(row["Amount"]),
                        Convert.ToDateTime(row["Date"]),
                        Convert.ToInt32(row["Category_Id"]),
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
            string query = "INSERT INTO Expense (Concept, Amount, Date, Category_Id, User_Id, Enable) VALUES (@concept, @amount, @date, @catId, @userId, @enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@concept", this.Concept),
                new SqlParameter("@amount", this.Amount),
                new SqlParameter("@date", this.Date),
                new SqlParameter("@catId", this.Category_Id),
                new SqlParameter("@userId", this.User_Id),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        /// <summary>
        /// Realiza correcciones en la descripción o monto del gasto previamente salvado.
        /// </summary>
        public int UpdateExpense()
        {
            string query = "UPDATE Expense SET Concept = @concept, Amount = @amount, Date = @date, Category_Id = @catId WHERE Expense_Id = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", this.Expense_Id),
                new SqlParameter("@concept", this.Concept),
                new SqlParameter("@amount", this.Amount),
                new SqlParameter("@date", this.Date),
                new SqlParameter("@catId", this.Category_Id)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        /// <summary>
        /// Anula el registro financiero para que deje de afectar los cálculos.
        /// </summary>
        public int DisableExpense(int id)
        {
            string query = "UPDATE Expense SET Enable = 0 WHERE Expense_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }
    
}