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
    float _speedMoveUp = 10f;
    bool _moveCentre = false;
    bool _moveUp = true;
    bool _coll = true;

    Vector3 _direction;
    Quaternion _lookRotate;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.g_Game)
        {
            if (_moveCentre)
            {
                transform.position = Vector3.MoveTowards(transform.position, GameManager.g_targetLookRotation, _speedMoveCentre * Time.deltaTime);
            }
            if (_moveUp)
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, transform.position.y + 100f, transform.position.z), _speedMoveUp * Time.deltaTime);
                //Debug.Log("POS = " + transform.position.y);
            }

            if (transform.position.y >= GameManager.g_heightArena && _moveUp)
            {
                //Debug.Log("UP");
                _moveUp = false;
                _direction = (GameManager.g_targetLookRotation - transform.position).normalized;
                _lookRotate = Quaternion.LookRotation(_direction);

                transform.rotation = _lookRotate;
                _moveCentre = true;
            }

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
            obj.GetComponent<Rigidbody>().AddForce(new Vector3(_target.transform.position.x, 0.1f + GameManager.g_deltaDistPushEnemy, _target.transform.position.z) * _pushImpulse, ForceMode.Impulse);
            if (obj.GetComponent<Detecter>())
                obj.GetComponent<Detecter>().DellEnemy();
        }
    }
}
