using UnityEngine.Audio;
using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds; 
    public static AudioManager instance;
    public GameObject go;
    public GameObject go1;
    void Awake()
    {
        if (instance==null)
        {
            instance=this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source=gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
         
    }
    void Start()
    {
        // go = GameObject.FindWithTag("Slider");
        Play("Thema");
        // go = GameObject.Find("Slider");
    }
    void Update()
    {
        SetVolume("Thema");
        SetEffectVolume("Attack");
        SetEffectVolume("Coin");
        SetEffectVolume("Hearth");
        SetEffectVolume("LevelSuccess");
        SetEffectVolume("Game Over");
    }
    public void SetVolume(string name)
    {
        go = GameObject.Find("Slider");
        if (go!=null)
        {
            Sound s = Array.Find(sounds,sound=>sound.name==name);
            s.source.volume = go.GetComponent<Slider>().value;
            // Debug.Log("Not NUll");
        }


    }
    public void SetEffectVolume(string name)
    {
        go1 = GameObject.Find("Slider1");
        if (go1!=null)
        {
            Sound s = Array.Find(sounds,sound=>sound.name==name);
            s.source.volume = go1.GetComponent<Slider>().value;
            // Debug.Log("Not NUll");
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
        Sound s = Array.Find(sounds,sound=>sound.name==name);
        s.source.Play();
        // s.source.volume = go.GetComponent<Slider>().value;
    }
}
