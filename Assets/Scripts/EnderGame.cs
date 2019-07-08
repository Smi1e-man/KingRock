using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnderGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("END");
        if (other.gameObject.GetComponent<MeshRenderer>().material.color.a > 0.9f)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
