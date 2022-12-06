using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private PlayerInteraction playerInteraction;
    private int _score;

    private void Start()
    {
        _score = 0;
        currentScore.text = "Score: " + _score;
        playerInteraction.servedCustomerRight.AddListener(SetScore);
    }

    public void SetScore()
    {
        print("Player Scores!");
        _score += 100;
        currentScore.text = "Score: " + _score;
    }
}
