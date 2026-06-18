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
            if (newClosure == null)
                throw new ArgumentNullException(nameof(newClosure), "Los datos del cierre de caja están vacíos.");

            if (newClosure.User_Id <= 0)
                throw new ArgumentException("No se ha identificado al usuario responsable del cierre de caja.");

            if (newClosure.Initial_Cash < 0 || newClosure.Calculated_Income < 0 || newClosure.Real_Cash < 0)
                throw new ArgumentException("Los montos declarados en el arqueo no pueden contener valores negativos.");

            newClosure.Cash_Discrepancy = newClosure.Real_Cash - newClosure.Calculated_Income;

            return newClosure.InsertClosure();
        }
    }
}
