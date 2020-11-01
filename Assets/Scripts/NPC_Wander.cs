using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC_Wander : MonoBehaviour
{

    private float checkDestinationReachedInterval = 1f;
    private float destinationReachedThreshold = 1f;
    private float walkRadius = 5f;

    private NPC npc;
    private WaypointController waypointController;

    void Awake()
    {
        npc = GetComponent<NPC>();
        waypointController = GameObject.Find("GameController").GetComponent<WaypointController>();
        InvokeRepeating("CheckDestinationReached", 0f, checkDestinationReachedInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CheckDestinationReached()
    {
        if(npc.navMeshAgent.remainingDistance < destinationReachedThreshold)
        {
            npc.SetDestination(GenerateNewDestination());
        }
    }
    private Vector3 GenerateNewDestination()
    {
        return waypointController.GetWaypoint(npc.npcType).position;
    }

    private Vector3 GetRandomDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * walkRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, walkRadius, 1);
        return hit.position;
    }

}
