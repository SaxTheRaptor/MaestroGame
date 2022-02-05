using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 1f;
    public float lifespan = 1f;

    // Update is called once per frame
    void Update()
    {
        lifespan -= Time.deltaTime;
        if(lifespan <= 0){
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }
}
