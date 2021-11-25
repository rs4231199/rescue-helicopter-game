using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private AudioSource music;
    public static Music instance;
    public static bool executed;
    
     private void Awake()
     {
        if (executed == false) {
            DontDestroyOnLoad (this);
            executed = true;
        } else {
            Destroy (gameObject);
        }

         music = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
        PlayerPrefs.SetInt("musicOn", 1);
        PlayerPrefs.Save();
         if (music.isPlaying == false) {
            music.Play();
         }
     }
 
     public void StopMusic()
     {
        PlayerPrefs.SetInt("musicOn", 0);
        PlayerPrefs.Save();
         music.Stop();
     }

     public void toggle() {
         if (music.isPlaying) {
            StopMusic();
         }
         else {
             PlayMusic();
         }
     }
}
