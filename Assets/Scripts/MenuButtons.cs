using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GameObject pusheff;
   public GameObject story;
   public GameObject nostory;
   public GameObject howtplay;
   public GameObject htpwindow;

   public void playbtn() 
   {
        pusheff.SetActive(true);
        story.SetActive(true);
        nostory.SetActive(true);
        howtplay.SetActive(true);
   }

   public void Nstory() 
   {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("cat", 0);
        PlayerPrefs.SetInt("reset", 0);

        PlayerPrefs.SetInt("PlayingStory?", 0);
        SceneManager.LoadScene("MainGame");

   }

   public void Story() 
   {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("cat", 0);
        PlayerPrefs.SetInt("reset", 0);

        PlayerPrefs.SetInt("PlayingStory?", 1);
        SceneManager.LoadScene("IntroScene");
   }
   
   public void Restart()
   {
     SceneManager.LoadScene("MainMenu");
   }

   public void Return()
   {
     htpwindow.SetActive(false);
   }

   public void Showhtp()
   {
     htpwindow.SetActive(true);
   }

   public void skipDialogue() 
   {
     SceneManager.LoadScene("MainGame");
   }
}
