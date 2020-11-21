using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : MonoBehaviour
{
    // List<InventoryGridCell> 
    // Start is called before the first frame update
    public GameObject gridCellPrefab;
    public float cellSideOffsetX = 10, cellSideOffsetY = 10;
    public Vector2 gridSize;

    Vector2 rectSize, rectPos, rectPosRelativeToScreenOrigin;
    Vector2 cellSize;
    RectTransform rectTrans;

    //WIP, just tried to get the actual grid thing working here
    void Start()
    {
        
        rectTrans = GetComponent<RectTransform>();

        rectSize = new Vector2(rectTrans.rect.width * rectTrans.localScale.x,
            rectTrans.rect.height * rectTrans.localScale.y);
        Debug.Log(rectSize);
        rectPos = new Vector2(Math.Abs(rectTrans.rect.x),
            Math.Abs(rectTrans.rect.y));

        cellSize = new Vector2( rectSize.x   / gridSize.x,
            rectSize.y  / gridSize.y);
        
        rectPosRelativeToScreenOrigin = new Vector2(rectPos.x - rectSize.x / 2,
            rectPos.y - rectSize.y / 2);
        
        Vector2 cellPos;
        //This will actually loop over the InventoryGridItem list and call InstantiateGridCell on each of them

        for (int i = 0; i < gridSize.y; i++)
        {
            for (int j = 0; j < gridSize.x; j++)
            {
                
                cellPos = new Vector2(rectPosRelativeToScreenOrigin.x + j * cellSize.x + cellSize.x / 2,
                        rectPosRelativeToScreenOrigin.y + i * cellSize.y + cellSize.y / 2  );
                InventoryGridCell cell = Instantiate(gridCellPrefab, transform).GetComponent<InventoryGridCell>();
                cell.InitializeCell(cellSize, cellPos);
            }
        }
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = Input.mousePosition;

        
    }

    public void UpdateItems(List<InventoryItem> items)
    {

    }
}
