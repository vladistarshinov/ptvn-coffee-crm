using CoffeeCrmApp.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeCrmApp.BLL.Interfaces
{
    public interface IInventoryService
    {
        public List<ProductInventory> GetCurrentInventory();
        public ProductInventory GetProductById(int productId);
        public ResponseService<ProductInventory> UpdateQuantities(int id, int setting);
        //public void CreateSnapshot();
        public List<ProductInventorySnapshot> GetSnapshotsHistory();
    }
}
