using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.DAL.Models
{
    public class ProductInventory
    {
        public int Id { get; set; }
        public int QuantityOnHand { get; set; }
        public int IdealQuantity { get; set; }
        public Product Product { get; set; }
    }
}
