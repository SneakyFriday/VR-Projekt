using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawnPoint : MonoBehaviour
{
    public GameObject spawnedObject;
    public Transform spawnPosition;
    public float spawnDelay = 2f;

    private bool itemAvailable;
    private List<Collider> registeredColliders = new();

    private void Start()
    {
        Instantiate(spawnedObject, spawnPosition.position + new Vector3(0,0.05f,0), Quaternion.identity);
        itemAvailable = true;
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

    private void OnCollisionExit(Collision other)
    {
        print("Collision exit");

        if (other.gameObject.CompareTag(spawnedObject.tag))
        {
            if (registeredColliders.Contains(other.gameObject.GetComponent<Collider>()))
            {
                return;
            }
            registeredColliders.Add(other.gameObject.GetComponent<Collider>());
            itemAvailable = false;
            print("Item taken: " + other.gameObject.name);
        }
    }
}