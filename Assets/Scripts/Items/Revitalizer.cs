using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revitalizer : MonoBehaviour, IHitable
{

    public void OnHit()
    {
        LevelManager.Get().OneLiveUp();
        Destroy(gameObject);
    }
}
