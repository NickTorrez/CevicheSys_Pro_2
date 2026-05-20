using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Expense
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _expense_Id;
        private string _description;
        private double _amount;
        private DateTime _expense_Date;
        private int _category_Id; // Llave foránea hacia Category (Applied_Module == "Gastos")

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Expense_Id { get => _expense_Id; set => _expense_Id = value; }
        public string Description { get => _description; set => _description = value; }
        public double Amount { get => _amount; set => _amount = value; }
        public DateTime Expense_Date { get => _expense_Date; set => _expense_Date = value; }
        public int Category_Id { get => _category_Id; set => _category_Id = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */
        public Expense()
        {
            _description = string.Empty;
            _expense_Date = DateTime.Now;
        }

        public Expense(int id, string description, double amount, DateTime expenseDate, int categoryId)
        {
            _expense_Id = id;
            _description = description;
            _amount = amount;
            _expense_Date = expenseDate;
            _category_Id = categoryId;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */
        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "expenses.json");

        public static List<Expense> List() // Obtener todos los gastos de la base de datos JSON
        {
            string directory = Path.GetDirectoryName(PathArchivo);
            if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

            if (!File.Exists(PathArchivo)) return new List<Expense>(); // Si el archivo no existe, se devuelve una lista vacía
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Expense>>(json) ?? new List<Expense>();
        }

        public bool Save() // Guardar o actualizar el gasto en la base de datos JSON
        {
            List<Expense> list = List();

            if (this.Expense_Id == 0)
            {
                this.Expense_Id = list.Count > 0 ? list.Max(g => g.Expense_Id) + 1 : 1; // Asigna un nuevo ID incremental
                list.Add(this);
            }
            else
            {
                int index = list.FindIndex(g => g.Expense_Id == this.Expense_Id); // Busca el índice del gasto existente para actualizarlo
                if (index != -1) list[index] = this; // Si se encuentra, se actualiza el gasto en la lista
            }

            string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Delete(int id) // Eliminar un gasto por su ID
        {
            List<Expense> list = List();
            int index = list.FindIndex(g => g.Expense_Id == id); // Busca el índice del gasto a eliminar
            if (index != -1) // Si se encuentra, se elimina de la lista y se actualiza el archivo JSON
            {
                list.RemoveAt(index);
                string json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }
    }
}