using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] PullState _pullState;

    private void OnTriggerStay(Collider other)
    {
        //Debug.Log("STAY");
        if (other)
        {
            _pullState.OnStay(other);
        }
        //if (GameManager.g_MoveIn && )
    }
}
