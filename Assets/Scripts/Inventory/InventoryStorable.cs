using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryStorable : ScriptableObject
{
    [SerializeField]
    protected string _itemHash;
    [SerializeField]
    protected string _itemName;
    [SerializeField]
    protected bool _isStackable;
    [SerializeField]
    protected string _itemDescription;
    [SerializeField]
    protected Sprite _itemSprite;
    [SerializeField]
    protected int _maxItemStack;

    public void Constructor(string name, bool isStackable, int maxItemStack, string description, string itemHash)
    {
        _itemName = name;
        _itemDescription = description;
        _maxItemStack = maxItemStack;
        _isStackable = isStackable;
        _itemHash = itemHash;
    }

    public abstract GameObject GetContextMenu();
    
    public string Name
    {
        get
        {
            return _itemName;
        }
    }
   
    public string Description
    {
        get
        {
            return _itemDescription;
        }
    }
    public bool Stackable
    {
        get
        {
            return _isStackable;
        }
    }

    public int MaxItemStack
    {
        get
        {
            return Stackable ? _maxItemStack : 1;
        }
    }

    public string ItemHash
    {
        get
        {
            return _itemHash;
        }
    }
}

