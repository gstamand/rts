using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointController : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private List<Transform> merchantStallWPs = new List<Transform>();
    [SerializeField]private List<Transform> guardHouseWPs = new List<Transform>();
    [SerializeField]private List<Transform> dockWorkWPs = new List<Transform>();
    [SerializeField]private List<Transform> alleyWayWPs = new List<Transform>();
    [SerializeField]private List<Transform> randomWPs = new List<Transform>();

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetWaypoint(NPC.NPCType npcType)
    {
        if(npcType == NPC.NPCType.Dockworker)
        {
            return dockWorkWPs[Random.Range(0, dockWorkWPs.Count)];
        }
        if (npcType == NPC.NPCType.Merchant)
        {
            return merchantStallWPs[Random.Range(0, merchantStallWPs.Count)];
        }
        if (npcType == NPC.NPCType.Guard)
        {
            return guardHouseWPs[Random.Range(0, guardHouseWPs.Count)];
        }
        if (npcType == NPC.NPCType.Thief)
        {
            return alleyWayWPs[Random.Range(0, alleyWayWPs.Count)];
        }
        return randomWPs[Random.Range(0, randomWPs.Count)];
    }
}
