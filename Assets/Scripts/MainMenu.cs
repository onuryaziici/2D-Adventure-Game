using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneToContiune;
    public GameObject  gO;
    public int characterControl;
    public void Start()
    {
        characterControl=PlayerPrefs.GetInt("SelectedCharacter");
        sceneToContiune=PlayerPrefs.GetInt("SavedScene");
        if (sceneToContiune!=0)
        {
            gO.SetActive(true);
        }
    }
    public void DeleteSave()
    {
        // PlayerPrefs.SetInt("SavedScene",0);
        PlayerPrefs.DeleteAll();
        gO.SetActive(false);
    
    }
    public void CreateGame()
    {
        PlayerPrefs.DeleteAll();
    }
    // public void PlayGame()
    // {
    //     PlayerPrefs.SetInt("SelectedCharacter",selectedCharacter);
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    // }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void ContiuneGame()
    {
        // characterControl=PlayerPrefs.GetInt("SelectedCharacter");
        sceneToContiune=PlayerPrefs.GetInt("SavedScene");
        // SceneManager.LoadScene(sceneToContiune);
        SceneManager.LoadScene("Level Select");

       
    }



}
