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
        public int Supplier_Id { get; set; }
        public string Tax_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        /* --------------------------------------------------------------------- */
        /* Constructores (Llamadas a base() de Person)                           */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Inicializa un proveedor vacío por defecto.
        /// </summary>
        public Supplier() : base()
        {
            Tax_Id = string.Empty;
            First_Name = string.Empty;
            Last_Name = string.Empty;
            Address = string.Empty;
            Email = string.Empty;
        }

        /// <summary>
        /// Inicializa un proveedor con todos los datos legales y de contacto.
        /// </summary>
        public Supplier(int supplierId, string taxId, string firstName, string lastName, string address, string email, string phone, bool enable)
            : base(phone, enable)
        {
            Supplier_Id = supplierId;
            Tax_Id = taxId;
            First_Name = firstName;
            Last_Name = lastName;
            Address = address;
            Email = email;
        }

        /* --------------------------------------------------------------------- */
        /* Implementación del Polimorfismo (Regla de Identidad)                  */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Aplica la regla de negocio que verifica que la Cédula/RUC posea al menos 14 caracteres.
        /// </summary>
        public override bool ValidateIdentification()
        {
            return !string.IsNullOrWhiteSpace(Tax_Id) && Tax_Id.Trim().Length >= 14;
        }

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD (Persistencia desde el Dominio)                          */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Retorna el catálogo completo de proveedores activos.
        /// </summary>
        public List<Supplier> ListAllSuppliers()
        {
            var suppliers = new List<Supplier>();
            string query = "SELECT Supplier_Id, Tax_Id, First_Name, Last_Name, Address, Phone, Email, Enable FROM Supplier WHERE Enable = 1";

            using (var select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    suppliers.Add(new Supplier(
                        Convert.ToInt32(row["Supplier_Id"]),
                        row["Tax_Id"].ToString(),
                        row["First_Name"].ToString(),
                        row["Last_Name"].ToString(),
                        row["Address"].ToString(),
                        row["Email"].ToString(),
                        row["Phone"].ToString(),
                        Convert.ToBoolean(row["Enable"])
                    ));
                }
            }
            return suppliers;
        }

        /// <summary>
        /// Inserta un nuevo abastecedor en la base de datos.
        /// </summary>
        public int AddSupplier()
        {
            string query = @"INSERT INTO Supplier (Tax_Id, First_Name, Last_Name, Address, Phone, Email, Enable) 
                             VALUES (@TaxId, @FirstName, @LastName, @Address, @Phone, @Email, @Enable)";
            SqlParameter[] parameters = {
                new SqlParameter("@TaxId", this.Tax_Id),
                new SqlParameter("@FirstName", this.First_Name),
                new SqlParameter("@LastName", this.Last_Name),
                new SqlParameter("@Address", this.Address),
                new SqlParameter("@Phone", this.Phone),
                new SqlParameter("@Email", this.Email),
                new SqlParameter("@Enable", this.Enable)
            };

            using (var insert = new InsertCommand())
            {
                return insert.ExecuteInsert(query, parameters);
            }
        }

        /// <summary>
        /// Sobreescribe los datos del proveedor especificado.
        /// </summary>
        public int UpdateSupplier()
        {
            string query = @"UPDATE Supplier SET Tax_Id = @TaxId, First_Name = @FirstName, Last_Name = @LastName, 
                             Address = @Address, Phone = @Phone, Email = @Email WHERE Supplier_Id = @Id";
            SqlParameter[] parameters = {
                new SqlParameter("@Id", this.Supplier_Id),
                new SqlParameter("@TaxId", this.Tax_Id),
                new SqlParameter("@FirstName", this.First_Name),
                new SqlParameter("@LastName", this.Last_Name),
                new SqlParameter("@Address", this.Address),
                new SqlParameter("@Phone", this.Phone),
                new SqlParameter("@Email", this.Email)
            };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }

        /// <summary>
        /// Inhabilita al proveedor mediante borrado lógico.
        /// </summary>
        public int DisableSupplier(int id)
        {
            string query = "UPDATE Supplier SET Enable = 0 WHERE Supplier_Id = @Id";
            SqlParameter[] parameters = { new SqlParameter("@Id", id) };

            using (var update = new UpdateCommand())
            {
                return update.ExecuteUpdate(query, parameters);
            }
        }
    }

}
