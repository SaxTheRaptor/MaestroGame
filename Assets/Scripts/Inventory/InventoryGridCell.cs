using UnityEngine;
using System;
using UnityEngine.UI;
public class InventoryGridCell: MonoBehaviour
{
    public Image _itemImage;
    public Text _itemLabel;
    
    public InventoryGridCell(Sprite itemImage, string itemLabel)
    {
        _itemImage = GetComponentInChildren<Image>();
        _itemLabel = GetComponentInChildren<Text>();
        _itemImage.sprite = itemImage;
        _itemLabel.text = itemLabel;
    }

    public void Update()
    {

    }
}