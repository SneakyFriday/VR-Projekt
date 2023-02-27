using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GästeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject whatToSpawnPrefab;
    [Header("Spawn Rate Range (s)")]
    [SerializeField] private float minSpawnRate;
    [SerializeField] private float maxSpawnRate;
    public SettingsScriptableObject settingsScriptableObject;
    public float spawnTime = 1;
    private float spawnDelay;
    private bool[] seatTaken;
    public GameObject spawnPoint;
    public GameObject seat;
    private int seatNumber;
    public Animator anim;
    
    // TODO:
    // - Use a coroutine instead of InvokeRepeating
    // Invoke Repeating is not the best way to spawn objects
    // It is better to use a coroutine
    // https://docs.unity3d.com/ScriptReference/MonoBehaviour.StartCoroutine.html
    
    // - Use a queue instead of an array
    // You can use a queue to keep track of the seats that are taken
    // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.queue-1?view=netframework-4.8
    
    void Start()
    {   
        spawnDelay = settingsScriptableObject.spawnDelay;
        seatTaken = new bool[waypoints.Length];
        InvokeRepeating("spawnObjekt", spawnTime, spawnDelay = Random.Range(minSpawnRate,maxSpawnRate));
    }

    public void spawnObjekt()
    { 
        anim.SetTrigger("OpenDoor");
        seatNumber = Random.Range(0, waypoints.Length);
        if (!seatTaken[seatNumber]) {
            seatTaken[seatNumber] = true;
            seat = waypoints[seatNumber];
            Instantiate(whatToSpawnPrefab, spawnPoint.transform.position, Quaternion.identity);
        }
    }

    public Transform SetAgentDestination()
    {
        return seat.transform;
    }    
    
}


