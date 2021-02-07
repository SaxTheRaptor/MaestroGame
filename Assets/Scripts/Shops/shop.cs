using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shop : MonoBehaviour
{
    // Start is called before the first frame update
    public int money = 1000;
    public Text moneytext;
    public Text inventory;

    public void additem(string item)
    {
        moneytext.text = money.ToString();
        inventory.text += "/n" + item;
    }

}
