using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class basketbehavior : MonoBehaviour
{
    public float endtimer = 25f;
    public finditemsScript findscript;
    public beachitemsScript beachscript;
    public bool gameOn;
    public bool won;

    int lives;
    int score;
    int cat;

    // Start is called before the first frame update
    void Start()
    {
        gameOn = true;

        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
    }

    // Update is called once per frame
    void Update()
    {
        if (findscript.findlist.Count <= 0) {
            won = true;
        }

        if (gameOn == false) {
            won = false;
        }
    }

    IEnumerator EndMini()
    {
        gameEnds();
        yield return new WaitForSeconds(2);
    }
    void gameEnds() {
        endtimer = 2;
    }

    void checkGame() {
        if (findscript.findlist.Count <= 0) {
            won = true;
            gameEnds();
        }
    }

    void FixedUpdate()
    {
        if (endtimer > 0)
        {
            endtimer -= Time.fixedDeltaTime;

            if (endtimer <= 0)
            {
                if (won == false)
                {
                    lives -= 1;
                    cat = 1;
                    PlayerPrefs.SetInt("lives", lives);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                }
                else
                {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        checkGame();
        //check if won game already
        /// correct or wrong inputs
        if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.atlabass0) {
            if (findscript.findlist.Contains(0)) {
                findscript.findlist.Remove(0);
                checkGame();
            }
            else {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        } else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.axolot1) {
            if (findscript.findlist.Contains(1))
            {
                findscript.findlist.Remove(1);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.blueg2)
        {
            if (findscript.findlist.Contains(2))
            {
                findscript.findlist.Remove(2);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.clown3)
        {
            if (findscript.findlist.Contains(3))
            {
                findscript.findlist.Remove(3);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.dab4)
        {
            if (findscript.findlist.Contains(4))
            {
                findscript.findlist.Remove(4);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.gold5)
        {
            if (findscript.findlist.Contains(5))
            {
                findscript.findlist.Remove(5);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.gup6)
        {
            if (findscript.findlist.Contains(6))
            {
                findscript.findlist.Remove(6);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.high7)
        {
            if (findscript.findlist.Contains(7))
            {
                findscript.findlist.Remove(7);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.fishbob8)
        {
            if (findscript.findlist.Contains(8))
            {
                findscript.findlist.Remove(8);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.snail9)
        {
            if (findscript.findlist.Contains(9))
            {
                findscript.findlist.Remove(9);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.jun10)
        {
            if (findscript.findlist.Contains(10))
            {
                findscript.findlist.Remove(10);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.moss11)
        {
            if (findscript.findlist.Contains(11))
            {
                findscript.findlist.Remove(11);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.bag12)
        {
            if (findscript.findlist.Contains(12))
            {
                findscript.findlist.Remove(12);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
                Destroy(collision.gameObject);
            }
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.doll13)
        {
            if (findscript.findlist.Contains(13))
            {
                findscript.findlist.Remove(13);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.GetComponent<SpriteRenderer>().sprite == findscript.spider14)
        {
            if (findscript.findlist.Contains(14))
            {
                findscript.findlist.Remove(14);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
        else //starfish
        {
            if (findscript.findlist.Contains(15))
            {
                findscript.findlist.Remove(15);
                checkGame();
            }
            else
            {
                gameOn = false;
                gameEnds();
            }
            Destroy(collision.gameObject);
        }
    }
}
