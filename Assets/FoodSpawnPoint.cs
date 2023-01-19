using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnPoint : MonoBehaviour
{
    public GameObject spawnedObject;
    public Transform spawnPosition;
    public float spawnDelay = 2f;

    private bool itemAvailable = true;

    private void Start()
    {
        Instantiate(spawnedObject, spawnPosition.position, Quaternion.identity);
    }

    void Update()
    {
        if (!itemAvailable)
        {
            StartCoroutine(SpawnItem());
        }
    }

    IEnumerator SpawnItem()
    {
        itemAvailable = true;
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(spawnedObject, spawnPosition.position, Quaternion.identity);
        itemAvailable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag(spawnedObject.tag))
        {
            OnItemTaken();
        }
    }

    public void OnItemTaken()
    {
        itemAvailable = false;
    }
}