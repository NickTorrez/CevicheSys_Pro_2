using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.Repositories
{
    /// <summary>
    /// Repositorio concreto encargado del acceso a datos directo en SQL Server para la tabla Cliente.
    /// </summary>
    public class CustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT Id_Cliente, Nombre_Completo, Telefono, Enable FROM Cliente WHERE Enable = 1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
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
            }
            return customers;
        }

        public Customer GetById(int id)
        {
            string query = "SELECT Id_Cliente, Nombre_Completo, Telefono, Enable FROM Cliente WHERE Id_Cliente = @Id AND Enable = 1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Customer(
                                Convert.ToInt32(reader["Id_Cliente"]),
                                reader["Nombre_Completo"].ToString(),
                                reader["Telefono"].ToString(),
                                Convert.ToBoolean(reader["Enable"])
                            );
                        }
                    }
                }
            }
            return null;
        }

        public bool Insert(Customer customer)
        {
            string query = "INSERT INTO Cliente (Nombre_Completo, Telefono, Enable) VALUES (@FullName, @Phone, @Enable)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FullName", customer.FullName);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);
                    command.Parameters.AddWithValue("@Enable", customer.Enable);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Customer customer)
        {
            string query = "UPDATE Cliente SET Nombre_Completo = @FullName, Telefono = @Phone WHERE Id_Cliente = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", customer.CustomerId);
                    command.Parameters.AddWithValue("@FullName", customer.FullName);
                    command.Parameters.AddWithValue("@Phone", customer.Phone);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            string query = "UPDATE Cliente SET Enable = 0 WHERE Id_Cliente = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}
