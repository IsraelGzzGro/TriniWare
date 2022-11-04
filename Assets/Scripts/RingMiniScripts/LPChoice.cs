using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LPChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite LPbg;

    private void OnMouseDown()
    {
        mainbg.sprite = LPbg;
        ringmini.triggerchoice = true;
    }
}
