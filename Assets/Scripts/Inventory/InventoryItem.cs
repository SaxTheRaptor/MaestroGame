using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem 
{
    private int _quantity;
    private InventoryStorable _item;
    // Start is called before the first frame update
    public InventoryItem(InventoryStorable item, int quantity)
    {
        _quantity = quantity;
        _item = item;
    }
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            if (value < 0)
                    value = 0;
            _quantity = value;
        }
    }

    public InventoryStorable Item
    {
        get
        {
            return _item;
        }
    }
}
