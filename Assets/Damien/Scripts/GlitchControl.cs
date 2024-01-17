using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlitchControl : MonoBehaviour
{
    public Material mat;
    public float NoiseAmount;
    public float GlitchStr;
    public float ScanLinesStr;

    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("NoiseAmount" , NoiseAmount);
        mat.SetFloat("GlitchStr" , GlitchStr);
        mat.SetFloat("ScanlinesStr" , ScanLinesStr);
    }
}
