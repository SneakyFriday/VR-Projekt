using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    
    [Header("Länge der Schichten (Sec.)")]
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
    [Header("Schichtende Text")]
    [SerializeField] private TextMeshProUGUI shiftIsOver;
    [Header("Aktuelle Schichtanzeige")]
    [SerializeField] private TextMeshProUGUI currentShift;
    
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
        DisplayShift();
    }

    private void SetTime()
    {
        _currentTimeValue = _maxTimeValue;
    }

    private void DisplayTime(float timeToDisplay, float timeForFill)
    {
        if (timeToDisplay < 0)
        {
            shiftIsOver.gameObject.SetActive(true);
            timeToDisplay = 0;
        }

        float minute = Mathf.FloorToInt(timeToDisplay / 60);
        float second = Mathf.FloorToInt(timeToDisplay % 60);
        timeForFill = Mathf.FloorToInt(timeForFill);
        
        timeText.text = $"{minute:00}:{second:00}";
        fillImage.fillAmount = _maxFillAmount * timeForFill;
    }

    private void DisplayShift()
    {
        if (fillImage.fillAmount < morningShiftImage.fillAmount)
        {
            currentShift.text = "Morning Shift";
        }
        else if (fillImage.fillAmount > morningShiftImage.fillAmount && fillImage.fillAmount < middayShiftImage.fillAmount)
        {
            currentShift.text = "Midday Shift";
        }
        else if (fillImage.fillAmount > middayShiftImage.fillAmount && fillImage.fillAmount < eveningShiftImage.fillAmount)
        {
            currentShift.text = "Evening Shift";
        }
    }
}
