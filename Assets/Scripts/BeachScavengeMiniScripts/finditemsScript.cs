using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finditemsScript : MonoBehaviour
{
    public List<int> findlist;
    public SpriteRenderer find1;
    public SpriteRenderer find2;
    public SpriteRenderer find3;
    public SpriteRenderer selectedsprite;
    public Sprite atlabass0;
    public Sprite axolot1;
    public Sprite blueg2;
    public Sprite clown3;
    public Sprite dab4;
    public Sprite gold5;
    public Sprite gup6;
    public Sprite high7;
    public Sprite fishbob8;
    public Sprite snail9;
    public Sprite jun10;
    public Sprite moss11;
    public Sprite bag12;
    public Sprite doll13;
    public Sprite spider14;
    public Sprite star15;
    float totalfindnum;
    public int findlength;
    // Start is called before the first frame update
    void Start()
    {
        totalfindnum = Random.Range(1f,3f);
        findlength = Mathf.RoundToInt(totalfindnum);

        if (findlength == 3) {
            //do nothing, all sprites should be enabled
        } else if (findlength == 2) {
            find3.enabled = false; //disable sprite renderer of finditem3
        } else {
            find3.enabled = false;
            find2.enabled = false;
        }
        //generate random numbers for sprites
        for (int i = 0; i < findlength; i++) {
            float randnum = Random.Range(0f, 16f);
            findlist.Add(Mathf.RoundToInt(randnum));
        }
        //add sprites numbers to list & display in findbox
        for (int i = 0; i < findlength; i++) {
            int spritenum = findlist[i];
            if (i == 0) {
                selectedsprite = find1;
            } else if (i == 1) {
                selectedsprite = find2;
            } else {
                selectedsprite = find3;
            }

            switch (spritenum) {
                case 0:
                    selectedsprite.sprite = atlabass0;
                    break;
               case 1:
                    selectedsprite.sprite = axolot1;
                    break;
                case 2:
                    selectedsprite.sprite = blueg2;
                    break;
                case 3:
                    selectedsprite.sprite = clown3;
                    break;
                case 4:
                    selectedsprite.sprite = dab4;
                    break;
                case 5:
                    selectedsprite.sprite = gold5;
                    break;
                case 6:
                    selectedsprite.sprite = gup6;
                    break;
                case 7:
                    selectedsprite.sprite = high7;
                    break;
                case 8:
                    selectedsprite.sprite = fishbob8;
                    break;
                case 9:
                    selectedsprite.sprite = snail9;
                    break;
                case 10:
                    selectedsprite.sprite = jun10;
                    break;
                case 11:
                    selectedsprite.sprite = moss11;
                    break;
                case 12:
                    selectedsprite.sprite = bag12;
                    break;
                case 13:
                    selectedsprite.sprite = doll13;
                    break;
                case 14:
                    selectedsprite.sprite = spider14;
                    break;
                case 15:
                    selectedsprite.sprite = star15;
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
