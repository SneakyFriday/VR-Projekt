using TMPro;
using UnityEngine;

public class ShiftEndResume : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] servedValues;
    [SerializeField] private TextMeshProUGUI[] pointValues;
    [SerializeField] private TextMeshProUGUI pointsTierValue;
    [SerializeField] private GameObject endScreen;

    public void HandleTextValues(int s1c, int s2c, int s3c, int s1p, int s2p, int s3p)
    {
        servedValues[0].text = s1c.ToString();
        servedValues[1].text = s2c.ToString();
        servedValues[2].text = s3c.ToString();

        pointValues[0].text = s1p.ToString();
        pointValues[1].text = s2p.ToString();
        pointValues[2].text = s3p.ToString();

        int totalPoints = s1p + s2p + s3p;
        print("Total Points: " + totalPoints);

        if (totalPoints <= 500)
        {
            pointsTierValue.text = "B";
        }
        if (totalPoints < 500)
        {
            pointsTierValue.text = "A";
        }
        if (totalPoints >= 1500)
        {
            pointsTierValue.text = "S";
        }
    }

    public void ShowEndScreen()
    {
        Time.timeScale = 0;
        endScreen.SetActive(true);
    }
}
