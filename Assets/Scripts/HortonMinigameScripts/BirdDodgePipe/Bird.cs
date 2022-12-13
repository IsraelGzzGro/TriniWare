using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public Logic logic;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myRigidBody.velocity = Vector2.up * flapStrength;
        }

        if (transform.position.y < -50)
            logic.lose();
        if (logic.score >= 5)
            logic.win();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isAlive = false;
        logic.lose();
    }
}
