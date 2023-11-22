using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyOrthographicMovement : MonoBehaviour
{
    public NavMeshAgent agent;

    void Start()
    {
        StartOrthographicMovement();
    }

    public void StartOrthographicMovement()
    {
        SetRandomDestinationInOrthographicPlane();
    }

    void SetRandomDestinationInOrthographicPlane()
    {
        Vector3 randomPosition = GetRandomPositionInOrthographicPlane();
        agent.SetDestination(randomPosition);
    }

    Vector3 GetRandomPositionInOrthographicPlane()
    {
       
        float randomX = Random.Range(-10f, 10f); 
        float randomZ = Random.Range(-10f, 10f);
        Vector3 randomPosition = new Vector3(randomX, 0f, randomZ);

        return randomPosition;
    }

    void Update()
    {
        
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetRandomDestinationInOrthographicPlane();
        }
    }
}
