using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Inventory.Models
{
    public abstract class Armor : InventoryStorable
    {
        protected int _damageReduction;

        // Start is called before the first frame update
        public abstract void UseArmor(int character);

        public override GameObject GetContextMenu()
        {
            throw new System.NotImplementedException();
        }
    }
}

