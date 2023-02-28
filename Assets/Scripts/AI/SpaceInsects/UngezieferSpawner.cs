using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UngezieferSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] spawnPoints;
     [SerializeField] private GameObject whatToSpawnPrefab;
    private bool[] spawnPointTaken;
    public float spawnTime = 1;
    public float spawnDelayMin;
    public float spawnDelayMax;
    private int spawnPointNumber;
    public float moveRadius = 5f;
    private Vector3 startingPosition;
    private float spawnDelay;
    private float timer = 0f;
    public float resetTime = 45f;

    // Start is called before the first frame update
    void Start()
    {
        spawnPointTaken = new bool[spawnPoints.Length];
        InvokeRepeating("spawnObjekt", spawnTime, spawnDelay = Random.Range(spawnDelayMin,spawnDelayMax));
        
    }
      void Update()
    {
        timer += Time.deltaTime;
        if (timer >= resetTime)
        {
            ResetSpawnPoints();
        }
    }

    private void ResetSpawnPoints()
    {
        for (int i = 0; i < spawnPointTaken.Length; i++)
        {
            spawnPointTaken[i] = false;
        }
        timer = 0f;
    }

     public void spawnObjekt()
    { 
        spawnPointNumber = Random.Range(0, spawnPoints.Length);
        if (!spawnPointTaken[spawnPointNumber]) {
            spawnPointTaken[spawnPointNumber] = true;
            Instantiate(whatToSpawnPrefab, spawnPoints[spawnPointNumber].transform.position, Quaternion.identity);
        }
    }
}


