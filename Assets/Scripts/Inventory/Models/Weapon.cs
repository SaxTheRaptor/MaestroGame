using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Assets.Scripts.Inventory.Models
{
    public abstract class Weapon : InventoryStorable
    {
        protected int _damage;
        public abstract void UseWeapon(int character, int enemy);

        public override GameObject GetContextMenu()
        {
            throw new NotImplementedException();
        }
    }
}

