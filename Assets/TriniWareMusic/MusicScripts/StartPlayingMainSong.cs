using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlayingMainSong : MonoBehaviour
{
    void Awake() 
    {
        GameObject.FindGameObjectWithTag("MainSong").GetComponent<KeepPlayingSong>().PlayMusic();
    }
}
