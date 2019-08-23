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

    int _index = 0; //last pos
    int _index2 = 0; //last last pos
    int _index3 = 0; //last last last pos
    int _index4 = 0; //last last last pos
    int _index5 = 0; //last last last pos


    int _indexA = 1; //+1 от позиции
    int _indexB = 15; //-1 от позиции

    int _oldLevel = 0;

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
        if (GameManager.g_level % 10 == 0 && GameManager.g_level != _oldLevel)
        {
            _oldLevel = GameManager.g_level;
            _deltaTimeSpawn -= 0.05f;
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

        for (_i = Random.Range(0f, _spawnPlaces.Count); _index == (int)_i || _index2 == (int)_i || _index3 == (int)_i || _index4 == (int)_i || _index5 == (int)_i || _indexA == (int)_i || _indexB == (int)_i; _i = Random.Range(0f, _spawnPlaces.Count))
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

    GameObject   RandEnemy()
    {
        return (_enemies[(int)Random.Range(0f, _enemies.Count)]);

    }

}
