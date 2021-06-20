using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

using System.Runtime.Serialization.Formatters.Binary;

public class Save : MonoBehaviour
{
    public static Save Instance {get; set;}

    private BinaryFormatter bf = new BinaryFormatter();

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null && Instance != this){
            Destroy(gameObject);
        }else{
            Instance = this;
        }
        Debug.Log("Save System Initiated " + Time.fixedTime);
        SaveFile s = new SaveFile("testsave1");
        
        //Testing Code
        // newSave(s);
        // Debug.Log(getSaves()[0]);
        // Debug.Log(getSave("testsave1").id);
    }

    public SaveFile getSave(string id){
        if (File.Exists("./Assets/Resources/Saves/" + id + ".requiem")) {
            FileStream stream = new FileStream("./Assets/Resources/Saves/" + id + ".requiem", FileMode.Open);
            SaveFile saveFile = bf.Deserialize(stream) as SaveFile;
            stream.Close();
            return saveFile;
        }
        Debug.Log("failed, doesn't exist");
        return null;
    }

    public string[] getSaves(){
        return Directory.GetFiles("./Assets/Resources/Saves/", "*.requiem");
    }

    public void newSave(SaveFile save){
        FileStream stream = new FileStream("./Assets/Resources/Saves/" + save.id + ".requiem", FileMode.Create);

        bf.Serialize(stream, save);
        stream.Close();
        Debug.Log("Game Saved!");
    }
}
