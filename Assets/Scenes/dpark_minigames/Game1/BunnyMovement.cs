using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BunnyMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement, movement2;
    public GameObject explosion;
    private bool alive = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        Vector3 zero = new Vector3(0, 0, 0);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        //zero.Normalize();
        movement = direction;
        movement2 = zero;
    }

    private void FixedUpdate(){
        if(!alive){
            moveCharacter(movement2);
            rb.velocity = new Vector3(0f, 0f,0f);
        } else moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.tag == "Player"){
            //Debug.Log("Collided with Player D:");
            GameObject e = Instantiate(explosion) as GameObject;
            e.transform.position = col.transform.position;
            //Debug.Log("Transform.position: " + transform.position);
            Destroy(col.gameObject);
            alive = false;
        }
        //this.gameObject.SetActive(false); //Destroy the barrier
    }


}
