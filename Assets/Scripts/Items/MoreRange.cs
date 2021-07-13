using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MoreRange : MonoBehaviour, IHitable
{
    public static Action AddBombRange;
    public void OnHit()
    {
        AddBombRange?.Invoke();
        Destroy(gameObject);
    }
}
