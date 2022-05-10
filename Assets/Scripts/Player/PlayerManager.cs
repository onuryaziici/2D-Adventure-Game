using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : MonoBehaviour
{
    public static Vector2 lastCheckPointPos = new Vector2(-5,1);
    public GameObject[] playerPrefabs;
    int characterIndex;

    public CinemachineVirtualCamera VCam;
    private void Awake()
    {
        
        characterIndex=PlayerPrefs.GetInt("SelectedCharacter",0);
        playerPrefabs[characterIndex].SetActive(true);
        GameObject playerrr = playerPrefabs[characterIndex];
        // Instantiate(playerPrefabs[characterIndex],lastCheckPointPos,Quaternion.identity);
        VCam.m_Follow = playerrr.transform;
    }
}
