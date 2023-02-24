using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
   public GameObject pusheff;
   public GameObject story;
   public GameObject nostory;
   public GameObject howtplay;
   public GameObject htpwindow;
   public Animator anim;
   public Text Hscore;
   int highscore;

   public Animator MainThemeFades;

   void Start() 
   {
     highscore = PlayerPrefs.GetInt("highscore");
     Hscore.text = "Highscore: " + highscore.ToString();
   }

   public void playbtn() 
   {
        pusheff.SetActive(true);
        story.SetActive(true);
        nostory.SetActive(true);
        howtplay.SetActive(true);

        //anim = GetComponent<Animator>();
   }

   public void Nstory() 
   {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("cat", 0);
        //PlayerPrefs.SetInt("reset", 0);

        PlayerPrefs.SetFloat("Timer",19.5f);
        PlayerPrefs.SetInt("IntroAnim", 1);

        PlayerPrefs.SetInt("PlayingStory?", 0);
        PlayerPrefs.SetInt("BeatStory", 0);
        
        StartCoroutine(FadeMusToGame());

   }

   public void Story() 
   {
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("score", 0);
        PlayerPrefs.SetInt("cat", 0);
        //PlayerPrefs.SetInt("reset", 0);

        PlayerPrefs.SetFloat("Timer",19.5f);
        PlayerPrefs.SetInt("IntroAnim", 1);

        PlayerPrefs.SetInt("PlayingStory?", 1);
        PlayerPrefs.SetInt("BeatStory", 0);
        
        StartCoroutine(FadeMusToIntro());
   }

   IEnumerator FadeMusToIntro() 
   {
     MainThemeFades.SetTrigger("FadeOUT");
     yield return new WaitForSeconds(2);
     SceneManager.LoadScene("IntroScene");
   }
   IEnumerator FadeMusToGame() 
   {
     MainThemeFades.SetTrigger("FadeOUT");
     yield return new WaitForSeconds(2);
     SceneManager.LoadScene("MainGame");
   }
   
   public void Restart()
   {
     SceneManager.LoadScene("MainMenu");
   }

   public void Return()
   {
     anim.SetBool("RetPressed", true);
     StartCoroutine(waitforpanel());
   }

   IEnumerator waitforpanel() 
   {
     yield return new WaitForSeconds(2);
     htpwindow.SetActive(false);
   }

   public void Showhtp()
   {
     anim.SetBool("RetPressed", false);
     htpwindow.SetActive(true);
   }

   public void skipDialogue() 
   {
     StartCoroutine(FadeMusGame());
   }

   IEnumerator FadeMusGame() 
   {
     MainThemeFades.SetTrigger("FadeOUT");
     yield return new WaitForSeconds(1.5f);
     SceneManager.LoadScene("MainGame");
   }
   public void skipDialogue2() 
   {
     SceneManager.LoadScene("GameOver");
   }
}
