using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsBehavior : MonoBehaviour
{
    public Sprite blueup;
    public Sprite bluedown;
    public Sprite pinkup;
    public Sprite pinkdown;
    public Sprite lightredup;
    public Sprite lightreddown;
    public Sprite greenup;
    public Sprite greendown;
    public Sprite darkredup;
    public Sprite darkreddown;
    public Sprite orangeup;
    public Sprite orangedown;
    public SpriteRenderer blueb;
    public SpriteRenderer pinkb;
    public SpriteRenderer lredb;
    public SpriteRenderer greenb;
    public SpriteRenderer dredb;
    public SpriteRenderer orangeb;
    public GameObject watchtext;
    public GameObject mimictext;
    public GameObject successtext;
    public GameObject failtext;
    public int totalnum;
    public List<int> orderlist;
    public int[] orderarr;
    public bool start = true;
    public bool pressed = true;
    public bool waitfororders = true;
    public bool failedpattern = false;
    public bool won;
    public int mousecounter;
    public float timer = 0.0f;

    int lives;
    int score;
    int cat;
    public float endtimer;
    //public int[] mousearr;

    // Start is called before the first frame update
    void Start()
    {

        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
        //instructions are only text active
        watchtext.SetActive(true);
        mimictext.SetActive(false);
        successtext.SetActive(false);
        failtext.SetActive(false);

        mousecounter = -1; //initial click is 0 in array
        totalnum = Mathf.RoundToInt(Random.Range(3f, 7f)); //total number of buttons to copy
        //change end tiemr length based on number in pattern order
        switch (totalnum) {
            case 3:
                endtimer = 18f; //8 seconds left to get 3 clicks
                break;
            case 4:
                endtimer = 22f; //10sec left to get 4 clicks
                break;
            case 5:
                endtimer = 28f; //14 sec left to get 5 clicks
                break;
            case 6:
                endtimer = 32f; //16 sec left to get 6 clicks
                break;
            case 7:
                endtimer = 38f; //22 sec to get 7 clicks
                break;
        }
        //make list of buttons
        for (int i = 0; i < totalnum; i++)
        {
            float randnum = Random.Range(0f, 5f);
            orderlist.Add(Mathf.RoundToInt(randnum));
        }
        orderarr = orderlist.ToArray();
        //mousearr = orderlist.ToArray();
    }

    //wait for start period to end
    IEnumerator WaitForStarting() {
        yield return new WaitForSeconds(3);
        start = false;
    }
    //trigger button playing pattern
    IEnumerator TriggeringOrders() {
        for (int i = 0; i < totalnum; i++) {
            if (pressed) {
                switch ((orderarr[i])) {
                    case 0: //blue button
                        Debug.Log("check blued");
                        blueb.sprite = bluedown;
                        break;
                    case 1: //pink button
                        Debug.Log("check pinkd");
                        pinkb.sprite = pinkdown;
                        break;
                    case 2: //lightred button
                        Debug.Log("check lightredd");
                        lredb.sprite = lightreddown;
                        break;
                    case 3: //green button
                        Debug.Log("check greend");
                        greenb.sprite = greendown;
                        break;
                    case 4: //darkred button
                        Debug.Log("check darkredd");
                        dredb.sprite = darkreddown;
                        break;
                    case 5: //orange button
                        Debug.Log("check oranged");
                        orangeb.sprite = orangedown;
                        break;
                }
                pressed = false;
                yield return new WaitForSeconds(1f);
            }
            if (pressed == false ) {
                switch ((orderarr[i]))
                {
                    case 0: //blue button
                        Debug.Log("check blueup");
                        blueb.sprite = blueup;
                        break;
                    case 1: //pink button
                        Debug.Log("check pinkup");
                        pinkb.sprite = pinkup;
                        break;
                    case 2: //lightred button
                        Debug.Log("check lightredup");
                        lredb.sprite = lightredup;
                        break;
                    case 3: //green button
                        Debug.Log("check greenup");
                        greenb.sprite = greenup;
                        break;
                    case 4: //darkred button
                        Debug.Log("check darkredup");
                        dredb.sprite = darkredup;
                        break;
                    case 5: //orange button
                        Debug.Log("check orangeup");
                        orangeb.sprite = orangeup;
                        break;
                }
            }
            pressed = true;
            yield return new WaitForSeconds(1f);
            Debug.Log("check up yield");
            Debug.Log("end first for i");
        }
        Debug.Log("end for loop");
        //set mimic active and watch inactive
        watchtext.SetActive(false);
        mimictext.SetActive(true); 
    }
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (start) {
            Debug.Log("check start");
            StartCoroutine(WaitForStarting());   
        }

        if (waitfororders == true && start == false) {
            Debug.Log("start corotine");
            StartCoroutine(TriggeringOrders());
            
            waitfororders = false;
        }

        if (failedpattern) {
            mimictext.SetActive(false);
            failtext.SetActive(true);
            won = false;
        }

        if (mousecounter>totalnum-1) {
            //more than array length
            mimictext.SetActive(false);
            failtext.SetActive(true);
            won = false;
        }

        if (mousecounter == totalnum-1 && failedpattern == false) {
            //game is success
            mimictext.SetActive(false);
            successtext.SetActive(true);
            won = true;
        }
    }

    /*void checkGame()
    {
        if (findscript.findlist.Count <= 0)
        {
            won = true;
            gameEnds();
        }
    } */

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
                } else {
                    score += 5;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                }
            }
        }
    }
}
