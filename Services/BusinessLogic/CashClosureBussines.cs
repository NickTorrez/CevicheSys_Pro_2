using CevicheSys_Pro_2.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.Services.Repositories;
using CevicheSys_Pro_2;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    public class CashClosureBussines
    {
        private readonly CashClosureRepository _closureRepository;
        private readonly FinancialRepository _financialRepository;

        public CashClosureBussines(CashClosureRepository closureRepo, FinancialRepository financialRepo)
        {
            _closureRepository = closureRepo;
            _financialRepository = financialRepo;
        }

        public bool PerformDailyClosure(double realCash)
        {
            DateTime today = DateTime.Today;
            DateTime endOfDay = today.AddDays(1).AddTicks(-1);

            double systemIncome = _financialRepository.GetTotalIncome(today, endOfDay);
            var closure = new Cash_Closure(0, DateTime.Now, realCash, systemIncome);

            return _closureRepository.SaveClosure(closure);
        }
    }
}
