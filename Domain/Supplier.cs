using System;
using System.Data;
using Microsoft.Data.SqlClient;
using CevicheSys_Pro_2.Services.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2
{
    /// <summary>
    /// Entidad que representa a los proveedores y pescadores del negocio. Hereda de Person.
    /// </summary>
    public class Supplier : Person
    {
        /* --------------------------------------------------------------------- */
        /* Propiedades Específicas de la Entidad                                 */
        /* --------------------------------------------------------------------- */
        public int SupplierId { get; set; }       // Id_Proveedor (PK)
        public string TaxId { get; set; }         // Cedula_Ruc
        public string FirstName { get; set; }     // Nombre
        public string LastName { get; set; }      // Apellido
        public string Address { get; set; }       // Direccion
        public string Email { get; set; }         // Correo

        /* --------------------------------------------------------------------- */
        /* Constructores (Llamadas a base() de Person)                           */
        /* --------------------------------------------------------------------- */
        public Supplier() : base()
        {
            TaxId = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
        }

        public Supplier(int supplierId, string taxId, string firstName, string lastName, string address, string email, string phone, bool enable)
            : base(phone, enable)
        {
            SupplierId = supplierId;
            TaxId = taxId;
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Email = email;
        }

        /* --------------------------------------------------------------------- */
        /* Implementación del Polimorfismo (Regla de Identidad)                  */
        /* --------------------------------------------------------------------- */
        public override bool ValidateIdentification()
        {
            // Regla estricta para el proveedor: Cédula o RUC válido en Nicaragua (mínimo 14 caracteres)
            return !string.IsNullOrWhiteSpace(TaxId) && TaxId.Trim().Length >= 14;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD (Persistencia desde el Dominio)                          */
        /* --------------------------------------------------------------------- */

        public List<Supplier> ListAllSuppliers()
        {
            var suppliers = new List<Supplier>();
            string query = "SELECT Id_Proveedor, Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable FROM Proveedor WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    suppliers.Add(new Supplier(
                        Convert.ToInt32(row["Id_Proveedor"]),
                        row["Cedula_Ruc"].ToString(),
                        row["Nombre"].ToString(),
                        row["Apellido"].ToString(),
                        row["Direccion"].ToString(),
                        row["Correo"].ToString(),
                        row["Telefono"].ToString(), // Mapea al campo base
                        Convert.ToBoolean(row["Enable"])   // Mapea al campo base
                    ));
                }
            }
            return suppliers;
        }

        public int AddSupplier()
        {
            string query = @"INSERT INTO Proveedor (Cedula_Ruc, Nombre, Apellido, Direccion, Telefono, Correo, Enable) 
                             VALUES (@TaxId, @FirstName, @LastName, @Address, @Phone, @Email, @Enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@TaxId", this.TaxId),
                new SqlParameter("@FirstName", this.FirstName),
                new SqlParameter("@LastName", this.LastName),
                new SqlParameter("@Address", this.Address),
                new SqlParameter("@Phone", this.Phone),   // Heredado
                new SqlParameter("@Email", this.Email),
                new SqlParameter("@Enable", this.Enable)  // Heredado
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        public int UpdateSupplier()
        {
            string query = @"UPDATE Proveedor SET Cedula_Ruc = @TaxId, Nombre = @FirstName, Apellido = @LastName, 
                             Direccion = @Address, Telefono = @Phone, Correo = @Email WHERE Id_Proveedor = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", this.SupplierId),
                new SqlParameter("@TaxId", this.TaxId),
                new SqlParameter("@FirstName", this.FirstName),
                new SqlParameter("@LastName", this.LastName),
                new SqlParameter("@Address", this.Address),
                new SqlParameter("@Phone", this.Phone),
                new SqlParameter("@Email", this.Email)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        public int DisableSupplier(int id)
        {
            string query = "UPDATE Proveedor SET Enable = 0 WHERE Id_Proveedor = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }

}
