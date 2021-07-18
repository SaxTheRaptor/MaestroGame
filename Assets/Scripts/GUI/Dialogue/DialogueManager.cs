using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
    Dialogue Manager that handles events and dialogue triggers. Currently also handles time stop and resume, which can later 
    be moved to a different class for centralized control if desired. 

    TODO: 
        -After save files are implemented, preprocess dialogues based off of save file (Add to dialogue serializable)
    
    Authors: Xurya
*/
public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance { get; private set; }

    public GameObject panel; 
    public Text name_box;
    public Text dialogue_box;
    public Image avatar_box;
    private Queue<string> sentences;
    private Queue<Dialogue> diags;
    public GameObject background;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        diags = new Queue<Dialogue>();
    }

    public void StartDialogue(Dialogue[] dialogue)
    {
        foreach(Dialogue d in dialogue)
        {
            diags.Enqueue(d);
        }
        StartDialogue();
    }

    public void StartDialogue()
    {
        Dialogue dialogue = diags.Dequeue();

        Time.timeScale = 0;
        panel.SetActive(true);

        if(dialogue.ignoreAvatar){
            background.SetActive(false);
            avatar_box.sprite = null;
        }else{
            background.SetActive(true);
            name_box.text = dialogue.name;
            avatar_box.sprite = dialogue.avatar;
        }

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0 && diags.Count == 0)
        {
            EndDialogue();
            return;
        }else if(sentences.Count == 0)
        {
            StartDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialogue_box.text = sentence;
    }

    public void EndDialogue()
    {
        Time.timeScale = 1;
        panel.SetActive(false);
        Debug.Log("Dialogue Ended");
    }
}