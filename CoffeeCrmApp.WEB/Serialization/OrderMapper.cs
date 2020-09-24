using CoffeeCrmApp.DAL.Models;
using CoffeeCrmApp.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.Serialization
{
    public static class OrderMapper
    {
        public static SalesHistory SerializeInvoiceToOrder (InvoiceViewModel invoice)
        {
            var now = DateTime.UtcNow;
            var salesHistoryItems = invoice.OrderItems
                .Select(item => new SalesHistoryItem
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductViewModel(item.Product)
                }).ToList();

            return new SalesHistory
            {
                SalesHistories = salesHistoryItems,
                CreatedOn = now,
                UpdatedOn = now
            };
        }

        public static List<OrderViewModel> SerializeOrdersViewModel(IEnumerable<SalesHistory> orders)
        {
            return orders
                .Select(order => new OrderViewModel
                {
                    Id = order.Id,
                    OrderItems = SerializeOrderItems(order.SalesHistories),
                    Customer = CustomerMapper.SerializeCustomerViewModel(order.Customer),
                    CreatedOn = order.CreatedOn,
                    UpdatedOn = order.UpdatedOn,
                    IsPaid = order.IsPaid
                }).ToList();
        }

        private static List<OrderItemViewModel> SerializeOrderItems(IEnumerable<SalesHistoryItem> orderItems)
        {
            return orderItems
                .Select(item => new OrderItemViewModel
                {
                    Id = item.Id,
                    Quantity = item.Quantity,
                    Product = ProductMapper.SerializeProductViewModel(item.Product)
                }).ToList();
        }
    }
}
