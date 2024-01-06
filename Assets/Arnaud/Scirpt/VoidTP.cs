using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTP : MonoBehaviour
{
  public float ZoneMorte;
  public Collider Monstre;
  bool Teleportation = false;
  
  
  public GameObject tp;

  private void OnTriggerEnter (Collider Monstre)
    {
        Teleportation = true;
        Debug.Log("Monstreboughhhdazazd");
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
