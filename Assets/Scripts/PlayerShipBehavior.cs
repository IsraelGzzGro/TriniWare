using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipBehavior : MonoBehaviour
{
    public GameObject projectile;
    int counter = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && counter == 0)
        {
            shootBullet();
            counter++;
        }
    }

    void shootBullet()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
    }
}
