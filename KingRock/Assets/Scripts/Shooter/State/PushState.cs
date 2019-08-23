using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class PushState : MonoBehaviour, IState
{
    //private visual values
    [SerializeField] private bool _click;

    //private values
    private Transform _transform;
    private Transform _enemy;
    private Shooter _owner;
    private PullState _nextState;
    private int _speed;
    private float _distance;

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void InitState(int speed, float distance, Shooter shooter, IState state)
    {
        _speed = speed;
        _distance = distance;
		_owner = shooter;
		_nextState = (PullState)state;
		_transform = transform;
        _enemy = null;
    }

    public void SetEnemy(Transform enemy)
    {
        _enemy = enemy;
    }

    public void UpdateState()
    {
        if (_click)
        {
            PushEnemy();
            _enemy = null;
            _click = false;
            _owner.ChangeState(_nextState);
        }
        else if (_enemy && _enemy.GetChild(3).GetComponent<MeshRenderer>().material.color.a < 1f)
        {
            _enemy.parent = null;
            _enemy = null;
            _click = false;
            _owner.ChangeState(_nextState);
        }
        else if (_enemy)
        {
            MoveEnemy();
            ClickMouse();
        }
        else
            _owner.ChangeState(_nextState);

    }

    public void MoveEnemy()
    {
        _enemy.position = Vector3.MoveTowards(_enemy.position, 
            _transform.TransformDirection(new Vector3(0f, 4.5f + GameManager.g_deltaDistMoveEnemy, 1f * _distance)),
            _speed * Time.deltaTime);
    }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void ClickMouse()
    {
        if (Input.GetMouseButton(0))
        {
            _click = true;
        }
    }

    private void PushEnemy()
    {
        Rigidbody rb = _enemy.GetComponent<Rigidbody>();
        _enemy.parent = null;
        //push enemy
        _enemy.GetComponent<MoverEnemy>().PushEnemy();
        //change direction rotate
        _owner.GetComponent<Shooter>().ChangeAxisRotate();
    }
}
