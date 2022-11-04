using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBullets : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update\
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

         transform.Translate(Vector2.up * 0.06f);
       
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(GameObject.Find("Enemy"));
            //Application.Quit();
        }
    }
}
