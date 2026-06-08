using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Entidad que representa a los clientes de la cevichería. Hereda de Person.
    /// </summary>
    public class Customer : Person
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades Específicas de la Entidad                                 */
        /* --------------------------------------------------------------------- */
        public int CustomerId { get; set; }      // Id_Cliente (PK)
        public string FullName { get; set; }     // Nombre_Completo

        /* --------------------------------------------------------------------- */
        /* Constructores (Llamadas a base() de Person)                           */
        /* --------------------------------------------------------------------- */
        public Customer() : base()
        {
            FullName = string.Empty;
        }

        public Customer(int customerId, string fullName, string phone, bool enable) : base(phone, enable)
        {
            CustomerId = customerId;
            FullName = fullName;
        }

        /* --------------------------------------------------------------------- */
        /* Implementación del Polimorfismo (Regla de Identidad)                  */
        /* --------------------------------------------------------------------- */
        public override bool ValidateIdentification()
        {
            // Regla para el cliente: El nombre completo debe tener datos válidos
            return !string.IsNullOrWhiteSpace(FullName) && FullName.Trim().Length >= 3;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD (Persistencia desde el Dominio)                          */
        /* --------------------------------------------------------------------- */

        public List<Customer> ListAllCustomers()
        {
            var customers = new List<Customer>();
            string query = "SELECT Id_Cliente, Nombre_Completo, Telefono, Enable FROM Cliente WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(new Customer(
                        Convert.ToInt32(row["Id_Cliente"]),
                        row["Nombre_Completo"].ToString(),
                        row["Telefono"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return customers;
        }

        public int AddCustomer()
        {
            string query = "INSERT INTO Cliente (Nombre_Completo, Telefono, Enable) VALUES (@FullName, @Phone, @Enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", this.FullName),
                new SqlParameter("@Phone", this.Phone), // Heredado de Person
                new SqlParameter("@Enable", this.Enable) // Heredado de Person
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters); // Retorna filas afectadas
            }
        }

        public int UpdateCustomer()
        {
            string query = "UPDATE Cliente SET Nombre_Completo = @FullName, Telefono = @Phone WHERE Id_Cliente = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", this.CustomerId),
                new SqlParameter("@FullName", this.FullName),
                new SqlParameter("@Phone", this.Phone)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableCustomer(int id)
        {
            string query = "UPDATE Cliente SET Enable = 0 WHERE Id_Cliente = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }
}