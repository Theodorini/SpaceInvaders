using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour
{
    public void SetBar(float HP, float maxHP)
    {
        
        gameObject.transform.GetChild(2).transform.localScale = new Vector3(HP/maxHP, 1f,1f);
    }

}
