using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CoffeeCrmApp.DAL.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }

        [MaxLength(32)]
        public string Country { get; set; }

        [MaxLength(24)]
        public string City { get; set; }

        [MaxLength(50)]
        public string Address1 { get; set; }

        [MaxLength(50)]
        public string Address2 { get; set; }

        [MaxLength(50)]
        public string Email { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
