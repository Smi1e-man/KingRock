using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //protected
    [SerializeField] List<GameObject> _enemies;

    [SerializeField] float _radiusSpawn = 10f;
    [SerializeField] float _heightSpawn = 0f;  
    [SerializeField] float _deltaTimeSpawn = 1f;

    [SerializeField] float _deltaAngleSpawn = 20f;

    //private
    float   _nextTime;

    float   _angle;
    float   _old_angle;

    GameObject  _pref;

    float   _x;
    float   _z;
    //Vector3 _direction;
    //Quaternion _lookRotate;


    // Start is called before the first frame update
    void Start()
    {
        _angle = Random.Range(0f, 360f);
        _old_angle = _angle;

        SpawnEnemy(_angle, RandEnemy());
        _nextTime = Time.time + _deltaTimeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextTime)
        {
			_angle = Random.Range(0f, 360f);
            if ((_angle > (_old_angle + _deltaAngleSpawn)) || (_angle < (_old_angle - _deltaAngleSpawn)))
            {
                SpawnEnemy(_angle, RandEnemy());
                _old_angle = _angle;
            }
            _nextTime = Time.time + _deltaTimeSpawn;
        }
    }

    void    SpawnEnemy(float angle, GameObject enemy)
    {
		_x = _radiusSpawn * Mathf.Cos(angle);
        _z = _radiusSpawn * Mathf.Sin(angle);

        _pref = Instantiate(enemy, new Vector3(_x, _heightSpawn, _z), Quaternion.Euler(-90f, 0f, 0f));
        //_direction = (Vector3.zero - _pref.transform.position).normalized;
        //_lookRotate = Quaternion.LookRotation(_direction);

        //_pref.transform.rotation = _lookRotate;

    }

    GameObject   RandEnemy()
    {
        return (_enemies[(int)Random.Range(0f, _enemies.Count)]);

    }

}
