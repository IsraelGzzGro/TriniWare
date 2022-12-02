using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beachitemsScript : MonoBehaviour
{
    public GameObject selectedObject;
    Vector3 offset;

    public finditemsScript findscript;
    public List<int> wateritems; //5 total items
    public List<int> sanditems; //6 total items
    public bool watercheck;

    public SpriteRenderer water0;
    public SpriteRenderer water1;
    public SpriteRenderer water2;
    public SpriteRenderer water3;
    public SpriteRenderer water4;
    public SpriteRenderer sand0;
    public SpriteRenderer sand1;
    public SpriteRenderer sand2;
    public SpriteRenderer sand3;
    public SpriteRenderer sand4;
    public SpriteRenderer sand5;
    
    public SpriteRenderer selsprite;

    // Start is called before the first frame update
    void Start()
    {
        //sort based on watersprites or sandsprites
        for (int i = 0; i<findscript.findlist.Count; i++) {
            if (findscript.findlist[i] < 8) {
                wateritems.Add(findscript.findlist[i]);
            } else {
                sanditems.Add(findscript.findlist[i]);
            }
        }

        int waternum = 5-wateritems.Count;
        int sandnum = 6-sanditems.Count;
        //add random water items to list
        for (int i = 0; i < waternum; i++) {
            float randnum = Random.Range(0f, 8f);
            wateritems.Add(Mathf.RoundToInt(randnum));
        }
        //add random sand items to list
        for (int i = 0; i < sandnum; i++) {
            float randnum = Random.Range(8f, 16f);
            sanditems.Add(Mathf.RoundToInt(randnum));
        }
        //shuffle positions
        shuffle(wateritems, wateritems.Count);
        shuffle(sanditems, sanditems.Count);
        //switch water sprites accordingly
        watercheck = true;
        for (int i = 0; i < wateritems.Count; i++) {
            switchsprites(wateritems, i);
        }
        //switch sand sprites accordingly
        watercheck = false;
        for (int i = 0; i < sanditems.Count; i++) {
            switchsprites(sanditems, i);
        }
    }

    void shuffle(List<int> lst, int lstlength) {
        //shuffle numbers around based on current position in list randomly
        for (int i = 0; i < lstlength; i++)
        {
            int randomnum = Random.Range(0, lstlength);
            int swapnum = lst[randomnum];
            lst[randomnum] = lst[i];
            lst[i] = swapnum;
        }
    }

    void switchsprites(List<int> lst, int listnum) {
        int spritenum = lst[listnum];
        //check whether it is water item list  or sand item list, and make it the selected sprite
        if (watercheck) {
            switch (listnum)
            {
                case 0:
                    selsprite = water0;
                    break;
                case 1:
                    selsprite = water1;
                    break;
                case 2:
                    selsprite = water2;
                    break;
                case 3:
                    selsprite = water3;
                    break;
                case 4:
                    selsprite = water4;
                    break;
            }
        } else {
            switch (listnum)
            {
                case 0:
                    selsprite = sand0;
                    break;
                case 1:
                    selsprite = sand1;
                    break;
                case 2:
                    selsprite = sand2;
                    break;
                case 3:
                    selsprite = sand3;
                    break;
                case 4:
                    selsprite = sand4;
                    break;
                case 5:
                    selsprite = sand5;
                    break;
            }
        }
        //switch to the right sprite based on number
        switch (spritenum)
        {
            case 0:
                selsprite.sprite = findscript.atlabass0;
                break;
            case 1:
                selsprite.sprite = findscript.axolot1;
                break;
            case 2:
                selsprite.sprite = findscript.blueg2;
                break;
            case 3:
                selsprite.sprite = findscript.clown3;
                break;
            case 4:
                selsprite.sprite = findscript.dab4;
                break;
            case 5:
                selsprite.sprite = findscript.gold5;
                break;
            case 6:
                selsprite.sprite = findscript.gup6;
                break;
            case 7:
                selsprite.sprite = findscript.high7;
                break;
            case 8:
                selsprite.sprite = findscript.fishbob8;
                break;
            case 9:
                selsprite.sprite = findscript.snail9;
                break;
            case 10:
                selsprite.sprite = findscript.jun10;
                break;
            case 11:
                selsprite.sprite = findscript.moss11;
                break;
            case 12:
                selsprite.sprite = findscript.bag12;
                break;
            case 13:
                selsprite.sprite = findscript.doll13;
                break;
            case 14:
                selsprite.sprite = findscript.spider14;
                break;
            case 15:
                selsprite.sprite = findscript.star15;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //get mouse position relative to world
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);
            if (targetObject)
            {
                selectedObject = targetObject.transform.gameObject;
                offset = selectedObject.transform.position - mousePosition;
            }
        }
        //make selected object move to current mouse position
        if (selectedObject)
        {
            selectedObject.transform.position = mousePosition + offset;
        }

        //no longer selected, then stop selecting it
        if (Input.GetMouseButtonUp(0) && selectedObject)
        {
            selectedObject = null;
        }
    }
}
