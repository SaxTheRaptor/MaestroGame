using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneInteractTransition : MonoBehaviour
{

    //initialize scene
    public string sceneToLoad;
    
    //when player collision touches collision of a door, switch to stored scene. 
    //In the future, this will need to be changed to only occur when the player interacts with the door by "opening" it
    public void OnTriggerStay2D(Collider2D other)
    {
        if ((other.tag == "Player") && (Input.GetKeyDown("e")))
        {
            Debug.Log("Load Scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
