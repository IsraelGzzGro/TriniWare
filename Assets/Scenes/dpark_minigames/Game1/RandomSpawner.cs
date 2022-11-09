using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public int numOfEnem = 10;
    public float timeStart = 60;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeStart -= Time.deltaTime;
        float val = Mathf.Round(timeStart);
        Debug.Log(val);
        if(val % 5 == 0 && numOfEnem != 0){
            int randEnemy = Random.Range(0, enemyPrefabs.Length);
            int randSpawnPoint = Random.Range(0, spawnPoints.Length);
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            numOfEnem -= 1;
            timeStart += 1.5f;
        }
    }
}
