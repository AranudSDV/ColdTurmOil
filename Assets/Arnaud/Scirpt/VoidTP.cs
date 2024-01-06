using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTP : MonoBehaviour
{
  public float ZoneMorte;
  public Collider Monstre;
  bool Teleportation = false;
  
  
  public GameObject tp;

  /*private void OnTriggerEnter (Collider Monstre)
    {
        Teleportation = true;
        Debug.Log("Monstreboughhhdazazd");
    }
    */
    private void OnTriggerEnter (Collider colliderHit)
    {
    if(colliderHit.tag == "Monster")
    {
    Teleportation = true;
    }
    } 


    
    void Update()
    {
        if(transform.position.y < ZoneMorte)
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = tp.transform.position;
            GetComponent<CharacterController>().enabled = true;
        }

        if(Teleportation == true)
        {
           GetComponent<CharacterController>().enabled = false;
            transform.position = tp.transform.position;
            GetComponent<CharacterController>().enabled = true;
            Teleportation = false;
        }
        
    }
}
