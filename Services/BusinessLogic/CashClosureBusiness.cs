using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para el arqueo de caja.
    /// </summary>
    public class CashClosureBusiness
    {
        private readonly CashClosure closure = new CashClosure();

        public int InsertClosure(CashClosure newClosure)
        {
            if (newClosure == null) return 1;
            if (newClosure.User_Id <= 0) return 2;
            if (newClosure.Initial_Cash < 0) return 3;
            if (newClosure.Calculated_Income < 0) return 3;
            if (newClosure.Real_Cash < 0) return 3;

            newClosure.Notes_Remarks = newClosure.Notes_Remarks?.Trim() ?? string.Empty;
            newClosure.Cash_Discrepancy = newClosure.Real_Cash - newClosure.Calculated_Income;
            newClosure.Enable = true;

            return newClosure.AddCashClosure() > 0 ? 0 : 5;
        }

        public List<CashClosure> ListClosures()
        {
            return closure.ListAllClosures();
        }
    }
}
