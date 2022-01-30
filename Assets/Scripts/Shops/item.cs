public enum ItemType
{
    Artifacts,
    Key,
    Consumable,
    Material,
    Weapon
}

public class Item
{
    protected int cost;
    protected string itemName;
    private string description;
    protected bool stackable;
    private int stack;
    private ItemType itemType;

    //---=Init=---\\

    public Item(int newCost, string newItemName, string newDescription, bool newStackable, ItemType newItemType)
    {
        cost = newCost;
        itemName = newItemName;
        description = newDescription;
        stackable = newStackable;
        itemType = newItemType;
    }

    //---=Item Utilization=---\\

    protected virtual bool CanUseItem(object[] args = null)
    {
        //NOTE: Optional Implementation
        return true;
    }

    public virtual void UseItem(params object[] args)
    {
        //NOTE: Each element of args should be casted into their own class or data types
        //NOTE: The best thing to do would be to create a standard for each element in the array with something like an enum
        //Example: PlayerPrefs prefs = (PlayerPrefs)args[ParamType.PlayerPrefs];
        //or the int route: PlayerPrefs prefs = (PlayerPrefs)args[0];

        if (CanUseItem())
        {
            stack--;
        }
    }

    public void IncreaseItemStack(int amount)
    {
        stack = (stack + amount) < InventoryConsts.maxItemStack ? stack += amount : stack;
    }

    //---=Getters=---\\

    public int GetCost()
    {
        return cost;
    }

    public int GetItemStackCount()
    {
        return stack;
    }

    public string GetDescription()
    {
        return description;
    }

    public ItemType GetItemType()
    {
        return itemType;
    }
}