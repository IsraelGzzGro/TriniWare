using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LTChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite LTbg;

    private void OnMouseDown()
    {
        mainbg.sprite = LTbg;
        ringmini.triggerchoice = true;
    }
}
