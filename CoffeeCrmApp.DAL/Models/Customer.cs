using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.DAL.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public CustomerAddress PrimaryAddress { get; set; }
    }
}
