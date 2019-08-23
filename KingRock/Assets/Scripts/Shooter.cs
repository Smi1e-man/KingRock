using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class Shooter : MonoBehaviour
{

    [SerializeField] PullState _pullState;
    [SerializeField] PushState _pushState;
    [SerializeField, Range(0,360)] int _rotateSpeed;
    [SerializeField, Range(0,100)] int _pullSpeed;
    [SerializeField, Range(0,100)] int _pushSpeed;
    [SerializeField, Range(1f, 10f)] float _distance;

    private Transform _transform;
    private IState _state;

    Vector3 _axisRotate = Vector3.up;

    void Start()
    {
        _pullState.InitState(_pullSpeed, _distance, this, _pushState);
        _pushState.InitState(_pushSpeed, _distance, this, _pullState);
        _state = _pullState;
        _transform = transform;
    }


    void Update()
    {
        _state.UpdateState();
        if (GameManager.g_Game)
            Rotate();
    }

    private void Rotate()
    {
        Vector3 axis = _transform.position;
        _transform.RotateAround(axis, _axisRotate, _rotateSpeed * Time.deltaTime);
    }

    public void ChangeAxisRotate()
    {
        if (_axisRotate == Vector3.up)
        {
            _axisRotate = Vector3.down;
        }
        else
            _axisRotate = Vector3.up;
    }

    public void ChangeState(IState state)
    {
        _state = state;
    }
}
