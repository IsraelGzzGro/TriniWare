using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite RTbg;

    private void OnMouseDown()
    {
        mainbg.sprite = RTbg;
        ringmini.triggerchoice = true;
    }
}
