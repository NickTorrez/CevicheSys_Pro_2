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
        #region Properties
        public int Supplier_Id { get; set; }
        public string Tax_Id { get; set; } = string.Empty;
        public string First_Name { get; set; } = string.Empty;
        public string Last_Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        #endregion

        #region Constructors
        public Supplier() : base() { }

        public Supplier(int supplierId, string taxId, string firstName, string lastName, string address, string phone, string email, bool enable):base(phone, enable)
        {
            Supplier_Id = supplierId;
            Tax_Id = taxId;
            First_Name = firstName;
            Last_Name = lastName;
            Address = address;
            Phone = phone;
            Email = email;
            Enable = enable;
        }

        #endregion

        #region Validation Methods
        public bool ExistsByTaxId(string taxId, int currentSupplierId)
        {
            string sql = "SELECT CASE WHEN EXISTS (SELECT 1 FROM Supplier WHERE Tax_Id = @Tax_Id AND Supplier_Id <> @Supplier_Id AND Enable = 1) THEN 1 ELSE 0 END;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Tax_Id", SqlDbType.VarChar, 20) { Value = taxId },
                new SqlParameter("@Supplier_Id", SqlDbType.Int) { Value = currentSupplierId }
            };

            using (SelectQuery select = new SelectQuery())
            {
                return select.IsDuplicate(sql, parameters);
            }
        }

        // Implementación del miembro abstracto heredado de Person
        public override bool ValidateIdentification()
        {
            // Validación básica: Tax_Id debe existir y no exceder 20 caracteres (coincide con el parámetro SqlDbType.VarChar, 20)
            return !string.IsNullOrWhiteSpace(this.Tax_Id) && this.Tax_Id.Length <= 20;
        }
        #endregion

        #region Persistence Methods

        public DataTable ListAllSuppliers()
        {
            string sql = "SELECT Supplier_Id, Tax_Id, First_Name, Last_Name, Address, Phone, Email FROM Supplier WHERE Enable = 1 ORDER BY Last_Name ASC, First_Name ASC;";
            using (SelectQuery select = new SelectQuery())
            {
                return select.ExecuteSelect(sql);
            }
        }

        public int InsertSupplier()
        {
            string sql = "INSERT INTO Supplier (Tax_Id, First_Name, Last_Name, Address, Phone, Email, Enable) " +
                         "VALUES (@Tax_Id, @First_Name, @Last_Name, @Address, @Phone, @Email, @Enable);";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Tax_Id", SqlDbType.VarChar, 20) { Value = this.Tax_Id },
                new SqlParameter("@First_Name", SqlDbType.VarChar, 50) { Value = this.First_Name },
                new SqlParameter("@Last_Name", SqlDbType.VarChar, 50) { Value = this.Last_Name },
                new SqlParameter("@Address", SqlDbType.VarChar, 255) { Value = (object?)this.Address ?? DBNull.Value },
                new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = (object?)this.Phone ?? DBNull.Value },
                new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = (object?)this.Email ?? DBNull.Value },
                new SqlParameter("@Enable", SqlDbType.Bit) { Value = this.Enable }
            };

            using (InsertCommand cmd = new InsertCommand())
            {
                return cmd.ExecuteInsert(sql, parameters);
            }
        }

        public int UpdateSupplier()
        {
            string sql = "UPDATE Supplier SET Tax_Id = @Tax_Id, First_Name = @First_Name, Last_Name = @Last_Name, " +
                         "Address = @Address, Phone = @Phone, Email = @Email, Enable = @Enable WHERE Supplier_Id = @Supplier_Id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Supplier_Id", SqlDbType.Int) { Value = this.Supplier_Id },
                new SqlParameter("@Tax_Id", SqlDbType.VarChar, 20) { Value = this.Tax_Id },
                new SqlParameter("@First_Name", SqlDbType.VarChar, 50) { Value = this.First_Name },
                new SqlParameter("@Last_Name", SqlDbType.VarChar, 50) { Value = this.Last_Name },
                new SqlParameter("@Address", SqlDbType.VarChar, 255) { Value = (object?)this.Address ?? DBNull.Value },
                new SqlParameter("@Phone", SqlDbType.VarChar, 20) { Value = (object?)this.Phone ?? DBNull.Value },
                new SqlParameter("@Email", SqlDbType.VarChar, 100) { Value = (object?)this.Email ?? DBNull.Value },
                new SqlParameter("@Enable", SqlDbType.Bit) { Value = this.Enable }
            };

            using (UpdateCommand cmd = new UpdateCommand())
            {
                return cmd.ExecuteUpdate(sql, parameters);
            }
        }

        public int DeleteSupplier()
        {
            string sql = "UPDATE Supplier SET Enable = 0 WHERE Supplier_Id = @Supplier_Id;";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Supplier_Id", SqlDbType.Int) { Value = this.Supplier_Id }
            };

            using (UpdateCommand cmd = new UpdateCommand())
            {
                return cmd.ExecuteUpdate(sql, parameters);
            }
        }
        #endregion
    }

}
