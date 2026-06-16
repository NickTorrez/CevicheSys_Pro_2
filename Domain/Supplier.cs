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
        #endregion

        #region Validation Methods
        /// <summary>
        /// Aplica la regla de identidad polimórfica heredada de Person.
        /// </summary>
        public override bool ValidateIdentification()
        {
            return !string.IsNullOrWhiteSpace(Tax_Id) && Tax_Id.Trim().Length >= 14;
        }
        #endregion

        #region Persistence Methods
        public bool ExistsByTaxId(string taxId, int currentId = 0)
        {
            string sql = "SELECT CASE WHEN EXISTS(SELECT 1 FROM Supplier WHERE Tax_Id = @TaxId AND Supplier_Id <> @Id AND Enable = 1) THEN 1 ELSE 0 END";
            using SelectQuery select = new SelectQuery();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TaxId", SqlDbType.VarChar) { Value = taxId.Trim() },
                new SqlParameter("@Id", SqlDbType.Int) { Value = currentId }
            };
            return select.IsDuplicate(sql, parameters);
        }

        public bool InsertSupplier()
        {
            string sql = @"INSERT INTO Supplier (Tax_Id, First_Name, Last_Name, Address, Phone, Email, Enable)
                           VALUES (@TaxId, @FirstName, @LastName, @Address, @Phone, @Email, 1)";
            using InsertCommand insert = new InsertCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@TaxId", SqlDbType.VarChar) { Value = this.Tax_Id.Trim() },
                new SqlParameter("@FirstName", SqlDbType.VarChar) { Value = this.First_Name.Trim() },
                new SqlParameter("@LastName", SqlDbType.VarChar) { Value = this.Last_Name.Trim() },
                new SqlParameter("@Address", SqlDbType.VarChar) { Value = (object)this.Address ?? DBNull.Value },
                new SqlParameter("@Phone", SqlDbType.VarChar) { Value = (object)this.Phone ?? DBNull.Value },
                new SqlParameter("@Email", SqlDbType.VarChar) { Value = (object)this.Email ?? DBNull.Value }
            };
            return insert.ExecuteInsert(sql, parameters) > 0;
        }

        public bool UpdateSupplier()
        {
            string sql = @"UPDATE Supplier SET Tax_Id = @TaxId, First_Name = @FirstName, Last_Name = @LastName,
                           Address = @Address, Phone = @Phone, Email = @Email WHERE Supplier_Id = @Id AND Enable = 1";
            using UpdateCommand update = new UpdateCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Supplier_Id },
                new SqlParameter("@TaxId", SqlDbType.VarChar) { Value = this.Tax_Id.Trim() },
                new SqlParameter("@FirstName", SqlDbType.VarChar) { Value = this.First_Name.Trim() },
                new SqlParameter("@LastName", SqlDbType.VarChar) { Value = this.Last_Name.Trim() },
                new SqlParameter("@Address", SqlDbType.VarChar) { Value = (object)this.Address ?? DBNull.Value },
                new SqlParameter("@Phone", SqlDbType.VarChar) { Value = (object)this.Phone ?? DBNull.Value },
                new SqlParameter("@Email", SqlDbType.VarChar) { Value = (object)this.Email ?? DBNull.Value }
            };
            return update.ExecuteUpdate(sql, parameters) > 0;
        }

        public bool DeleteSupplier()
        {
            string sql = "UPDATE Supplier SET Enable = 0 WHERE Supplier_Id = @Id";
            using DeleteCommand delete = new DeleteCommand();
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Id", SqlDbType.Int) { Value = this.Supplier_Id }
            };
            return delete.ExecuteDelete(sql, parameters) > 0;
        }
        #endregion
    }

}
