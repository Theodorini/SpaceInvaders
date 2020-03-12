using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{

    public Sprite[] PowerUpSprites;
    public int Type = 0;
    public float ReloadSpeed=1;
    public SpaceShip PlayerSpaceShip;
    private float LoadingPercentage=0;
    private Image LoadingBar;
    private Image Center;
    

    private void Start()
    {
        LoadingBar = gameObject.transform.GetChild(0).GetComponent<Image>();
        if (LoadingBar == null)
            Debug.LogError("No image on PowerButton");
        LoadingBar.fillAmount = LoadingPercentage / 100;
        Center = gameObject.transform.GetChild(1).GetComponent<Image>();
        Center.sprite = PowerUpSprites[Type]; 
    }
    void Update()
    {
        if(LoadingPercentage<100)
        {

            LoadingPercentage += ReloadSpeed * Time.deltaTime;
            LoadingBar.fillAmount = LoadingPercentage / 100;
        }

    }
    public void OnCLick()
    {
        if (LoadingPercentage >= 100)
        {
            //Call power-up
            switch (Type)
            {
                case 0:
                    //increase number of bullets
                    PlayerSpaceShip.gameObject.GetComponent<GunPlayer>().Increment_NrBullets();
                    break;
                case 1:
                    //regen HP by 25%
                   PlayerSpaceShip.IncreaseHP();
                    break;
                case 2:
                    //increase bullet damage
                    PlayerSpaceShip.gameObject.GetComponent<GunPlayer>().IncreaseDamage();
                    break;
                case 3:
                    //Max bullets timmed
                    PlayerSpaceShip.gameObject.GetComponent<GunPlayer>().MaxBullets();
                    break;

                default:
                    Debug.Break();
                    break;
            }


            LoadingPercentage = 0;
        }
    }
}

