using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Expense
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _expense_Id;
        private string _description;
        private double _amount;
        private DateTime _expense_Date;
        private int _category_Id;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Expense_Id { get => _expense_Id; set => _expense_Id = value; }
        public string Description { get => _description; set => _description = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public DateTime Expense_Date { get => _expense_Date; set => _expense_Date = value; }
        public int Category_Id { get => _category_Id; set => _category_Id = value; }
  

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Expense()
        {
            _description = string.Empty;
            _expense_Date = DateTime.Now;
        }

        public Expense(int id, string description, double amount, DateTime expenseDate, int categoryId)
        {
            _expense_Id = id;
            _description = description;
            _amount = amount;
            _expense_Date = expenseDate;
            _category_Id = categoryId;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos                                                               */
        /* --------------------------------------------------------------------- */
        public static List<Expense> List()
        {
            var list = new List<Expense>();
            string query = "SELECT Id_Gasto, Concepto, Monto, Fecha, Id_Categoria FROM Gasto";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Expense
                {
                    Expense_Id = Convert.ToInt32(row["Id_Gasto"]),
                    Description = row["Concepto"].ToString(),
                    Amount = Convert.ToDouble(row["Monto"]),
                    Expense_Date = Convert.ToDateTime(row["Fecha"]),
                    Category_Id = Convert.ToInt32(row["Id_Categoria"])
                });
            }
            return list;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@conc", this.Description),
                new SqlParameter("@monto", this.Amount),
                new SqlParameter("@fec", this.Expense_Date),
                new SqlParameter("@cat", this.Category_Id)
            };

            if (this.Expense_Id == 0)
            {
                string query = "INSERT INTO Gasto (Concepto, Monto, Fecha, Id_Categoria) VALUES (@conc, @monto, @fec, @cat)";
                using var insert = new InsertCommand();
                this.Expense_Id = insert.ExecuteInsertReturnId(query, p);
            }
            else
            {
                string query = "UPDATE Gasto SET Concepto=@conc, Monto=@monto, Fecha=@fec, Id_Categoria=@cat WHERE Id_Gasto=@id";
                var pUpdate = new List<SqlParameter>(p) { new SqlParameter("@id", this.Expense_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUpdate.ToArray());
            }
            return true;
        }
    }
}