using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAmbiant : MonoBehaviour
{

    public Collider ZoneAmbiant;
    public bool PlayerInZone = false;
    
    

    void Update()
    {
        if (PlayerInZone == true)
        {
            AudioManager.instance.PlayOneShot(FMODEvent.instance.AmbiantSFX, this.transform.position);
        }
    }

   
    
    

    void OnTriggerEnter (Collider ZoneAmbiant)
    {
     
     PlayerInZone = true;
      
    }

        
    
}
