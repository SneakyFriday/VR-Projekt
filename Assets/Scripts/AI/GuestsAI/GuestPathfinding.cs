using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class GuestPathfinding : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private GästeSpawner spawner;
    [SerializeField] private PlayerInteraction playerInteraction;
    [SerializeField] public GameObject SpawnPoint;
    private Vector3 pos;

    void Start()
    {
        _agent.isStopped = true;
        pos = transform.position;
        StartCoroutine(FreezeObjekt());
    }

    IEnumerator FreezeObjekt()
    {
        yield return new WaitForSeconds((float)2);
        _agent.isStopped = false;
        SetDestination();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_agent.destination, 1f);
    }

    private void SetDestination()
    {
        if (_agent.isStopped == false)
        {
            spawner = FindObjectOfType<GästeSpawner>();
            _agent.destination = spawner.SetAgentDestination().position;
        }
    }

    void Update()
    {
        bool istBedient = playerInteraction.BedienStatus();
        if (istBedient == true)
        {
            _agent.destination = SpawnPoint.transform.position;

            if (Vector3.Distance(transform.position, SpawnPoint.transform.position) < 1f)
            {
                Destroy(gameObject);
            }
        }

        bool timeOver = playerInteraction.timeIsOver();
        if (timeOver == true)
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
        if (Vector3.Distance(transform.position, _agent.destination) < 1f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}