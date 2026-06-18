using CevicheSys_Pro_2.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para las salidas de efectivo.
    /// </summary>
    public class ExpenseBusiness
    {
        public DataTable ListExpenses() => new Expense().ListAllExpenses();

        public int InsertExpense(Expense newExpense)
        {
            if (newExpense == null)
                throw new ArgumentNullException(nameof(newExpense), "Los datos del gasto están vacíos.");

            if (string.IsNullOrWhiteSpace(newExpense.Concept))
                throw new ArgumentException("El concepto o descripción del gasto es obligatorio.");

            if (newExpense.Amount <= 0)
                throw new ArgumentException("El monto del gasto debe ser mayor a cero.");

            if (newExpense.Category_Id <= 0)
                throw new ArgumentException("Debe clasificar el gasto seleccionando una categoría válida.");

            if (newExpense.User_Id <= 0)
                throw new ArgumentException("No se ha identificado al usuario que registra el gasto.");

            return newExpense.InsertExpense();
        }

        public int UpdateExpense(Expense existingExpense)
        {
            if (existingExpense == null || existingExpense.Expense_Id <= 0)
                throw new ArgumentException("El gasto proporcionado es inválido para actualización.");

            if (string.IsNullOrWhiteSpace(existingExpense.Concept))
                throw new ArgumentException("El concepto o descripción del gasto es obligatorio.");

            if (existingExpense.Amount <= 0)
                throw new ArgumentException("El monto del gasto debe ser mayor a cero.");

            if (existingExpense.Category_Id <= 0)
                throw new ArgumentException("Debe clasificar el gasto seleccionando una categoría válida.");

            return existingExpense.UpdateExpense();
        }

        public int DeleteExpense(int id)
        {
            if (id <= 0)
                throw new ArgumentException("Se requiere un ID de gasto válido para anularlo.");

            Expense expenseToDelete = new Expense { Expense_Id = id };
            return expenseToDelete.DeleteExpense();
        }
    }
}
