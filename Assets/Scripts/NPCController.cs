using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{

    private List<NPC> npcs = new List<NPC>();

    public NPC npc;

    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < 50; i++)
        {
            NPC newNPC = Instantiate(npc);
            newNPC.npcType = (NPC.NPCType) UnityEngine.Random.Range(0, Enum.GetNames(typeof(NPC.NPCType)).Length);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
