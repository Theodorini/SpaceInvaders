using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private int damage = 20; 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy target = collision.GetComponent<Enemy>();
        BulletEnemy target2 = collision.GetComponent<BulletEnemy>();
        if (target != null)
        {
            target.TakeDamage(damage);
            
          
        }
        else if (target2 != null)
        {
            Destroy(collision.gameObject);
        }

        //Here we check what Power_Up we hit and apply it's effects
    }
}
