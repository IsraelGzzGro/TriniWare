using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepPlayingSong : MonoBehaviour
{
    private static KeepPlayingSong instance = null;
    public static KeepPlayingSong Instance{get{return instance;}}
    private AudioSource _audioSource;
    
     private void Awake()
     {
        if (instance != null && instance != this) {
             Destroy(this.gameObject);
             return;
         } else {
             instance = this;
         }
         DontDestroyOnLoad(transform.gameObject);
         _audioSource = GetComponent<AudioSource>();
     }
 
     public void PlayMusic()
     {
         if (_audioSource.isPlaying) return;
         _audioSource.Play();
     }
 
     public void StopMusic()
     {
         _audioSource.Stop();
     }
}