using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    public float ReloadSpeed=1;
    private float LoadingPercentage=0;
    private Image LoadingBar;
    private void Start()
    {
        LoadingBar = gameObject.transform.GetChild(0).GetComponent<Image>();
        if (LoadingBar == null)
            Debug.LogError("No image on PowerButton");
        LoadingBar.fillAmount = LoadingPercentage / 100;
    }
    void Update()
    {
        if(LoadingPercentage<100)
        {
            Debug.Log("Loading Percentage + " + LoadingPercentage);
            LoadingPercentage += ReloadSpeed * Time.deltaTime;
            LoadingBar.fillAmount = LoadingPercentage / 100;
        }

    }
    public void OnCLick()
    {
        if (LoadingPercentage == 100)
        {
            //Call power-up
        }
    }
}

