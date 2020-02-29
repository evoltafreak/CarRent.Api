using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CarRent.Api.EF;
using OpenAPI.Models;

namespace CarRent.Api.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private MapperConfiguration _customerConfig;
        private MapperConfiguration _customerConfig2;
        public CustomerRepository()
        {
            _customerConfig = new MapperConfiguration(cfg => cfg.CreateMap<CustomerEntity, Customer>()
                .ForPath(dest => dest.Place.IdPlace, act => act.MapFrom(src => src.FidPlace)));
            _customerConfig2 = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerEntity>()
                .ForMember(dest => dest.FidPlace, act => act.MapFrom(src => src.Place.IdPlace)));
        }

        public long AddCustomer(Customer customer)
        {
            IMapper mapper = _customerConfig2.CreateMapper();
            CustomerEntity customerEntity = new CustomerEntity();
            using (var context = new CarRentDbContext())
            {
                customerEntity = mapper.Map<Customer, CustomerEntity>(customer);
                context.CustomerEntity.Add(customerEntity);
                context.SaveChanges();
            }
            return customerEntity.IdCustomer;
        }

        public void DeleteCustomerById(long idCustomer)
        {
            using (var context = new CarRentDbContext())
            {
                context.CustomerEntity.Remove(context.CustomerEntity.Single(c => c.IdCustomer == idCustomer));
                context.SaveChanges();
            }
        }


        public List<Customer> ReadAllCustomer()
        {
            List<CustomerEntity> customerList = new List<CustomerEntity>();
            using (var context = new CarRentDbContext())
            {
                customerList = context.CustomerEntity.ToList();
            }
            
            IMapper mapper = _customerConfig.CreateMapper();
            List<Customer> customers = mapper.Map<List<CustomerEntity>, List<Customer>>(customerList);
            return customers;
        }

        public Customer ReadCustomerById(long idCustomer)
        {
            CustomerEntity customerEntity = new CustomerEntity();
            using (var context = new CarRentDbContext())
            {
                customerEntity = context.CustomerEntity.FirstOrDefault(c => c.IdCustomer == idCustomer);
            }
            
            IMapper mapper = _customerConfig.CreateMapper();
            return mapper.Map<CustomerEntity, Customer>(customerEntity);
        }

        public void UpdateCustomer(Customer customer)
        {
            IMapper mapper = _customerConfig2.CreateMapper();
            using (var context = new CarRentDbContext())
            {
                context.CustomerEntity.Update(mapper.Map<Customer, CustomerEntity>(customer));
                context.SaveChanges();
            }
        }

    }
}
