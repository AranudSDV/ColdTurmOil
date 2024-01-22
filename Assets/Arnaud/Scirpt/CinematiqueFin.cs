using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematiqueFin : MonoBehaviour
{

    public GameObject FX;
    public GameObject Canva;

    
    void Start()
    {
        FX.SetActive(true);
    }

    
    void Update()
    {
        StartCoroutine(Cinematique1());
    }

     IEnumerator Cinematique1()
    {
        
        yield return new WaitForSeconds(5);
        Destroy(FX);
        Canva.SetActive(true);

         
    }
}
