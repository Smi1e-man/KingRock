using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void HitEnter();
    public static event HitEnter OnHit;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("DETECTED");
        if (OnHit != null)
        {
            OnHit();
        }
    }
}
