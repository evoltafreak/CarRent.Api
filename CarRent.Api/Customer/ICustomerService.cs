﻿using OpenAPI.Models;
using System.Collections.Generic;

namespace CarRent.Api.Services
{
    public interface ICustomerService
    {
        long AddCustomer(Customer customer);
        int DeleteByCustomerId(long idCCustomer);
        List<Customer> ReadAllCustomer();
        Customer ReadCustomerById(long idCustomer);
        long UpdateCustomer(Customer customer);

    }
}
