using CevicheSys_Pro_2.Services.Repositories;
using CevicheSys_Pro_2.Services.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class ExpenseBussines
    {
        private readonly ExpenseRepository _expenseRepository;
        public ExpenseBussines(ExpenseRepository repository) => _expenseRepository = repository;

        public bool RegisterExpense(Expense expense)
        {
            if (expense.Amount <= 0) throw new ArgumentException("El monto del gasto debe ser mayor a cero.");
            return _expenseRepository.Insert(expense);
        }
    }
}
