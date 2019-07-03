using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] GameObject _target;
    //[SerializeField] float _valImpulse = 10f;
    Rigidbody rb;
    bool _move = true;
    bool _move2 = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 1f * Time.deltaTime);
        }

        if (_move2)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, 15f * Time.deltaTime);
        }

        if (transform.position.x > 10 || transform.position.x < -10 ||
            transform.position.z > 10 || transform.position.z < -10 ||
            transform.position.y < -2)
        {
            _move = false;
            _move2 = false;
        }
    }

    public void     MoveOff()
    {
        _move = false;
    }

    public void     PushEnemy()
    {
        //rb.AddForce(Vector3.left * 150f);
        _move2 = true;
    }

}
