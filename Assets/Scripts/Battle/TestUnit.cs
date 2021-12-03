using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestUnit : Unit
{
    public GameObject projectile;
    public override void BasicAttack(){
        Instantiate(projectile, this.transform);
    }
}