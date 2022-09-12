using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;    


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

       foreach (Sounds s in sounds)
        {
         s.audioSource =gameObject.AddComponent<AudioSource>();   
         s.audioSource.clip = s.clip;

         s.audioSource.volume = s.volume;
         s.audioSource.pitch = s.pitch;
         s.audioSource.loop = s.loop;
        }
    }
    private void Start()
    {
        Play("Theme");
        
    }

    public void Play(string name)
    {
       Sounds s = Array.Find(sounds, sounds => sounds.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound:" + name +"not found!");
            return;
        }
        
        s.audioSource.Play();
    }
}
