using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eggCrackController : MonoBehaviour
{
    [SerializeField] private int maxCutStrokes = 1;
    [SerializeField] private GameObject cuttedPrefab;
    private int currentCutStrokes;

    private void Start()
    {
        currentCutStrokes = maxCutStrokes;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("Stove") && !other.gameObject.CompareTag("floor")) return;
        var offset = new Vector3(0, 0.02f, 0);
        Destroy(gameObject);
        var transform1 = transform;
        Instantiate(cuttedPrefab, transform1.position + offset, transform1.rotation);

    }
    
}
