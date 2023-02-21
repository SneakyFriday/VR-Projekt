using UnityEngine;

public class randomMover : MonoBehaviour
{
    public float moveRadius = 2f; // Der Radius, in dem das Objekt zufällig bewegt werden soll
    public float moveSpeed = 2f; // Die Geschwindigkeit, mit der sich das Objekt bewegen soll

    private Vector3 startingPosition; // Die Startposition des Objekts
    private Vector3 targetPosition; // Die Zielposition des Objekts
    private bool movingToTarget = false; // Gibt an, ob sich das Objekt gerade zur Zielposition bewegt
    public bool isFalling;
    public float fallgeschwindingkeit = 10f;

    private void Start()
    {
        startingPosition = new Vector3 (transform.position.x, 0.1f, transform.position.z);
        targetPosition = GetRandomPosition();
        isFalling = true;
    }

    private void Update()
    {
        if (isFalling ){
            transform.Translate(Vector3.down * Time.deltaTime * fallgeschwindingkeit);
        }
        if (transform.position.y <= 0.1f){
            isFalling = false;
        }

        if (!movingToTarget)
        {
            // Wenn sich das Objekt nicht zur Zielposition bewegt, wähle eine neue zufällige Position aus
            targetPosition = GetRandomPosition();
            movingToTarget = true;
        }

        // Berechne die Richtung zur Zielposition
        Vector3 moveDirection = targetPosition - transform.position;
        moveDirection.y = 0;

        // Wenn das Objekt nicht schon an der Zielposition ist, drehe es in die Richtung der Zielposition
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), 10f * Time.deltaTime);
        }

        // Begrenze die Bewegung auf den definierten Radius um den Startpunkt
        Vector3 newPosition = transform.position + moveDirection.normalized * moveSpeed * Time.deltaTime;
        if (Vector3.Distance(startingPosition, newPosition) <= moveRadius)
        {
            transform.position = newPosition;
        }

        // Wenn das Objekt die Zielposition erreicht hat, setze movingToTarget auf false
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToTarget = false;
        }
    }

    // Hilfsmethode, um eine zufällige Position innerhalb des Bewegungsradius zu wählen
    private Vector3 GetRandomPosition()
    {
        Vector2 randomDirection = Random.insideUnitCircle * moveRadius;
        return startingPosition + new Vector3(randomDirection.x, 0, randomDirection.y);
    }
}
