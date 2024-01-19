using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTP : MonoBehaviour
{
  public float ZoneMorte;
  public Collider Monstre;
  bool Teleportation = false;
  public GameObject Deathh;
  public GameObject MonsterDeathh;
  
  
  public GameObject tp;

  /*private void OnTriggerEnter (Collider Monstre)
    {
        Teleportation = true;
        Debug.Log("Monstreboughhhdazazd");
    }
    */
    private void OnTriggerEnter (Collider colliderHit)
    {
    if(colliderHit.tag == "Monster")
    {
    Teleportation = true;
    }
    } 


    
    void Update()
    {
        if(transform.position.y < ZoneMorte)
        {
            StartCoroutine(Death());
            
        }

        if(Teleportation == true)
        {
            
            StartCoroutine(MonsterDeath());
        }
        
    }

    IEnumerator Death()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = tp.transform.position;
        Deathh.SetActive(true);
        yield return new WaitForSeconds(4);
         Deathh.SetActive(false);
         GetComponent<CharacterController>().enabled = true;
         
    }

    IEnumerator MonsterDeath()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = tp.transform.position;
        MonsterDeathh.SetActive(true);
        yield return new WaitForSeconds(4);
         MonsterDeathh.SetActive(false);
         GetComponent<CharacterController>().enabled = true;
         Teleportation = false;
         
    }
}
