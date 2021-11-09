using Assets.Scripts.Inventory.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace Assets.Scripts.Inventory.UI
{
    public class InventoryGrid : MonoBehaviour
    {
        // List<InventoryGridCell> 
        // Start is called before the first frame update
        public GameObject gridCellPrefab;
        public EventHandler DragStarted, DragEnded;
        public float cellSideOffsetX, cellSideOffsetY;
        public Vector2 gridSize;
        private InventoryStorage inventory;
        Vector2 rectSize, rectPos, rectPosRelativeToScreenOrigin;
        Vector2 cellSize, newSize;
        private bool initialized = false;
        RectTransform rectTrans;

        //WIP, just tried to get the actual grid thing working here
        void Start()
        {

            StartCoroutine(WaitForEndOfFrame (() =>
            {
                Canvas.ForceUpdateCanvases();
                this.transform.hasChanged = false;
                rectTrans = GetComponent<RectTransform>();
                SetTransform();
                initialized = true;
            }, 1));
        }

        private void SetTransform()
        {
            rectSize = new Vector2(rectTrans.rect.width * rectTrans.localScale.x,
                    rectTrans.rect.height * rectTrans.localScale.y);
           
            rectPos = new Vector2(Math.Abs(transform.position.x),
                Math.Abs(transform.position.y));

            cellSize = new Vector2(rectSize.x / gridSize.x,
                rectSize.y / gridSize.y);

            rectPosRelativeToScreenOrigin = new Vector2(transform.position.x - rectSize.x / 2,
                transform.position.y - rectSize.y / 2);
        }
        
        private IEnumerator WaitForEndOfFrame(Action func, int sec)
        {
            yield return new WaitForSeconds(sec);
            func();
            

        }

        public InventoryGridItem GetItemAt(Vector2 pos)
        {
            
            pos = new Vector2(pos.x - rectPosRelativeToScreenOrigin.x, pos.y - rectPosRelativeToScreenOrigin.y);
            Vector2 newCellSize = gridCellPrefab.GetComponent<RectTransform>().rect.size;
            newCellSize.Scale(new Vector2(cellSize.x / gridSize.x, cellSize.y / gridSize.y));
            int x = (int)(cellSize.x);
            int y = (int)(cellSize.y);
            //TODO Invertire senso griglia Y
            x = Mathf.FloorToInt(pos.x / cellSize.x);
            y = Mathf.FloorToInt(pos.y / cellSize.y);
            return inventory._items.FirstOrDefault((item) =>
            {
               return item.GridX == x && item.GridY == y;
            });
            
            
        
        }

        // Update is called once per frame
        void Update()
        {
            
            Vector3 pos = Input.mousePosition;

            if (Input.GetMouseButtonDown(0))
            {
                if (pos.x > rectPos.x - rectSize.x / 2 && pos.x < rectPos.x + rectSize.x / 2
                    && pos.y < rectPos.y + rectSize.y / 2 && pos.y > rectPos.y - rectSize.y / 2)
                {
                    InventoryGridItem selectedItem = GetItemAt(pos);
                    SelectedItemEventArgs e = new SelectedItemEventArgs() { fromInventory = inventory, selectedItem = selectedItem };
                    DragStarted?.Invoke(this, e);
                }
               
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (pos.x > rectPos.x - rectSize.x / 2 && pos.x < rectPos.x + rectSize.x / 2
                    && pos.y < rectPos.y + rectSize.y / 2&& pos.y > rectPos.y - rectSize.y / 2)
                {
                    InventoryGridItem selectedItem = GetItemAt(pos);
                    SelectedItemEventArgs e = new SelectedItemEventArgs() { fromInventory = inventory,  selectedItem = selectedItem};
                    DragEnded?.Invoke(this, e);
                }
            }

            if (transform.hasChanged && initialized)
            {
                Debug.Log("CHANGED");
                SetTransform();
                transform.hasChanged = false;
            }

        }

 

        public void Show(InventoryStorage inventory)
        {
            if (initialized)
            {
                this.inventory = inventory;
                inventory.InventoryUpdated += UpdateItems;
                UpdateItems(null, null);
            } else
            {
                StartCoroutine(WaitForEndOfFrame( () =>
                {
                    this.inventory = inventory;
                    inventory.InventoryUpdated += UpdateItems;
                    UpdateItems(null, null);
                }, 2));
            }
            
            
        }

        

        public void UpdateItems(object sender, EventArgs args)
        {
            //TODO improve algorithm
            Vector2 cellPos;
            //This will actually loop over the InventoryGridItem list and call InstantiateGridCell on each of them
            for(int x = 0; x < transform.childCount; x++)
            {
                Destroy(transform.GetChild(x).gameObject);
            }

            inventory._items.ForEach(item =>
            {
                cellPos = new Vector2(rectPosRelativeToScreenOrigin.x + item.GridX * cellSize.x + cellSize.x / 2,
                            rectPosRelativeToScreenOrigin.y + item.GridY * cellSize.y + cellSize.y / 2);
                InventoryGridCell cell = Instantiate(gridCellPrefab, transform).GetComponent<InventoryGridCell>();


                Vector2 cellScale = new Vector2(cellSize.x / rectSize.x, cellSize.y / rectSize.y);

                Vector2 newSize = cell.InitializeCell(cellScale, cellPos);
                cell.SetContent(item.InventoryItem);
            });

           
        }
    }

}

