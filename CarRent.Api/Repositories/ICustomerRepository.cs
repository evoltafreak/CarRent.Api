using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public interface ICustomerRepository
    {
        long AddCustomer(Customer customer);
        void DeleteCustomerById(long idCustomer);
        List<Customer> ReadAllCustomer();
        Customer ReadCustomerById(long idCustomer);
        void UpdateCustomer(Customer customer);
    }
}
