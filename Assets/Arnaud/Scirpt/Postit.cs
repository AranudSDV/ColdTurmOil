using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Postit : MonoBehaviour
{
    public TextMeshProUGUI EcranTexte;
    public string TextePostit;
    public bool rayHitPostit;

    void Start()
    {
        rayHitPostit = false;
    }
    
    void Update()
    {
        if(rayHitPostit == true)
        {
            EcranTexte.text = "test";
            Debug.Log("Scirpt POstit rayhit");
        }
        else
        {
            
        }
    }
}
