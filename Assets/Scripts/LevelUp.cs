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
    GameObject _oldPref;

    Vector3 _deltaScale = new Vector3(2f, 2f, 2f);
    Vector3 _deltaScaleClean = new Vector3(1f, 1f, 0f);

    float _distCheak = 1.5f;
    float _scaleCheak = 100f;
    float _heightCheak = 4f;

    Vector3 _spawnDelta = new Vector3(0f, 0f, 0f);

    Vector3 _ndist = new Vector3(0f, 1.5f, 0f);
    Vector3 _ndist2 = new Vector3(0f, 4f, 0f);
    Vector3 _ndistClean = new Vector3(0f, -100f, 0f);

    int _backLevel;

    bool _active = true;
    bool _spawnActive = true;

    float _oldScore;

    float _i;

    // Start is called before the first frame update
    void Start()
    {
        _pref = SpawnPLace();
        _pref.GetComponent<MeshRenderer>().material.color = Color.white;
        _pref.transform.localScale = new Vector3(20f, 20f, 20f);
        _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
        _oldPref = _pref;

        _generator.SetActive(false);

        _backLevel = GameManager.g_level;

        //_spawnDelta += new Vector3(0f, 4f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("LVL = " + GameManager.g_level);
        //перед запуском нового уровня - зачистка & переопределение переменных & 
        if (_backLevel < GameManager.g_level)
        {
            if (_spawnActive)
            {
                _spawnActive = false;
                GameManager.g_activeScore = false;
                //generator OFF
                _generator.SetActive(false);
                //зачистка
                _spawnDelta += new Vector3(0f, 4f, 0f);
                _pref = SpawnPLace();
                _pref.transform.localScale = new Vector3(20f, 20f, 20f);
                _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
                _pref.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            if (_pref.transform.localScale.x < (_scaleCheak + 20f))
            {
                //Debug.Log("LVL2" + _pref.transform.localScale);
                //Debug.Log(_spawnDelta);
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
                    //_spawnDelta += new Vector3(0f, 1.5f, 0f);
                    _ndist += new Vector3(0f, 5f, 0f);
                    _ndist2 += new Vector3(0f, 4f, 0f);

                    _heightCheak += 4f;
                    _distCheak += 4f;

                    GameManager.g_deltaDistMoveEnemy += 4f;
                    GameManager.g_deltaDistPushEnemy += 0.1f;

                    _pref = SpawnPLace();
                    _pref.transform.localScale = new Vector3(20f, 20f, 20f);
                    _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
                    _pref.GetComponent<MeshRenderer>().material.color = Color.white;

                    _oldPref.GetComponent<MeshRenderer>().material.color = RandColor();
                    _oldPref = _pref;

                    _backLevel = GameManager.g_level;
                    GameManager.g_Active = true;
                    _spawnActive = true;
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
                    //Debug.Log(_distCheak);
                    _pref.transform.position = Vector3.MoveTowards(_pref.transform.position, _ndist, 2f * Time.deltaTime);
                }
                else
                {
                    //запуск нового уровня(противников)
                    _active = false;
                    GameManager.g_targetLookRotation = _targetLookRotation.transform.position;
                    _generator.SetActive(true);
                    GameManager.g_activeScore = true;
                }
                if (_pref.transform.localScale.z < _scaleCheak)
                {
                    _pref.transform.localScale += _deltaScale;
                }
            }
        }
    }

    Color   RandColor()
    {
        _i = Random.Range(0f, 6f);
        if (_i < 1f)
            return (Color.blue);
        else if (_i < 2f)
            return (Color.cyan);
        else if (_i < 3f)
            return (Color.magenta);
        else if (_i < 4f)
            return (Color.yellow);
        else
            return (Color.red);
    }

    GameObject    SpawnPLace()
    {
        return (Instantiate(_place, _spawnDelta, Quaternion.identity));
    }
}
