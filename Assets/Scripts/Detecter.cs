using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{

    private bool _active = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (_active)
        {
            _active = false;
            transform.parent.gameObject.GetComponent<MoverEnemy>().MoveOff();
            transform.parent.gameObject.GetComponent<MoverEnemy>().CollOff();

            for (int i = 0; i < transform.root.childCount; i++)
            {
                if (transform.root.GetChild(i) != null)
                {
                    Transform child = transform.root.GetChild(i);
                    if (child.GetComponent<Detecter>())
                        child.gameObject.GetComponent<Detecter>().GravityOn();
                }
            }
        }
    }

    public void GravityOn()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
