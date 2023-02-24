using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PHGame2Script : MonoBehaviour
{
    private float timer = 7;
    int lives;
    int score;
    int cat;
    public Text gt;
    public Text inp;
    int variation;
    [SerializeField] GameObject word1;
    [SerializeField] GameObject word2;
    [SerializeField] GameObject word3;
    [SerializeField] GameObject word4;
    [SerializeField] GameObject word5;
    

    void Start() 
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        gt = GetComponent<Text>();

        variation = Random.Range(1,6);

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
        if(variation == 4)
        {
            word4.SetActive(true);
        }
        if(variation == 5)
        {
            word5.SetActive(true);
        }
    }
    void Update() 
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            inp.text += 'a';
        } else if (Input.GetKeyDown(KeyCode.B))
        {
            inp.text += 'b';
        } else if (Input.GetKeyDown(KeyCode.C))
        {
            inp.text += 'c';
        } else if (Input.GetKeyDown(KeyCode.D))
        {
            inp.text += 'd';
        } else if (Input.GetKeyDown(KeyCode.E))
        {
            inp.text += 'e';
        } else if (Input.GetKeyDown(KeyCode.F))
        {
            inp.text += 'f';
        } else if (Input.GetKeyDown(KeyCode.G))
        {
            inp.text += 'g';
        } else if (Input.GetKeyDown(KeyCode.H))
        {
            inp.text += 'h';
        } else if (Input.GetKeyDown(KeyCode.I))
        {
            inp.text += 'i';
        } else if (Input.GetKeyDown(KeyCode.J))
        {
            inp.text += 'j';
        } else if (Input.GetKeyDown(KeyCode.K))
        {
            inp.text += 'k';
        } else if (Input.GetKeyDown(KeyCode.L))
        {
            inp.text += 'l';
        } else if (Input.GetKeyDown(KeyCode.M))
        {
            inp.text += 'm';
        } else if (Input.GetKeyDown(KeyCode.N))
        {
            inp.text += 'n';
        } else if (Input.GetKeyDown(KeyCode.O))
        {
            inp.text += 'o';
        } else if (Input.GetKeyDown(KeyCode.P))
        {
            inp.text += 'p';
        } else if (Input.GetKeyDown(KeyCode.Q))
        {
            inp.text += 'q';
        } else if (Input.GetKeyDown(KeyCode.R))
        {
            inp.text += 'r';
        } else if (Input.GetKeyDown(KeyCode.S))
        {
            inp.text += 's';
        } else if (Input.GetKeyDown(KeyCode.T))
        {
            inp.text += 't';
        } else if (Input.GetKeyDown(KeyCode.U))
        {
            inp.text += 'u';
        } else if (Input.GetKeyDown(KeyCode.V))
        {
            inp.text += 'v';
        } else if (Input.GetKeyDown(KeyCode.W))
        {
            inp.text += 'w';
        } else if (Input.GetKeyDown(KeyCode.X))
        {
            inp.text += 'x';
        } else if (Input.GetKeyDown(KeyCode.Y))
        {
            inp.text += 'y';
        } else if (Input.GetKeyDown(KeyCode.Z))
        {
            inp.text += 'z';
        } else if (Input.GetKeyDown(KeyCode.Backspace) && inp.text.Length > 0)
        {
            inp.text = inp.text.Substring(0, inp.text.Length-1);
        }

        
    }
    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                if(inp.text == "nincompoop" && variation == 1) 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else if(inp.text == "blackjacks" && variation == 2) 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else if(inp.text == "applejacks" && variation == 3) 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else if(inp.text == "paddywhack" && variation == 4) 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else if(inp.text == "chickenpox" && variation == 5) 
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else 
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
}
