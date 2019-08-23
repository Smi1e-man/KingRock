using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUp : MonoBehaviour
{
    //private visual values
    [SerializeField]
    private Gradient _gradient = null;
    [SerializeField]
    private GameObject _place = null;
    [SerializeField]
    private GameObject _generator = null;
    [SerializeField]
    private GameObject _spawnPlaces = null;
    [SerializeField]
    private GameObject _targetLookRotation = null;

    //private values
    private GameObject _pref;
    private GameObject _oldPref;

    private Vector3 _deltaScale = new Vector3(2f, 2f, 2f);
    private Vector3 _deltaScaleClean = new Vector3(1f, 1f, 0f);

    private float _distCheak = 1.5f;
    private float _scaleCheak = 100f;
    private float _heightCheak = 4f;

    private Vector3 _spawnDelta = new Vector3(0f, 0f, 0f);

    private Vector3 _ndist = new Vector3(0f, 1.5f, 0f);
    private Vector3 _ndist2 = new Vector3(0f, 4f, 0f);
    private Vector3 _ndistClean = new Vector3(0f, -100f, 0f);

    private int _backLevel;

    private bool _active = true;
    private bool _spawnActive = true;

    private float _oldScore;
    private float _i;
    private float _colorIndex = 0f;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _pref = SpawnPLace();
        _pref.GetComponent<MeshRenderer>().material.color = Color.white;
        _pref.transform.localScale = new Vector3(20f, 20f, 20f);
        _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
        _oldPref = _pref;

        _generator.SetActive(false);

        _backLevel = GameManager.g_level;
    }

    private void Update()
    {
        //after start new level - clean & change values
        if (_backLevel < GameManager.g_level)
        {
            if (_spawnActive)
            {
                _spawnActive = false;
                GameManager.g_activeScore = false;
                //generator OFF
                _generator.SetActive(false);
                //clean
                _spawnDelta += new Vector3(0f, 4f, 0f);
                _pref = SpawnPLace();
                _pref.transform.localScale = new Vector3(20f, 20f, 20f);
                _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
                _pref.GetComponent<MeshRenderer>().material.color = Color.green;
            }
            if (_pref.transform.localScale.x < (_scaleCheak + 20f))
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
                    //change values
                    _ndist += new Vector3(0f, 5f, 0f);
                    _ndist2 += new Vector3(0f, 4f, 0f);

                    _heightCheak += 4f;
                    _distCheak += 4f;

                    GameManager.g_deltaDistMoveEnemy += 4f;

                    _pref = SpawnPLace();
                    _pref.transform.localScale = new Vector3(20f, 20f, 20f);
                    _pref.transform.localEulerAngles = new Vector3(-90f, 0f, 0f);
                    _pref.GetComponent<MeshRenderer>().material.color = Color.white;

                    _oldPref.GetComponent<MeshRenderer>().material.color = _gradient.Evaluate(_colorIndex);
                    if (_colorIndex + 0.05f >= 1)
                        _colorIndex = 0f;
                    else
                        _colorIndex += 0.05f;
                    _oldPref = _pref;

                    _backLevel = GameManager.g_level;

                    GameManager.g_ScoreView = true;
                    GameManager.g_Active = true;
                    _spawnActive = true;
                    _active = true;
                }
            }

        }

        //new place
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
                    //start new level(start enemies)
                    _active = false;
                    GameManager.g_targetLookRotation = _targetLookRotation.transform.position;
                    _spawnPlaces.transform.position += new Vector3(0f, 3f, 0f);
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

    private GameObject SpawnPLace()
    {
        return (Instantiate(_place, _spawnDelta, Quaternion.identity));
    }
}
