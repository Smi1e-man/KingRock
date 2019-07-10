using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public float g_Score = 0;
    static public float g_oldScore = 0;
    static public float g_maxValueScore = 1000;

    static public int g_level = 1;
    static public int g_oldlevel = 1;

    static public float g_heightArena = 4.2f;
    //static public float g_oldheightArena = 4.2f;

    static public Vector3 g_targetLookRotation = Vector3.zero;
    static public float g_deltaDistMoveEnemy = 0;
    static public float g_deltaDistPushEnemy = 0;

    static public bool g_activeScore = true;

    static public bool g_Active = false;

    //static public bool g_detected = true;
}
