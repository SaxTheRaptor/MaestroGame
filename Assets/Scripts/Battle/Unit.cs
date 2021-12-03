using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public string unitName;
    
    //Temporary stats due to no stat classes yet
    public int damage;
    public int maxHP;
    public int currentHP;
    public int speed;

    public Animator animator;

    void Start(){
        animator = GetComponent<Animator>();
    }

    public virtual void BasicAttack(){
        animator.Play("basicAttack");
    }

    public void TakeDamage(int damage){
        this.damage -= damage;
    }
}
