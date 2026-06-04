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
    /// Repositorio concreto encargado del acceso a datos directo en SQL Server para la tabla Proveedor.
    /// </summary>
    public class SupplierRepository
    {
        private readonly string _connectionString;

        public SupplierRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Supplier> GetAll()
        {
            List<Supplier> suppliers = new List<Supplier>();
            string query = "SELECT Id_Proveedor, Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable FROM Proveedor WHERE Enable = 1";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new Supplier(
                                Convert.ToInt32(reader["Id_Proveedor"]),
                                reader["Cedula_Ruc"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Apellido"].ToString(),
                                reader["Direccion"].ToString(),
                                reader["Correo"].ToString(),
                                reader["Telefono"].ToString(),
                                Convert.ToBoolean(reader["Enable"])
                            ));
                        }
                    }
                }
            }
            return suppliers;
        }

        public Supplier GetById(int id)
        {
            string query = "SELECT Id_Proveedor, Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable FROM Proveedor WHERE Id_Proveedor = @Id AND Enable = 1";

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
                            return new Supplier(
                                Convert.ToInt32(reader["Id_Proveedor"]),
                                reader["Cedula_Ruc"].ToString(),
                                reader["Nombre"].ToString(),
                                reader["Apellido"].ToString(),
                                reader["Direccion"].ToString(),
                                reader["Correo"].ToString(),
                                reader["Telefono"].ToString(),
                                Convert.ToBoolean(reader["Enable"])
                            );
                        }
                    }
                }
            }
            return null;
        }

        public bool Insert(Supplier supplier)
        {
            string query = @"INSERT INTO Proveedor (Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable) 
                            VALUES (@TaxId, @FirstName, @LastName, @Address, @Phone, @Email, @Enable)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TaxId", supplier.TaxId);
                    command.Parameters.AddWithValue("@FirstName", supplier.FirstName);
                    command.Parameters.AddWithValue("@LastName", supplier.LastName);
                    command.Parameters.AddWithValue("@Address", supplier.Address);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone);
                    command.Parameters.AddWithValue("@Email", supplier.Email);
                    command.Parameters.AddWithValue("@Enable", supplier.Enable);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Update(Supplier supplier)
        {
            string query = @"UPDATE Proveedor 
                            SET Cedula_Ruc = @TaxId, Nombre = @FirstName, Apellido = @LastName, 
                                Direccion = @Address, Telefono = @Phone, Correo = @Email 
                            WHERE Id_Proveedor = @Id";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", supplier.SupplierId);
                    command.Parameters.AddWithValue("@TaxId", supplier.TaxId);
                    command.Parameters.AddWithValue("@FirstName", supplier.FirstName);
                    command.Parameters.AddWithValue("@LastName", supplier.LastName);
                    command.Parameters.AddWithValue("@Address", supplier.Address);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone);
                    command.Parameters.AddWithValue("@Email", supplier.Email);

                    connection.Open();
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool Delete(int id)
        {
            string query = "UPDATE Proveedor SET Enable = 0 WHERE Id_Proveedor = @Id";

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
