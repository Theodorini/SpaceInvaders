using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlgorithm : MonoBehaviour
{
    public Spawner[] Spawners;
    void Start()
    {
        InvokeRepeating("StartSpawn", 1f, 3f);
    }
    public void StartSpawn()
    {
       int spawnNumber = (int) Random.Range(1, 5);
        while(spawnNumber--!=0)
        {
            //Spawners[(int)Random.Range(0, 4)].Spawn(1, (int)Random.Range(5,50), 50,1f,100,100);
        }
    }
}
