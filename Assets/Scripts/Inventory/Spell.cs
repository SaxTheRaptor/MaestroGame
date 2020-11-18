using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Spell : InventoryStorable
{
    protected int _spellCooldown;
    // Start is called before the first frame update
    public abstract void UseSpell(int character);

    public override GameObject GetContextMenu()
    {
        throw new System.NotImplementedException();
    }
}
