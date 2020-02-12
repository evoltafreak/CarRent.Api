using OpenAPI.Models;
using System.Collections.Generic;

namespace CarRent.Api.Services
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        void DeleteByCustomerId(long idCCustomer);
        List<Customer> ReadAllCustomer();
        Customer ReadCustomerById(long idCustomer);
        void UpdateCustomer(Customer customer);

    }
}
