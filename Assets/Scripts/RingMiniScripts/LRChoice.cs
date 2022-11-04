using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LRChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite LRbg;

    private void OnMouseDown()
    {
        mainbg.sprite = LRbg;
        ringmini.outcome = true;
        ringmini.triggerchoice = true;
    }
}
