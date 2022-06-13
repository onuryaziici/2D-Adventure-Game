using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale=1f;
        GameIsPaused=false;
    }
    public void Restart()
    {
         Application.LoadLevel(Application.loadedLevel);
    }
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale=0f;
        GameIsPaused=true;
    }
    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
    }    
}
