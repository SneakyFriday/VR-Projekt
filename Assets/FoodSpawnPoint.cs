using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FoodSpawnPoint : MonoBehaviour
{
    public GameObject spawnedObject;
    public Transform spawnPosition;
    public float spawnDelay = 2f;
    public Animator animator;
    
    [SerializeField] private Image refillImage;
    private int _availableItemsCount;
    private bool itemAvailable;
    private int maxItemsAvailable = 10;
    private List<Collider> registeredColliders = new();
    private static readonly int SpawnBeamActive = Animator.StringToHash("spawnBeamActive");

    private void Start()
    {
        _availableItemsCount = 0;
        if(refillImage != null) refillImage.fillAmount = 1;
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
        refillImage.fillAmount -= 0.1f;
        animator.SetTrigger(SpawnBeamActive);
        Instantiate(spawnedObject, spawnPosition.position, Quaternion.identity);
        itemAvailable = true;
    }

    public void RefillItems()
    {
        _availableItemsCount += 1;
        refillImage.fillAmount = _availableItemsCount / 100;
        print("Refilled Items at Kitchen: " + _availableItemsCount);
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