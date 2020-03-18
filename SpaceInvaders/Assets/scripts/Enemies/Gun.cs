using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shootingSpeed;
    public GameObject bulletPrefab;
    private Transform FirePoint;

    private void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);

    }
    public void ConstructorBulletEnemy(float RTF, float bulletSpeed, int damage)
    {
        if(bulletPrefab.GetComponent<BulletEnemy>()!=null)
        {
            shootingSpeed = RTF;
            bulletPrefab.GetComponent<BulletEnemy>().Constructor(bulletSpeed, damage);
            startShoot();
        }
    }
    
    private void startShoot()
    {
        FirePoint = gameObject.transform.GetChild(0).GetComponent<Transform>();
        InvokeRepeating("Shoot", 1f, shootingSpeed);//rate of fire = shootingSpeend (delay between shots) 
    }
    
}
