using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public void Spawn(int MoveType, int HP, int Speed)
    {
        Enemy obj = Object.Instantiate(EnemyPrefab, gameObject.transform.position, gameObject.transform.rotation).GetComponent<Enemy>();
        obj.Constructor(HP, MoveType, Speed);
    }
}
