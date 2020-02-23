using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float speed = 5;
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy target = collision.GetComponent<Enemy>();
        if(target!=null)
        {
            target.TakeDamage(10);
            Destroy(gameObject);
        }
        if(collision.GetComponent<Border>()!=null)
        {
            Destroy(gameObject);
        }
    }
}
