using System.Collections;
using UnityEngine;

public class MenuItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject interactionObject;
    [SerializeField] private int spawnTime;

    public void jk()
    {
        
    }

    IEnumerator SpawnObject()
    {
        yield return new WaitForSeconds(spawnTime);
        Instantiate(interactionObject, transform.position, Quaternion.identity);
    }

}
