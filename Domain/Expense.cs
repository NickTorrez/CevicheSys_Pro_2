using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Registra las salidas financieras y costos operativos del negocio.
    /// </summary>
    public class Expense
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades de la Entidad                                             */
        /* --------------------------------------------------------------------- */
        public int Expense_Id { get; set; }     // Id_Gasto (PK) 
        public string Description { get; set; } // Descripcion
        public double Amount { get; set; }      // Monto 
        public DateTime Expense_Date { get; set; } // Fecha_Gasto 
        public int Category_Id { get; set; }    // Id_Categoria (FK de tipo "Gastos") 
        public bool Enable { get; set; }        // Enable

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Expense()
        {
            Description = string.Empty;
            Expense_Date = DateTime.Now; 
            Amount = 0.0;
            Enable = true;
        }

        public Expense(int expenseId, string description, double amount, DateTime expenseDate, int categoryId, bool enable = true)
        {
            Expense_Id = expenseId;
            Description = description;
            Amount = amount;
            Expense_Date = expenseDate;
            Category_Id = categoryId;
            Enable = enable;
        }
    }
    
}