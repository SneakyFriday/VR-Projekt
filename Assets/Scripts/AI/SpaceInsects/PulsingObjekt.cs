using UnityEngine;

public class PulsingObjekt : MonoBehaviour
{
    public float pulseSpeed = 1.0f;
    public float minScale = 0.5f;
    public float maxScale = 1.5f;

    private Vector3 initialScale;
    private float t = 0.0f;
    private bool isPulsingUp = true;

    private void Start()
    {
        initialScale = transform.localScale;
    }

    private void Update()
    {
        // Berechne den aktuellen Skalierungsfaktor
        float scale = Mathf.Lerp(minScale, maxScale, t);

        // Skaliere das Objekt
        transform.localScale = initialScale * scale;

        // Erhöhe oder verringere t entsprechend der Pulsing-Rate
        if (isPulsingUp)
        {
            t += Time.deltaTime * pulseSpeed;
            if (t > 1.0f)
            {
                t = 1.0f;
                isPulsingUp = false;
            }
        }
        else
        {
            t -= Time.deltaTime * pulseSpeed;
            if (t < 0.0f)
            {
                t = 0.0f;
                isPulsingUp = true;
            }
        }
    }
}