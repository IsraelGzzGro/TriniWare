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
        SceneManager.LoadScene("MainGame");
   }

   public void Story() 
   {
        SceneManager.LoadScene("IntroScene");
   }
}
