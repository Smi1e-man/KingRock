using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamera : MonoBehaviour
{
    //private visual values
    [SerializeField]
    private GameObject _player = null;

    //private values
    private Vector3 _offset;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    private void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
