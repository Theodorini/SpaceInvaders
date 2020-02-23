using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int onHit;
    private int HP;

    public void Constructor(int HP, int moveSelect, int speed)
    {
        this.HP = HP;
        onHit = (int)(HP * 0.1);
        switch(moveSelect)
        {
            case 1:
                gameObject.AddComponent<DownMovement>();
                gameObject.GetComponent<DownMovement>().SetSpeed(speed);
            break;



            default:
                break;
        }
    }
    
    public void TakeDamage(int demage)
    {
        HP -= demage;
        Debug.Log(HP);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

   
}
