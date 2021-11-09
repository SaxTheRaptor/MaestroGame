using Assets.Scripts.Inventory.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Inventory.Controllers
{
    public abstract class AbstractInventoryManager: MonoBehaviour
    {

        public void SetListeners(List<InventoryGrid> invGrids)
        {
            invGrids.ForEach((invGrid) =>
           {
               invGrid.DragStarted += OnStartDrag;
               invGrid.DragEnded += OnEndDrag;
           });
        }


        public abstract void OnStartDrag(object sender, EventArgs args);

        public abstract void OnEndDrag(object sender, EventArgs args);
    }
}
