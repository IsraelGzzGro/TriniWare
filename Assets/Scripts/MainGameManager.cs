using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainGameManager : MonoBehaviour
{
    public GameObject[] livesarr;
    public GameObject[] catfaces;
    public static List<string> mGames = new List<string> {"PlaceholderGame", "PlaceholderGame2", "DodgeGame", "HTS"};
    int randnum;
    string holder;
    private float _delay = 3;
    public TextMeshProUGUI scoretxt;
    int lives;
    int score;
    int cat;

    void Start() 
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
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
            livesarr[0].SetActive(false);
        }
        if(lives == 1)
        {
            livesarr[0].SetActive(false);
            livesarr[1].SetActive(false);
        }
        if(lives == 0) 
        {
            livesarr[0].SetActive(false);
            livesarr[1].SetActive(false);
            livesarr[2].SetActive(false);
        }
        Debug.Log("mGames.Count = " + mGames.Count);

        if(mGames.Count <= 0) 
        {
            mGames.Add("HTS");
            mGames.Add("DodgeGame");
            mGames.Add("PlaceholderGame2");
            mGames.Add("PlaceholderGame");
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