using UnityEngine;
using ItemTypes;


public abstract class Item :  InventoryStorable
{
    public abstract void UseItem(int character);

    public override GameObject GetContextMenu()
    {
        throw new System.NotImplementedException();
    }
}