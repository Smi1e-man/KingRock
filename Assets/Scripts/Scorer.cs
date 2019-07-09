using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scorer : MonoBehaviour
{

    [SerializeField] Slider     _slider;
    [SerializeField] Text       _textScore;
    [SerializeField] Text       _textLVL;

    float _maxValue = 5000;

    // Start is called before the first frame update
    void Start()
    {
        _slider.maxValue = _maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        _slider.value = GameManager.g_Score;
        _textScore.text = GameManager.g_Score.ToString();
        _textLVL.text = "LeVeL " + GameManager.g_level;

        //level up
        if (GameManager.g_Score >= _maxValue)
        {
            GameManager.g_level += 1;
            _maxValue += 10000;
            _slider.maxValue = _maxValue;
        }
    }
}
