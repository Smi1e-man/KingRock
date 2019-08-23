using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class Shooter : MonoBehaviour
{
    //private visual values
    [SerializeField] private PullState _pullState = null;
    [SerializeField] private PushState _pushState = null;
    [SerializeField, Range(0,360)] private int _rotateSpeed = 0;
    [SerializeField, Range(0,100)] private int _pullSpeed = 0;
    [SerializeField, Range(0,100)] private int _pushSpeed = 0;
    [SerializeField, Range(1f, 10f)] private float _distance = 0f;

    //private values
    private Transform _transform;
    private IState _state;

    private Vector3 _axisRotate = Vector3.up;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _pullState.InitState(_pullSpeed, _distance, this, _pushState);
        _pushState.InitState(_pushSpeed, _distance, this, _pullState);
        _state = _pullState;
        _transform = transform;
    }


    private void Update()
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

    /// <summary>
    /// Public Methods.
    /// </summary>
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
