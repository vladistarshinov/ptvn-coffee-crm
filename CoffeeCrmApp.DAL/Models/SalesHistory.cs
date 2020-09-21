using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.DAL.Models
{
    public class SalesHistory
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public Customer Customer { get; set; }
        public List<SalesHistoryItem> SalesHistories { get; set; }
        public bool IsPaid { get; set; }
    }
}
