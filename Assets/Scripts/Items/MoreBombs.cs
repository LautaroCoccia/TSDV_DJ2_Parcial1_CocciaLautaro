using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MoreBombs : MonoBehaviour,IHitable
{
    public static Action AddBombs;
    public void OnHit()
    {
        AddBombs?.Invoke();
        Destroy(gameObject);
    }
}
