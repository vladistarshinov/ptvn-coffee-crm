using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.DAL.Models
{
    public class SalesHistoryItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }
}
