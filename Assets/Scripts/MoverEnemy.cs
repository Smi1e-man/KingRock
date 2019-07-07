using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Interface;

public class MoverEnemy : MonoBehaviour
{
    //protected
    [SerializeField] List<GameObject> _objects;

    [SerializeField] GameObject _target;

    [SerializeField] float _speedMoveCentre = 1f;
    [SerializeField] float _pushImpulse = 1f;

    //private
    float _speedMoveUp = 40f;
    bool _moveCentre = false;
    bool _moveUp = true;
    bool _coll = true;

    Vector3 _direction;
    Quaternion _lookRotate;

    // Start is called before the first frame update
    void Start()
    {
        //_direction = (Vector3.zero - transform.position).normalized;
        //_lookRotate = Quaternion.LookRotation(_direction);

        //transform.rotation = _lookRotate;


    }

    // Update is called once per frame
    void Update()
    {
        if (_moveCentre)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, _speedMoveCentre * Time.deltaTime);
        }
        if (_moveUp)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z), _speedMoveUp * Time.deltaTime);
        }

        if (transform.position.y >= 0.5f && _moveUp)
        {
            Debug.Log("UP");
            _moveUp = false;
            _direction = (Vector3.zero - transform.position).normalized;
            _lookRotate = Quaternion.LookRotation(_direction);

            transform.rotation = _lookRotate;
            _moveCentre = true;
        }
    }

    public void MoveOn()
    {
        _moveCentre = true;
    }

    public void     MoveOff()
    {
        _moveCentre = false;
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
            obj.GetComponent<Rigidbody>().AddForce(_target.transform.position * _pushImpulse, ForceMode.Impulse);
        }
    }
}
