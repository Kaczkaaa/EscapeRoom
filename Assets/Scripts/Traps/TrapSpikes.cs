using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapSpikes : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        IDamagable damagableobject = other.GetComponent<IDamagable>();
        if (damagableobject != null)
        {
            damagableobject.OnKill();
        }
    }
}
    

