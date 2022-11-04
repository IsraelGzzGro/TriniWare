using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite LIbg;

    private void OnMouseDown()
    {
        mainbg.sprite = LIbg;
        ringmini.triggerchoice = true;
    }
}
