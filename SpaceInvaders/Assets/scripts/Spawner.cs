using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    /// <summary>
    /// Spawn Enemies at fixed point
    /// </summary>
    /// <param name="MoveType">type of enemy movememnt - used for if statements in emeny class to select movement script</param>
    /// <param name="HP">it's HP - in Enemy class</param>
    /// <param name="Speed">how fast the enemy moves - in movement class, set in Enemy class</param>
    /// <param name="RTF">Rate of Fire (time between each bullet) - in Gun class</param>
    /// <param name="bulletSpeed">the speed of a bullet - in BulletEnemy class</param>
    /// <param name="damage">how much damage a bullet does - in BulletEnemy class</param>
    public void Spawn(int MoveType, int HP, int Speed, float RTF,float bulletSpeed, int damage)
    {
        Enemy obj = Object.Instantiate(EnemyPrefab, gameObject.transform.position, gameObject.transform.rotation).GetComponent<Enemy>();
        obj.Constructor(HP, MoveType, Speed,RTF,bulletSpeed,damage);
    }
}
