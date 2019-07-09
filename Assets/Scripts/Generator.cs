using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //protected
    [SerializeField] List<GameObject> _enemies;
    [SerializeField] List<GameObject> _spawnPlaces;
     
    [SerializeField] float _deltaTimeSpawn = 1f;

    //private
    float   _nextTime;

    GameObject  _pref;

    Vector3 _direction;
    Quaternion _lookRotate;

    int _index = 0;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy(RandEnemy(), RandSpawnPlace());
        _nextTime = Time.time + _deltaTimeSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > _nextTime)
        {
            SpawnEnemy(RandEnemy(), RandSpawnPlace());

            _nextTime = Time.time + _deltaTimeSpawn;
        }
    }

    void    SpawnEnemy(GameObject enemy, GameObject spawnPlace)
    {
        _pref = Instantiate(enemy, spawnPlace.transform.position, Quaternion.identity);
        _direction = (GameManager.g_targetLookRotation - _pref.transform.position).normalized;
        _lookRotate = Quaternion.LookRotation(_direction);

        _pref.transform.rotation = _lookRotate;

    }

    GameObject  RandSpawnPlace()
    {
        float _i;
        for (_i = Random.Range(0f, _spawnPlaces.Count); _index == (int)_i; _i = Random.Range(0f, _spawnPlaces.Count))
        {
            ;
        }
        _index = (int)_i;
        return (_spawnPlaces[_index]);
    }

    GameObject   RandEnemy()
    {
        return (_enemies[(int)Random.Range(0f, _enemies.Count)]);

    }

}
