using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShipBehavior : MonoBehaviour
{
    public GameObject projectile;
    int counter = 0;
    private float timer = 10;
    int lives;
    int score;
    int cat;
    bool hitenemy = false;
    
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
    }
    
    void Update()
    {
        if (Input.GetKeyDown("space") && counter == 0)
        {
            shootBullet();
            counter++;
        }
    }

    void FixedUpdate() 
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                if(hitenemy == false) 
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

    public void hitsEnemy()
    {
        timer = 2;
        hitenemy = true;
    }

    void shootBullet()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
