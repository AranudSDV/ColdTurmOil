using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSnow : MonoBehaviour
{
    public GameObject FX_SnowFall;
    public GameObject FX_Blizzard;
    // Start is called before the first frame update
    void Start()
    {
        FX_SnowFall.SetActive(false);
       FX_Blizzard.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
