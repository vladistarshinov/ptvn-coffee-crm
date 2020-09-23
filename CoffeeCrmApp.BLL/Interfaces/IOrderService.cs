using CoffeeCrmApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.BLL.Interfaces
{
    public interface IOrderService
    {
        List<SalesHistory> GetAllOrders();
        ResponseService<bool> CreateInvoiceForOrder(SalesHistory order);
        ResponseService<bool> SuccessOrderStatus(int id);
    }
}
