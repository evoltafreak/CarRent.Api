using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.Entities;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private MapperConfiguration _customerConfig;
        private MapperConfiguration _customerConfig2;
        private CarRentDbContext dbCtx;
        public CustomerRepository(CarRentDbContext dbCtx)
        {
            this.dbCtx = dbCtx;
            _customerConfig = new MapperConfiguration(cfg => cfg.CreateMap<CustomerEntity, Customer>()
                .ForPath(dest => dest.Place.IdPlace, act => act.MapFrom(src => src.FidPlace)));
            _customerConfig2 = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerEntity>()
                .ForMember(dest => dest.FidPlace, act => act.MapFrom(src => src.Place.IdPlace)));
        }

        public long AddCustomer(Customer customer)
        {
            IMapper mapper = _customerConfig2.CreateMapper();
            CustomerEntity customerEntity = mapper.Map<Customer, CustomerEntity>(customer);
            dbCtx.CustomerEntity.Add(customerEntity);
            dbCtx.SaveChanges();
            return customerEntity.IdCustomer;
        }

        public int DeleteCustomerById(long idCustomer)
        {
            dbCtx.CustomerEntity.Remove(dbCtx.CustomerEntity.Single(c => c.IdCustomer == idCustomer));
            return dbCtx.SaveChanges();
        }


        public List<Customer> ReadAllCustomer()
        {
            List<CustomerEntity> customerList = new List<CustomerEntity>();
            customerList = dbCtx.CustomerEntity.ToList();

            IMapper mapper = _customerConfig.CreateMapper();
            List<Customer> customers = mapper.Map<List<CustomerEntity>, List<Customer>>(customerList);
            return customers;
        }

        public Customer ReadCustomerById(long idCustomer)
        {
            CustomerEntity customerEntity = new CustomerEntity();
            customerEntity = dbCtx.CustomerEntity.FirstOrDefault(c => c.IdCustomer == idCustomer);

            IMapper mapper = _customerConfig.CreateMapper();
            return mapper.Map<CustomerEntity, Customer>(customerEntity);
        }

        public long UpdateCustomer(Customer customer)
        {
            IMapper mapper = _customerConfig2.CreateMapper();
            CustomerEntity customerEntity = mapper.Map<Customer, CustomerEntity>(customer);
            dbCtx.CustomerEntity.Update(customerEntity);
            dbCtx.SaveChanges();
            return customerEntity.IdCustomer;
        }

    }
}
