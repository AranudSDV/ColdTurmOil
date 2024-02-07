using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidTP : MonoBehaviour
{
  public float ZoneMorte;
  public Collider Monstre;
  
  bool Teleportation = false;
  bool Teleportation2 = false;
  public GameObject Deathh;
  public GameObject MonsterDeathh;
  
  
  public GameObject tp;
  public GameObject tp2;


    private void OnTriggerEnter (Collider colliderHit)
    {
        Debug.Log("JEnadujardin");
        if(colliderHit.tag == "Monster")
        {
         Teleportation = true;
        }
        if(colliderHit.tag == "Monster2")
        {
         Teleportation2 = true;
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
        if(Teleportation2 == true)
        {
            
            StartCoroutine(MonsterDeath2());
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

     IEnumerator MonsterDeath2()
    {
        GetComponent<CharacterController>().enabled = false;
        transform.position = tp2.transform.position;
        MonsterDeathh.SetActive(true);
        yield return new WaitForSeconds(4);
         MonsterDeathh.SetActive(false);
         GetComponent<CharacterController>().enabled = true;
         Teleportation2 = false;
         
    }
}
