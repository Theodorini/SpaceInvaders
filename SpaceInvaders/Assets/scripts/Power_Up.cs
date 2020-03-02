using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    private int Type;
    public int Get_Type ()
    {
        return Type;
    }
    // Called in PowerupSpawner to set the spawn type for the newly created object;
    public void Constructor(int type)
    {
        Type = type;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        SpaceShip target = collision.GetComponent<SpaceShip>();
        if(target!=null)
        {
            switch(Type)
            {
                case 0:
                    target.GetComponent<GunPlayer>().Increment_NrBullets();
                    break;
                case 1:
                    target.GetComponent<SpaceShip>().IncreaseHP();
                    break;
                default:
                    Debug.Break();
                    break;
            }
            Destroy(gameObject);
        }
    }
}
/*
 * else
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
 */
