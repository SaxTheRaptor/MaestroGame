using Assets.Scripts.Inventory.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Linq;

public class InventoryEditor : EditorWindow
{
    InventoryStorage selectedInventory;
    int rows = 1;
    int columns = 1;
    Vector2 scrollPos;
    InventoryGridItem selectedItem;
    [MenuItem ("Window/Inventory Editor")]
    public static void ShowWindow()
    {
        GetWindow(typeof(InventoryEditor));
    }
    void OnGUI()
    {
        Texture a = (Texture)AssetDatabase.LoadAssetAtPath("Assets/Scripts/Inventory/Editor/plus.jpg", typeof(Texture));
        //GUI.DrawTexture(new Rect(50, 50, 50, 50), a);
        //selectedInventory = (InventoryStorage)EditorGUI.ObjectField(new Rect(100, 100, 400, 50), "Inventory", selectedInventory,  typeof(InventoryStorage), true);


        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical();
        GUILayout.BeginArea(new Rect(0, 0, position.width * (2f/3f), 50));
        rows = EditorGUILayout.IntField("Rows", rows);
        columns = EditorGUILayout.IntField("Columns", columns);
        float buttonWidth = (position.width * (2f/3f)) / columns;
        float buttonHeight = 100;
        GUILayout.EndArea();


        GUILayout.BeginArea(new Rect(0, 60, position.width * (2f/3f), 600));

        if (selectedInventory != null && selectedInventory._items != null)
        {
            scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width * (2f / 3f)), GUILayout.Height(500));
            for (int x = 0; x < rows; x++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int y = 0; y < columns; y++)
                {
                    //EditorGUILayout.Button("Test", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight));
                    InventoryGridItem item = selectedInventory._items.FirstOrDefault((_item) =>
                    {
                        return _item.GridX == x && _item.GridY == y;
                    });
                    
                    if (item != null && item.InventoryItem != null )
                    {
                        if (GUILayout.Button(item.InventoryItem.ItemStorable.Name + " " + item.InventoryItem.Quantity,GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight)))
                        {
                            selectedItem = item;
                        }

                    }
                    else
                    {
                        GUILayout.Button("Add slot", GUILayout.Width(buttonWidth), GUILayout.Height(buttonHeight));
                    }


                }
                EditorGUILayout.EndHorizontal();
            }
            EditorGUILayout.EndScrollView();
        }
        
        GUILayout.EndArea();

        GUILayout.EndVertical();

        GUILayout.BeginArea(new Rect(position.width * (2f / 3f) +10, 0, position.width * (1f/3f) - 10, position.height));
        GUILayout.BeginVertical();
        InventoryStorage oldInv = selectedInventory;
        selectedInventory = (InventoryStorage)EditorGUILayout.ObjectField(selectedInventory, typeof(InventoryStorage), true);
        if (selectedInventory != null && oldInv != selectedInventory)
        {
            InventorySelected();
        }
        if (selectedItem != null && selectedItem.InventoryItem != null && selectedItem.InventoryItem.ItemStorable != null)
        {
            selectedItem.InventoryItem.Quantity = EditorGUILayout.IntField("Quantity", selectedItem.InventoryItem.Quantity);
            EditorGUILayout.TextField("Name", selectedItem.InventoryItem.ItemStorable.Name.ToString());
            selectedItem.InventoryItem.ItemStorable = (InventoryStorable)EditorGUILayout.ObjectField(selectedItem.InventoryItem.ItemStorable, typeof(InventoryStorable), false);
        }
        GUILayout.Button("Pigiami");
        GUILayout.EndVertical();
        GUILayout.EndArea();
        //GUILayout.BeginArea();

        GUILayout.EndHorizontal();




    }

    void InventorySelected()
    {
        rows = selectedInventory._items.Max((item) => item.GridX);
        columns = selectedInventory._items.Max((item) => item.GridY);



    }

}
