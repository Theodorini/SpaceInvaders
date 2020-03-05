using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy target = collision.GetComponent<Enemy>();
        BulletEnemy target2 = collision.GetComponent<BulletEnemy>();
        if ((target != null)||(target2!=null))
        {
            
            Destroy(collision.gameObject);
          
        }
        //Here we check what Power_Up we hit and apply it's effects
    }
}
