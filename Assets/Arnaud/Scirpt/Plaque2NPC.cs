using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plaque2NPC : MonoBehaviour
{
    public GameObject NPC1;
    public GameObject NPC2;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider collision)
    {
        
        Destroy(NPC1);
        Destroy(NPC2);

        
    }
}
