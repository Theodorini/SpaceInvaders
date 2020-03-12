using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public int maxHp = 100;
    public int HP=100;
    public float moveSpeed =25;
    public HpBar hpBar;
    public GameObject Shield;
    public GameObject Bomb;
    private bool Shield_running = false;
    private bool Bomb_running = false;

    private void Start()
    {
        Shield.SetActive(false);
        Bomb.SetActive(false);
    }
    private void Update()
    {
        MoveShip();
      
        
    }

    private void MoveShip()
    {
        if (Input.touchCount > 0)
        {
            // The screen has been touched so store the touch
            Touch touch = Input.GetTouch(0);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y, 10));
            if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touchPosition.y>Screen.height/10)
            {
                // If the finger is on the screen, move the object smoothly to the touch position
                touchPosition.z = 0f;
                transform.position = Vector3.Lerp(transform.position, touchPosition, Time.deltaTime * moveSpeed);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy target = collision.GetComponent<Enemy>();
        if ((target != null)&&(Bomb_running==false))
        {
            TakeDamage(target.getDamageOnHit());
            Destroy(collision.gameObject);
            gameObject.GetComponent<GunPlayer>().DecreaseBullets();
        }
        //Here we check what Power_Up we hit and apply it's effects
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            hpBar.SetBar(0f, maxHp);
            Destroy(gameObject);
        }
        else
        {
            hpBar.SetBar(HP, maxHp);
        }
    }
    public void IncreaseHP()
    {
        //increase HP with a quarter of maxHP
        if (HP + maxHp / 4 > maxHp)
            HP = maxHp;
        else
            HP += maxHp / 4;
        hpBar.SetBar(HP, maxHp);
    }
    public IEnumerator StartShield()
    {
        
        Shield_running = true;
     
        Debug.Log("Am intrat");
        Shield.SetActive(true);
       
        yield return new WaitForSecondsRealtime(5f);
        Debug.Log("Am iesit");
        Shield_running = false;
        Shield.SetActive(false);

    }
    public void StartShield_Coroutine()
    {

        StartCoroutine(StartShield());

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
        Bomb_running = false;
    }

    public bool Get_ShieldRunning()
    {
        return Shield_running;
    }
    public void Set_BombStatus(bool n)
    {
        Bomb_running = n;
    }
    public bool Get_BombStatus()
    {
        return Bomb_running;
    }
}
