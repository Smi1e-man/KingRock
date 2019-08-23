using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameAnalyticsSDK;

public class GameManager : MonoBehaviour
{
    //public values
    static public float g_Score = 0;
    static public float g_oldScore = 0;
    static public float g_maxValueScore = 1000;

    static public int g_level = 1;
    static public int g_oldlevel = 1;

    static public float g_heightArena = 4.2f;

    static public Vector3 g_targetLookRotation = Vector3.zero;
    static public float g_deltaDistMoveEnemy = 0;
    static public float g_deltaDistPushEnemy = 0;

    static public bool g_activeScore = true;

    static public bool g_Active = false;

    static public bool g_ScoreView = true;

    static public bool g_Game = true;

    /// <summary>
    /// Private Methods.
    /// </summary>
    private void Start()
    {
        GameAnalytics.Initialize();
        Application.targetFrameRate = 60;
        g_level = PlayerPrefs.GetInt("lvl", 1);
        g_oldlevel = PlayerPrefs.GetInt("oldlvl", 1);
        g_Score = PlayerPrefs.GetFloat("score", 0.0f);
        g_oldScore = PlayerPrefs.GetFloat("oldscore", 0.0f);
        g_maxValueScore = PlayerPrefs.GetFloat("maxvalscore", 1000f);
        g_deltaDistPushEnemy = PlayerPrefs.GetFloat("delpushen", 0.0f);
    }

    private void Update()
    {
        PlayerPrefs.SetInt("lvl", g_level);
        PlayerPrefs.SetInt("oldlvl", g_oldlevel);
        PlayerPrefs.SetFloat("score", g_Score);
        PlayerPrefs.SetFloat("oldscore", g_oldScore);
        PlayerPrefs.SetFloat("maxvalscore", g_maxValueScore);
        PlayerPrefs.SetFloat("delpushen", g_deltaDistPushEnemy);
        Debug.Log(PlayerPrefs.GetInt("lvl"));
        PlayerPrefs.Save();
    }
}
