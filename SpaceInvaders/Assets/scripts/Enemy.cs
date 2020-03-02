using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int onHit;
    private int maxHp;
    private HpBar hpBar;
    private int HP;

    public void Constructor(int HP, int moveSelect, int speed, float RTF,float bulletSpeed, int damage)
    {
        this.HP = HP;
        this.maxHp = HP;
        this.hpBar = gameObject.transform.GetChild(1).GetComponent<HpBar>();
        onHit = (int)(HP * 0.1);
        gameObject.GetComponent<Gun>().ConstructorBulletEnemy(RTF, bulletSpeed, damage);
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
        if (HP <= 0)
            return;
        HP -= demage;

        if (HP <= 0)
        {
            hpBar.SetBar(0f, maxHp);
            PowerupSpawner PowerupSpawner_Instance = gameObject.GetComponent<PowerupSpawner>();
            PowerupSpawner_Instance.Spawn();
            Destroy(gameObject);
        }
        else
            hpBar.SetBar(HP, maxHp);
    }
    public int getDamageOnHit()
    {
        return onHit;
    }
   
}
