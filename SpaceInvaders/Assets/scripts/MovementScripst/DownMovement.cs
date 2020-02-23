using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMovement : MonoBehaviour
{
    private Rigidbody2D Rb;
    private float speed;

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Rb.velocity = (transform.up * -1) * speed;
    }
}
