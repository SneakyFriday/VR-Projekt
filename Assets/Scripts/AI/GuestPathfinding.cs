using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GuestPathfinding : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GästeSpawner spawner;

    void Start()
    {
        spawner = FindObjectOfType<GästeSpawner>();
        _agent.destination = spawner.SetAgentDestination().position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_agent.destination, 2f);
    }
}
