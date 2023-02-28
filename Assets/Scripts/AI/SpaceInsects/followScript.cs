using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class followScript : MonoBehaviour
{
    public Transform target;
    public GameObject UI;

    private void Update()
    {
        // Setze die Position des Texts auf die Position des Targets (in diesem Fall der Gegner)
        UI.transform.position = target.position + Vector3.up * 1f;
    }
}