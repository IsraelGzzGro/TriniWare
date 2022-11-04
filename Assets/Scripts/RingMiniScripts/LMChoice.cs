using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite LMbg;

    private void OnMouseDown()
    {
        mainbg.sprite = LMbg;
        ringmini.triggerchoice = true;
    }
}
