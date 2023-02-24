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
    public GameObject[] IntroStuff;
    public GameObject[] StandardStuff;
    public GameObject IntroScore;
    public GameObject Score;
    public static List<string> mGames = new List<string> {"FaultyPC", "PlaceholderGame2", "MazeGame", "HTS", "RingMini", "BeachScavenge", "GlowMemoryMini", "Fishing", "1-10 Minigame"};
    public static List<string> mGamesRefill = new List<string> {"FaultyPC", "PlaceholderGame2", "MazeGame", "HTS", "RingMini", "BeachScavenge", "GlowMemoryMini", "Fishing", "1-10 Minigame"};
    public static List<string> bGames = new List<string> {"bossgame_dpark", "Masher"};
     public static List<string> bGamesRefill = new List<string> {"bossgame_dpark", "Masher"};
    int randnum;
    string holder;
    private float timer;
    private float timercheck;
    public Text scoretxt;
    public Text scoretxtintro;
    int lives;
    int score;
    int cat;
    int playingstory;
    int introanimations;
    //int playboss;
    int highscore = 0;

    public GameObject MainMusic;

    void Start() 
    {
       {StartCoroutine(StartMusic());}

        highscore = PlayerPrefs.GetInt("highscore");
        timer = PlayerPrefs.GetFloat("Timer");
        timercheck = PlayerPrefs.GetFloat("Timer");
        
        if(timercheck > 5) PlayerPrefs.SetFloat("Timer",5);

        //playboss = PlayerPrefs.GetInt("reset");
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        playingstory = PlayerPrefs.GetInt("PlayingStory?");
        introanimations = PlayerPrefs.GetInt("IntroAnim");

        if(introanimations == 1) 
        {
            foreach(GameObject obj in IntroStuff) 
            {
                obj.SetActive(true);
            }
        }
        if (introanimations == 0)
        {
            foreach(GameObject obj2 in StandardStuff) 
            {
                obj2.SetActive(true);
            }
        }

        if(playingstory == 0 && introanimations == 1) 
        {
            IntroScore.SetActive(true);
        } else if (playingstory == 0) 
        {
            Score.SetActive(true);
        }

        if (highscore < score) 
        {
            PlayerPrefs.SetInt("highscore", score);
        }
        scoretxt.text = "Score: " + score;
        scoretxtintro.text = "Score: " + score;
        
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

        /*if(mGames.Count == 0 && playboss == 0) 
        {
            mGames.Add("bossgame_dpark");
            playboss = 1;
            PlayerPrefs.SetInt("reset", playboss);
        }
        if(mGames.Count == 0 && playboss == 1) 
        {
            mGames.Add("RingMini");
            mGames.Add("BeachScavenge");
            mGames.Add("HTS");
            mGames.Add("MazeGame");
            mGames.Add("PlaceholderGame2");
            mGames.Add("FaultyPC");
            playboss = 0;
            PlayerPrefs.SetInt("reset", playboss);
        }*/

        if(introanimations == 1) {PlayerPrefs.SetInt("IntroAnim", 0);}
    }

    public void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                if(lives == 0) 
                {
                    SceneManager.LoadScene("GameOver");
                    mGames = mGamesRefill;
                    bGames = bGamesRefill;
                } else if(playingstory == 1 && bGames.Count == 0) 
                {
                    mGames = mGamesRefill;
                    bGames = bGamesRefill;
                    PlayerPrefs.SetInt("BeatStory", 1);
                    SceneManager.LoadScene("OutroScene");
                } else if(mGames.Count == 0) 
                {
                    mGames = mGamesRefill;
                    
                    if(bGames.Count == 0) 
                    {
                        bGames = bGamesRefill;

                        randnum = Random.Range(0,mGames.Count);
                        holder = mGames[randnum];
                        mGames.Remove(holder);
                        SceneManager.LoadScene(holder);
                    }

                    randnum = Random.Range(0,bGames.Count);
                    holder = bGames[randnum];
                    bGames.Remove(holder);
                    SceneManager.LoadScene(holder);
                    
                } else 
                {
                    randnum = Random.Range(0,mGames.Count);
                    holder = mGames[randnum];
                    mGames.Remove(holder);
                    SceneManager.LoadScene(holder);
                }
            }
        }
    }

    IEnumerator StartMusic() 
    {
        yield return new WaitForSeconds(16);
        MainMusic.SetActive(true);
    }
}
