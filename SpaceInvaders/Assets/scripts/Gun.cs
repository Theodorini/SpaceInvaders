using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform FirePoint;
    public float shootingSpeed;
    public GameObject bulletPrefab;
    void Start()
    {
        InvokeRepeating("Shoot", 0.1f, shootingSpeed);
    }
    
    private void Shoot()
    {
        Instantiate(bulletPrefab, FirePoint.position, FirePoint.rotation);
    }
}
