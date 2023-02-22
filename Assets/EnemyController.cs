using UnityEngine;
using TMPro;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public int pointsToDisplay;
    public float displayTime;
    public float fadeTime;
    public float subtractTime;
    public GameObject AddPointsText;

    private bool hasBeenDestroyed = false;

    public void Start()
    {
        InvokeRepeating("SubtractPoints", subtractTime, subtractTime);
    }

    // Hier werden die Punkte angezeigt. Es wird ein kleiner Animationseffekt hinzugefügt.
    private IEnumerator DisplayPoints()
    {
        if (pointsToDisplay < 3)
        {
            pointsText.text = "-" + Mathf.Abs(pointsToDisplay).ToString() + " points";
            pointsText.color = Color.red;
        }
        else
        {
            pointsText.text = "+" + pointsToDisplay.ToString() + " points";
            pointsText.color = Color.green;
        }

    pointsText.transform.position = transform.position + Vector3.up * 1f;
    pointsText.CrossFadeAlpha(1f, fadeTime, false);

    // Berechnung für den Fade out Effekt und die Position des Textes.
    float elapsedTime = 0f;
    while (elapsedTime < displayTime && pointsText.canvasRenderer.GetAlpha() > 0)
    {
        elapsedTime += Time.deltaTime;

        // Bestimmt die Position des Textes
        Vector3 newPosition = pointsText.transform.position;
        newPosition += Vector3.up * Time.deltaTime * 0.3f;
        pointsText.transform.position = newPosition;

        yield return null;
    }

    // Der Fade out Effekt wird ausgeführt.
    pointsText.CrossFadeAlpha(0f, fadeTime, false);
    yield break;
}

    // Zieht eine Punktezahl nach einer gewissen Zeit ab.
    public void SubtractPoints()
    {
        pointsToDisplay = -2;
        StartCoroutine(DisplayPoints());
    }

    // Vergibt einmalig eine gesetzte Punktzahl
    public void AddPoints()
    {
        if (!hasBeenDestroyed)
        {

            Instantiate(AddPointsText, transform.position, Quaternion.identity);
            hasBeenDestroyed = true;
            Destroy(gameObject);
        }
    }

    // Sobald der Spieler den Gegner berührt, wird die Punktzahl vergeben und der Gegner zerstört.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("PlayerContainer"))
        {
            AddPoints();
        }
    }
}