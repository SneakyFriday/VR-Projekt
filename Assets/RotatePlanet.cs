using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    [SerializeField] private float rotateSpeed = 50f; // Drehgeschwindigkeit

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f); // Rotiere um Y-Achse
    }
}