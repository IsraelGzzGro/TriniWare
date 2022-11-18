using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailboxGame : MonoBehaviour
{
    private Rigidbody2D rb;
    private float timer = 11;
    int lives;
    int score;
    int cat;
    public GameObject package;
    public GameObject flagup;
    public GameObject[] var1;
    public GameObject[] var2;
    bool gamewon = false;
    int variation;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");

        variation = Random.Range(0,2);

        if(variation == 0)
        {
            foreach(GameObject wall in var1) 
            {
                wall.SetActive(true);
            }
        } else
        {
            foreach(GameObject wall2 in var2) 
            {
                wall2.SetActive(true);
            }
        }
        Debug.Log("Var = " + variation);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            package.SetActive(false);
            flagup.SetActive(true);
            gamewon = true;
        }
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                Physics2D.gravity = new Vector2(0, -9.8f);
                if(gamewon == true) 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else {
                lives -= 1;
                cat = 1;
                PlayerPrefs.SetInt("lives", lives);
                PlayerPrefs.SetInt("cat", cat);
                SceneManager.LoadScene("MainGame");
                }
            }
        }
    }
}
