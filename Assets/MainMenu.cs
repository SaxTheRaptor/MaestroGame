using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("OverWorld");
    }

    public void QuitGame()
    {
        Debug.Log("KT Exinction Event");
        Application.Quit();
    }

    public void NewGame()
    {
        Debug.Log("https://store.steampowered.com/app/837470/Untitled_Goose_Game/");
    }
}