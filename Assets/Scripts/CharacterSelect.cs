using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    public int selectedCharacter;
    public int currentSceneIndex;


    private void Awake()
    {
        // selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter",0);
        
    }
    public void SelectCharacter1()
    {
        selectedCharacter=0;
        // PlayerPrefs.GetInt("SelectedCharacter",0);
        // cIndex=0;
    }
    public void SelectCharacter2()
    {
        selectedCharacter=1;
        // PlayerPrefs.GetInt("SelectedCharacter",1);
        // cIndex=1;
    }
    public void PlayGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.GetInt("SavedScene",currentSceneIndex);
        currentSceneIndex=SceneManager.GetActiveScene().buildIndex+1;
        PlayerPrefs.SetInt("SavedScene",currentSceneIndex);
        selectedCharacter=PlayerPrefs.GetInt("SelectedCharacter",selectedCharacter);
        PlayerPrefs.SetInt("SelectedCharacter",selectedCharacter);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
