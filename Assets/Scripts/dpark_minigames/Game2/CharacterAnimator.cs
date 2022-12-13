using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    MasherScript ms;
    //public GameObject cam;
    private Animator anim;
    int h;
    int cnt = 1;

    void Awake(){
        ms = GameObject.Find("Main Camera").GetComponent<MasherScript>();
        int h = ms.health;
    }

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        h = ms.health;

        if(h <= 0 && cnt == 1){
            cnt -= 1;
            Debug.Log("Death Reached");
            //anim.SetBool("isDead", true);
            GetComponent<Animator>().SetTrigger("isDead_");
        }

    }
}
