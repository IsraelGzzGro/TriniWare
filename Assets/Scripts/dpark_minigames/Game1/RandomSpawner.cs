using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RandomSpawner : MonoBehaviour
{
    public static RandomSpawner instance;
    private float timer = 27;
    int lives;
    int score;
    int cat;
    bool alive = true;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    private GameObject enem;
    public int numOfEnem = 10;
    public float timeStart = 60;

    // Start is called before the first frame update
    void Start()
    {
        lives = PlayerPrefs.GetInt("lives");
        score = PlayerPrefs.GetInt("score");
        cat = PlayerPrefs.GetInt("cat");
    }

    public void lost() 
    {
        alive = false;
        timer = 2;
    }

    void FixedUpdate() 
    {
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;

            if (timer <= 0)
            {
                if(alive == true) 
                {
                    score += 15;
                    cat = 2;
                    PlayerPrefs.SetInt("score", score);
                    PlayerPrefs.SetInt("cat", cat);
                    SceneManager.LoadScene("MainGame");
                } else {
                lives -= 1;
                cat = 1;
                PlayerPrefs.SetInt("lives", lives);
                PlayerPrefs.SetInt("cat", cat);
                SceneManager.LoadScene("MainGame");
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        float val = Mathf.Round(timeStart);
        //Debug.Log(val);
        if(val % 5 == 0 && numOfEnem != 0){
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            if(randSpawnPoint > 4){
                enem = enemyPrefabs[randEnemy];
                GameObject rat = Instantiate(enem, spawnPoints[randSpawnPoint].position, transform.rotation);
                rat.transform.localScale = new Vector3(rat.transform.localScale.x , rat.transform.localScale.y *-1, rat.transform.localScale.z);
                
                numOfEnem -= 1;
                timeStart += 1.5f;
            }
            else {
                Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
                numOfEnem -= 1;
                timeStart += 1.5f;
            }
        }
    }
}
