using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public float shootingSpeed;
    public GameObject bulletPrefab;
    private Transform FirePoint;

    public int NrBullets;
    public int BulletDamage = 10;

    private IEnumerator BulletDamageBuff=null;

    private IEnumerator MaxBulletsIenumerator=null;
    private int ActualBullets;
    private void Shoot()
    {
        if (NrBullets % 2 == 0)
        {
            for (int i = 1; i <= NrBullets / 2; i++)
            {
                GameObject bullet1 = Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, i * 2 - 0.75f)));
                bullet1.GetComponent<Bullet>().SetDamage(BulletDamage);
                GameObject bullet2 = Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, -(i * 2 - 0.75f))));
                bullet2.GetComponent<Bullet>().SetDamage(BulletDamage);
            }
        }
        else
        {
            for (int i = 1; i <= NrBullets / 2; i++)
            {
               GameObject bullet1 = Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, i * 2)));
                bullet1.GetComponent<Bullet>().SetDamage(BulletDamage);
                GameObject bullet2 = Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, -i * 2 )));
                bullet2.GetComponent<Bullet>().SetDamage(BulletDamage);
            }
            GameObject bullet = Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            bullet.GetComponent<Bullet>().SetDamage(BulletDamage);
        }

    }
    
    private void Start()
    {
        FirePoint = gameObject.transform.GetChild(0).GetComponent<Transform>();
        bulletPrefab.GetComponent<Bullet>().SetDamage(BulletDamage);
        InvokeRepeating("Shoot", 1f, shootingSpeed);//rate of fire = shootingSpeend (delay between shots) 
    }
    //Currently used in SpaceShip to increase number of bullets
    public void Increment_NrBullets()
    {
        if(NrBullets<10)
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
