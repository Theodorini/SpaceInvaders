using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float shootingSpeed;
    public GameObject bulletPrefab;
    private Transform FirePoint;
    void Start()
    {
        FirePoint = gameObject.GetComponentInChildren<Transform>();
        InvokeRepeating("Shoot", 0.1f, shootingSpeed);//rate of fire = shootingSpeend (delay between shots) 
    }
    
    private void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
