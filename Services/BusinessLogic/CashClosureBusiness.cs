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

            // Los montos financieros no deben ser negativos (aunque el real podría ser cero si hubo robo/pérdida total)
            if (newClosure.Initial_Cash < 0 || newClosure.Calculated_Income < 0 || newClosure.Real_Cash < 0) return 3;

            // Se calcula el descuadre internamente antes de insertar para asegurar integridad lógica
            newClosure.Cash_Discrepancy = newClosure.Real_Cash - newClosure.Calculated_Income;

            bool success = newClosure.InsertClosure();
            return success ? 0 : 4;
        }
    }
}
