using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject pusheff;
   public GameObject story;
   public GameObject nostory;

   public void playbtn() 
   {
        pusheff.SetActive(true);
        story.SetActive(true);
        nostory.SetActive(true);
   }

   public void Nstory() 
   {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("cat", 0);
        SceneManager.LoadScene("MainGame");

   }

   public void Story() 
   {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("cat", 0);
        SceneManager.LoadScene("IntroScene");
   }
   
   public void Restart()
   {
     SceneManager.LoadScene("MainMenu");
   }
}
