using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Logic : MonoBehaviour
{
    private SpriteRenderer sr;
    public Sprite[] foods;
    float randomNumber;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(0,19);
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = foods[(int)randomNumber];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
