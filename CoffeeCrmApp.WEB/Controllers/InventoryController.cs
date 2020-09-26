using CoffeeCrmApp.BLL.Interfaces;
using CoffeeCrmApp.WEB.Serialization;
using CoffeeCrmApp.WEB.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.Controllers
{
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly ILogger<InventoryController> _logger;
        private readonly IInventoryService _inventoryService;

        public InventoryController(ILogger<InventoryController> logger,
                               IInventoryService inventoryService)
        {
            _logger = logger;
            _inventoryService = inventoryService;
        }

        [HttpGet("/api/inventory")]
        public ActionResult GetCurrentInventory()
        {
            _logger.LogInformation("Получение всех данных о продукте");
            var inventory = _inventoryService.GetCurrentInventory()
                .Select(i => new InventoryViewModel
                {
                    Id = i.Id,
                    QuantityOnHand = i.QuantityOnHand,
                    IdealQuantity = i.IdealQuantity,
                    Product = ProductMapper.SerializeProductViewModel(i.Product)
                })
                .OrderBy(inv => inv.Product.Name)
                .ToList();

            return Ok(inventory);
        }

        [HttpPatch("/api/inventory")]
        public ActionResult UpdateInventory ([FromBody] ShipmentViewModel shipment)
        {
            _logger.LogInformation("Изменение количества товара с Id " +
                                   $"{shipment.ProductId} - " +
                                   $"{shipment.SettingQuantities}");

            var id = shipment.ProductId;
            var settingQuantities = shipment.SettingQuantities;
            var inventory = _inventoryService.UpdateQuantities(id, settingQuantities);
            return Ok(inventory);
        }
    }
}
