using CoffeeCrmApp.BLL.Interfaces;
using CoffeeCrmApp.DAL;
using CoffeeCrmApp.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeeCrmApp.BLL.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly CoffeeCrmDbContext _db;
        private readonly ILogger<InventoryService> _logger;

        public InventoryService(CoffeeCrmDbContext dbContext, ILogger<InventoryService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        /// <summary>
        /// Возвращает все данные о товаре (инвентарь) из БД
        /// </summary>
        /// <returns>List<ProductInventory></returns> 
        public List<ProductInventory> GetCurrentInventory()
        {
            return _db.ProductInventories
                .Include(i => i.Product)
                .Where(i => !i.Product.IsArchived)
                .ToList();
        }

        /// <summary>
        /// Возвращает товар по его Id
        /// </summary>
        /// <param name="productId">productId</param>
        /// <returns>Product</returns>
        public ProductInventory GetProductById(int productId)
        {
            return _db.ProductInventories
                .Include(i => i.Product)
                .FirstOrDefault(i => i.Product.Id == productId);
        }

        /// <summary>
        /// Создает чек товара
        /// </summary>
        /// <param name="inventory"></param>
        private void CreateSnapshot(ProductInventory inventory)
        {
            var now = DateTime.UtcNow;

            var snapshot = new ProductInventorySnapshot
            {
                CreatedSnapshotOn = now,
                Product = inventory.Product,
                QuantityOnHand = inventory.QuantityOnHand
            };

            _db.Add(snapshot);
        }

        /// <summary>
        /// Редактирует единицы измерения для обеспечиваемого товара
        /// Регулирует значение QuantityOnHand в переменной setting
        /// </summary>
        /// <param name="id">product Id</param>
        /// <param name="setting">number of added/removed units from inventory</param>
        /// <returns>ResponseService<ProductInventory></returns>
        public ResponseService<ProductInventory> UpdateQuantities(int id, int setting)
        {
            var now = DateTime.UtcNow;
            try
            {
                var inventory = _db.ProductInventories
                    .Include(i => i.Product)
                    .First(i => i.Product.Id == id);

                inventory.QuantityOnHand += setting;

                try
                {
                    CreateSnapshot(inventory);
                }
                catch (Exception e)
                {
                    _logger.LogError("Ошибка при создании чека с товаром");
                    _logger.LogError(e.StackTrace);
                }

                _db.SaveChanges();

                return new ResponseService<ProductInventory>
                {
                    IsSuccess = true,
                    Data = inventory,
                    Message = $"Данные товара с идентификатором {id} изменены!",
                    Time = now
                };
            }
            catch
            {
                return new ResponseService<ProductInventory>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Ошибка при изменении данных товара",
                    Time = now
                };
            }
        }

        /// <summary>
        /// Вовзращает историю чеков товаров за последние 6 часов
        /// </summary>
        /// <returns>List<ProductInventorySnapshot></returns>
        public List<ProductInventorySnapshot> GetSnapshotsHistory()
        {
            var valueOfLastTime = DateTime.UtcNow - TimeSpan.FromHours(24);
            return _db.ProductInventorySnapshots
                .Include(s => s.Product)
                .Where(s =>
                       s.CreatedSnapshotOn > valueOfLastTime
                       && !s.Product.IsArchived
                ).ToList();
        }
    }
}
