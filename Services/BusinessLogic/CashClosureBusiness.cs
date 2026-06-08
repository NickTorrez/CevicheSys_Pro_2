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
        private CashClosure closure;

        public CashClosureBusiness()
        {
            closure = new CashClosure();
        }

        public int InsertClosure(CashClosure newClosure)
        {
            if (newClosure == null) return 1;

            // Regla: El dinero real reportado no puede ser un número negativo
            if (newClosure.Real_Cash < 0) return 2;

            // La propiedad Cash_Discrepancy ya fue validada matemáticamente en el constructor del Dominio

            if (newClosure.AddCashClosure() > 0)
                return 0;
            else
                return 3;
        }

        public List<CashClosure> ListClosures()
        {
            return closure.ListAllClosures();
        }
    }
}
