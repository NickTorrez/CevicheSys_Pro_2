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
        public int InsertExpense(Expense newExpense)
        {
            if (newExpense == null) return 1;
            if (string.IsNullOrWhiteSpace(newExpense.Concept)) return 2;
            if (newExpense.Amount <= 0) return 3;
            if (newExpense.Category_Id <= 0 || newExpense.User_Id <= 0) return 4;

            bool success = newExpense.InsertExpense();
            return success ? 0 : 5;
        }

        public int UpdateExpense(Expense existingExpense)
        {
            if (existingExpense == null || existingExpense.Expense_Id <= 0) return 1;
            if (string.IsNullOrWhiteSpace(existingExpense.Concept)) return 2;
            if (existingExpense.Amount <= 0) return 3;
            if (existingExpense.Category_Id <= 0) return 4;

            bool success = existingExpense.UpdateExpense();
            return success ? 0 : 5;
        }

        public int DeleteExpense(int id)
        {
            if (id <= 0) return 1;
            Expense expenseToDelete = new Expense { Expense_Id = id };
            bool success = expenseToDelete.DeleteExpense();
            return success ? 0 : 5;
        }
    }
}
