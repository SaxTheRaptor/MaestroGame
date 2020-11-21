using UnityEngine;
using System;
using UnityEngine.UI;
public class InventoryGridCell: MonoBehaviour
{
    public Image _itemImage;
    public Text _itemLabel;

    RectTransform rectTrans;
    public int gridX, gridY;
    
    public InventoryGridCell(Sprite itemImage, string itemLabel)
    {
        _itemImage = GetComponentInChildren<Image>();
        _itemLabel = GetComponentInChildren<Text>();
        _itemImage.sprite = itemImage;
        _itemLabel.text = itemLabel;
    }
    public void Awake()
    {
        rectTrans = GetComponent<RectTransform>();
        Debug.Log("HELLO MY SIZE IS " + rectTrans.rect.x + " " + rectTrans.rect.y);
    }
    public void Start()
    {
        
    }

    public void InitializeCell(Vector2 size, Vector2 pos)
    {
        float cellScaleX = size.x / Math.Abs(rectTrans.rect.width);
        float cellScaleY = size.y / Math.Abs(rectTrans.rect.height);
        //Debug.Log("PAN RECT " + panRect.x + " " + panRect.y);
        //Debug.Log("CELL SCALE " + cellScaleX + " " + cellScaleY);
        rectTrans.localScale = new Vector2(cellScaleX, cellScaleY);
        transform.position = pos;
        
    }

    public void Update()
    {

    }
}