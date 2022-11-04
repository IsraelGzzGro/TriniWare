using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PHGame2Script : MonoBehaviour
{
    private float timer = 5;
    int lives;
    int score;
    int cat;
    public Text gt;
    public InputField inp;
    

    void Start() 
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        gt = GetComponent<Text>();
    }
    void Update() 
    {
        if(inp.text == "nincompoop") 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
    }
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
