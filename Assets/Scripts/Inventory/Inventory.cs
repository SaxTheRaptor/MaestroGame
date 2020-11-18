using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ItemTypes;
using System;

public class Inventory : MonoBehaviour
{
    List<InventoryItem> _items = new List<InventoryItem>();
    //could alternatively be List<T> _items = new List<T>();

    private void Start()
    {
        HealthPotion small = Resources.Load<HealthPotion>("Storables/Items/Small Health Potion");
        HealthPotion medium = Resources.Load<HealthPotion>("Storables/Items/Medium Health Potion");
        HealthPotion large = Resources.Load<HealthPotion>("Storables/Items/Large Health Potion");
        //add all the possible items
        AddItem(small, 5);
        AddItem(medium, 8);
        AddItem(large, 9);

        //_items[0].Constructor("Health Potion,", true, _ITEM_TYPE.POTION, "Heals you", 99);
    }

    public void Use(int _current_item, int _character)
    {
        /*if (_items[_current_item].GetItemCount() > 0)
        {
            _items[_current_item].UseItem(_character);
        }*/
    }

    public void AddItem(InventoryStorable item, int itemsToAdd)
    {
        InventoryItem itemInInventory = _items.FirstOrDefault(i => i.Item.ItemHash == item.ItemHash);
        
        if (itemInInventory != null)
        {
            if (itemInInventory.Item.Stackable)
            {
                itemInInventory.Quantity += itemsToAdd;
                if (itemInInventory.Quantity > itemInInventory.Item.MaxItemStack)
                    itemInInventory.Quantity = itemInInventory.Item.MaxItemStack;
            }
        }
        else
        {
            itemInInventory = new InventoryItem(item, itemsToAdd);
            _items.Add(itemInInventory);
        }
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