using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detecter : MonoBehaviour
{
    //protected
    [SerializeField] GameObject _placeParent;

    //private
    private bool _active = true;

    private float _timeStep = 0.2f;
    private float _nextTime = 1f;

    private float _deltaAlpha = 0.8f;

    //Update
    private void Update()
    {
        if (_active == false && _nextTime <= Time.time)
        {
            if (GetComponent<MeshRenderer>())
            {
                GetComponent<MeshRenderer>().material.color *= _deltaAlpha;
                if (GetComponent<MeshRenderer>().material.color.a < 0.1f)
                    Destroy(transform.parent.gameObject);
                //Debug.Log(GetComponent<MeshRenderer>().material.color.a);
            }
            _nextTime = Time.time + _timeStep;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.parent != transform.parent)
        {
            if (transform.parent.gameObject.GetComponent<MoverEnemy>().GetColl())
            {
                transform.parent.gameObject.GetComponent<MoverEnemy>().MoveOff();
                transform.parent.gameObject.GetComponent<MoverEnemy>().CollOff();

                for (int i = 0; i < transform.parent.childCount; i++)
                {
                    if (transform.parent.GetChild(i) != null)
                    {
                        Transform child = transform.parent.GetChild(i);
                        if (child.GetComponent<Detecter>())
                        {
                            Debug.Log("NO");
                            child.gameObject.GetComponent<Detecter>().GravityOn();
                            child.gameObject.GetComponent<Detecter>().DellEnemy();
                        }
                        else if (child.parent.GetComponent<Shooter>())
                        {
                            Debug.Log("123");
                        }
                    }
                }
            }
        }
    }

    public void DellEnemy()
    { 
        _active = false;
        _nextTime = Time.time + _timeStep;
    }

    public void GravityOn()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }
}
