using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;

namespace CevicheSys_Pro_2
{
    public class Supplier
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _supplier_Id;
        private string _tax_Id; // Representa la Cédula o RUC
        private string _first_Name;
        private string _last_Name;
        private string _address;
        private string _phone;
        private string _email;
        private string _product_Type; // Ej: "Mariscos", "Envases Plásticos"

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Supplier()
        {
            _tax_Id = string.Empty;
            _first_Name = string.Empty;
            _last_Name = string.Empty;
            _address = string.Empty;
            _phone = string.Empty;
            _email = string.Empty;
            _product_Type = string.Empty;
        }

        public Supplier(int id, string taxId, string firstName, string lastName, string address, string phone, string email, string productType)
        {
            _supplier_Id = id;
            _tax_Id = taxId;
            _first_Name = firstName;
            _last_Name = lastName;
            _address = address;
            _phone = phone;
            _email = email;
            _product_Type = productType;
        }

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Supplier_Id { get => _supplier_Id; set => _supplier_Id = value; }
        public string Tax_Id { get => _tax_Id; set => _tax_Id = value; }
        public string First_Name { get => _first_Name; set => _first_Name = value; }
        public string Last_Name { get => _last_Name; set => _last_Name = value; }
        public string Address { get => _address; set => _address = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Email { get => _email; set => _email = value; }
        public string Product_Type { get => _product_Type; set => _product_Type = value; }

        /* --------------------------------------------------------------------- */
        /* Métodos de Persistencia JSON                                          */
        /* --------------------------------------------------------------------- */

        private static string PathArchivo => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "suppliers.json");

        /// <summary>
        ///     Obtiene la lista de proveedores deserializando el contenido JSON almacenado en PathArchivo.
        /// </summary>
        /// <remarks>Puede lanzar excepciones de E/S o de deserialización si la lectura del archivo falla
        /// o el formato JSON es inválido. El archivo debe contener un arreglo JSON de objetos Supplier.</remarks>
        /// <returns>Lista de Supplier cargada desde el archivo; devuelve una lista vacía si el archivo no existe o si la
        /// deserialización produce null.</returns>
        public static List<Supplier> List()
        {
            if (!File.Exists(PathArchivo)) return new List<Supplier>();
            string json = File.ReadAllText(PathArchivo);
            return JsonSerializer.Deserialize<List<Supplier>>(json) ?? new List<Supplier>();
        }

        public bool Save()
        {
            List<Supplier> lista = List();

            // Si es un nuevo registro (Id == 0), autogeneramos el ID e insertamos
            if (this.Supplier_Id == 0)
            {
                // Regla: Evitar duplicados de cédula o RUC
                if (lista.Any(p => p.Tax_Id.Equals(this.Tax_Id, StringComparison.OrdinalIgnoreCase)))
                {
                    return false; // Retorna falso indicando que ya existe
                }

                this.Supplier_Id = lista.Count > 0 ? lista.Max(p => p.Supplier_Id) + 1 : 1;
                lista.Add(this);
            }
            else
            {
                // Si ya tiene ID, es una edición de datos
                int index = lista.FindIndex(p => p.Supplier_Id == this.Supplier_Id);
                if (index != -1)
                {
                    lista[index] = this;
                }
            }

            string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(PathArchivo, json);
            return true;
        }

        public static bool Delete(int id)
        {
            List<Supplier> lista = List();
            int index = lista.FindIndex(p => p.Supplier_Id == id);
            if (index != -1)
            {
                lista.RemoveAt(index);
                string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(PathArchivo, json);
                return true;
            }
            return false;
        }
    }

}
