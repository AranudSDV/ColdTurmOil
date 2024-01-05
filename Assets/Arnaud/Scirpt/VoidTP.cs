using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTP : MonoBehaviour
{
  public float ZoneMorte;
  
  public GameObject tp;

    
    void Update()
    {
        if(transform.position.y < ZoneMorte)
        {
            GetComponent<CharacterController>().enabled = false;
            transform.position = tp.transform.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
}
