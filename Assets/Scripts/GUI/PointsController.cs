using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    //private int _currentScore;
    //private int _burgerScore = 100;

    private void Start()
    {
        //_currentScore = 0;
        currentScoreTxt.text = "Score: 0";
    }

    // public void SetScore()
    // {
    //     print("Player Scores!");
    //     _currentScore += _burgerScore;
    //     print(_currentScore);
    //     currentScoreTxt.text = "Score: " + _currentScore;
    // }
}
