using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject objectToMove;
    public GameObject moveDirection;
    private float speedUp = 5f;
     
    void OnTriggerEnter (Collider other)
    {
      objectToMove.transform.position = Vector3.MoveTowards(objectToMove.transform.position, moveDirection.transform.position, speedUp * Time.deltaTime);
    }
}
