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
        private readonly Expense expense = new Expense();

        public int InsertExpense(Expense newExpense)
        {
            if (newExpense == null) return 1;
            if (string.IsNullOrWhiteSpace(newExpense.Concept)) return 2;
            if (newExpense.Amount <= 0) return 3;
            if (newExpense.Category_Id <= 0) return 4;
            if (newExpense.User_Id <= 0) return 4;

            newExpense.Concept = newExpense.Concept.Trim();
            newExpense.Enable = true;

            return newExpense.AddExpense() > 0 ? 0 : 5;
        }

        public int UpdateExpense(Expense modifiedExpense)
        {
            if (modifiedExpense == null || modifiedExpense.Expense_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(modifiedExpense.Concept)) return 2;
            if (modifiedExpense.Amount <= 0) return 3;
            if (modifiedExpense.Category_Id <= 0) return 4;

            modifiedExpense.Concept = modifiedExpense.Concept.Trim();

            return modifiedExpense.UpdateExpense() > 0 ? 0 : 5;
        }

        public int DisableExpense(int id)
        {
            if (id <= 0) return 1;
            return expense.DisableExpense(id) > 0 ? 0 : 5;
        }

        public List<Expense> ListExpenses()
        {
            return expense.ListAllExpenses();
        }
    }
}
