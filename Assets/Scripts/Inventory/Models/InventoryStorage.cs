using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using System;

namespace Assets.Scripts.Inventory.Models
{
    public class InventoryStorage : MonoBehaviour
    {
        

        [SerializeField]
        public List<InventoryGridItem> _items = new List<InventoryGridItem>();
        public event EventHandler InventoryUpdated;
        //could alternatively be List<T> _items = new List<T>();

        private void Start()
        {
            HealthPotion small = Resources.Load<HealthPotion>("Storables/Items/Small Health Potion");
            HealthPotion medium = Resources.Load<HealthPotion>("Storables/Items/Medium Health Potion");
            HealthPotion large = Resources.Load<HealthPotion>("Storables/Items/Large Health Potion");
            //add all the possible items
            //AddItem(small, 5);
            //AddItem(medium, 8);
            //AddItem(large, 9);

            //_items[0].Constructor("Health Potion,", true, _ITEM_TYPE.POTION, "Heals you", 99);
        }

        public void Use(int _current_item, int _character)
        {
            /*if (_items[_current_item].GetItemCount() > 0)
            {
                _items[_current_item].UseItem(_character);
            }*/
        }

        public void AddItem(InventoryItem inventoryItem)
        {
            InventoryGridItem itemInInventory = _items.FirstOrDefault(i => i.InventoryItem.ItemStorable.ItemHash == inventoryItem.ItemStorable.ItemHash);

            if (itemInInventory != null)
            {
                if (itemInInventory.InventoryItem.ItemStorable.Stackable)
                {
                    int diff = itemInInventory.InventoryItem.ItemStorable.MaxItemStack - itemInInventory.InventoryItem.Quantity;
                    itemInInventory.InventoryItem.Quantity += inventoryItem.Quantity;
                    if (itemInInventory.InventoryItem.Quantity > itemInInventory.InventoryItem.ItemStorable.MaxItemStack)
                    {
                        itemInInventory.InventoryItem.Quantity = itemInInventory.InventoryItem.ItemStorable.MaxItemStack;
                        inventoryItem.Quantity -= diff;
                    }

                }
            }
            else
            {
                _items.Sort((item1, item2) =>
                {
                    if (item1.GridX < item2.GridX)
                    {
                        return -1;
                    }
                    else if (item1.GridX > item2.GridX)
                    {
                        return 1;
                    }
                    else
                    {
                        if (item1.GridY < item2.GridY)
                            return -1;
                        else if (item1.GridY > item2.GridY)
                            return 1;
                        else
                            return 0;
                    }
                });
                InventoryGridItem freeSlot = _items.FirstOrDefault((item) => item.InventoryItem == null);
                if (freeSlot == null)
                    throw new Exception("No more space in the inventory");
                freeSlot.InventoryItem = inventoryItem;
            }
        }

        public void AddItem(InventoryItem item, int x, int y)
        {
            InventoryGridItem itemInInventory = _items.FirstOrDefault(i => i.GridX == x && i.GridY == y); ;

            if (itemInInventory != null)
            {

                if (itemInInventory.InventoryItem != null)
                {
                    if (itemInInventory.InventoryItem.ItemStorable.Stackable)
                    {
                        int diff = itemInInventory.InventoryItem.ItemStorable.MaxItemStack - itemInInventory.InventoryItem.Quantity;
                        itemInInventory.InventoryItem.Quantity += item.Quantity;
                        if (itemInInventory.InventoryItem.Quantity > itemInInventory.InventoryItem.ItemStorable.MaxItemStack)
                        {
                            itemInInventory.InventoryItem.Quantity = itemInInventory.InventoryItem.ItemStorable.MaxItemStack;
                            item.Quantity -= diff;
                        }

                    }
                } else
                {
                    itemInInventory.InventoryItem = item;
                }
                InventoryUpdated?.Invoke(this, null);
                
            }
            else
            {
                throw new Exception("Lo slot non esiste");
            }
        }

        public void RemoveItem(InventoryGridItem item)
        {
            item.InventoryItem = null;
            InventoryUpdated?.Invoke(this, null);
        }



        public void GetContextWindow()
        {

        }

        private void SortInventory(_ITEM_TYPE _type)
        {
            /*switch(_type)
            {
                case _ITEM_TYPE.ARMOUR:
                    _items = _items.OrderBy(c => c.GetType() - Enum.GetNames(typeof(_ITEM_TYPE)).Length - 1).ToList();
                    break;
                case _ITEM_TYPE.FOOD:

                    break;
                case _ITEM_TYPE.POTION:

                    break;
                case _ITEM_TYPE.WEAPON:

                    break;
            }*/


        }
    }
}
