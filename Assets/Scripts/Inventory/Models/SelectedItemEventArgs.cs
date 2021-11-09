using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Inventory.Models
{
    public class SelectedItemEventArgs: EventArgs
    {
        public InventoryStorage fromInventory;
        public InventoryGridItem selectedItem;
    }
}
