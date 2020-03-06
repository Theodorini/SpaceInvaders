using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    //Called by an Enemy on his death,gets Rng.Counter from SpawnAlgorithm
    public int NumberOfPowerups = 4;
    public GameObject[] PowerUp_Prefab;
    private Transform SpawnPoint;
    private int Rng;
    // Spawns an powerup of the given Type if the Rng says so;
    public void Spawn()
    {
        // Check for GameObject called SpawnAlg then get the class SpawnAlgorith from it and then get its rng counter;
        GameObject  SpawnAlg_Obj = GameObject.Find("SpawnAlg");
        SpawnAlgorithm SpawnAlg_Script = SpawnAlg_Obj.GetComponent<SpawnAlgorithm>();
        Rng = SpawnAlg_Script.Get_RngCounter_Powerups();
        //check if type 1 is needed to spawn
        int type = Random.Range(6, 6);
        //int type = Random.Range(2, Rng);

        SpawnPoint = gameObject.transform; // get pos from Enemy here 
        if(type<NumberOfPowerups)
        {
            SpawnAlg_Script.Resest_RngCounter_Powerups();
            GameObject obj =  Instantiate(PowerUp_Prefab[type], SpawnPoint.transform.position, SpawnPoint.transform.rotation);
            obj.GetComponent<Power_Up>().Constructor(type);
        }
        else
            SpawnAlg_Script.Decrement_RngCounter_Powerups(); 
    }
}
