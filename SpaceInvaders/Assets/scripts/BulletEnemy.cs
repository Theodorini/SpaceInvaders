using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float speed;
    public int damage;
    private void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Rb.velocity = (transform.up * -1) * speed;
    }
    public void Constructor(float bulletSpeed, int damage)
    {
        this.damage = damage;
        speed = bulletSpeed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SpaceShip target = collision.GetComponent<SpaceShip>();
        if ((target != null)&&(target.Get_PhaseOut_running()==false))
        {
            target.TakeDamage(damage);
            Destroy(gameObject);
        }
       
    }
}
