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
        private Customer customer;

        public CustomerBusiness()
        {
            customer = new Customer();
        }

        public int InsertCustomer(Customer newCustomer)
        {
            if (newCustomer == null) return 1;

            // Validación polimórfica heredada de la clase base Person
            if (!newCustomer.ValidateIdentification())
                return 2; // El nombre del cliente no cumple con la longitud mínima

            if (newCustomer.AddCustomer() > 0)
                return 0;
            else
                return 3; // Error de persistencia
        }

        public int UpdateCustomer(Customer modifiedCustomer)
        {
            if (modifiedCustomer == null || modifiedCustomer.Customer_Id <= 0) return 1;

            if (!modifiedCustomer.ValidateIdentification())
                return 2;

            if (modifiedCustomer.UpdateCustomer() > 0)
                return 0;
            else
                return 3;
        }

        public int DisableCustomer(int id)
        {
            if (id <= 0) return 1;

            if (customer.DisableCustomer(id) > 0)
                return 0;
            else
                return 3;
        }

        public List<Customer> ListCustomers()
        {
            return customer.ListAllCustomers();
        }
    }
}
