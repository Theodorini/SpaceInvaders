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
                    //increase number of bullets
                    target.GetComponent<GunPlayer>().Increment_NrBullets();
                    break;
                case 1:
                    //regen HP by 25%
                    target.GetComponent<SpaceShip>().IncreaseHP();
                    break;
                case 2:
                    //increase bullet damage
                    target.GetComponent<GunPlayer>().IncreaseDamage();
                    break;
                case 3:
                    //Max bullets timmed
                    target.GetComponent<GunPlayer>().MaxBullets();
                    break;
                case 4:
                    //Shield
                    if(target.GetComponent<SpaceShip>().Get_ShieldRunning() == false)
                       target.GetComponent<SpaceShip>().StartShield_Coroutine();
                    break;
                case 5:
                    //Bomb
                    target.GetComponent<SpaceShip>().Start_bomb_Coroutine();
                    break;
                case 6:
                    if (target.GetComponent<SpaceShip>().Get_PhaseOut_running() == false)
                        target.GetComponent<SpaceShip>().Start_PhaseOut_Coroutine();
                    break;
                case 7:
                    if (target.GetComponent<SpaceShip>().Get_SlowTime_running() == false)
                        target.GetComponent<SpaceShip>().Start_TimeSlow_Coroutine();
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
