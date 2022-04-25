using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInObject : MonoBehaviour
{
    // Start is called before the first frame update
    SpriteRenderer rend;
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        Color c = rend.material.color;
        c.a = 0f;
        rend.material.color = c;
    }

  


    public void OnTriggerEnter2D(Collider2D other)
    {
    
            IEnumerator FadeIn()
            {
                for (float f = 0.5f; f <= 1; f += 0.05f)
                {
                    Color c = rend.material.color;
                    c.a = f;
                    rend.material.color = c;
                    yield return new WaitForSeconds(0.05f);
                }
            }


            void startFading()
            {
                StartCoroutine("FadeIn");
            }
        
    }
}
