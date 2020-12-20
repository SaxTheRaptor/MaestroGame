using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Provides functionality for the Pause Menu. 
 * */
public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    /*
     * Resumes the game
     * */
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    /*
     * Pauses the game
     * */
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    /*
     * Brings up the Options menu.
     * 
     * TODO: Implement
     * */
    public void Options()
    {
        Debug.Log("Options Clicked");
    }

    /*
     * Quits the game and saves state if necessary.
     * 
     * TODO: Implement
     * */
    public void Quit()
    {
        Debug.Log("Quit Clicked");
    }
}
