using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinTrigger : MonoBehaviour
{
    public bool PlayerInZone = false;
    public Collider Fin;

    void Start()
    {
        
    }

    private void OnTriggerEnter (Collider fin)
    {
      PlayerInZone = true;
    }
    
    void Update()
    {

     if(PlayerInZone == true)
     {
        StartCoroutine(FinGame());
     }

    }

    IEnumerator FinGame()
    {
        
        yield return new WaitForSeconds(4);
        SceneManager.LoadSceneAsync("Fin");
         
    }

}
