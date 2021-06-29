using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    Dialogue Trigger to place on gameobjects that should trigger a dialogue event. This class currently delegates the task to
    the dialogue manager singleton and destroys the gameobject on completion. 
    
    Authors: Xurya
*/

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue[] dialogue;
    public int type = 0;
    public bool destroy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == 1 && collision.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
            if (destroy)
            {
                Destroy(this.gameObject);
            }
        } else {
            TriggerDialogue();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (type == 1 && collision.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
            if (destroy)
            {
                Destroy(this.gameObject);
            }
        } else {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue ()
    {
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
