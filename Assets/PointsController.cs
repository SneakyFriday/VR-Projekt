using System;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    private int _currentScore;
    private int _burgerScore = 100;

    private void Awake()
    {
        _currentScore = 0;
        currentScoreTxt.text = "Score: ";
    }

    public void SetScore()
    {
        print("Player Scores!");
        _currentScore += _burgerScore;
        currentScoreTxt.text = "Score: " + _currentScore;
        print(_currentScore);
    }
}
