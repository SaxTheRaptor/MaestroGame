using UnityEngine;

[CreateAssetMenu(fileName = "New Health Potion Data", menuName = "Item Data/Health Potion Data")]
public class HealthPotion : Item
{
    [SerializeField]
    private int _healAmount = 0;
    public override void UseItem(int _character) //will be replaced by character class
    {
        //will be replaced by character class
        int hp = 0;
        hp += _healAmount;

       
    }
}