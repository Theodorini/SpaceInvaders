using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float speed = 5;
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Rb.velocity = (transform.up * -1) * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpaceShip target = collision.GetComponent<SpaceShip>();
        if (target != null)
        {
            target.TakeDamage(10);
            Destroy(gameObject);
        }
        if (collision.GetComponent<Border>() != null)
        {
            Destroy(gameObject);
        }
    }
}
