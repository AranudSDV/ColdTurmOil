using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchMonstre : MonoBehaviour

{
    public GameObject Glitchy;
   
     void OnTriggerEnter (Collider glitchM)
    {
        if(glitchM.CompareTag("Monstreu"))
        {
            Glitchy.SetActive(true);
        }
    }
     void OnTriggerExit (Collider glitchM)
    {
        if(glitchM.CompareTag("Monstreu"))
        {
            Glitchy.SetActive(false);
        }
    }
}
