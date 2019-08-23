using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clicker : MonoBehaviour
{

    bool push = false;

    // Start is called before the first frame update
    RaycastHit hit;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Click");
            //Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
            {
                Debug.Log("Ray");
                push = true;
                //hit.transform.position = Vector3.MoveTowards(hit.transform.position, transform.position, 50f * Time.deltaTime);
                //hit.transform.position = Vector3.Lerp(hit.transform.position, transform.position, 10f);
            }
            else
            {
                push = false;
            }
        }
        if (push)
        {
            hit.transform.parent.gameObject.transform.position = Vector3.MoveTowards(hit.transform.parent.gameObject.transform.position, transform.position, 25f * Time.deltaTime);
            if (hit.transform.parent.gameObject.transform.position == transform.position)
            {
                //Debug.Log("WORK");
                hit.transform.parent.gameObject.transform.RotateAround(Vector3.zero, Vector3.up, 7f);
            }
        }

    }
}
