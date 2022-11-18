using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleMovementScript : MonoBehaviour
{
    public GameObject explosion;
    private Rigidbody2D rb;
    public float playerSpd = 40f;

    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update(){
        if(Input.GetKey(KeyCode.LeftArrow)){
            gameObject.transform.Rotate(0f, 0f, 10f * Time.deltaTime * playerSpd);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            gameObject.transform.Rotate(0f, 0f, -10f * Time.deltaTime * playerSpd);
        }
    }

    private void onTriggerEnter2D(Collider2D other){
        //Debug.Log("Collision detected");
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = transform.position;
        Destroy(other.gameObject);
        this.gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log(col.gameObject.name);
        GameObject e = Instantiate(explosion) as GameObject;
        e.transform.position = col.transform.position;
        Debug.Log("Transform.position: " + col.transform.position);
        Destroy(col.gameObject);
        //this.gameObject.SetActive(false); //Destroy the barrier
    }

}
