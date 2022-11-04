using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DodgeGame : MonoBehaviour
{
     private float timer = 6;
    int lives;
    int score;
    int cat;
    public GameObject player;
    bool gothit = false;
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
    }

    public void hit() 
    {
        gothit = true;
    }

    void Update()
    {
        player.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        player.transform.position = new Vector3(player.transform.position.x, 
            player.transform.position.y, 0);
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                if(gothit == true) 
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
}