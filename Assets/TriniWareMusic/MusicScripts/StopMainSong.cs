using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMainSong : MonoBehaviour
{
    void Awake() 
    {
        GameObject.FindGameObjectWithTag("MainSong").GetComponent<KeepPlayingSong>().StopMusic();
    }

}
