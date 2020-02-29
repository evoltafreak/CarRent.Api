using System.Collections.Generic;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public interface ICustomerRepository
    {
        long AddCustomer(Customer customer);
        int DeleteCustomerById(long idCustomer);
        List<Customer> ReadAllCustomer();
        Customer ReadCustomerById(long idCustomer);
        long UpdateCustomer(Customer customer);
    }
}
