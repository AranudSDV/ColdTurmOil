using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlitchControl : MonoBehaviour
{
    public Material mat;
    public float NoiseAmount;
    public float GlitchStr;
    public float ScanLinesStr;
    public GameObject Fusible;
    public bool isEnabled;
    public ScriptableRendererFeature feature;
    // Update is called once per frame
    void Update()
    {
        mat.SetFloat("NoiseAmount" , NoiseAmount);
        mat.SetFloat("GlitchStr" , GlitchStr);
        mat.SetFloat("ScanlinesStr" , ScanLinesStr);
    }
}
