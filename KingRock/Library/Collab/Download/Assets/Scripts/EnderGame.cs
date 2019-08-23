using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnderGame : MonoBehaviour
{
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _generator;
    [SerializeField] Text _textCompleted;
    [SerializeField] Image _imageScore;

    bool _restart = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_restart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _restart = false;
                GameManager.g_Game = true;

                _panel.SetActive(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("END");
        if (other.gameObject.GetComponent<MeshRenderer>().material.color.a > 0.9f)
        {
            GameManager.g_heightArena = 4.2f;
            GameManager.g_deltaDistMoveEnemy = 0f;
            GameManager.g_deltaDistPushEnemy = 0f;

            GameManager.g_Score = GameManager.g_oldScore;

            GameManager.g_level = GameManager.g_oldlevel;

            GameManager.g_Game = false;

            GameManager.g_activeScore = false;

            _generator.SetActive(false);
            _panel.SetActive(true);

            _textCompleted.text = ((int)(_imageScore.fillAmount * 100)).ToString() + "% COMPLETED";
            _restart = true;

        }
    }
}
