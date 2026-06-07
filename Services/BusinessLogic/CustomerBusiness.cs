using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Gestiona el CRUD y las reglas de validación para la tabla Cliente.
    /// </summary>
    public class CustomerBusiness
    {
        private readonly string _connectionString;

        public CustomerBusiness(string connectionString) => _connectionString = connectionString;

        public List<Customer> ObtainAllCustomers()
        {
            var customers = new List<Customer>();
            string query = "SELECT Id_Cliente, Nombre_Completo, Telefono, Enable FROM Cliente WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        customers.Add(new Customer(
                            Convert.ToInt32(reader["Id_Cliente"]),
                            reader["Nombre_Completo"].ToString(),
                            reader["Telefono"].ToString(),
                            Convert.ToBoolean(reader["Enable"])
                        ));
                    }
                }
            }
            return customers;
        }

        public bool RegisterCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (!customer.ValidateIdentification())
                throw new InvalidOperationException("El cliente debe poseer un nombre de longitud válida.");

            string query = "INSERT INTO Cliente (Nombre_Completo, Telefono, Enable) VALUES (@FullName, @Phone, @Enable)";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@FullName", customer.FullName);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Enable", customer.Enable);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModifyCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));
            if (customer.CustomerId <= 0) throw new ArgumentException("ID de cliente inválido.");
            if (!customer.ValidateIdentification())
                throw new InvalidOperationException("El nombre modificado no cumple las reglas.");

            string query = "UPDATE Cliente SET Nombre_Completo = @FullName, Telefono = @Phone WHERE Id_Cliente = @Id";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", customer.CustomerId);
                cmd.Parameters.AddWithValue("@FullName", customer.FullName);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveCustomer(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Cliente SET Enable = 0 WHERE Id_Cliente = @Id";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
