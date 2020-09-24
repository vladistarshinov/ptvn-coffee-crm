using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public CustomerViewModel Customer { get; set; }
        public List<OrderItemViewModel> OrderItems { get; set; }
        public bool IsPaid { get; set; }
    }
}
