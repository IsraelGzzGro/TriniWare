using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RMChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite RMbg;

    private void OnMouseDown()
    {
        mainbg.sprite = RMbg;
        ringmini.triggerchoice = true;
    }
}
