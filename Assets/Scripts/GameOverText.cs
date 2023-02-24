using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverText : MonoBehaviour
{
    public GameObject HighscoreText;
    public GameObject HighscoreText1;
    public Text Stext;
    public GameObject StoryWin;
    public GameObject StoryWin1;
    public GameObject StoryLose;
    int story;
    int wonstory;
    int score;

    void Awake() 
    {
        GameObject.FindGameObjectWithTag("MainSong").GetComponent<KeepPlayingSong>().StopMusic();
    }
    void Start() 
    {
        score = PlayerPrefs.GetInt("score");
        story = PlayerPrefs.GetInt("PlayingStory?");
        wonstory = PlayerPrefs.GetInt("BeatStory");
       
        if(story == 0) 
        {
            HighscoreText.SetActive(true);
            HighscoreText1.SetActive(true);
            Stext.text = "Score: " + score.ToString();
        } else if (story == 1 && wonstory == 1) 
        {
            StoryWin.SetActive(true);
            StoryWin1.SetActive(true);
        } else if (story == 1 && wonstory == 0) 
        {
            StoryLose.SetActive(true);
        }
    }
}
