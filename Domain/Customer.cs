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
        public int Customer_Id { get; set; }
        public string Full_Name { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores (Llamadas a base() de Person)                           */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa un nuevo cliente vacío.
        /// </summary>
        public Customer() : base()
        {
            Full_Name = string.Empty;
        }

        /// <summary>
        /// Inicializa un cliente con la información completa.
        /// </summary>
        public Customer(int customerId, string fullName, string phone, bool enable) : base(phone, enable)
        {
            Customer_Id = customerId;
            Full_Name = fullName;
        }

        /* --------------------------------------------------------------------- */
        /* Implementación del Polimorfismo (Regla de Identidad)                  */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Valida que el nombre completo del cliente cumpla con el estándar mínimo de longitud.
        /// </summary>
        public override bool ValidateIdentification()
        {
            return !string.IsNullOrWhiteSpace(Full_Name) && Full_Name.Trim().Length >= 3;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD (Persistencia desde el Dominio)                          */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Obtiene el catálogo completo de clientes activos.
        /// </summary>
        public List<Customer> ListAllCustomers()
        {
            var customers = new List<Customer>();
            string query = "SELECT Customer_Id, Full_Name, Phone, Enable FROM Customer WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    customers.Add(new Customer(
                        Convert.ToInt32(row["Customer_Id"]),
                        row["Full_Name"].ToString(),
                        row["Phone"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return customers;
        }

        /// <summary>
        /// Inserta el cliente en la base de datos SQL Server.
        /// </summary>
        public int AddCustomer()
        {
            string query = "INSERT INTO Customer (Full_Name, Phone, Enable) VALUES (@FullName, @Phone, @Enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@FullName", this.Full_Name),
                new SqlParameter("@Phone", this.Phone),
                new SqlParameter("@Enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        /// <summary>
        /// Actualiza la información personal del cliente.
        /// </summary>
        public int UpdateCustomer()
        {
            string query = "UPDATE Customer SET Full_Name = @FullName, Phone = @Phone WHERE Customer_Id = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", this.Customer_Id),
                new SqlParameter("@FullName", this.Full_Name),
                new SqlParameter("@Phone", this.Phone)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        /// <summary>
        /// Realiza un borrado lógico del cliente ocultándolo del sistema.
        /// </summary>
        public int DisableCustomer(int id)
        {
            string query = "UPDATE Customer SET Enable = 0 WHERE Customer_Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }
}