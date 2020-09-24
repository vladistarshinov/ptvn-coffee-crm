using CoffeeCrmApp.DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoffeeCrmApp.WEB.ViewModels
{
    public class CustomerViewModel
    {
        public int Id { get; set; }
        [MaxLength(32)] public string FirstName { get; set; }
        [MaxLength(32)] public string LastName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public CustomerAddressViewModel PrimaryAddress { get; set; }
    }

    public class CustomerAddressViewModel {
        public int Id { get; set; }
        [MaxLength(32)] public string Country { get; set; }
        [MaxLength(24)] public string City { get; set; }
        [MaxLength(50)] public string Address1 { get; set; }
        [MaxLength(50)] public string Address2 { get; set; }
        [MaxLength(50)] public string Email { get; set; }
    }
}