using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power_Up : MonoBehaviour
{
    private int Type=1;
    public int Get_Type ()
    {
        return Type;
    }
    // Called in PowerupSpawner to set the spawn type for the newly created object;
    public void Constructor(int type)
    {
        Type = type;
      
    }
}
