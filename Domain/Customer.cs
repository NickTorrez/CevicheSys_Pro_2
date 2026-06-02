using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;

namespace CevicheSys_Pro_2
{
    public class Customer
    {
        /* --------------------------------------------------------------------- */
        /* Campos / Atributos                                                    */
        /* --------------------------------------------------------------------- */
        private int _customer_Id;
        private string _full_Name;
        private string _phone;

        /* --------------------------------------------------------------------- */
        /* Propiedades con Validaciones                                          */
        /* --------------------------------------------------------------------- */
        public int Customer_Id { get => _customer_Id; set => _customer_Id = value; }
        public string Full_Name { get => _full_Name; set => _full_Name = value; }
        public string Phone { get => _phone; set => _phone = value; }

        /* --------------------------------------------------------------------- */
        /* Constructores                                                         */
        /* --------------------------------------------------------------------- */

        public Customer() { }

        public Customer(int id, string fullName, string phone)
        {
            _customer_Id = id; _full_Name = fullName; _phone = phone;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos                                                              */
        /* --------------------------------------------------------------------- */

        public static List<Customer> List()
        {
            var list = new List<Customer>();
            string query = "SELECT Id_Cliente, Nombre_Completo, Telefono FROM Cliente";
            using var select = new SelectQuery();
            DataTable dt = select.ExecuteSelect(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Customer
                {
                    Customer_Id = Convert.ToInt32(row["Id_Cliente"]),
                    Full_Name = row["Nombre_Completo"].ToString(),
                    Phone = row["Telefono"] != DBNull.Value ? row["Telefono"].ToString() : string.Empty
                });
            }
            return list;
        }

        public bool Save()
        {
            SqlParameter[] p = {
                new SqlParameter("@name", this.Full_Name),
                new SqlParameter("@phone", string.IsNullOrEmpty(this.Phone) ? DBNull.Value : this.Phone)
            };

            if (this.Customer_Id == 0)
            {
                string query = "INSERT INTO Cliente (Nombre_Completo, Telefono) VALUES (@name, @phone)";
                using var insert = new InsertCommand();
                this.Customer_Id = insert.ExecuteInsertReturnId(query, p);
            }
            else
            {
                string query = "UPDATE Cliente SET Nombre_Completo=@name, Telefono=@phone WHERE Id_Cliente=@id";
                var pUpdate = new List<SqlParameter>(p) { new SqlParameter("@id", this.Customer_Id) };
                using var update = new UpdateCommand();
                update.ExecuteUpdate(query, pUpdate.ToArray());
            }

            return true;
        }
    }
}