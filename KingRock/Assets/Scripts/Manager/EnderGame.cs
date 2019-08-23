using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnderGame : MonoBehaviour
{
    //private visual values
    [SerializeField]
    private GameObject _panel = null;
    [SerializeField]
    private GameObject _generator = null;
    [SerializeField]
    private Text _textCompleted = null;
    [SerializeField]
    private Image _imageScore = null;

    //private values
    private bool _restart = false;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Update()
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
