using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSkill : MonoBehaviour
{

    [SerializeField] GameObject _block;
    [SerializeField] GameObject _target;

    bool _scale = false;

    Vector3 _scaleStap = new Vector3(6f, 3f, 0.5f);
    Vector3 _startPos;
    Vector3 _startScale;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = _block.transform.position;
        _startScale = _block.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //_block.GetComponent<Rigidbody>().AddForce(_target.transform.position * 3f, ForceMode.Impulse);
            _scale = true;
        }

        if (_scale)
        {
            if (_block.transform.localScale.x < 6.1f)
            {
                _block.transform.localScale += _scaleStap * Time.deltaTime;

            }
            if (_block.transform.position.z < 12f)
            {
                _block.transform.position = Vector3.MoveTowards(_block.transform.position, _target.transform.position, 15f * Time.deltaTime);
            }
            else
            {
                //Debug.Log("IMPULSE");
                _block.GetComponent<Rigidbody>().AddForce(_target.transform.position * 0.3f, ForceMode.Impulse);
                _scale = false;
                _block.transform.localScale = _startScale;
                _block.transform.position = _startPos;
            }

        }
    }
}
