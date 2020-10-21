using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using ItemTypes;
using System;

public class Inventory : MonoBehaviour
{
    List<Item> _items = new List<Item>();
    //could alternatively be List<T> _items = new List<T>();

    private void Start()
    {
        //add all the possible items
        _items.Add(new HealthPotion());
        _items[0].Constructor("Health Potion,", true, _ITEM_TYPE.POTION, "Heals you", 99);
    }

    public void Use(int _current_item, int _character)
    {
        if (_items[_current_item].GetItemCount() > 0)
        {
            _items[_current_item].UseItem(_character);
        }
    }

    public void AddItem(Item _item, int _items_to_add)
    {
        if(_item.GetStackable() && _item.GetMaxItemStack() < _item.GetMaxItemStack() + _items_to_add)
        {
            _item.AddItem(_items_to_add);
        }
        else
        {
            _items.Add(_item);
        }
    }

    private void SortInventory(_ITEM_TYPE _type)
    {
        switch(_type)
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
        }


    }
}