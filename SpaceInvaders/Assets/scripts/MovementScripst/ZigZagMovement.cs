using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    public float angle = 1;



    private Rigidbody2D Rb;
    private float speed;
    private float SpriteWith;

    // Start is called before the first frame update
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        //Rb.velocity = (transform.up * -1) * speed;
        Rb.velocity = new Vector2(angle, -1) * speed;
        //
    }

    public void SetSpeed(int speed)
    {

        this.speed = speed;
    }

    public void SetSpriteWidth(float width)
    {
        this.SpriteWith = width;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = Camera.main.WorldToScreenPoint(Rb.transform.position);
        if (position.x + SpriteWith >= Screen.width)
        {
            Rb.velocity = new Vector2(-angle, -1) * speed;
        }
        else if (position.x - SpriteWith <= 0)
        {
            Rb.velocity = new Vector2(angle, -1) * speed;
        }
    }
}
