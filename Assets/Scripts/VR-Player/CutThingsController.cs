using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutThingsController : MonoBehaviour
{
    [SerializeField] private int maxCutStrokes = 3;
    [SerializeField] private GameObject cuttedPrefab;
    private int currentCutStrokes;

    private void Start()
    {
        currentCutStrokes = maxCutStrokes;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Knife"))
        {
            if (currentCutStrokes > 1) currentCutStrokes--;
            else
            {
                var offset = new Vector3(0, 0.05f, 0);
                Destroy(gameObject);
                var transform1 = transform;
                Instantiate(cuttedPrefab, transform1.position + offset, transform1.rotation);
            }
        }
        
    }
}
