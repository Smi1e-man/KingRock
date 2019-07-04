using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoverEnemy : MonoBehaviour
{
    [SerializeField] List<GameObject> _objects;

    [SerializeField] GameObject _target;

    bool _move = true;

    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject obj in _objects)
        {
            Detecter.OnHit += MoveOff;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_move)
        {
            transform.position = Vector3.MoveTowards(transform.position, Vector3.zero, 0.8f * Time.deltaTime);
        }
    }

    /// <summary>
    /// useGravity!!!!!!!!!!!!!
    /// </summary>
    /// <param name="other">Other.</param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("COLL");
        MoveOff();
        foreach (GameObject obj in _objects)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public void     MoveOff()
    {
        Debug.Log("OFF");
        _move = false;
    }

    public void     PushEnemy()
    {
        foreach(GameObject obj in _objects)
        {
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().AddForce(_target.transform.position * 1f, ForceMode.Impulse);
        }
    }
}
