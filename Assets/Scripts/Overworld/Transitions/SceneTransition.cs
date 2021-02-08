 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour { 

    //initialize scene
    public string sceneToLoad;
    //position of player
    public Vector2 playerPosition;
    public VectorValue playerStorage;
    //when player collision touches collision of a door, switch to stored scene. 
    //In the future, this will need to be changed to only occur when the player interacts with the door by "opening" it
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            playerStorage.initialValue = playerPosition;
            Debug.Log("Load Scene: " + sceneToLoad);
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
