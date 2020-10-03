using CoffeeCrmApp.BLL.Interfaces.Product;
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
    public class ProductController: ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet("/api/products")]
        public ActionResult GetProducts()
        {
            _logger.LogInformation("Загрузка всех товаров");
            var products = _productService.GetAllProducts();
            var productData = products
                .Select(product => ProductMapper.SerializeProductViewModel(product));
            return Ok(productData);
        }

        [HttpPost("/api/product")]
        public ActionResult AddNewProduct([FromBody] ProductViewModel product) 
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Добавление продукта");
            var newProduct = ProductMapper.SerializeProductViewModel(product);
            var newProductData = _productService.CreateNewProduct(newProduct);
            return Ok(newProductData);
        }

        [HttpPatch("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id)
        {
            _logger.LogInformation("Архивирование продукта");
            var archiveResult = _productService.ArchiveProduct(id);
            return Ok(archiveResult);
        }
    }
}
