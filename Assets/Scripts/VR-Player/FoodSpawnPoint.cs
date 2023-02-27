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

    private float _availableItemsCount;
    private bool itemAvailable;
    private float maxItemsAvailable = 10f;
    private List<Collider> registeredColliders = new();
    private static readonly int SpawnBeamActive = Animator.StringToHash("spawnBeamActive");
    private bool _isAnimatorNotNull;

    private void Start()
    {
        _isAnimatorNotNull = animator != null;
        _availableItemsCount = maxItemsAvailable;
        if(refillImage != null) refillImage.fillAmount = 1;
        Instantiate(spawnedObject, spawnPosition.position + new Vector3(0,0.05f,0), Quaternion.identity);
        itemAvailable = true;
    }

    void Update()
    {
        if (!itemAvailable && _availableItemsCount > 0)
        {
            StartCoroutine(SpawnItem());
        }
    }

    IEnumerator SpawnItem()
    {
        itemAvailable = true;
        yield return new WaitForSeconds(spawnDelay);
        if(_isAnimatorNotNull) animator.SetTrigger(SpawnBeamActive);
        Instantiate(spawnedObject, spawnPosition.position, Quaternion.identity);
        itemAvailable = true;
    }

    public void RefillItems()
    {
        _availableItemsCount += 1;
        if(refillImage != null) refillImage.fillAmount = _availableItemsCount / 10;
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
            _availableItemsCount -= 1;
            if(refillImage != null) refillImage.fillAmount = _availableItemsCount / 10;
            itemAvailable = false;
            print("Item taken: " + other.gameObject.name);
        }
    }

    public int GetAvailableItems()
    {
        return (int)_availableItemsCount;
    }

    public int GetMaxItemsAvailable()
    {
        return (int)maxItemsAvailable;
    }
}