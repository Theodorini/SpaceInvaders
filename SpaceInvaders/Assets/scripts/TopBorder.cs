using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopBorder : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Bullet>() != null|| collision.GetComponent<BulletEnemy>()!=null|| collision.GetComponent<Laser>() != null)
            Destroy(collision.gameObject);
    }
}
