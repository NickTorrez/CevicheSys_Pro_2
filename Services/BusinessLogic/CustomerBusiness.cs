using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CevicheSys_Pro_2.Domain;

namespace CevicheSys_Pro_2.Services.BusinessLogic
{
    /// <summary>
    /// Controlador de lógica de negocio para la gestión de clientes.
    /// </summary>
    public class CustomerBusiness
    {
        private readonly Customer customer = new Customer();

        public int InsertCustomer(Customer newCustomer)
        {
            if (newCustomer == null) return 1;
            if (!newCustomer.ValidateIdentification()) return 2;

            newCustomer.Full_Name = newCustomer.Full_Name.Trim();
            newCustomer.Phone = newCustomer.Phone?.Trim() ?? string.Empty;
            newCustomer.Enable = true;

            return newCustomer.AddCustomer() > 0 ? 0 : 5;
        }

        public int UpdateCustomer(Customer modifiedCustomer)
        {
            if (modifiedCustomer == null || modifiedCustomer.Customer_Id <= 0) return 1;
            if (!modifiedCustomer.ValidateIdentification()) return 2;

            modifiedCustomer.Full_Name = modifiedCustomer.Full_Name.Trim();
            modifiedCustomer.Phone = modifiedCustomer.Phone?.Trim() ?? string.Empty;

            return modifiedCustomer.UpdateCustomer() > 0 ? 0 : 5;
        }

        public int DisableCustomer(int id)
        {
            if (id <= 0) return 1;
            return customer.DisableCustomer(id) > 0 ? 0 : 5;
        }

        public List<Customer> ListCustomers()
        {
            return customer.ListAllCustomers();
        }
    }
}
