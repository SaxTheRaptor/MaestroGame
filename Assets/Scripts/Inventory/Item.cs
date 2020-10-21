using UnityEngine;
using ItemTypes;
public abstract class Item : ScriptableObject
{
    protected string _item_name;
    protected bool _is_stackable;
    protected _ITEM_TYPE _item_type;
    protected int _item_count;
    protected string _item_description;
    [SerializeField] 
    protected Sprite _item_sprite;
    protected int _max_item_stack;

    public void Constructor(string _name, bool _stackable, _ITEM_TYPE _type, string _description, int _item_stack)
    {
        _item_name = _name;
        _is_stackable = _stackable;
        _item_type = _type;
        _item_description = _description;
        _max_item_stack = _item_stack;
    }

    public abstract void UseItem(int _character);

    public void AddItem(int _count)
    {
        _item_count += _count;
    }
    public string GetName()
    {
        return _item_name;
    }

    public int GetItemCount()
    {
        return _item_count;
    }

    public string GetDescription()
    {
        return _item_description;
    }
    public bool GetStackable()
    {
        return _is_stackable;
    }

    public int GetMaxItemStack()
    {
        return _max_item_stack;
    }
}