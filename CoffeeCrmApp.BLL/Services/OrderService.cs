using CoffeeCrmApp.BLL.Interfaces;
using CoffeeCrmApp.BLL.Interfaces.Product;
using CoffeeCrmApp.DAL;
using CoffeeCrmApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeCrmApp.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly CoffeeCrmDbContext _db;
        private readonly ILogger<OrderService> _logger;
        private readonly IProductService _productService;
        private readonly IInventoryService _inventoryService;

        public OrderService(CoffeeCrmDbContext dbContext, 
                            ILogger<OrderService> logger,
                            IProductService productService,
                            IInventoryService inventoryService)
        {
            _db = dbContext;
            _logger = logger;
            _productService = productService;
            _inventoryService = inventoryService;
        }

        /// <summary>
        /// Возвращает все заказы в системе
        /// </summary>
        /// <returns>List<SalesHistory></returns>
        public List<SalesHistory> GetAllOrders()
        {
            return _db.SalesHistories
                .Include(h => h.Customer)
                    .ThenInclude(с => с.PrimaryAddress)
                .Include(h => h.SalesHistories)
                    .ThenInclude(item => item.Product)
                .ToList();
        }

        /// <summary>
        /// Создает данные товара для чека покупателю
        /// </summary>
        /// <param name="order">order's data</param>
        /// <returns>ResponseService<bool></returns>
        public ResponseService<bool> CreateInvoiceForOrder(SalesHistory order)
        {
            var now = DateTime.UtcNow;

            _logger.LogInformation("Cгенерирован новый заказ");

            foreach (var item in order.SalesHistories)
            {
                item.Product = _productService
                    .GetProductById(item.Product.Id);

                // item.Quantity = item.Quantity;

                var inventoryId = _inventoryService
                    .GetProductById(item.Product.Id).Id;

                _inventoryService.UpdateQuantities(inventoryId, -item.Quantity);
            }

            try
            {
                _db.SalesHistories.Add(order);
                _db.SaveChanges();

                return new ResponseService<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = "Заказ создан",
                    Time = now
                };
            }
            catch (Exception e)
            {
                return new ResponseService<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }

        /// <summary>
        /// Ставит флаг о закрытии заказа (статус - оплачено)
        /// </summary>
        /// <param name="id">order id</param>
        /// <returns>ResponseService<bool></returns>
        public ResponseService<bool> SuccessOrderStatus(int id)
        {
            var now = DateTime.UtcNow;
            var order = _db.SalesHistories.Find(id);
            order.UpdatedOn = now;
            order.IsPaid = true;

            try
            {
                _db.SalesHistories.Update(order);
                _db.SaveChanges();

                return new ResponseService<bool>
                {
                    IsSuccess = true,
                    Data = true,
                    Message = $"Заказ {order.Id} закрыт: оплачено",
                    Time = now
                };
            }
            catch (Exception e)
            {
                return new ResponseService<bool>
                {
                    IsSuccess = false,
                    Data = false,
                    Message = e.StackTrace,
                    Time = now
                };
            }
        }
    }
}
