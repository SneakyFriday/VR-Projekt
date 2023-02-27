using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI vrScoreTxt;
    //private int _currentScore;
    //private int _burgerScore = 100;

    private void Start()
    {
        //_currentScore = 0;
        currentScoreTxt.text = "Score: 0";
        vrScoreTxt.text = "Score: 0";
    }

    // public void SetScore()
    // {
    //     print("Player Scores!");
    //     _currentScore += _burgerScore;
    //     print(_currentScore);
    //     currentScoreTxt.text = "Score: " + _currentScore;
    // }
}
