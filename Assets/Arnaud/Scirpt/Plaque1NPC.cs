using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque1NPC : MonoBehaviour
{
    public GameObject NPC;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider collision)
    {
        Debug.Log("Trigger npc");
        

        NPC.GetComponent<AllieNPC>().NPC1IsMoving = true;
        NPC.GetComponent<AllieNPC>().NPC2IsMoving = true;
    }
}
