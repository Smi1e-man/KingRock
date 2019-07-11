using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    //[SerializeField] Slider     _slider;
    [SerializeField] Text       _textScore;
    [SerializeField] Text       _textLVL;
    [SerializeField] Image      _imageLVL;


    // Start is called before the first frame update
    void Start()
    {
        //_slider.maxValue = GameManager.g_maxValueScore;
        _textLVL.text = "LeVeL " + GameManager.g_level;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.g_ScoreView)
            _imageLVL.fillAmount = GameManager.g_Score / GameManager.g_maxValueScore;
        //_slider.value = GameManager.g_Score;
        _textScore.text = GameManager.g_Score.ToString();
        if (GameManager.g_Active)
            _textLVL.text = "Level " + GameManager.g_level;

        //level up
        if (GameManager.g_Score >= GameManager.g_maxValueScore)
        {
            GameManager.g_oldScore = GameManager.g_Score;

            GameManager.g_level += 1;
            GameManager.g_oldlevel = GameManager.g_level;

            Debug.Log("OldLEVEL = " + GameManager.g_oldlevel);

            GameManager.g_ScoreView = false;
            //увеличение необходимого скора для прохождения лвл
            GameManager.g_maxValueScore += GameManager.g_level * 1000;
        }

        if (GameManager.g_Active)
        {
            Debug.Log("LEVEL UP2");

            GameManager.g_heightArena += 4f;
            //GameManager.g_oldheightArena = GameManager.g_heightArena;

            //_slider.maxValue = GameManager.g_maxValueScore;

            GameManager.g_Active = false;
        }
    }
}
