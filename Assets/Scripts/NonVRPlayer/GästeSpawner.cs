using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GästeSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] waypoints; // Array aus Gameobjekten, beinhaltet jeden Sitzplatz.
    public GameObject whatToSpawnPrefab; // Das Prefab, welches gespawnt werden soll.
    public float spawnTime = 1f; // Zeit zwischen den Spawns.
    float spawnDelay; // Zeit bis zum ersten Spawn.
    bool[] seatTaken; // Array aus bools, beinhaltet ob ein Sitzplatz besetzt ist oder nicht.

    // Start is called before the first frame update
    void Start()
    {
        seatTaken = new bool[waypoints.Length]; // Initialisiert das Array mit der Länge des waypoints Arrays.
        InvokeRepeating("spawnObjekt", spawnTime, spawnDelay= Random.Range(3, 7)); // Ruft wiederholt die spawnObjekt Methode auf, mit einer Startzeit und einem Delay bis zum nächsten Spawnen.
    }

    public void spawnObjekt()
    {
        int seatNumber = Random.Range(0, waypoints.Length); // Zufällige Zahl zwischen 0 und der Länge der Sitzplätze.
        if (seatTaken[seatNumber] == false) // Wenn der Sitzplatz nicht besetzt ist, wird das Objekt gespawnt.
        {
            Instantiate(whatToSpawnPrefab, waypoints[seatNumber].transform.position, Quaternion.identity); // Spawnt das Prefab, an einem random Platz. 
            seatTaken[seatNumber] = true; // Der Sitzplatz wird als besetzt markiert.
            //Debug.Log("Gast an Tisch "+ seatNumber+" Eingetroffen");
            
        }
    }
}


