using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PHGame2Script : MonoBehaviour
{
    private float timer = 6;
    int lives;
    int score;
    int cat;
    public Text gt;
    public InputField inp;
    int variation;
    [SerializeField] GameObject word1;
    [SerializeField] GameObject word2;
    [SerializeField] GameObject word3;
    

    void Start() 
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        gt = GetComponent<Text>();

        variation = Random.Range(1,4);

        if(variation == 1)
        {
            word1.SetActive(true);
        }
        if(variation == 2)
        {
            word2.SetActive(true);
        }
        if(variation == 3)
        {
            word3.SetActive(true);
        }
    }
    void Update() 
    {
        if(inp.text == "nincompoop" && variation == 1) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
        if(inp.text == "blackjacks" && variation == 2) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
        if(inp.text == "applejacks" && variation == 3) 
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
