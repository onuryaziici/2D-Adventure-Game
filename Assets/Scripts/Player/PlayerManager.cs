using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static Vector2 lastCheckPointPos = new Vector2(-5,1);
    public GameObject[] playerPrefabs;
    public int characterIndex;
    CharacterSelect cS;
    public Text score;

    public CinemachineVirtualCamera VCam;
    private void Awake()
    {
        characterIndex=PlayerPrefs.GetInt("SelectedCharacter");
        playerPrefabs[characterIndex].SetActive(true);
        GameObject playerrr = playerPrefabs[characterIndex];
        VCam.m_Follow = playerrr.transform;
        // Instantiate(playerPrefabs[characterIndex],lastCheckPointPos,Quaternion.identity);
    }
    public void Update()
    {
        score.text=PlayerPrefs.GetInt("Coin").ToString();
        // score = GetComponent<Text>();
        // score.text=playerPrefabs.GetInt("Coin");
    }



}
