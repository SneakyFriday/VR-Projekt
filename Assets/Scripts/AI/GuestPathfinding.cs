using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GuestPathfinding : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GästeSpawner spawner;
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] public GameObject SpawnPoint;

    void Start()
    {
        spawner = FindObjectOfType<GästeSpawner>();
        _agent.destination = spawner.SetAgentDestination().position;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_agent.destination, 1f);
    }

    void Update() {
        bool istBedient = playerInteraction.BedienStatus();
        if (istBedient == true)
        {
            _agent.destination = SpawnPoint.transform.position;

            if (Vector3.Distance(transform.position, SpawnPoint.transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }
    }
    public bool isSeated()
    {
        if (Vector3.Distance(transform.position, _agent.destination) < 2f)
        {

            return true;
        }
        else
        {
            return false;
        }
       
    }
}
