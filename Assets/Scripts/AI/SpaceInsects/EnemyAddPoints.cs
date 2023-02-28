using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAddPoints : MonoBehaviour
{
    public TextMeshProUGUI pointsText;
    public int pointsToDisplay;
    public float displayTime;
    public float fadeTime;

    private bool hasBeenDestroyed = false;

    public void Start()
    {
        AddPoints();
    }

    // Hier werden die Punkte angezeigt. Es wird ein kleiner Animationseffekt hinzugefügt.
    private IEnumerator DisplayPoints(int pointsToDisplay)
    {
            pointsText.text = "+" + pointsToDisplay.ToString() + " points";
            pointsText.color = Color.green;

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

    // Vergibt einmalig eine gesetzte Punktzahl
    public void AddPoints()
    {
        if (!hasBeenDestroyed)
        {
            pointsToDisplay = 10;
            StartCoroutine(DisplayPoints(pointsToDisplay));
            hasBeenDestroyed = true;
            Invoke("Destroy", 2f);
        }
    }

    public void Destroy ()
    {
        Destroy(gameObject);
    }
}
