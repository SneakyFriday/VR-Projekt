using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    
    [Header("Länge der Schichten")]
    [SerializeField] private int morningShiftLength;
    [SerializeField] private int middayShiftLength;
    [SerializeField] private int eveningShiftLength;
    [Header("Anzeigebilder")]
    [SerializeField] private Image morningShiftImage;
    [SerializeField] private Image middayShiftImage;
    [SerializeField] private Image eveningShiftImage;
    [SerializeField] private Image fillImage;
    [Header("Analoge Anzeige")]
    [SerializeField] private TextMeshProUGUI timeText;
    
    private float _currentTimeValue;
    private float _timeForFill;
    private bool _timerOn;
    private float _maxTimeValue;
    private float _maxFillAmount;


    private void Start()
    {
        _maxTimeValue = morningShiftLength + middayShiftLength + eveningShiftLength;

        _maxFillAmount = 1 / _maxTimeValue;
        
        morningShiftImage.fillAmount = _maxFillAmount * morningShiftLength;
        middayShiftImage.fillAmount = _maxFillAmount * (middayShiftLength + morningShiftLength);
        eveningShiftImage.fillAmount = _maxFillAmount * (morningShiftLength + eveningShiftLength + middayShiftLength);

        SetTime();
        
    }

    void Update()
    {
        if (_currentTimeValue > 0)
        {
            _currentTimeValue -= Time.deltaTime;
            _timeForFill += Time.deltaTime;
        }
        else
        {
            _currentTimeValue = 0;
        }
        
        DisplayTime(_currentTimeValue, _timeForFill);
    }

    private void SetTime()
    {
        _currentTimeValue = _maxTimeValue;
    }

    private void DisplayTime(float timeToDisplay, float timeForFill)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);
        timeForFill = Mathf.FloorToInt(timeForFill);
        
        timeText.text = $"{minute:00}:{second:00}";
        fillImage.fillAmount = _maxFillAmount * timeForFill;
        //print((timeForFill));
        //print(fillImage.fillAmount);
    }
}
