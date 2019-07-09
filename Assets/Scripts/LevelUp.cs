using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    [SerializeField] GameObject _place;
    [SerializeField] GameObject _generator;
    [SerializeField] GameObject _spawnPlaces;
    [SerializeField] GameObject _targetLookRotation;

    GameObject _pref;
    Vector3 _deltaScale = new Vector3(2f, 2f, 2f);
    Vector3 _deltaScaleClean = new Vector3(2f, 2f, 0f);

    float _distCheak = 1.5f;
    float _scaleCheak = 100f;
    float _heightCheak = 4f;

    Vector3 _spawnDelta = new Vector3(0f, 0f, 0.02f);

    Vector3 _ndist = new Vector3(0f, 1.5f, 0f);
    Vector3 _ndist2 = new Vector3(0f, 4f, 0f);
    Vector3 _ndistClean = new Vector3(0f, -100f, 0f);

    int _backLevel;

    bool _active = true;

    // Start is called before the first frame update
    void Start()
    {
        _pref = SpawnPLace();
        _pref.transform.localScale = new Vector3(20f, 20f, 20f);
        _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

        _generator.SetActive(false);

        _backLevel = GameManager.g_level;
    }

    // Update is called once per frame
    void Update()
    {
        //перед запуском нового уровня - зачистка & переопределение переменных & 
        if (_backLevel < GameManager.g_level)
        {
            _generator.SetActive(false);
            //зачистка
            _pref = SpawnPLace();
            _pref.transform.localScale = new Vector3(20f, 20f, 20f);
            _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
            if (_pref.transform.localScale.x < (_scaleCheak + 5f))
            {
                _pref.transform.localScale += _deltaScaleClean;
            }
            else
            {
                if(_pref.transform.position.y > _spawnPlaces.transform.position.y)
                {
                    _pref.transform.position = Vector3.MoveTowards(_pref.transform.position, _ndistClean, 15f * Time.deltaTime);
                }
                else
                {
                    Destroy(_pref.gameObject);
                    //переопределение переменных
                    _spawnDelta += new Vector3(0f, 0f, 0.04f);
                    _ndist += new Vector3(0f, 3f, 0f);
                    _ndist2 += new Vector3(0f, 4f, 0f);

                    _pref = SpawnPLace();
                    _pref.transform.localScale = new Vector3(20f, 20f, 20f);
                    _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);

                    _active = true;
                }
            }

        }

        //появляется новая площадка
        if (_active)
        {
            if (transform.position.y < _heightCheak)
            {
                transform.position = Vector3.MoveTowards(transform.position, _ndist2, 8f * Time.deltaTime);
            }
            else
            {
                if (_pref.transform.position.y < _distCheak)
                {
                    _pref.transform.position = Vector3.MoveTowards(_pref.transform.position, _ndist, 2f * Time.deltaTime);
                }
                else
                {
                    //запуск нового уровня(противников)
                    _active = false;
                    GameManager.g_heightArena += 4f;
                    GameManager.g_targetLookRotation = _targetLookRotation.transform.position;
                    _generator.SetActive(true);
                }
                if (_pref.transform.localScale.z < _scaleCheak)
                {
                    _pref.transform.localScale += _deltaScale;
                }
            }
        }
    }

    GameObject    SpawnPLace()
    {
        return (Instantiate(_place, _spawnDelta, Quaternion.identity));
    }
}
