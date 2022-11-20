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
            if (currentCutStrokes > 0) currentCutStrokes--;
            else
            {
                var offset = new Vector3(0, 0.2f, 0);
                Destroy(gameObject, 0.1f);
                Instantiate(cuttedPrefab, transform.position + offset, transform.rotation);
            }
        }
        
    }
}
