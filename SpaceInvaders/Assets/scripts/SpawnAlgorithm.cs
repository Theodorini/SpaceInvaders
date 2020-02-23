using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlgorithm : MonoBehaviour
{
    public Spawner[] Spawners;
    void Start()
    {
        InvokeRepeating("StartSpawn", 2f, 7f);
    }
    public void StartSpawn()
    {
       int spawnNumber = (int) Random.Range(0, 4);
        Spawners[spawnNumber].Spawn(1, (int)Random.Range(5,50), 50);
    }
}
