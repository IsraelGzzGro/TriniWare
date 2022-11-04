using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgePlayerScipt : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject mainscript;

    void start() 
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "DodgeEnemy")
        {
            mainscript.GetComponent<DodgeGame>().hit();
            gameObject.SetActive(false);
        }
    }
}
