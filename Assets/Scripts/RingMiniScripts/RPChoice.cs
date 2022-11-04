using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPChoice : MonoBehaviour
{
    public RingMiniGame ringmini; 
    public SpriteRenderer mainbg;
    public Sprite RPbg;

    private void OnMouseDown()
    {
        mainbg.sprite = RPbg;
        ringmini.triggerchoice = true;
    }
}
