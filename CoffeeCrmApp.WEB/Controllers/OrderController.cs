using CoffeeCrmApp.BLL.Interfaces;
using CoffeeCrmApp.BLL.Interfaces.Product;
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
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger,
                               ICustomerService customerService,
                               IOrderService orderService)
        {
            _logger = logger;
            _customerService = customerService;
            _orderService = orderService;
        }

        [HttpGet("/api/orders")]
        public ActionResult GetOrders()
        {
            var orders = _orderService.GetAllOrders();
            var ordersList = OrderMapper.SerializeOrdersViewModel(orders);
            return Ok(ordersList);  
        }

        [HttpPost("/api/order")]
        public ActionResult GenerateNewOrder ([FromBody] InvoiceViewModel invoice)
        {
            _logger.LogInformation("Создание нового заказа");
            var order = OrderMapper.SerializeInvoiceToOrder(invoice);
            order.Customer = _customerService.GetCustomerById(invoice.CustomerId);
            _orderService.CreateInvoiceForOrder(order);
            return Ok();
        }

        [HttpPatch("/api/order/complete/{id}")]
        public ActionResult GetCompleteOrder(int id)
        {
            _logger.LogInformation($"Cтатус заказа {id} - оплачено");
            _orderService.SuccessOrderStatus(id);
            return Ok();
        }
    }
}
