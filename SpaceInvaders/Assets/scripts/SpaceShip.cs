using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public int maxHp = 100;
    public int HP=100;
    private float moveSpeed =25;
    public HpBar hpBar;
    public GameObject Shield;
    public GameObject Bomb;
   
    private bool Shield_running = false;
    private bool Bomb_running = false;
    private bool PhaseOut_running = false;
    private IEnumerator SlowTime_running = null;
    private IEnumerator PhaseOutCorutine=null;
    private IEnumerator ShieldCorutine=null;

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
            Vector3 BottomBorder = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 10));
            if ((touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) && touchPosition.y >-(BottomBorder.y - BottomBorder.y *0.4f))
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
        if ((target != null)&&(Bomb_running==false)&&(PhaseOut_running==false))
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
    // Coroutines for all timed functions and Start calls for them
    public IEnumerator StartShield()
    {
        
        Shield_running = true;
        Shield.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        Shield_running = false;
        Shield.SetActive(false);
        ShieldCorutine = null;

    }
    public void StartShield_Coroutine()
    {
        if(ShieldCorutine!=null)
        {
            StopCoroutine(ShieldCorutine);
        }
        ShieldCorutine = StartShield();
        StartCoroutine(ShieldCorutine);

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
    public void Start_PhaseOut_Coroutine()
    {
        if(PhaseOutCorutine!=null)
        {
            StopCoroutine(PhaseOutCorutine);

        }
        PhaseOutCorutine = Start_PhaseOut();
        StartCoroutine(PhaseOutCorutine);
    }
    public IEnumerator Start_PhaseOut()
    {
        
        PhaseOut_running = true;
        yield return new WaitForSecondsRealtime(5f);
        PhaseOutCorutine = null;
        PhaseOut_running = false;
       
    }
    public void Start_TimeSlow_Coroutine()
    {
        if(SlowTime_running!=null)
        {
            StopCoroutine(SlowTime_running);
            moveSpeed = moveSpeed / 2;
            Time.timeScale = 1f;
            SlowTime_running = null;
        }
        SlowTime_running = Start_TimeSlow();
        StartCoroutine(SlowTime_running);
    }
    public IEnumerator Start_TimeSlow()
    {
        Time.timeScale = 0.5f;
        moveSpeed = moveSpeed * 2;
         yield return new WaitForSecondsRealtime(10f);
        SlowTime_running = null;
        moveSpeed = moveSpeed / 2;
        Time.timeScale = 1f;
    }
    //Get Functions for all timed buffs
    public bool Get_ShieldRunning()
    {
        return Shield_running;
    }
    public bool Get_PhaseOut_running()
    {
        return PhaseOut_running;
    }
    public bool Get_BombStatus()
    {
        return Bomb_running;
    }
    
}
