using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchDoorControll : MonoBehaviour
{
    public GameObject Glitchy;
    // Start is called before the first frame update
    void Start()
    {
        Glitchy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
         if(Inventory.instance.HasObject("Manivelle") == true)
         {
        Glitchy.SetActive(true);
       
         }
    }
}
