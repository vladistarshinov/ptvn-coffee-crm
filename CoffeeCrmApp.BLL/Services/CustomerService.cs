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

        public ResponseService<Customer> UpdateCustomer(int id, Customer customer)
        {
       
            var customerById = _db.Customers
                .Include(customer => customer.PrimaryAddress)
                .FirstOrDefault(x => x.Id == id);

            if (customerById != null)
            {
                try
                {
                    customerById.Id = id;
                    customerById.FirstName = customer.FirstName;
                    customerById.LastName = customer.LastName;
                    customerById.Phone = customer.Phone;
                    customerById.CreatedOn = customer.CreatedOn;
                    customerById.UpdatedOn = DateTime.UtcNow;
                    customerById.PrimaryAddress.City = customer.PrimaryAddress.City;
                    customerById.PrimaryAddress.Country = customer.PrimaryAddress.Country;
                    customerById.PrimaryAddress.Address1 = customer.PrimaryAddress.Address1;
                    customerById.PrimaryAddress.Address2 = customer.PrimaryAddress.Address2;
                    customerById.PrimaryAddress.Email = customer.PrimaryAddress.Email;
                    customerById.PrimaryAddress.UpdatedOn = DateTime.UtcNow;

                    _db.SaveChanges();

                    return new ResponseService<Customer>
                    {
                        IsSuccess = true,
                        Data = customer,
                        Message = "Пользователь изменен в системе",
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

            return new ResponseService<Customer>
            {
                IsSuccess = false,
                Data = customer,
                Message = "Пользователь не найден в системе", 
                Time = DateTime.UtcNow
            };
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
