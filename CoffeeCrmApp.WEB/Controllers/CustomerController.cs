﻿using CoffeeCrmApp.BLL.Interfaces;
using CoffeeCrmApp.WEB.Serialization;
using CoffeeCrmApp.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.Controllers
{
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger,
                               ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        [HttpGet("/api/customers/{id}")]
        public ActionResult GetCustomer(int id)
        {
            _logger.LogInformation("Получение клиента по Id");
            var customer = _customerService.GetCustomerById(id);
            return Ok(customer);
        }

        [HttpGet("/api/customers")]
        public ActionResult GetCustomers()
        {
            _logger.LogInformation("Получение списка всех клиентов");
            var customers = _customerService.GetAllCustomers();
            var customersList = customers
                .Select(customer => new CustomerViewModel
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    Phone = customer.Phone,
                    PrimaryAddress = CustomerMapper.CustomerAddressMapper(customer.PrimaryAddress),
                    CreatedOn = customer.CreatedOn,
                    UpdatedOn = customer.UpdatedOn
                })
                .OrderBy(customer => customer.Id)
                .ToList();
            return Ok(customersList);
        }

        [HttpPut("/api/customer/{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Изменение данных о клиенте");

            customer.UpdatedOn = DateTime.UtcNow;

            var customerData = CustomerMapper.SerializeCustomerViewModel(customer);
            var editCustomer = _customerService.UpdateCustomer(id, customerData);
            return Ok(editCustomer);
        }

        [HttpPost("/api/customer")]
        public ActionResult CreateNewCustomer([FromBody] CustomerViewModel customer)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Cоздание нового клиента");

            customer.CreatedOn = DateTime.UtcNow;
            customer.UpdatedOn = DateTime.UtcNow;

            var customerData = CustomerMapper.SerializeCustomerViewModel(customer);
            var newCustomer = _customerService.CreateCustomer(customerData);
            return Ok(newCustomer);
        }

        [HttpDelete("/api/customer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            _logger.LogInformation("Удаление клиента из базы");
            var customer = _customerService.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}
