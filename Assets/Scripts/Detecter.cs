using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        transform.parent.gameObject.GetComponent<MoverEnemy>().MoveOff();
        transform.parent.gameObject.GetComponent<MoverEnemy>().CollOff();

        for (int i = 0; i < transform.root.childCount; i++)
        {
            Transform child = transform.root.GetChild(i);
            child.gameObject.GetComponent<Detecter>().GravityOn();
        }
    }

    public void GravityOn()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
