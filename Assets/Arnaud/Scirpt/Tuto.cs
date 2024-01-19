using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuto : MonoBehaviour
{

    public Collider Tuto1;
    public GameObject TexteF;


    
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter (Collider Tuto1)
    {
        StartCoroutine(TexteCrouch());
    }

    IEnumerator TexteCrouch()
    {
        TexteF.SetActive(true);
        yield return new WaitForSeconds(4);
        TexteF.SetActive(false);
         
    }
}
