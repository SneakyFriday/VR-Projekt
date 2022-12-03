using System;
using TMPro;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    [SerializeField] private float maxTimeValue;
    [SerializeField]private TextMeshProUGUI timeText;
    private float _currentTimeValue;
    private bool timerOn;


    private void Start()
    {
        SetTime();
    }

    void Update()
    {
        if (_currentTimeValue > 0)
        {
            _currentTimeValue -= Time.deltaTime;
        }
        else
        {
            _currentTimeValue = 0;
        }
        
        DisplayTime(_currentTimeValue);
    }

    public void SetTime()
    {
        _currentTimeValue = maxTimeValue;
    }

    public void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);
        Vector2 time = new Vector2(minute, second);
        timeText.text = $"{minute:00}:{second:00}";
    }
}
