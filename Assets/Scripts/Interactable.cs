﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetKeyDown(interactKey)){
            interactAction.Invoke();
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            isInRange = false;
        }
    }
}
