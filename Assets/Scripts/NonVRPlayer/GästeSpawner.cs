using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GästeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private GameObject whatToSpawnPrefab;
    public SettingsScriptableObject settingsScriptableObject;
    public float spawnTime = 1;
    private float spawnDelay;
    private bool[] seatTaken;
    public GameObject spawnPoint;
    public GameObject seat;
    private int seatNumber;
    public Animator anim;
    
    void Start()
    {   
        spawnDelay = settingsScriptableObject.spawnDelay;
        seatTaken = new bool[waypoints.Length];
        InvokeRepeating("spawnObjekt", spawnTime, spawnDelay = Random.Range(30,40));
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


