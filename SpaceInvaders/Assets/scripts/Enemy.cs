using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int onHit;
    public int HP=100;

    private void Start()
    {
        onHit = (int)(HP * 0.1);
    }
    void Update()
    {

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
