using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Unit
{

    // Start is called before the first frame update

    public NPCType npcType;

    public enum NPCType
    {
        Peasant,
        Merchant,
        Guard,
        Dockworker,
        Thief,
        Zombie
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
