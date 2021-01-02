using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string name = "Placeholder";
    public int health = 100;
    public List<Skill> skills; //TOPD: Implement
    
    public void TakeDamage(int damage){
        if(health < damage){
            health = 0;
            //TODO: set vars for anims
            Death();
            return;
        }
        health -= damage;
    }

    public void Death(){
        Debug.Log(name + ": Argh..."); //placeholder. Can use dialogue.
    }
}
