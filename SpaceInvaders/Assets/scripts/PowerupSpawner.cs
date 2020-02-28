using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{

    //Called by an Enemy on his death,gets Rng.Counter from SpawnAlgorithm
    public GameObject PowerUp_Prefab;
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
        int type = Random.Range(1, Rng);
        switch(type)
        {
            case 1:
                SpawnPoint= gameObject.transform; // get pos from Enemy here 
                Power_Up PowerUp_Script = PowerUp_Prefab.GetComponent<Power_Up>();
                PowerUp_Script.Constructor(1);
                Instantiate(PowerUp_Prefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);
                SpawnAlg_Script.Resest_RngCounter_Powerups();

                break;
            default:
                //More if elses (Random.Range(1,Rng)==x) where x is the type of powerup
                SpawnAlg_Script.Decrement_RngCounter_Powerups();
                break;
        }
        
    }
}
