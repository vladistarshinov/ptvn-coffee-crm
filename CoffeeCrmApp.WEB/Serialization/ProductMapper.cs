using CoffeeCrmApp.WEB.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.Serialization
{
    public static class ProductMapper
    {
        /// <summary>
        /// Передает Product data model в Product view model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static ProductViewModel SerializeProductViewModel(DAL.Models.Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn
            };
        }

        /// <summary>
        /// Передает Product view model в Product data model
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public static DAL.Models.Product SerializeProductViewModel(ProductViewModel product)
        {
            return new DAL.Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                IsTaxable = product.IsTaxable,
                IsArchived = product.IsArchived,
                CreatedOn = product.CreatedOn,
                UpdatedOn = product.UpdatedOn
            };
        }
    }
}
