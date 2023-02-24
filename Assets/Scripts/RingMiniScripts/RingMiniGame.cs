using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RingMiniGame : MonoBehaviour
{
    public float endtimer = 5;
    int check = 0;
    int lives;
    int score;
    int cat;
    bool won;
    public SpriteRenderer mainbg;
    public bool outcome = false;
    public float timer = 0.0f;
    public Sprite losebg;
    public Sprite winbg;
    public bool triggerchoice = false;

    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        outcome = false;
    }

    void Update()
    {
        if (triggerchoice) {
            StartCoroutine(EndMini());
            if (outcome)
            {
                won = true;
            }
            else {
                won = false;
            }
        }

        //if past 6 sec, end game based on outcome
        timer += Time.deltaTime;
        if (timer >= 6) {
            if (outcome)
            {
                mainbg.sprite = winbg;
                won = true;
            }
            else {
                mainbg.sprite = losebg;
                won = false;
            }
        }
    }

    void FixedUpdate() 
    {
        if (endtimer > 0)
        {
            endtimer -= Time.fixedDeltaTime;

            if (endtimer <= 0)
            {
                if(won == false) 
                {
                    lives -= 1;
                    cat = 1;
                    PlayerPrefs.SetInt("lives", lives);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                }
            }
        }
 }
    IEnumerator EndMini() {
        gameEnds();
        yield return new WaitForSeconds(1);
        if (outcome)
        {
            mainbg.sprite = winbg;
        }
        else {
            mainbg.sprite = losebg;
        }
    }

    void gameEnds() 
    {
        if (check == 0) 
        {
            endtimer = 3;
            check += 1;
        }
    }
}
