using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [MaxLength(32)] public string Name { get; set; }
        [MaxLength(100)] public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsTaxable { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}
