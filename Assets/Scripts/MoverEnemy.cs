using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Interface;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject> _objects;

    [SerializeField] GameObject _target;

    [SerializeField] float _speed = 1f;

    bool _move = true;
    bool _coll = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speed * Time.deltaTime);
        }
    }

    public void     MoveOff()
    {
        //Debug.Log("OFF");
        _move = false;
    }

    public void     CollOff()
    {
        _coll = false;
    }

    public bool     GetColl()
    {
        return _coll;
    }

    public void     PushEnemy()
    {
        foreach(GameObject obj in _objects)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().AddForce(_target.transform.position * 1f, ForceMode.Impulse);
        }
    }
}
