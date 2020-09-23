using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.BLL.Interfaces
{
    public interface ICustomerService
    {
        List<DAL.Models.Customer> GetAllCustomers();
        DAL.Models.Customer GetCustomerById(int id);
        ResponseService<DAL.Models.Customer> CreateCustomer(DAL.Models.Customer customer);
        ResponseService<bool> DeleteProduct(int id);
    }
}
