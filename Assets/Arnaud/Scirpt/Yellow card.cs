using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yellowcard : MonoBehaviour
{

    public Collider CardColli;
    public Renderer Cardrend;

    public bool cardisok = false;
   
    
    
    void Start()
    {
        Cardrend = GetComponent<Renderer>();
        CardColli = GetComponent<Collider>();
    }

    
    void Update()
    {
        if(cardisok == true)
        {
         Cardrend.enabled = true;
         CardColli.enabled = true;
        }
    }
}
