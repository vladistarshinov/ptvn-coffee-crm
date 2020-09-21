using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.DAL.Models
{
    public class ProductInventorySnapshot
    {
        public int Id { get; set; }
        public int QuantityOnHand { get; set; }
        public DateTime CreatedSnapshotOn { get; set; }
        public Product Product { get; set; }
    }
}
