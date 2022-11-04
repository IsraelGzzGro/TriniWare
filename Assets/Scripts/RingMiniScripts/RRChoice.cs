using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RRChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite RRbg;

    private void OnMouseDown()
    {
        mainbg.sprite = RRbg;
        ringmini.triggerchoice = true;
    }
}
