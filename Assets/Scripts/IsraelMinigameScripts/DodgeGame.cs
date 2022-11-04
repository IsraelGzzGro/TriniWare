using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DodgeGame : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
     private float timer = 6;
    int lives;
    int score;
    int cat;
    public GameObject mouseControl;
    bool gothit = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
    }

    void Update()
    {
        mouseControl.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseControl.transform.position = new Vector3(mouseControl.transform.position.x, 
            mouseControl.transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.gameObject.tag == "DodgeEnemy") 
        {
            gothit = true;
            mouseControl.SetActive(false);
        }
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
