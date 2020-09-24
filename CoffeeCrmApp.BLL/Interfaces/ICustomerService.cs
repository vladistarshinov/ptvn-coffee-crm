using CoffeeCrmApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.BLL.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers();
        DAL.Models.Customer GetCustomerById(int id);
        ResponseService<Customer> CreateCustomer(Customer customer);
        ResponseService<bool> DeleteCustomer(int id);
    }
}
