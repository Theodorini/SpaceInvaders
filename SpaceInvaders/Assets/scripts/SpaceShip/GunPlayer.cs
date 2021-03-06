﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public float shootingSpeed;
    public float GrenadeShootingSpeed;
    public GameObject[] bulletPrefab;
    public GameObject Grenade_Prefab;
    public int NrBullets;
    public int MaxNumberOfBullets;
    public int BulletDamage = 10;

    private Transform FirePoint;
    private int Projectile_Type = 1;
    private IEnumerator BulletDamageBuff;
    private IEnumerator MaxBulletsIenumerator;
    private int ActualBullets;

    public void Constructor(float shootingSpeed, float grenadeShootingSpeed,int NrBullets, int MaxNumberOfBullets, int BulletDamage, int Projectile_Type)
    {
        this.shootingSpeed = shootingSpeed;
        this.GrenadeShootingSpeed = grenadeShootingSpeed;
        this.NrBullets = NrBullets;
        this.MaxNumberOfBullets = MaxNumberOfBullets;
        this.BulletDamage = BulletDamage;
        this.Projectile_Type = Projectile_Type;
        BulletDamageBuff = null;
        MaxBulletsIenumerator = null;
    }

    private void Shoot()
    {
        if (NrBullets % 2 == 0)
        {
            for (int i = 1; i <= NrBullets / 2; i++)
            {
                GameObject bullet1 = Instantiate(bulletPrefab[Projectile_Type], FirePoint.position, Quaternion.Euler(new Vector3(0, 0, i * 2 - 0.75f)));
                if (bullet1.GetComponent<Bullet>())
                    bullet1.GetComponent<Bullet>().SetDamage(BulletDamage);
                else if (bullet1.GetComponent<Laser>())
                    bullet1.GetComponent<Laser>().SetDamage(BulletDamage);
                GameObject bullet2 = Instantiate(bulletPrefab[Projectile_Type], FirePoint.position, Quaternion.Euler(new Vector3(0, 0, -(i * 2 - 0.75f))));
                if (bullet2.GetComponent<Bullet>())
                    bullet2.GetComponent<Bullet>().SetDamage(BulletDamage);
                else if (bullet2.GetComponent<Laser>())
                    bullet2.GetComponent<Laser>().SetDamage(BulletDamage);
            }
        }
        else
        {
            for (int i = 1; i <= NrBullets / 2; i++)
            {
               GameObject bullet1 = Instantiate(bulletPrefab[Projectile_Type], FirePoint.position, Quaternion.Euler(new Vector3(0, 0, i * 2)));

                if (bullet1.GetComponent<Bullet>())
                    bullet1.GetComponent<Bullet>().SetDamage(BulletDamage);
                else if (bullet1.GetComponent<Laser>())
                    bullet1.GetComponent<Laser>().SetDamage(BulletDamage);

                GameObject bullet2 = Instantiate(bulletPrefab[Projectile_Type], FirePoint.position, Quaternion.Euler(new Vector3(0, 0, -i * 2 )));

                if (bullet2.GetComponent<Bullet>())
                    bullet2.GetComponent<Bullet>().SetDamage(BulletDamage);
                else if (bullet2.GetComponent<Laser>())
                    bullet2.GetComponent<Laser>().SetDamage(BulletDamage);
            }
            GameObject bullet = Instantiate(bulletPrefab[Projectile_Type], FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            if(bullet.GetComponent<Bullet>())
            bullet.GetComponent<Bullet>().SetDamage(BulletDamage);
            else if (bullet.GetComponent<Laser>())
                bullet.GetComponent<Laser>().SetDamage(BulletDamage);

        }
        
    }
    
    private void Start()
    {
        FirePoint = gameObject.transform.GetChild(0).GetComponent<Transform>();
        //For now we set the damage at the start of the program this might change later
       if(bulletPrefab[Projectile_Type].GetComponent<Bullet>())
        bulletPrefab[Projectile_Type].GetComponent<Bullet>().SetDamage(BulletDamage);
       else if (bulletPrefab[Projectile_Type].GetComponent<Laser>())
            bulletPrefab[Projectile_Type].GetComponent<Laser>().SetDamage(BulletDamage);

        InvokeRepeating("Shoot", 1f, shootingSpeed);//rate of fire = shootingSpeed (delay between shots) 
        InvokeRepeating("Shoot_Grenade", 5f, GrenadeShootingSpeed);
    }
    //Currently used in SpaceShip to increase number of bullets
    public void Increment_NrBullets()
    {
        if(NrBullets<MaxNumberOfBullets)
            NrBullets++;
    }
    public void DecreaseBullets()
    {
        NrBullets -= NrBullets / 2;
        //delete one half of bullets
    }
    public void IncreaseDamage()
    {
        if(BulletDamageBuff!=null)
        {
            StopCoroutine(BulletDamageBuff);
            BulletDamage -= (int)BulletDamage/5;
        }
        BulletDamageBuff = IncreaseDamageCorutine();
        StartCoroutine(BulletDamageBuff);
    }

    private  IEnumerator IncreaseDamageCorutine()
    {
        int value = BulletDamage / 4;
        BulletDamage += value;
         yield return new WaitForSecondsRealtime(5f);
        BulletDamage -= value;
        BulletDamageBuff = null;
    }

    public void MaxBullets()
    {
        if(MaxBulletsIenumerator!=null)
        {
            StopCoroutine(MaxBulletsIenumerator);
            NrBullets = ActualBullets;
        }
        MaxBulletsIenumerator = MaxBulletsCorutine();
        StartCoroutine(MaxBulletsIenumerator);
    }
    private IEnumerator MaxBulletsCorutine()
    {
        ActualBullets = NrBullets;
        NrBullets = 12;
        yield return new WaitForSecondsRealtime(5f);
        MaxBulletsIenumerator = null;
        NrBullets = ActualBullets;
    }
    public void Shoot_Grenade()
    {
        GameObject Grenade = Instantiate(Grenade_Prefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }
}
/*
 * Strait fire
 * for(int i=1;i<=NrBullets/2;i++)
        {
            Instantiate(bulletPrefab, FirePoint.position+(new Vector3(i*2,0,0)), Quaternion.Euler(new Vector3(0, 0, 0)));
            Instantiate(bulletPrefab, FirePoint.position+(new Vector3(-(i*2),0,0)), Quaternion.Euler(new Vector3(0, 0, 0)));
        }
        if(NrBullets%2!=0)
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));



    ///Angular fire
    for(int i=1;i<=NrBullets/2;i++)
        {
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0,0, i)));
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0,0, -i)));
        }
        if(NrBullets%2!=0)
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
 */
