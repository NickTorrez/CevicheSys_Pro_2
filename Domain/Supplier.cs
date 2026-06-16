using CevicheSys_Pro_2.Domain;
using CevicheSys_Pro_2.Services.Persistence;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

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

        public string FullName => $"{First_Name} {Last_Name}".Trim();

        /* --------------------------------------------------------------------- */
        /* Métodos CRUD (Persistencia desde el Dominio)                          */
        /* --------------------------------------------------------------------- */

        /// <summary>
        /// Retorna el catálogo completo de proveedores activos.
        /// </summary>
        public List<Supplier> ListAllSuppliers()
        {
            List<Supplier> list = new List<Supplier>();
            string query = "SELECT Supplier_Id, Tax_Id, First_Name, Last_Name, Address, Phone, Email, Enable FROM Supplier WHERE Enable = 1";

            using (SelectQuery select = new SelectQuery())
            {
                DataTable dt = select.ExecuteSelect(query);
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new Supplier(
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

            return list;
        }

        /// <summary>
        /// Inserta un nuevo abastecedor en la base de datos.
        /// </summary>
        public int AddSupplier()
        {
            string query = @"INSERT INTO Supplier (Tax_Id, First_Name, Last_Name, Address, Phone, Email, Enable)
                             VALUES (@taxId, @firstName, @lastName, @address, @phone, @email, @enable)";

            SqlParameter[] parameters =
            {
                new SqlParameter("@taxId", Tax_Id),
                new SqlParameter("@firstName", First_Name),
                new SqlParameter("@lastName", Last_Name),
                new SqlParameter("@address", (object)Address ?? DBNull.Value),
                new SqlParameter("@phone", (object)Phone ?? DBNull.Value),
                new SqlParameter("@email", (object)Email ?? DBNull.Value),
                new SqlParameter("@enable", Enable)
            };

            using (InsertCommand insert = new InsertCommand())
                return insert.ExecuteInsert(query, parameters);
            
        }

        /// <summary>
        /// Sobreescribe los datos del proveedor especificado.
        /// </summary>
        public int UpdateSupplier()
        {
            string query = @"UPDATE Supplier
                             SET Tax_Id = @taxId, First_Name = @firstName, Last_Name = @lastName,
                                 Address = @address, Phone = @phone, Email = @email
                             WHERE Supplier_Id = @id";

            SqlParameter[] parameters =
            {
                new SqlParameter("@id", Supplier_Id),
                new SqlParameter("@taxId", Tax_Id),
                new SqlParameter("@firstName", First_Name),
                new SqlParameter("@lastName", Last_Name),
                new SqlParameter("@address", (object)Address ?? DBNull.Value),
                new SqlParameter("@phone", (object)Phone ?? DBNull.Value),
                new SqlParameter("@email", (object)Email ?? DBNull.Value)
            };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }

        /// <summary>
        /// Inhabilita al proveedor mediante borrado lógico.
        /// </summary>
        public int DisableSupplier(int id)
        {
            string query = "UPDATE Supplier SET Enable = 0 WHERE Supplier_Id = @id";
            SqlParameter[] parameters = { new SqlParameter("@id", id) };

            using (UpdateCommand update = new UpdateCommand())
                return update.ExecuteUpdate(query, parameters);
        }
    }

}
