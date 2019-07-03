﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class PullState : MonoBehaviour, IState
{
	private Transform _enemy;
	private Transform _transform;
	private Shooter _owner;
    private PushState _nextState;
    private int _speed;
    private float _distance;
    private bool _done;
    private bool _active;

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
    }

    public void UpdateState()
    {
        if (!Input.GetMouseButton(0))
            _active = true;
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

    private void ClickMouse()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(_transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                _enemy = hit.transform.parent.transform;
                _enemy.parent = _transform;
                _enemy.GetComponent<MoverEnemy>().MoveOff(); //new code
            }
        }
	}
    IEnumerator Reload()
    {
        yield return new WaitForSeconds(1);
        _active = true;

    }
    public void MoveEnemy()
    {
        _enemy.position = Vector3.MoveTowards(_enemy.position, _transform.TransformDirection(Vector3.forward * _distance), _speed * Time.deltaTime);
        if (_transform.TransformDirection(Vector3.forward * _distance) == _enemy.position)
            _done = true;
    }
}