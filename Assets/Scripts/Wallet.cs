using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Moneys = 0;

    //gives ya money
    public void addMoneys(int quantity)
    {
        if ((quantity + Moneys) > 1000) {
            Debug.Log("You have enough money!")
        } else { 
            Debug.Log(quantity + Moneys);
            Moneys += quantity;
        }
        //TODO: some sort of UI element + anim
        
    }

    //takes away ur money
    public void subMoneys(int quantity)
    {
        if ((quantity - Moneys) < 0)
        {
            Debug.Log("https://www.poorpeoplescampaign.org/")
        } else { 
            Debug.Log(quantity - Moneys);
            Moneys -= quantity;
        }
        //TODO: some sort of UI element + anim
    }

    public int getMoneys()
    {
        return Moneys;
        Debug.Log( Moneys );
    }

}
