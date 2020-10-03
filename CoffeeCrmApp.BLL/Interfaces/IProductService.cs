using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.BLL.Interfaces.Product
{
    public interface IProductService
    {
        List<DAL.Models.Product> GetAllProducts();
        DAL.Models.Product GetProductById(int id);
        ResponseService <DAL.Models.Product> CreateNewProduct(DAL.Models.Product product);
        ResponseService <DAL.Models.Product> ArchiveProduct(int id);
    }
}
