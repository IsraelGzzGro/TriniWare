using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tile_Logic : MonoBehaviour
{
    public List<Button> buttons;
    public List<Button> shuffledButtons;
    int counter;
    int lives;
    int score;
    int cat;
    private float timer = 10;

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        StartGame(); //Set the game
    }

    public void StartGame(){
        counter = 1;
        shuffledButtons = buttons.OrderBy(a => Random.Range(0, 100)).ToList(); //Shuffle
        for(int i = 1; i < 11; i++){
            shuffledButtons[i-1].GetComponentInChildren<Text>().text = i.ToString();
            shuffledButtons[i-1].interactable = true;
            shuffledButtons[i-1].image.color = Color.white;
        }

    }

    public void pressButton(Button button){
        if(int.Parse(button.GetComponentInChildren<Text>().text) == counter){
            counter++;
            //button.interactable = false;
            button.image.color = Color.green;
            Debug.Log("Pressed: " + (int.Parse(button.GetComponentInChildren<Text>().text)) + " | Counter: " + counter);
            if(counter == 11){
                StartCoroutine(presentResult(true));
            } 
        } else {
            StartCoroutine(presentResult(false));
        }
    }

    public IEnumerator presentResult(bool win){
        if(!win){ //If Lost
            foreach(var button in shuffledButtons){
                button.image.color = Color.red;
                //button.interactable = false;
            }
            lives -= 1;
            cat = 1;
            PlayerPrefs.SetInt("lives", lives);
            PlayerPrefs.SetInt("cat", cat);
            yield return new WaitForSeconds(2f);
            SceneManager.LoadScene("MainGame");
        } else 
        {
            score += 5;  
            cat = 2;
            PlayerPrefs.SetInt("score", score);
            PlayerPrefs.SetInt("cat", cat);
            yield return new WaitForSeconds(2f);
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
