using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPlayer : MonoBehaviour
{
    public float shootingSpeed;
    public GameObject bulletPrefab;
    private Transform FirePoint;
    public int NrBullets;
    private void Shoot()
    {
       
        for(int i=1;i<=NrBullets/2;i++)
        {
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0,0, i)));
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0,0, -i)));
        }
        if(NrBullets%2!=0)
            Instantiate(bulletPrefab, FirePoint.position, Quaternion.Euler(new Vector3(0, 0, 0)));

    }
    
    private void Start()
    {
        FirePoint = gameObject.transform.GetChild(0).GetComponent<Transform>();
        InvokeRepeating("Shoot", 1f, shootingSpeed);//rate of fire = shootingSpeend (delay between shots) 
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
