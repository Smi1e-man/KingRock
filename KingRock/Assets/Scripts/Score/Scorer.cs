using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{
    //private visual values
    [SerializeField] 
    private Text _textScore = null;
    [SerializeField]
    private Text _textLVL = null;
    [SerializeField]
    private Image _imageLVL = null;


    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        _textLVL.text = "Level " + GameManager.g_level;
    }

    private void Update()
    {
        if (GameManager.g_ScoreView)
            _imageLVL.fillAmount = (GameManager.g_Score - GameManager.g_oldScore) /
                (GameManager.g_maxValueScore - GameManager.g_oldScore);
        _textScore.text = GameManager.g_Score.ToString();
        if (GameManager.g_Active)
            _textLVL.text = "Level " + GameManager.g_level;

        //level up
        if (GameManager.g_Score >= GameManager.g_maxValueScore)
        {
            GameManager.g_oldScore = GameManager.g_Score;

            GameManager.g_level += 1;
            GameManager.g_oldlevel = GameManager.g_level;

            GameManager.g_ScoreView = false;
            //add new need score for finish lvl
            GameManager.g_maxValueScore += GameManager.g_level * 300;
        }

        if (GameManager.g_Active)
        {
            GameManager.g_heightArena += 4f;
            GameManager.g_Active = false;
        }
    }
}
