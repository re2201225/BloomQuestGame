using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour, Item
{

    public static event Action<int> OnSunCollect;
    public int worth = 7;


    public void Collect()
    {
        OnSunCollect.Invoke(worth);

        Destroy(gameObject); 

    }

     
}