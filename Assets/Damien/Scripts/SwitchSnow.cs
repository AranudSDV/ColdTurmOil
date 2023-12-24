using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSnow : MonoBehaviour
{
    public GameObject FX_SnowFall;
    public GameObject FX_Blizzard;
    public GameObject Fusible;
    // Start is called before the first frame update
    void Start()
    {
        FX_SnowFall.SetActive(true);
       FX_Blizzard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      if(Inventory.instance.HasObject("Fusible") == true)
     {
        FX_Blizzard.SetActive(true);
        FX_SnowFall.SetActive(false);
     }

     }
}
