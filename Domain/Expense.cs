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
        public int Expense_Id { get; set; }     // Id_Gasto (PK)
        public string Description { get; set; } // Descripcion
        public double Amount { get; set; }      // Monto
        public DateTime Expense_Date { get; set; } // Fecha_Gasto
        public int Category_Id { get; set; }    // Id_Categoria (FK de tipo "Gastos")
        public bool Enable { get; set; }        // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Expense()
        {
            Description = string.Empty;
            Expense_Date = DateTime.Now;
            Amount = 0.0;
            Enable = true;
        }

        public Expense(int expenseId, string description, double amount, DateTime expenseDate, int categoryId, bool enable = true)
        {
            Expense_Id = expenseId;
            Description = description;
            Amount = amount;
            Expense_Date = expenseDate;
            Category_Id = categoryId;
            Enable = enable;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia (CRUD)                                        */
        /* --------------------------------------------------------------------- */

        public List<Expense> ListAllExpenses()
        {
            var list = new List<Expense>();
            string query = "SELECT Id_Gasto, Descripcion, Monto, Fecha_Gasto, Id_Categoria, Enable FROM Gasto WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Expense(
                        Convert.ToInt32(row["Id_Gasto"]),
                        row["Descripcion"].ToString(),
                        Convert.ToDouble(row["Monto"]),
                        Convert.ToDateTime(row["Fecha_Gasto"]),
                        Convert.ToInt32(row["Id_Categoria"]),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return list;
        }

        public int AddExpense()
        {
            string query = "INSERT INTO Gasto (Descripcion, Monto, Fecha_Gasto, Id_Categoria, Enable) VALUES (@desc, @amount, @date, @catId, @enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@desc", this.Description),
                new SqlParameter("@amount", this.Amount),
                new SqlParameter("@date", this.Expense_Date),
                new SqlParameter("@catId", this.Category_Id),
                new SqlParameter("@enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int UpdateExpense()
        {
            string query = "UPDATE Gasto SET Descripcion = @desc, Monto = @amount, Fecha_Gasto = @date, Id_Categoria = @catId WHERE Id_Gasto = @id";
            SqlParameter[] parameters = {
                new SqlParameter("@id", this.Expense_Id),
                new SqlParameter("@desc", this.Description),
                new SqlParameter("@amount", this.Amount),
                new SqlParameter("@date", this.Expense_Date),
                new SqlParameter("@catId", this.Category_Id)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableExpense(int id)
        {
            string query = "UPDATE Gasto SET Enable = 0 WHERE Id_Gasto = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }
    
}