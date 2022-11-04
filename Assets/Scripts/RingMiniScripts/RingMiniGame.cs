using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingMiniGame : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer mainbg;
    public bool outcome = false;
    public float timer = 0.0f;
    public Sprite losebg;
    public Sprite winbg;
    public bool triggerchoice = false;

    void Start()
    {
        outcome = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerchoice) {
            StartCoroutine(EndMini());
        }

        //if past 10 sec, end game based on outcome
        timer += Time.deltaTime;
        if (timer >= 10) {
            if (outcome)
            {
                mainbg.sprite = winbg;
            }
            else {
                mainbg.sprite = losebg;
            }
        }
    }
    IEnumerator EndMini() {
        yield return new WaitForSeconds(2);
        if (outcome)
        {
            mainbg.sprite = winbg;
        }
        else {
            mainbg.sprite = losebg;
        }
    }
}
