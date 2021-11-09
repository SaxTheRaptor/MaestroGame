using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Just an abstraction. Didn't want to store the quantity in the scriptable object, 
 i.e. the SO will only act as a blueprint. */
namespace Assets.Scripts.Inventory.Models
{
    [System.Serializable]
    public class InventoryItem
    {
        [SerializeField]
        private int _quantity;
        [SerializeField]
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

        public InventoryStorable ItemStorable
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }

       
    }
}

