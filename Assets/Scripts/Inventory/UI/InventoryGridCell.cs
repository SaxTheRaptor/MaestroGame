using UnityEngine;
using System;
using UnityEngine.UI;
using Assets.Scripts.Inventory.Models;

namespace Assets.Scripts.Inventory.UI
{
    public class InventoryGridCell : MonoBehaviour
    {
        public Image _itemImage;
        public Text _itemLabel;
        public Text _itemQuantity;
        RectTransform rectTrans;
        public int gridX, gridY;

        
        public void Awake()
        {
            rectTrans = GetComponent<RectTransform>();
            Debug.Log("HELLO MY SIZE IS " + rectTrans.rect.x + " " + rectTrans.rect.y);
        }
        public void Start()
        {

        }

        public Vector2 InitializeCell(Vector2 scale, Vector2 pos)
        {
            
            rectTrans.localScale = scale;
            transform.position = pos;
            return scale * rectTrans.rect.size;
        }

        public void SetContent(InventoryItem item)
        {
            if (item != null)
            {
                _itemQuantity.text = item.Quantity.ToString();
                _itemLabel.text = item.ItemStorable.name;
            } else
            {
                _itemQuantity.text = "No item";
                _itemLabel.text = "No item";
            }
            
            
        }

        public void Update()
        {

        }
    }
}
