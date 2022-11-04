using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RIChoice : MonoBehaviour
{
    public RingMiniGame ringmini;
    public SpriteRenderer mainbg;
    public Sprite RIbg;

    private void OnMouseDown()
    {
        mainbg.sprite = RIbg;
        ringmini.triggerchoice = true;
    }
}
