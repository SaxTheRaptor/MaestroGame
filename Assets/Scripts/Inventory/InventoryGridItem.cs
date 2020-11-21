using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

/* This is will hold a reference to the actual item stored in the cell, the cell position in the grid(x,y)
 * and a reference to the actual game object cell. Thought it was cool to add an abstraction
 * layer here, didnt think it was a good idea to let the actual cell view have this sorta info */
class InventoryGridItem
{
    private InventoryItem _item;
    private int _gridX, _gridY;
    public InventoryGridItem()
    {

    }


    /*This will take the grid specific parameters like position and scale and will return the
        cell gameobject, which will be added to the grid transform
        This class will also pass the sprite and label
    */
    public GameObject InstantiateGridCell()
    {
        return null;
    }

    public InventoryItem Item { get => _item; set => _item = value; }
    public int GridX { get => _gridX; set => _gridX = value; }
    public int GridY { get => _gridY; set => _gridY = value; }
}

