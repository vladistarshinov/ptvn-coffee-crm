using CoffeeCrmApp.DAL.Models;
using CoffeeCrmApp.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.Serialization
{
    public static class CustomerMapper
    {
        public static CustomerViewModel SerializeCustomerViewModel (Customer customer)
        {
            return new CustomerViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = CustomerAddressMapper(customer.PrimaryAddress),
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn
            };
        }

        public static Customer SerializeCustomerViewModel(CustomerViewModel customer)
        {
            return new Customer
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                PrimaryAddress = CustomerAddressMapper(customer.PrimaryAddress),
                CreatedOn = customer.CreatedOn,
                UpdatedOn = customer.UpdatedOn
            };
        }

        public static CustomerAddressViewModel CustomerAddressMapper(CustomerAddress address)
        {
            return new CustomerAddressViewModel
            {
                Country = address.Country,
                City = address.City,
                Address1 = address.Address1,
                Address2 = address.Address2,
                Email = address.Email,
            };
        }

        public static CustomerAddress CustomerAddressMapper(CustomerAddressViewModel address)
        {
            return new CustomerAddress
            {
                Country = address.Country,
                City = address.City,
                Address1 = address.Address1,
                Address2 = address.Address2,
                Email = address.Email,
            };
        }
    }
}
