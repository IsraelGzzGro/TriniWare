using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PHGameScript : MonoBehaviour
{
    //this is the seconds for the timer in FixedUpdate
    private float timer = 6;
    
    //these 3 local variables need to be set at the start of every game
    int lives;
    int score;
    int cat;
    //these ^

    int variation;
    [SerializeField] GameObject inst1;
    [SerializeField] GameObject inst2;
    [SerializeField] GameObject inst3;
    [SerializeField] GameObject instShift;
    [SerializeField] GameObject SgagR;
    [SerializeField] GameObject LcatR;
    [SerializeField] GameObject SgagL;
    [SerializeField] GameObject LcatL;

    void Start() 
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");

        variation = Random.Range(1,6);

        StartCoroutine(instruction());

    }

    //this is the actual "game" in this case it is just to press s certain key so when you do, you win, and that is the code for what winning does
    //this will obviously be bigger and more complex for other games, but that code has to be there before leaving to the main game
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Space) && variation == 1) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
        if(Input.GetKeyDown(KeyCode.Tab) && variation == 2) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
        if(Input.GetKeyDown(KeyCode.Y) && variation == 3) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
        if(Input.GetKeyDown(KeyCode.RightShift) && variation == 4) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
        if(Input.GetKeyDown(KeyCode.LeftShift) && variation == 5) 
        {
            score += 5;
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            SceneManager.LoadScene("MainGame");
        }
    }

    IEnumerator instruction() {
        yield return new WaitForSeconds(3);
        
        if(variation == 1)
        {
            inst1.SetActive(true);
        }
        if(variation == 2)
        {
            inst2.SetActive(true);
        }
        if(variation == 3)
        {
            inst3.SetActive(true);
        }
        if(variation == 5)
        {
            instShift.SetActive(true);
            SgagR.SetActive(true);
            LcatR.SetActive(true);
        }
        if(variation == 6)
        {
            instShift.SetActive(true);
            SgagL.SetActive(true);
            LcatL.SetActive(true);
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
