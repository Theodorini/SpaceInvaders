using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D Rb;
    void Start()
    {
        Rb.velocity = (transform.up * -1) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpaceShip target = collision.GetComponent<SpaceShip>();
        if (target != null)
        {
            target.TakeDamage(20);
            Destroy(gameObject);
        }
        if (collision.GetComponent<Border>() != null)
        {
            Destroy(gameObject);
        }
    }
}
