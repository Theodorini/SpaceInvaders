using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAlgorithm : MonoBehaviour
{
    public Spawner[] Spawners;
    public int RngCounter_Powerups=1; // Random.Range (1,RngCounter) where RngCounter descreases by 1 whenever an enemy spawns a Power_Up)
    void Start()
    {
        InvokeRepeating("StartSpawn", 1f, 3f);
    }
    public void StartSpawn()
    {
       int spawnNumber = (int) Random.Range(1,3);
        while(spawnNumber--!=0)
        {
            Spawners[(int)Random.Range(0, 4)].Spawn((int)Random.Range(1, 3), (int)Random.Range(5,50), 50,1f,100,15);
        }
    }
    public int Get_RngCounter_Powerups()
    {
        return RngCounter_Powerups;
    }
    public void Decrement_RngCounter_Powerups()
    {
        RngCounter_Powerups--;
    }
    public void Resest_RngCounter_Powerups()
    {
        RngCounter_Powerups = 10; // Or any other value
    }
}
