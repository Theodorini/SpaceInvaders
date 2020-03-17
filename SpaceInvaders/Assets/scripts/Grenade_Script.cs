using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Script : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float speed = 5;
    private bool Bomb_running = false;
    private int damage;
    public GameObject Bomb;
    void Start()
    {
        Rb = gameObject.GetComponent<Rigidbody2D>();
        Rb.velocity = transform.up * speed;
        
        

    }
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy target = collision.GetComponent<Enemy>();
        if (target != null)
        {
            Start_bomb_Coroutine();
        }


    }
    public int GetDamage()
    {
        return damage;
    }
    public void SetDamage(int value)
    {

        damage = value;
    }
    public void Start_bomb_Coroutine()
    {
        StartCoroutine(Start_bomb());
    }
    public IEnumerator Start_bomb()
    {

        Bomb_running = true;
        Bomb.SetActive(true);
        yield return new WaitForSecondsRealtime(0.2f);

        Bomb.SetActive(false);
        Destroy(gameObject);
        Bomb_running = false;
    }
}
