using UnityEngine;

public class SinkAndDestroy : MonoBehaviour
{

    public float destroyHeight = -1f; // Höhe, bei der das Objekt zerstört wird
    public float colliderDisableDelay = 2f; // Verzögerung, bevor der Collider deaktiviert wird

    private Collider col;
    private float colliderDisableTimer;

    private void Start()
    {
        col = GetComponent<Collider>();
        colliderDisableTimer = Time.time + colliderDisableDelay;
    }

    private void Update()
    {
            // Deaktiviere den Collider nach einer Verzögerung
            if (Time.time > colliderDisableTimer)
            {
                col.enabled = false;
            }

        // Wenn das Objekt unter die Zerstörungshöhe fällt, zerstöre es
        if (transform.position.y < destroyHeight)
        {
            Destroy(gameObject);
        }
    }
}
