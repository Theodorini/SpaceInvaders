using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Ships;
    public GameObject Button;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Play(int ShipType, int MaxHP, float MoveSpeed, float shootingSpeed, float grenadeShootingSpeed, int NrBullets, int MaxNumberOfBullets, int BulletDamage, int Projectile_Type)
    {
        GameObject ship = Instantiate(Ships[ShipType], new Vector3(0f,0f,0f),Quaternion.Euler(0f,0f,0f));
        ship.GetComponent<SpaceShip>().Constructor(MaxHP, MoveSpeed, shootingSpeed, grenadeShootingSpeed, NrBullets, MaxNumberOfBullets, BulletDamage, Projectile_Type);
        Button.GetComponent<PowerButton>().PlayerSpaceShip = ship.GetComponent<SpaceShip>();
    }
}
