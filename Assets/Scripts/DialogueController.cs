using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    int counter = 1;
    [SerializeField] GameObject LeeAnne;
    [SerializeField] GameObject Sup;
    [SerializeField] GameObject lore1;
    [SerializeField] GameObject lore2;
    [SerializeField] GameObject lore3;
    [SerializeField] GameObject lore4;
    [SerializeField] GameObject lore5;
    [SerializeField] GameObject lore6;
    [SerializeField] GameObject lore7;
    [SerializeField] GameObject lore8;
    [SerializeField] GameObject lore9;
    [SerializeField] GameObject lore10;
    [SerializeField] GameObject lore11;
    [SerializeField] GameObject LeeAnne1;
    [SerializeField] GameObject LeeAnne2;
    [SerializeField] GameObject LeeAnne3;
    [SerializeField] GameObject LeeAnne4;
    [SerializeField] GameObject LeeAnne5;
    [SerializeField] GameObject LeeAnne6;
    [SerializeField] GameObject LeeAnne7;
    [SerializeField] GameObject LeeAnne8;
    [SerializeField] GameObject LeeAnne9;
    [SerializeField] GameObject LeeAnne10;
    [SerializeField] GameObject LeeAnne11;



    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && counter == 1) 
        {
            LeeAnne.SetActive(false);
            Sup.SetActive(false);
            LeeAnne1.SetActive(true);
            lore1.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 2) 
        {
            LeeAnne1.SetActive(false);
            lore1.SetActive(false);
            LeeAnne2.SetActive(true);
            lore2.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 3) 
        {
            LeeAnne2.SetActive(false);
            lore2.SetActive(false);
            LeeAnne3.SetActive(true);
            lore3.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 4) 
        {
            LeeAnne3.SetActive(false);
            lore3.SetActive(false);
            LeeAnne4.SetActive(true);
            lore4.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 5) 
        {
            LeeAnne4.SetActive(false);
            lore4.SetActive(false);
            LeeAnne5.SetActive(true);
            lore5.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 6) 
        {
            LeeAnne5.SetActive(false);
            lore5.SetActive(false);
            LeeAnne6.SetActive(true);
            lore6.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 7) 
        {
            LeeAnne6.SetActive(false);
            lore6.SetActive(false);
            LeeAnne7.SetActive(true);
            lore7.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 8) 
        {
            LeeAnne7.SetActive(false);
            lore7.SetActive(false);
            LeeAnne8.SetActive(true);
            lore8.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 9) 
        {
            LeeAnne8.SetActive(false);
            lore8.SetActive(false);
            LeeAnne9.SetActive(true);
            lore9.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 10) 
        {
            LeeAnne9.SetActive(false);
            lore9.SetActive(false);
            LeeAnne10.SetActive(true);
            lore10.SetActive(true);
            //counter += 1;
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 11) 
        {
            LeeAnne10.SetActive(false);
            lore10.SetActive(false);
            LeeAnne11.SetActive(true);
            lore11.SetActive(true);
            //counter += 1;   
        }
        if (Input.GetKeyDown(KeyCode.Space) && counter == 12) 
        {
            SceneManager.LoadScene("MainGame");
        }
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            counter += 1;
        }

    }
}
