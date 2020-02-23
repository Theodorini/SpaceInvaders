using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public Rigidbody2D Rb;
    void Start()
    {
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
