using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{
    public delegate void HitEnter();
    public static event HitEnter OnHit;

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("COLL");
    //    if (OnHit != null)
    //    {
    //        OnHit();
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLL");
        if (OnHit != null)
        {
            OnHit();
        }
    }
}
