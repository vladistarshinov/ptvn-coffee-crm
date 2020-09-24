using CoffeeCrmApp.BLL.Interfaces;
using CoffeeCrmApp.DAL;
using CoffeeCrmApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeCrmApp.BLL.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CoffeeCrmDbContext _db;

        public CustomerService(CoffeeCrmDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Добавляет нового покупателя в БД
        /// </summary>
        /// <param name="customer">Customer instance</param>
        /// <returns>ResponseService<Customer></returns>
        public ResponseService<Customer> CreateCustomer(Customer customer)
        {
            try
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();

                return new ResponseService<Customer>
                {
                    IsSuccess = true,
                    Data = customer,
                    Message = "Новый пользователь добавлен в систему",
                    Time = DateTime.UtcNow
                };
            }
            catch(Exception e)
            {
                return new ResponseService<Customer>
                {
                    IsSuccess = false,
                    Data = customer,
                    Message = e.StackTrace, 
                    Time = DateTime.UtcNow
                };
            }
        }

        /// <summary>
        /// Возвращает список всех покупателей, имеющихся в БД
        /// </summary>
        /// <returns>List<Customer></returns>
        public List<Customer> GetAllCustomers()
        {
            return _db.Customers
                .Include(customer => customer.PrimaryAddress)
                .OrderBy(customer => customer.LastName)
                .ToList();
        }

        /// <summary>
        /// Выводит покупателя по Id
        /// </summary>
        /// <param name="id">int customer primary key</param>
        /// <returns>Customer</returns>
        public Customer GetCustomerById(int id)
        {
            return _db.Customers.Find(id);
        }

        /// <summary>
        /// Удаляет пользователя из БД
        /// </summary>
        /// <param name="id">int customer primary key</param>
        /// <returns>ResponseService<bool></returns>
        public ResponseService<bool> DeleteCustomer(int id)
        {
            var customer = _db.Customers.Find(id);

            if (customer == null)
            {
                return new ResponseService<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = "Покупатель не найден!",
                    Time = DateTime.UtcNow
                };
            }

            try
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();

                return new ResponseService<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = "Покупатель успешно удален из системы",
                    Time = DateTime.UtcNow
                };
            }
            catch (Exception e)
            {
                return new ResponseService<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
