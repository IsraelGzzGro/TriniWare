using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public GameObject[] livesarr;
    public GameObject[] catfaces;
    public static List<string> mGames = new List<string> {"FaultyPC", "PlaceholderGame2", "MazeGame", "HTS", "RingMini"};
    int randnum;
    string holder;
    private float _delay = 3;
    public Text scoretxt;
    public GameObject stxt;
    int lives;
    int score;
    int cat;
    int playingstory;

    int needtoreset;

    void Start() 
    {
        needtoreset = PlayerPrefs.GetInt("reset");
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        playingstory = PlayerPrefs.GetInt("PlayingStory?");

        if(playingstory == 0) {stxt.SetActive(true);}
        scoretxt.text = "Score: " + score;
        if(cat == 0) 
        {
            catfaces[0].SetActive(true);
        }
        if(cat == 1) 
        {
            catfaces[1].SetActive(true);
        }
        if(cat == 2) 
        {
            catfaces[2].SetActive(true);
        }
        if(lives == 2) 
        {
            livesarr[2].SetActive(false);
        }
        if(lives == 1)
        {
            livesarr[1].SetActive(false);
            livesarr[2].SetActive(false);
        }
        if(lives == 0) 
        {
            livesarr[0].SetActive(false);
            livesarr[1].SetActive(false);
            livesarr[2].SetActive(false);
        }
        Debug.Log("mGames.Count = " + mGames.Count);
        Debug.Log("needtoreset = " + needtoreset);

        if(mGames.Count == 0 && needtoreset == 0) 
        {
            mGames.Add("bossgame_dpark");
            needtoreset = 1;
            PlayerPrefs.SetInt("reset", needtoreset);
        }
        if(mGames.Count == 0 && needtoreset == 1) 
        {
            mGames.Add("RingMini");
            mGames.Add("HTS");
            mGames.Add("MazeGame");
            mGames.Add("PlaceholderGame2");
            mGames.Add("FaultyPC");
            needtoreset = 0;
            PlayerPrefs.SetInt("reset", needtoreset);
        } 
        
    }

    public void FixedUpdate()
    {
        if (_delay > 0)
        {
            _delay -= Time.fixedDeltaTime;

            if (_delay <= 0)
            {
                if(lives == 0) 
                {
                    SceneManager.LoadScene("GameOver");
                } 
                else 
                {
                    randnum = Random.Range(0,mGames.Count);
                    //Debug.Log("randnum = " + randnum);
                    holder = mGames[randnum];
                    mGames.Remove(holder);
                    SceneManager.LoadScene(holder);
                }
            }
        }
    }
}
