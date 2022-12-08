using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeButton : MonoBehaviour
{
    public ButtonsBehavior buttoncontroller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        //check if wait period for triggering orders is over
        if (buttoncontroller.waitfororders == false)
        {
            buttoncontroller.orangeb.sprite = buttoncontroller.orangedown;
        }
    }
    private void OnMouseUp()
    {
        if (buttoncontroller.waitfororders == false)
        {
            buttoncontroller.orangeb.sprite = buttoncontroller.orangeup;
            buttoncontroller.mousecounter += 1;
            //check if number of clicks exceeds the pattern length
            if (buttoncontroller.mousecounter > buttoncontroller.totalnum-1)
            {
                buttoncontroller.failedpattern = true;
                buttoncontroller.won = false;
                buttoncontroller.endtimer = 1;
            }
            else
            {
                if (buttoncontroller.mousecounter == buttoncontroller.totalnum - 1)
                {
                    if (buttoncontroller.orderarr[buttoncontroller.mousecounter] != 5)
                    {
                        buttoncontroller.failedpattern = true;
                        buttoncontroller.won = false;
                        buttoncontroller.endtimer = 1;
                    }
                    else
                    {
                        buttoncontroller.won = true;
                        buttoncontroller.endtimer = 1;
                    }
                }
                //if the value of the current position is not the same as the order in array, then failed pattern
                if (buttoncontroller.orderarr[buttoncontroller.mousecounter] != 5)
                {
                    buttoncontroller.failedpattern = true;
                    buttoncontroller.won = false;
                    buttoncontroller.endtimer = 1;
                }
            }
        }
    }
}
