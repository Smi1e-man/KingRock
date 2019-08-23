using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerSector : MonoBehaviour
{
    //private visual values
    [SerializeField]
    private PullState _pullState = null;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void OnTriggerStay(Collider other)
    {
        if (other)
        {
            _pullState.OnStay(other);
        }
    }
}
