using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public int HP=100;
    public float moveSpeed =25;

    private void Update()
    {
        MoveShip();
      
        
    }

    private void MoveShip()
    {
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
                touchPosition.z = 0f;
                transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * moveSpeed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy target = collision.GetComponent<Enemy>();
        if (target != null)
        {
            HP -= target.getDamageOnHit();
            Destroy(collision.gameObject);
            Debug.Log("taget destroyed");
        }
        //Here we check what Power_Up we hit and apply it's effects
        else
        {
            Power_Up target_power_up = collision.GetComponent<Power_Up>();
            if (target_power_up != null)
            {
                if (target_power_up.Get_Type() == 1)
                {
                    GunPlayer gun_powerup_instance = gameObject.GetComponent<GunPlayer>();
                    gun_powerup_instance.Increment_NrBullets();
                    Destroy(collision.gameObject);
                    Debug.Log("Well done comrade, you got that power_up");
                }
            }

        }
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
