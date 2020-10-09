using CoffeeCrmApp.BLL.Interfaces.Product;
using CoffeeCrmApp.DAL;
using CoffeeCrmApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeCrmApp.BLL.Services
{
    public class ProductService : IProductService
    {

        private readonly CoffeeCrmDbContext _db;

        public ProductService(CoffeeCrmDbContext dbContext)
        {
            _db = dbContext;
        }

        /// <summary>
        /// Получить все товары из БД
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        /// <summary>
        /// Получить товар по Id из БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Product GetProductById(int id)
        {
            return _db.Products.Find(id);
        }

        /// <summary>
        /// Получить инвентарь товара по Id из БД
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInventory GetProductInventoryById(int id)
        {
            return _db.ProductInventories.Find(id);
        }

        /// <summary>
        /// Создать новый товар в БД
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ResponseService<Product> CreateNewProduct(Product product)
        {
            try
            {
                _db.Products.Add(product);

                var newInventory = new ProductInventory
                {
                    Product = product,
                    QuantityOnHand = 0,
                    IdealQuantity = 10
                };

                _db.ProductInventories.Add(newInventory);
                _db.SaveChanges();

                return new ResponseService<Product>
                {
                    IsSuccess = true,
                    Message = "Новый товар создан в системе",
                    Data = product,
                    Time = DateTime.UtcNow
                };

            } catch (Exception e)
            {
                return new ResponseService<Product>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = product,
                    Time = DateTime.UtcNow
                };
            }
        }

        /// <summary>
        /// Заархивировать товар по флагу IsArchived
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ResponseService<Product> ArchiveProduct(int id)
        {
            try
            {
                var product = _db.Products.Find(id);
                product.IsArchived = true;
                _db.SaveChanges();

                return new ResponseService<Product>
                {
                    IsSuccess = true,
                    Message = "Товар заархивирован",
                    Data = product,
                    Time = DateTime.UtcNow
                };

            }
            catch (Exception e)
            {
                return new ResponseService<Product>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = null,
                    Time = DateTime.UtcNow
                };
            }
        }
    }
}
