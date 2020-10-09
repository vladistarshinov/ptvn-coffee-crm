using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeCrmApp.WEB.ViewModels
{
    public class InventorySnapshotViewModel
    {
        public int ProductId { get; set; }
        public List<int> QuantityOnHand { get; set; }
    }

    public class SnapshotResponse
    {
        public List<InventorySnapshotViewModel> InventorySnapshots { get; set; }
        public List<DateTime> Timeline { get; set; }
    }
}
