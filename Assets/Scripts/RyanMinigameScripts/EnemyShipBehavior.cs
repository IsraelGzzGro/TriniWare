using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyShipBehavior : MonoBehaviour
{
    //public Text tt;
    //private int counter = 0;
    public GameObject player;
    void Update()
    {
       /* counter++;
        if (counter >= 50)
        {  
            Destroy(tt);
        }

        if(counter >= 60)
        {   
           counter = 60;
           transform.Translate(Vector2.right * 0.002f);
        }*/

    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Bullet"))
        {
            player.GetComponent<PlayerShipBehavior>().hitsEnemy();
            Destroy(GameObject.Find("PlayerBullets(Clone)"));
        }
    }
}
