using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para las salidas de efectivo.
    /// </summary>
    public class ExpenseBusiness
    {
        private Expense expense;

        public ExpenseBusiness()
        {
            expense = new Expense();
        }

        public int InsertExpense(Expense newExpense)
        {
            if (newExpense == null) return 1;

            // Reglas de negocio contables
            if (newExpense.Amount <= 0) return 2; // Un egreso no puede ser cero o negativo
            if (string.IsNullOrWhiteSpace(newExpense.Concept)) return 3; // Debe justificarse la salida

            if (newExpense.AddExpense() > 0)
                return 0;
            else
                return 4;
        }

        public int UpdateExpense(Expense modifiedExpense)
        {
            if (modifiedExpense == null || modifiedExpense.Expense_Id <= 0) return 1;
            if (modifiedExpense.Amount <= 0) return 2;

            if (modifiedExpense.UpdateExpense() > 0)
                return 0;
            else
                return 4;
        }

        public int DisableExpense(int id)
        {
            if (id <= 0) return 1;

            if (expense.DisableExpense(id) > 0)
                return 0;
            else
                return 4;
        }

        public List<Expense> ListExpenses()
        {
            return expense.ListAllExpenses();
        }
    }
}
