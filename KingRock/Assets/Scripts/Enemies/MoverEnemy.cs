using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Interface;

public class MoverEnemy : MonoBehaviour
{
    //private visual values
    [SerializeField]
    private List<GameObject> _objects = null;
    [SerializeField]
    private GameObject _target = null;
    [SerializeField]
    private float _speedMoveCentre = 1f;
    [SerializeField]
    private float _pushImpulse = 1f;

    //private values
    private float _speedMoveUp = 10f;
    private bool _moveCentre = false;
    private bool _moveUp = true;
    private bool _coll = true;

    private Vector3 _direction;
    private Quaternion _lookRotate;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Update()
    {
        if (GameManager.g_Game)
        {
            if (_moveCentre)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    GameManager.g_targetLookRotation, _speedMoveCentre * Time.deltaTime);
            }
            if (_moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position,
                    new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z),
                    _speedMoveUp * Time.deltaTime);
            }

            if (transform.position.y >= GameManager.g_heightArena && _moveUp)
            {
                _moveUp = false;
                _direction = (GameManager.g_targetLookRotation - transform.position).normalized;
                _lookRotate = Quaternion.LookRotation(_direction);

                transform.rotation = _lookRotate;
                _moveCentre = true;
            }

        }
    }

    /// <summary>
    /// Public Methods.
    /// </summary>
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
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(_target.transform.position.x,
                0.1f + GameManager.g_deltaDistPushEnemy, _target.transform.position.z) * _pushImpulse,
                ForceMode.Impulse);
            if (obj.GetComponent<Detecter>())
                obj.GetComponent<Detecter>().DellEnemy();
        }
    }
}
