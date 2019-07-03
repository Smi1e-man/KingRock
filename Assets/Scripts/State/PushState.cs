﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Interface;

public class PushState : MonoBehaviour, IState
{
	private Transform _transform;
	private Transform _enemy;
	private Shooter _owner;
    private PullState _nextState;
    private int _speed;
    private float _distance;
    [SerializeField] bool _click;

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
        if(_click)
        {
            PushEnemy();
            Debug.Log("Push");
            _enemy = null;
            _click = false;
            _owner.ChangeState(_nextState);
        }
        else if (_enemy)
        {
            Debug.Log("Move Enemy");
            MoveEnemy();
            ClickMouse();
        }
    }


    private void ClickMouse()
    {
        if (Input.GetMouseButton(0))
        {
            _click = true;
        }
    }

    public void MoveEnemy()
	{
		_enemy.position = Vector3.MoveTowards(_enemy.position, _transform.TransformDirection(Vector3.forward * _distance), _speed * Time.deltaTime);
	}

    private void PushEnemy()
    {
        Rigidbody rb = _enemy.GetComponent<Rigidbody>();
        _enemy.parent = null;
        // Добавить код для push enemy
        _enemy.GetComponent<MoverEnemy>().PushEnemy();
    }

}
