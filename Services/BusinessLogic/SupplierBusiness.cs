using CevicheSys_Pro_2.UI.Catalogs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    //// <summary>
    /// Gestiona el CRUD y las reglas de validación estricta para la tabla Proveedor.
    /// </summary>
    public class SupplierBusiness
    {
        private readonly string _connectionString;

        public SupplierBusiness(string connectionString) => _connectionString = connectionString;

        public List<Supplier> ObtainAllSuppliers()
        {
            var suppliers = new List<Supplier>();
            string query = "SELECT Id_Proveedor, Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable FROM Proveedor WHERE Enable = 1";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (var reader = cmd.ExecuteReader())
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
            return suppliers;
        }

        public bool RegisterSupplier(Supplier supplier)
        {
            if (supplier == null) throw new ArgumentNullException(nameof(supplier));
            if (!supplier.ValidateIdentification())
                throw new InvalidOperationException("La Cédula o RUC debe tener al menos 14 caracteres.");
            if (string.IsNullOrWhiteSpace(supplier.FirstName) || string.IsNullOrWhiteSpace(supplier.LastName))
                throw new InvalidOperationException("Nombre y Apellido son obligatorios.");

            string query = @"INSERT INTO Proveedor (Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable) 
                             VALUES (@TaxId, @FirstName, @LastName, @Address, @Phone, @Email, @Enable)";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TaxId", supplier.TaxId);
                cmd.Parameters.AddWithValue("@FirstName", supplier.FirstName);
                cmd.Parameters.AddWithValue("@LastName", supplier.LastName);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);
                cmd.Parameters.AddWithValue("@Enable", supplier.Enable);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModifySupplier(Supplier supplier)
        {
            if (supplier == null || supplier.SupplierId <= 0) throw new ArgumentException("Proveedor no válido.");
            if (!supplier.ValidateIdentification()) throw new InvalidOperationException("Cédula/RUC inválida.");

            string query = @"UPDATE Proveedor SET Cedula_Ruc = @TaxId, Nombre = @FirstName, Apellido = @LastName, 
                             Direccion = @Address, Telefono = @Phone, Correo = @Email WHERE Id_Proveedor = @Id";

            using (var conn = new SqlConnection(_connectionString))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", supplier.SupplierId);
                cmd.Parameters.AddWithValue("@TaxId", supplier.TaxId);
                cmd.Parameters.AddWithValue("@FirstName", supplier.FirstName);
                cmd.Parameters.AddWithValue("@LastName", supplier.LastName);
                cmd.Parameters.AddWithValue("@Address", supplier.Address);
                cmd.Parameters.AddWithValue("@Phone", supplier.Phone);
                cmd.Parameters.AddWithValue("@Email", supplier.Email);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool RemoveSupplier(int id)
        {
            if (id <= 0) throw new ArgumentException("ID no válido.");
            string query = "UPDATE Proveedor SET Enable = 0 WHERE Id_Proveedor = @Id";

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
