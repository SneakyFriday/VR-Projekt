using UnityEngine;
using TMPro;
using System.Collections;

public class deathAnimation : MonoBehaviour
{
    public GameObject[] bodyParts; // Array der Körperteile
    public float explosionForce = 100f; // Kraft der Explosion
    public float explosionRadius = 10f; // Radius der Explosion

    public void Start()
    {
        DeathAnimation();
    }
    public void DeathAnimation()
    {
        foreach (GameObject bodyPart in bodyParts)
        {
            GameObject newBodyPart = Instantiate(bodyPart, transform.position, Quaternion.identity);
            Rigidbody rigidbody = newBodyPart.AddComponent<Rigidbody>();

                // Füge eine zufällige Kraft hinzu, um die Körperteile zu "poppen"
                Vector3 explosionDirection = Random.insideUnitSphere * explosionForce + new Vector3 (0, 1, 0);
                rigidbody.AddForce(explosionDirection);
        }

        // Findet alle Körperteile im Radius der Explosion und fügt ihnen Kraft hinzu
        foreach (GameObject bodyPart in GameObject.FindGameObjectsWithTag("BodyPart"))
        {
            if (Vector3.Distance(transform.position, bodyPart.transform.position) < explosionRadius)
            {
                Rigidbody rigidbody = bodyPart.GetComponent<Rigidbody>();

                if (rigidbody != null)
                {
                    Vector3 explosionDirection = (bodyPart.transform.position - transform.position).normalized * explosionForce;
                    rigidbody.AddForce(explosionDirection);
                }
            }
        }

    }
}

