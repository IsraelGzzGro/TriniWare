using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PHGameScript : MonoBehaviour
{
    private float timer = 2;
    int lives;
    int score;
    int cat;

    //these local variables need to be set at the start of every game
    void Start() 
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");

    }

    //this is the actual "game" in this case it is just to press space so when you do, you win, and that is the code for what winning does
    //this will obviously be bigger and more complex for other games, but that code has to be there before leaving to the main game
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
    }

    //this block of code is the timer, the code under if(timer<=0) is what happens when you lose, 
    //in other games we can do more complex stuff here like animations and such before going back to the main game
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                lives -= 1;
                cat = 1;
                PlayerPrefs.SetInt("lives", lives);
                PlayerPrefs.SetInt("cat", cat);
                SceneManager.LoadScene("MainGame");
            }
        }
    }
}
