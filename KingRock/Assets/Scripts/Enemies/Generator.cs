using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    //private visual values
    [SerializeField] 
    private List<GameObject> _enemies = null;
    [SerializeField]
    private List<GameObject> _spawnPlaces = null;
    [SerializeField]
    private float _deltaTimeSpawn = 1f;

    //private values
    private float _nextTime;

    private GameObject _pref;

    private Vector3 _direction;
    private Quaternion _lookRotate;

    private int _index = 0; //last pos
    private int _index2 = 0; //last last pos
    private int _index3 = 0; //last last last pos
    private int _index4 = 0; //last last last last pos
    private int _index5 = 0; //last last last last last pos

    private int _indexA = 1; //+1 from position
    private int _indexB = 15; //-1 from position

    private int _oldLevel = 0;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        SpawnEnemy(RandEnemy(), RandSpawnPlace());
        _nextTime = Time.time + _deltaTimeSpawn;
    }

    private void Update()
    {
        if (Time.time > _nextTime)
        {
            SpawnEnemy(RandEnemy(), RandSpawnPlace());

            _nextTime = Time.time + _deltaTimeSpawn;
        }
        if (GameManager.g_level % 10 == 0 && GameManager.g_level != _oldLevel)
        {
            _oldLevel = GameManager.g_level;
            _deltaTimeSpawn -= 0.05f;
        }

    }

    private void SpawnEnemy(GameObject enemy, GameObject spawnPlace)
    {
        _pref = Instantiate(enemy, spawnPlace.transform.position, Quaternion.identity);
        _direction = (GameManager.g_targetLookRotation - _pref.transform.position).normalized;
        _lookRotate = Quaternion.LookRotation(_direction);

        _pref.transform.rotation = _lookRotate;

    }

    private GameObject RandSpawnPlace()
    {
        float _i;

        for (_i = Random.Range(0f, _spawnPlaces.Count);
            _index == (int)_i || _index2 == (int)_i || _index3 == (int)_i ||
            _index4 == (int)_i || _index5 == (int)_i || _indexA == (int)_i ||
            _indexB == (int)_i; _i = Random.Range(0f, _spawnPlaces.Count))
        {
            ;
        }
        _index5 = _index4;
        _index4 = _index3;
        _index3 = _index2;
        _index2 = _index;
        _index = (int)_i;

        _indexA = ((int)_i + 1) % 16;
        if ((int)_i == 0)
            _indexB = 15;
        else
            _indexB = (int)_i - 1;
        return (_spawnPlaces[_index]);
    }

    private GameObject RandEnemy()
    {
        return (_enemies[(int)Random.Range(0f, _enemies.Count)]);

    }

}
