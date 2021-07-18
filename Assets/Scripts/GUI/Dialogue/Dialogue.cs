using UnityEngine;


/*
    Basic Dialogue that is serealizable for future expansion, such as dynamic text from save files, time, events, etc.

    TODO: 
        -When save files are implemented, modify class to support completion status for preprocessing.

    Authors: Xurya
*/

[System.Serializable]
public class Dialogue
{
    public string name;

    [TextArea(3,10)]
    public string[] sentences;
    public Sprite avatar;
    public bool ignoreAvatar;
}
