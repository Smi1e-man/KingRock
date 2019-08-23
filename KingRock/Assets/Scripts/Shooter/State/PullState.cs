using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class PullState : MonoBehaviour, IState
{
    //private values
	private Transform _enemy;
	private Transform _transform;
	private Shooter _owner;
    private PushState _nextState;
    private int _speed;
    private float _distance;
    private bool _done;
    private bool _active;
    private bool _moveIn;

    /// <summary>
    /// Public Methods.
    /// </summary>
    public void InitState(int speed, float distance,Shooter shooter, IState state)
    {
        _speed = speed;
        _distance = distance;
		_owner = shooter;
        _nextState = (PushState)state;
        _transform = transform;
        _enemy = null;
        _done = false;
        _active = false;
        _moveIn = false;
    }

    public void UpdateState()
    {
        if (!Input.GetMouseButton(0))
        {
            _active = true;
            _moveIn = false;
        }
        if (_done)
        {
            _nextState.SetEnemy(_enemy);
            _enemy = null;
            _active = false;
            _done = false;
            _owner.ChangeState(_nextState);
        }
        else if (_enemy)
        {
            MoveEnemy();
        }
        else if (_active)
            ClickMouse();
    }

    public void OnStay(Collider other)
    {
        if (_moveIn && other)
        {
            _moveIn = false;
            _enemy = other.transform.parent.transform;
            _enemy.parent = _transform;
            _enemy.GetComponent<MoverEnemy>().MoveOff();

            if (_enemy.GetComponent<MoverEnemy>().GetColl() == false) //don't touch crushed object
            {
                _enemy.parent = null;
                _enemy = null;
            }
        }
    }

    public void MoveEnemy()
    {
        _enemy.position = Vector3.MoveTowards(_enemy.position,
            _transform.TransformDirection(new Vector3(0f, 4.5f + GameManager.g_deltaDistMoveEnemy, 1f * _distance)),
            _speed * Time.deltaTime);
        if (_transform.TransformDirection(new Vector3(0f, 4.5f + GameManager.g_deltaDistMoveEnemy, 1f * _distance)) == _enemy.position)
        {
            _done = true;
        }
    }

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void ClickMouse()
    {
        if (Input.GetMouseButton(0))
        {
            _moveIn = true;
        }
    }

    private IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        _active = true;
    }

}
