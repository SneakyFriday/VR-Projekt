using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GästeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // Array aus Gameobjekten, beinhaltet jeden Sitzplatz.
    public GameObject whatToSpawnPrefab; // Das Prefab, welches gespawnt werden soll.
    public float spawnTime = 1f; // Zeit zwischen den Spawns.
    float spawnDelay; // Zeit bis zum ersten Spawn.
    bool[] seatTaken; // Array aus bools, beinhaltet ob ein Sitzplatz besetzt ist oder nicht.
    public GameObject spawnPoint; // Das Objekt, welches den Spawnpunkt darstellt.
    public GameObject seat;
    
    void Start()
    {
        seatTaken = new bool[waypoints.Length]; // Initialisiert das Array mit der Länge des waypoints Arrays.
        //InvokeRepeating("spawnObjekt", spawnTime, spawnDelay= Random.Range(3, 7)); // Ruft wiederholt die spawnObjekt Methode auf, mit einer Startzeit und einem Delay bis zum nächsten Spawnen.
        spawnObjekt();
    }

    public void spawnObjekt()
    { 
        int seatNumber = Random.Range(0, waypoints.Length);
        if (!seatTaken[seatNumber]) {
            Instantiate(whatToSpawnPrefab, spawnPoint.transform.position, Quaternion.identity);
            seatTaken[seatNumber] = true;
            seat = waypoints[seatNumber];
        }
    } 
    public GameObject seatTransform()
    {
        return seat;
    }
}


