using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damage = 50;

    public void Action(Character character){
        character.TakeDamage(damage);
    }

    public void OnTriggerEnter2D(Collider2D other){
        Character character = other.gameObject.GetComponent<Character>();
        Debug.Log(character.name + " stepped on a trap!");
        Action(character);
    }
}
