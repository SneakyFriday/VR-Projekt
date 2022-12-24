using System;
using UnityEngine;
using UnityEngine.AI;

public class GuestPathfinding : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject _target;
    public GästeSpawner spawner;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // Der NavMeshAgent wird an den Agent gebunden.
        //agent.destination = spawner.seatTransform().transform.position;
    }
}
