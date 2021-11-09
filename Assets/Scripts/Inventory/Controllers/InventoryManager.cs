using Assets.Scripts.Inventory.UI;
using Assets.Scripts.Inventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Controllers
{
    public class InventoryManager: AbstractInventoryManager
    {
        public InventoryGrid invGrid;
        public List<InventoryGrid> openGrids = new List<InventoryGrid>();
        public List<InventoryStorage>  invStorages;
        private SelectedItemEventArgs initialItem;


        void Start()
        {
            Show(invStorages);
        }
        public override void OnEndDrag(object sender, EventArgs args)
        {
            SelectedItemEventArgs e = (SelectedItemEventArgs)args;

            if (e.selectedItem.GridX == initialItem.selectedItem.GridX && e.selectedItem.GridY == initialItem.selectedItem.GridY)
                return;

            InventoryItem item1 = e.selectedItem.InventoryItem;
            InventoryItem item2 = initialItem.selectedItem.InventoryItem;


            e.fromInventory.RemoveItem(e.selectedItem);
            initialItem.fromInventory.RemoveItem(initialItem.selectedItem);
            
            initialItem.fromInventory.AddItem(item1, initialItem.selectedItem.GridX, initialItem.selectedItem.GridY);
            e.fromInventory.AddItem(item2, e.selectedItem.GridX, e.selectedItem.GridY);
        }

        public override void OnStartDrag(object sender, EventArgs args)
        {
            SelectedItemEventArgs e = (SelectedItemEventArgs)args;
            initialItem = e;
        }

        public void Show(List<InventoryStorage> inventories)
        {
            openGrids.Clear();
            
            inventories.ForEach((inventory) =>
           {
               InventoryGrid inventGrid = Instantiate(invGrid, FindObjectOfType<Canvas>().transform, false);
               inventGrid.Show(inventory);
               openGrids.Add(inventGrid);

           });

            base.SetListeners(openGrids);
        }


    }
}
