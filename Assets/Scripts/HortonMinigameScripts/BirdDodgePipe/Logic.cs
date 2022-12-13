using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Logic : MonoBehaviour
{
    public int score;
    public Text scoreText;

    [ContextMenu("Increase Score")]
    public void addScore(int amt)
    {
        score += amt;
        scoreText.text = score.ToString();
    }

    public void lose()
    {
        Debug.Log("You Died!");
        //PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 5);
        PlayerPrefs.SetInt("cat", 1);
        PlayerPrefs.SetInt("lives", PlayerPrefs.GetInt("lives") - 1);
        SceneManager.LoadScene("MainGame");
    }

    public void win()
    {
        
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + 5);
        PlayerPrefs.SetInt("cat", 2);
        SceneManager.LoadScene("MainGame");
    }
}
